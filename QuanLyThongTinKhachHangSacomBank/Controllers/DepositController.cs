using System;
using System.Data;
using System.Windows.Forms;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Views.Common;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Deposit;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Transfer;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class DepositController
    {
        private IDepositView depositView;
        private UserControl activeUC;
        private readonly DatabaseContext dbContext;
        private readonly IConfiguration configuration;
        private readonly EmployeeModel currentEmployee;
        private AccountModel receiverAccount;
        private IDepositViewData lastDepositViewData;
        private bool isTransactionSuccessful;

        public event EventHandler TransactionCompleted;

        public DepositController(EmployeeModel currentEmployee, DatabaseContext dbContext, IConfiguration configuration)
        {
            activeUC = null;
            this.currentEmployee = currentEmployee;
            this.dbContext = dbContext;
            this.configuration = configuration;
            this.isTransactionSuccessful = false;
        }

        public void OpenDeposit(UserControl depositUC)
        {
            try
            {
                depositView = new FormDeposit();
                activeUC = depositUC;

                if (activeUC is IDepositViewData depositViewData)
                {
                    depositViewData.ConfirmRequested += (s, e) => HandleConfirm();
                    depositViewData.CancelRequested += (s, e) => HandleCancel();
                    depositViewData.AccountIDLostFocus += (s, e) => HandleAccountIDLostFocus(depositViewData);
                }

                depositView.LoadUserControl(depositUC);
                depositView.ShowForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong DepositController.OpenDeposit: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleAccountIDLostFocus(IDepositViewData depositViewData)
        {
            try
            {
                string accountID = depositViewData.AccountID;
                if (!string.IsNullOrWhiteSpace(accountID))
                {
                    receiverAccount = GetAccountByCode(accountID);
                    if (receiverAccount == null)
                    {
                        depositViewData.ShowError("Tài khoản không tồn tại!");
                        depositViewData.SetAccountInfo(null, "", "");
                        depositViewData.TransactionDescription = "";
                        return;
                    }

                    if (receiverAccount.AccountStatus == "Khóa")
                    {
                        depositViewData.ShowError("Tài khoản đang bị khóa!");
                        depositViewData.SetAccountInfo(null, "", "");
                        depositViewData.TransactionDescription = "";
                        return;
                    }

                    if (receiverAccount.AccountStatus == "Đóng")
                    {
                        depositViewData.ShowError("Tài khoản đã bị đóng!");
                        depositViewData.SetAccountInfo(null, "", "");
                        depositViewData.TransactionDescription = "";
                        return;
                    }

                    string phone = "";
                    string citizenID = "";
                    using (var connection = dbContext.GetConnection())
                    {
                        if (connection == null)
                        {
                            throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
                        }
                        connection.Open();
                        using (var command = new SqlCommand("SELECT Phone, CitizenID FROM CUSTOMER WHERE CustomerID = @CustomerID", connection))
                        {
                            command.Parameters.AddWithValue("@CustomerID", receiverAccount.CustomerID);
                            using (var reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    phone = reader["Phone"]?.ToString() ?? "";
                                    citizenID = reader["CitizenID"]?.ToString() ?? "";
                                }
                            }
                        }
                    }

                    depositViewData.SetAccountInfo(receiverAccount, phone, citizenID);
                    depositViewData.TransactionDescription = $"{receiverAccount.AccountName} nap tien tu quay giao dich";
                    depositViewData.HideError();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kiểm tra tài khoản: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleConfirm()
        {
            try
            {
                if (activeUC is IDepositViewData depositViewData)
                {
                    if (string.IsNullOrWhiteSpace(depositViewData.AccountID) ||
                        string.IsNullOrWhiteSpace(depositViewData.AccountName) ||
                        string.IsNullOrWhiteSpace(depositViewData.Phone) ||
                        string.IsNullOrWhiteSpace(depositViewData.CitizenID) ||
                        string.IsNullOrWhiteSpace(depositViewData.Balance) ||
                        string.IsNullOrWhiteSpace(depositViewData.Amount) ||
                        string.IsNullOrWhiteSpace(depositViewData.TransactionDescription))
                    {
                        depositViewData.ShowError("Vui lòng nhập đầy đủ thông tin!");
                        return;
                    }

                    decimal amount;
                    if (!decimal.TryParse(depositViewData.Amount, out amount) || amount <= 0)
                    {
                        depositViewData.ShowError("Số tiền không hợp lệ!");
                        return;
                    }

                    if (amount < 5000)
                    {
                        depositViewData.ShowError("Số tiền nạp tối thiểu là 5,000 VND!");
                        return;
                    }

                    depositViewData.HideError();

                    FormOTP formOTP = new FormOTP();
                    var otpController = new OTPController(formOTP, formOTP, new DepositOTPControllerAdapter(receiverAccount, dbContext), configuration);
                    if (formOTP.ShowDialog() == DialogResult.OK)
                    {
                        lastDepositViewData = depositViewData;
                        string transactionCode = SaveTransaction(depositViewData); // Chỉ lấy TransactionCode
                        lastDepositViewData.TransactionCode = transactionCode;
                        isTransactionSuccessful = true;

                        activeUC = new UC_SuccessfulDeposit();
                        SetupSuccessfulDeposit(activeUC as ISuccessfulDepositView, depositViewData);
                        depositView.LoadUserControl(activeUC);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xác nhận nạp tiền: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string SaveTransaction(IDepositViewData depositViewData) 
        {
            using (var connection = dbContext.GetConnection())
            {
                if (connection == null)
                {
                    throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
                }
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int transactionTypeID;
                        using (var command = new SqlCommand("SELECT TransactionTypeID FROM TRANSACTION_TYPE WHERE TransactionTypeName = @TransactionTypeName", connection, transaction))
                        {
                            command.Parameters.AddWithValue("@TransactionTypeName", "Nạp tiền");
                            var result = command.ExecuteScalar();
                            if (result == null)
                            {
                                throw new Exception("Không tìm thấy TransactionTypeID cho 'Nạp tiền'.");
                            }
                            transactionTypeID = (int)result;
                        }

                        int newTransactionId;
                        using (var command = new SqlCommand(
                            "INSERT INTO [TRANSACTION] (Amount, TransactionDate, TransactionStatus, HandledBy, TransactionDescription, TransactionMethod, AccountID, TransactionTypeID) " +
                            "OUTPUT INSERTED.TransactionID " +
                            "VALUES (@Amount, @TransactionDate, @TransactionStatus, @HandledBy, @TransactionDescription, @TransactionMethod, @AccountID, @TransactionTypeID)", connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Amount", decimal.Parse(depositViewData.Amount));
                            command.Parameters.AddWithValue("@TransactionDate", DateTime.Now);
                            command.Parameters.AddWithValue("@TransactionStatus", "Hoàn tất");
                            command.Parameters.AddWithValue("@HandledBy", (object)(currentEmployee?.EmployeeID) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@TransactionDescription", depositViewData.TransactionDescription);
                            command.Parameters.AddWithValue("@TransactionMethod", "Tại quầy");
                            command.Parameters.AddWithValue("@AccountID", receiverAccount.AccountID);
                            command.Parameters.AddWithValue("@TransactionTypeID", transactionTypeID);
                            newTransactionId = (int)command.ExecuteScalar();
                        }

                        string transactionCode;
                        using (var command = new SqlCommand(
                            "SELECT TransactionCode FROM [TRANSACTION] WHERE TransactionID = @TransactionID", connection, transaction))
                        {
                            command.Parameters.AddWithValue("@TransactionID", newTransactionId);
                            transactionCode = command.ExecuteScalar()?.ToString();
                            if (string.IsNullOrEmpty(transactionCode))
                            {
                                throw new Exception("Không thể lấy TransactionCode sau khi thêm giao dịch.");
                            }
                        }

                        using (var command = new SqlCommand("UPDATE ACCOUNT SET Balance = Balance + @Amount WHERE AccountID = @AccountID", connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Amount", decimal.Parse(depositViewData.Amount));
                            command.Parameters.AddWithValue("@AccountID", receiverAccount.AccountID);
                            command.ExecuteNonQuery();
                        }

                        // Thêm bản ghi vào bảng NOTIFICATION
                        int notificationTypeId;
                        using (var command = new SqlCommand("SELECT NotificationTypeID FROM NOTIFICATION_TYPE WHERE NotificationTypeName = @NotificationTypeName", connection, transaction))
                        {
                            command.Parameters.AddWithValue("@NotificationTypeName", "Giao dịch");
                            var result = command.ExecuteScalar();
                            if (result == null)
                            {
                                throw new Exception("Không tìm thấy NotificationTypeID cho 'Giao dịch'.");
                            }
                            notificationTypeId = (int)result;
                        }

                        string notificationMessage = $"{receiverAccount.AccountName} nạp tiền {decimal.Parse(depositViewData.Amount).ToString("#,##0")} VND thành công vào tài khoản!";
                        using (var command = new SqlCommand(
                            "INSERT INTO [NOTIFICATION] (Title, NotificationMessage, NotificationDate, NotificationStatus, ReferenceID, CustomerID, EmployeeID, NotificationTypeID) " +
                            "VALUES (@Title, @NotificationMessage, @NotificationDate, @NotificationStatus, @ReferenceID, @CustomerID, @EmployeeID, @NotificationTypeID)", connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Title", "Nạp tiền thành công!");
                            command.Parameters.AddWithValue("@NotificationMessage", notificationMessage);
                            command.Parameters.AddWithValue("@NotificationDate", DateTime.Now);
                            command.Parameters.AddWithValue("@NotificationStatus", "Chưa xem");
                            command.Parameters.AddWithValue("@ReferenceID", newTransactionId); // TransactionID là ReferenceID
                            command.Parameters.AddWithValue("@CustomerID", receiverAccount.CustomerID);
                            command.Parameters.AddWithValue("@EmployeeID", DBNull.Value); // EmployeeID là NULL
                            command.Parameters.AddWithValue("@NotificationTypeID", notificationTypeId);
                            command.ExecuteNonQuery();
                        }

                        receiverAccount.Balance += decimal.Parse(depositViewData.Amount);
                        transaction.Commit();

                        TransactionCompleted?.Invoke(this, EventArgs.Empty);
                        return transactionCode; // Chỉ trả về TransactionCode
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Lỗi khi lưu giao dịch: " + ex.Message);
                    }
                }
            }
        }

        private void SetupSuccessfulDeposit(ISuccessfulDepositView view, IDepositViewData depositViewData)
        {
            string customerFullname = "";
            using (var connection = dbContext.GetConnection())
            {
                if (connection == null)
                {
                    throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
                }
                connection.Open();
                using (var command = new SqlCommand("SELECT Fullname FROM CUSTOMER WHERE CustomerID = @CustomerID", connection))
                {
                    command.Parameters.AddWithValue("@CustomerID", receiverAccount.CustomerID);
                    customerFullname = command.ExecuteScalar()?.ToString() ?? receiverAccount.AccountName;
                }
            }

            string formattedAmount = decimal.Parse(depositViewData.Amount).ToString("#,##0") + " VND";

            view.Amount = formattedAmount;
            view.CustomerName = customerFullname;
            view.CustomerAccountID = receiverAccount.AccountCode;
            view.AccountBalance = receiverAccount.Balance.ToString("#,##0") + " VND";
            view.TransactionDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            view.EmployeeName = currentEmployee?.EmployeeName ?? "Nhân viên";
            view.TransactionDescription = depositViewData.TransactionDescription;

            view.DoneClicked += (s, e) => HandleDone();
            view.InvoiceClicked += (s, e) => ExportToPDF();
        }

        private void ExportToPDF()
        {
            try
            {
                if (lastDepositViewData == null || receiverAccount == null)
                {
                    MessageBox.Show("Không có thông tin giao dịch để xuất hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy thông tin giao dịch
                string transactionCode = lastDepositViewData.TransactionCode;
                string transactionDescription = "";
                decimal amount = 0;
                string handledBy = "";
                string customerFullname = "";
                using (var connection = dbContext.GetConnection())
                {
                    if (connection == null)
                    {
                        throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
                    }
                    connection.Open();
                    using (var command = new SqlCommand(
                        "SELECT Amount, TransactionDescription, HandledBy " +
                        "FROM [TRANSACTION] WHERE TransactionCode = @TransactionCode", connection))
                    {
                        command.Parameters.AddWithValue("@TransactionCode", transactionCode);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                amount = reader.GetDecimal("Amount");
                                transactionDescription = reader.GetString("TransactionDescription");
                                handledBy = reader.IsDBNull(reader.GetOrdinal("HandledBy")) ? "Nhân viên" : reader.GetString("HandledBy");
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy giao dịch với mã giao dịch này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    using (var command = new SqlCommand("SELECT FullName FROM CUSTOMER WHERE CustomerID = @CustomerID", connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", receiverAccount.CustomerID);
                        customerFullname = command.ExecuteScalar()?.ToString() ?? receiverAccount.AccountName;
                    }
                }

                string formattedAmount = amount.ToString("#,##0") + " VND";

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                    saveFileDialog.Title = "Chọn nơi lưu hóa đơn giao dịch";
                    saveFileDialog.FileName = $"DepositReceipt_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string pdfPath = saveFileDialog.FileName;

                        string directory = Path.GetDirectoryName(pdfPath);
                        if (!Directory.Exists(directory))
                        {
                            Directory.CreateDirectory(directory);
                        }

                        try
                        {
                            string tempFile = Path.Combine(directory, "temp_test.txt");
                            File.WriteAllText(tempFile, "test");
                            File.Delete(tempFile);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Không có quyền ghi file tại thư mục: {directory}\nVui lòng chọn thư mục khác.\nChi tiết lỗi: {ex.Message}", "Lỗi quyền truy cập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (File.Exists(pdfPath))
                        {
                            try
                            {
                                using (FileStream fs = new FileStream(pdfPath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                                {
                                    fs.Close();
                                }
                                File.Delete(pdfPath);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"File {pdfPath} đang bị khóa bởi một tiến trình khác.\nVui lòng đóng ứng dụng đang sử dụng file (nếu có) và thử lại.\nChi tiết lỗi: {ex.Message}", "Lỗi truy cập file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        string projectDir = AppDomain.CurrentDomain.BaseDirectory;
                        string arialFontPath = Path.Combine(projectDir, "Resources", "fonts", "ARIAL.TTF");
                        string arialBoldFontPath = Path.Combine(projectDir, "Resources", "fonts", "ARIALBD.TTF");

                        if (!File.Exists(arialFontPath) || !File.Exists(arialBoldFontPath))
                        {
                            MessageBox.Show($"Không tìm thấy file font tại:\n- {arialFontPath}\n- {arialBoldFontPath}\nVui lòng kiểm tra thư mục Resources/fonts trong dự án.", "Lỗi font", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        try
                        {
                            BaseFont arialBaseFont = BaseFont.CreateFont(arialFontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                            BaseFont arialBoldBaseFont = BaseFont.CreateFont(arialBoldFontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                            iTextSharp.text.Font font = new iTextSharp.text.Font(arialBaseFont, 10);
                            iTextSharp.text.Font boldFont = new iTextSharp.text.Font(arialBoldBaseFont, 10);
                            iTextSharp.text.Font headerFont = new iTextSharp.text.Font(arialBoldBaseFont, 18, iTextSharp.text.Font.ITALIC, new BaseColor(0, 102, 204));
                            iTextSharp.text.Font subHeaderFont = new iTextSharp.text.Font(arialBoldBaseFont, 12);
                            iTextSharp.text.Font footerHighlightFont = new iTextSharp.text.Font(arialBoldBaseFont, 10, iTextSharp.text.Font.NORMAL, new BaseColor(255, 147, 0));

                            using (FileStream fs = new FileStream(pdfPath, FileMode.Create, FileAccess.Write, FileShare.None))
                            {
                                Document document = new Document(PageSize.A4, 36, 36, 36, 36);
                                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                                document.Open();

                                document.Add(new Paragraph("Sacombank", headerFont)
                                {
                                    Alignment = Element.ALIGN_LEFT
                                });

                                document.Add(new Paragraph("HÓA ĐƠN GIAO DỊCH NẠP TIỀN", subHeaderFont)
                                {
                                    Alignment = Element.ALIGN_LEFT
                                });

                                document.Add(new Paragraph($"Ngày xuất:  {DateTime.Now:dd/MM/yyyy HH:mm:ss}", font)
                                {
                                    Alignment = Element.ALIGN_LEFT
                                });

                                document.Add(new Paragraph($"Mã giao dịch: {transactionCode}", font)
                                {
                                    Alignment = Element.ALIGN_LEFT
                                });

                                PdfPTable lineTable = new PdfPTable(1);
                                lineTable.WidthPercentage = 100;
                                PdfPCell lineCell = new PdfPCell() { Border = PdfPCell.BOTTOM_BORDER, BorderColor = new BaseColor(0, 102, 204), FixedHeight = 5f };
                                lineTable.AddCell(lineCell);
                                document.Add(lineTable);

                                document.Add(new Paragraph("\n"));

                                PdfPTable table = new PdfPTable(new float[] { 1, 3, 5 });
                                table.WidthPercentage = 100;
                                table.DefaultCell.Border = PdfPCell.BOX;

                                table.AddCell(new PdfPCell(new Phrase("STT", boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = new BaseColor(200, 220, 255), Padding = 5f });
                                table.AddCell(new PdfPCell(new Phrase("Hạng mục", boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = new BaseColor(200, 220, 255), Padding = 5f });
                                table.AddCell(new PdfPCell(new Phrase("Nội dung", boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = new BaseColor(200, 220, 255), Padding = 5f });

                                table.AddCell(new PdfPCell(new Phrase("1", font)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5f });
                                table.AddCell(new PdfPCell(new Phrase("Thông tin khách hàng", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5f });
                                PdfPTable subTableCustomer = new PdfPTable(new float[] { 1, 2 });
                                subTableCustomer.WidthPercentage = 100;
                                subTableCustomer.DefaultCell.Border = PdfPCell.NO_BORDER;
                                subTableCustomer.AddCell(new PdfPCell(new Phrase("Khách hàng", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableCustomer.AddCell(new PdfPCell(new Phrase(customerFullname, boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableCustomer.AddCell(new PdfPCell(new Phrase("Mã tài khoản", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableCustomer.AddCell(new PdfPCell(new Phrase(receiverAccount.AccountCode, boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableCustomer.AddCell(new PdfPCell(new Phrase("Số dư sau giao dịch", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableCustomer.AddCell(new PdfPCell(new Phrase(receiverAccount.Balance.ToString("#,##0") + " VND", boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                table.AddCell(new PdfPCell(subTableCustomer) { Border = PdfPCell.BOX, Padding = 5f });

                                table.AddCell(new PdfPCell(new Phrase("2", font)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5f });
                                table.AddCell(new PdfPCell(new Phrase("Thông tin giao dịch", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5f });
                                PdfPTable subTableTransaction = new PdfPTable(new float[] { 1, 2 });
                                subTableTransaction.WidthPercentage = 100;
                                subTableTransaction.DefaultCell.Border = PdfPCell.NO_BORDER;
                                subTableTransaction.AddCell(new PdfPCell(new Phrase("Số tiền", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableTransaction.AddCell(new PdfPCell(new Phrase(formattedAmount, boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableTransaction.AddCell(new PdfPCell(new Phrase("Nội dung", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableTransaction.AddCell(new PdfPCell(new Phrase(transactionDescription, boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableTransaction.AddCell(new PdfPCell(new Phrase("Phương thức", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableTransaction.AddCell(new PdfPCell(new Phrase("Tại quầy", boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableTransaction.AddCell(new PdfPCell(new Phrase("Người xử lý", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableTransaction.AddCell(new PdfPCell(new Phrase(handledBy, boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                // Đã bỏ "Ngày giao dịch" khỏi subTableTransaction
                                table.AddCell(new PdfPCell(subTableTransaction) { Border = PdfPCell.BOX, Padding = 5f });

                                document.Add(table);

                                document.Add(new Paragraph("\n\n"));
                                PdfPTable footerTable = new PdfPTable(1);
                                footerTable.WidthPercentage = 100;
                                PdfPCell footerCell = new PdfPCell();
                                footerCell.Border = PdfPCell.NO_BORDER;
                                footerCell.HorizontalAlignment = Element.ALIGN_CENTER;

                                footerCell.AddElement(new Paragraph("NGÂN HÀNG THƯƠNG MẠI CỔ PHẦN SÀI GÒN THƯƠNG TÍN", footerHighlightFont)
                                {
                                    Alignment = Element.ALIGN_LEFT
                                });
                                footerCell.AddElement(new Paragraph("•  266 - 268 Nam Kỳ Khởi Nghĩa, Q.3, TP.HCM", font)
                                {
                                    Alignment = Element.ALIGN_LEFT
                                });
                                footerCell.AddElement(new Paragraph("•  1800 5858 88/+84 28 3526 6060", font)
                                {
                                    Alignment = Element.ALIGN_LEFT
                                });
                                footerCell.AddElement(new Paragraph("•  sacombank.com.vn/ask@sacombank.com", font)
                                {
                                    Alignment = Element.ALIGN_LEFT
                                });

                                footerTable.AddCell(footerCell);
                                document.Add(footerTable);

                                document.Close();
                                writer.Close();
                            }

                            MessageBox.Show($"Hóa đơn đã được xuất thành công tại: {pdfPath}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi khi tạo file PDF tại {pdfPath}: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất hóa đơn PDF: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                if (lastDepositViewData == null || receiverAccount == null)
                {
                    MessageBox.Show("Không có thông tin giao dịch để xuất hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy thông tin giao dịch
                string transactionCode = lastDepositViewData.TransactionCode;
                string transactionDescription = "";
                decimal amount = 0;
                string handledBy = "";
                string customerFullname = "";
                using (var connection = dbContext.GetConnection())
                {
                    if (connection == null)
                    {
                        throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
                    }
                    connection.Open();
                    using (var command = new SqlCommand(
                        "SELECT Amount, TransactionDescription, HandledBy " +
                        "FROM [TRANSACTION] WHERE TransactionCode = @TransactionCode", connection))
                    {
                        command.Parameters.AddWithValue("@TransactionCode", transactionCode);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                amount = reader.GetDecimal("Amount");
                                transactionDescription = reader.GetString("TransactionDescription");
                                handledBy = reader.IsDBNull(reader.GetOrdinal("HandledBy")) ? "Nhân viên" : reader.GetString("HandledBy");
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy giao dịch với mã giao dịch này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    using (var command = new SqlCommand("SELECT FullName FROM CUSTOMER WHERE CustomerID = @CustomerID", connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", receiverAccount.CustomerID);
                        customerFullname = command.ExecuteScalar()?.ToString() ?? receiverAccount.AccountName;
                    }
                }

                string formattedAmount = amount.ToString("#,##0") + " VND";

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                    saveFileDialog.Title = "Chọn nơi lưu hóa đơn giao dịch";
                    saveFileDialog.FileName = $"DepositReceipt_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string pdfPath = saveFileDialog.FileName;

                        string directory = Path.GetDirectoryName(pdfPath);
                        if (!Directory.Exists(directory))
                        {
                            Directory.CreateDirectory(directory);
                        }

                        try
                        {
                            string tempFile = Path.Combine(directory, "temp_test.txt");
                            File.WriteAllText(tempFile, "test");
                            File.Delete(tempFile);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Không có quyền ghi file tại thư mục: {directory}\nVui lòng chọn thư mục khác.\nChi tiết lỗi: {ex.Message}", "Lỗi quyền truy cập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (File.Exists(pdfPath))
                        {
                            try
                            {
                                using (FileStream fs = new FileStream(pdfPath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                                {
                                    fs.Close();
                                }
                                File.Delete(pdfPath);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"File {pdfPath} đang bị khóa bởi một tiến trình khác.\nVui lòng đóng ứng dụng đang sử dụng file (nếu có) và thử lại.\nChi tiết lỗi: {ex.Message}", "Lỗi truy cập file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        string projectDir = AppDomain.CurrentDomain.BaseDirectory;
                        string arialFontPath = Path.Combine(projectDir, "Resources", "fonts", "ARIAL.TTF");
                        string arialBoldFontPath = Path.Combine(projectDir, "Resources", "fonts", "ARIALBD.TTF");

                        if (!File.Exists(arialFontPath) || !File.Exists(arialBoldFontPath))
                        {
                            MessageBox.Show($"Không tìm thấy file font tại:\n- {arialFontPath}\n- {arialBoldFontPath}\nVui lòng kiểm tra thư mục Resources/fonts trong dự án.", "Lỗi font", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        try
                        {
                            BaseFont arialBaseFont = BaseFont.CreateFont(arialFontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                            BaseFont arialBoldBaseFont = BaseFont.CreateFont(arialBoldFontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                            iTextSharp.text.Font font = new iTextSharp.text.Font(arialBaseFont, 10);
                            iTextSharp.text.Font boldFont = new iTextSharp.text.Font(arialBoldBaseFont, 10);
                            iTextSharp.text.Font headerFont = new iTextSharp.text.Font(arialBoldBaseFont, 18, iTextSharp.text.Font.ITALIC, new BaseColor(0, 102, 204));
                            iTextSharp.text.Font subHeaderFont = new iTextSharp.text.Font(arialBoldBaseFont, 12);
                            iTextSharp.text.Font footerHighlightFont = new iTextSharp.text.Font(arialBoldBaseFont, 10, iTextSharp.text.Font.NORMAL, new BaseColor(255, 147, 0));

                            using (FileStream fs = new FileStream(pdfPath, FileMode.Create, FileAccess.Write, FileShare.None))
                            {
                                Document document = new Document(PageSize.A4, 36, 36, 36, 36);
                                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                                document.Open();

                                document.Add(new Paragraph("Sacombank", headerFont)
                                {
                                    Alignment = Element.ALIGN_LEFT
                                });

                                document.Add(new Paragraph("HÓA ĐƠN GIAO DỊCH NẠP TIỀN", subHeaderFont)
                                {
                                    Alignment = Element.ALIGN_LEFT
                                });

                                document.Add(new Paragraph($"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}", font)
                                {
                                    Alignment = Element.ALIGN_LEFT
                                });

                                document.Add(new Paragraph($"Mã giao dịch: {transactionCode}", font)
                                {
                                    Alignment = Element.ALIGN_LEFT
                                });

                                PdfPTable lineTable = new PdfPTable(1);
                                lineTable.WidthPercentage = 100;
                                PdfPCell lineCell = new PdfPCell() { Border = PdfPCell.BOTTOM_BORDER, BorderColor = new BaseColor(0, 102, 204), FixedHeight = 5f };
                                lineTable.AddCell(lineCell);
                                document.Add(lineTable);

                                document.Add(new Paragraph("\n"));

                                PdfPTable table = new PdfPTable(new float[] { 1, 3, 5 });
                                table.WidthPercentage = 100;
                                table.DefaultCell.Border = PdfPCell.BOX;

                                table.AddCell(new PdfPCell(new Phrase("STT", boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = new BaseColor(200, 220, 255), Padding = 5f });
                                table.AddCell(new PdfPCell(new Phrase("Hạng mục", boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = new BaseColor(200, 220, 255), Padding = 5f });
                                table.AddCell(new PdfPCell(new Phrase("Nội dung", boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = new BaseColor(200, 220, 255), Padding = 5f });

                                table.AddCell(new PdfPCell(new Phrase("1", font)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5f });
                                table.AddCell(new PdfPCell(new Phrase("Thông tin khách hàng", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5f });
                                PdfPTable subTableCustomer = new PdfPTable(new float[] { 1, 2 });
                                subTableCustomer.WidthPercentage = 100;
                                subTableCustomer.DefaultCell.Border = PdfPCell.NO_BORDER;
                                subTableCustomer.AddCell(new PdfPCell(new Phrase("Họ và tên", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableCustomer.AddCell(new PdfPCell(new Phrase(customerFullname, boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableCustomer.AddCell(new PdfPCell(new Phrase("Mã tài khoản", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableCustomer.AddCell(new PdfPCell(new Phrase(receiverAccount.AccountCode, boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableCustomer.AddCell(new PdfPCell(new Phrase("Số dư sau giao dịch", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableCustomer.AddCell(new PdfPCell(new Phrase(receiverAccount.Balance.ToString("#,##0") + " VND", boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                table.AddCell(new PdfPCell(subTableCustomer) { Border = PdfPCell.BOX, Padding = 5f });

                                table.AddCell(new PdfPCell(new Phrase("2", font)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5f });
                                table.AddCell(new PdfPCell(new Phrase("Thông tin giao dịch", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5f });
                                PdfPTable subTableTransaction = new PdfPTable(new float[] { 1, 2 });
                                subTableTransaction.WidthPercentage = 100;
                                subTableTransaction.DefaultCell.Border = PdfPCell.NO_BORDER;
                                subTableTransaction.AddCell(new PdfPCell(new Phrase("Số tiền", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableTransaction.AddCell(new PdfPCell(new Phrase(formattedAmount, boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableTransaction.AddCell(new PdfPCell(new Phrase("Nội dung", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableTransaction.AddCell(new PdfPCell(new Phrase(transactionDescription, boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableTransaction.AddCell(new PdfPCell(new Phrase("Phương thức", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableTransaction.AddCell(new PdfPCell(new Phrase("Tại quầy", boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableTransaction.AddCell(new PdfPCell(new Phrase("Người xử lý", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableTransaction.AddCell(new PdfPCell(new Phrase(handledBy, boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                // Đã bỏ "Ngày giao dịch" khỏi subTableTransaction
                                table.AddCell(new PdfPCell(subTableTransaction) { Border = PdfPCell.BOX, Padding = 5f });

                                document.Add(table);

                                document.Add(new Paragraph("\n\n"));
                                PdfPTable footerTable = new PdfPTable(1);
                                footerTable.WidthPercentage = 100;
                                PdfPCell footerCell = new PdfPCell();
                                footerCell.Border = PdfPCell.NO_BORDER;
                                footerCell.HorizontalAlignment = Element.ALIGN_CENTER;

                                footerCell.AddElement(new Paragraph("NGÂN HÀNG THƯƠNG MẠI CỔ PHẦN SÀI GÒN THƯƠNG TÍN", footerHighlightFont)
                                {
                                    Alignment = Element.ALIGN_LEFT
                                });
                                footerCell.AddElement(new Paragraph("•  266 - 268 Nam Kỳ Khởi Nghĩa, Q.3, TP.HCM", font)
                                {
                                    Alignment = Element.ALIGN_LEFT
                                });
                                footerCell.AddElement(new Paragraph("•  1800 5858 88/+84 28 3526 6060", font)
                                {
                                    Alignment = Element.ALIGN_LEFT
                                });
                                footerCell.AddElement(new Paragraph("•  sacombank.com.vn/ask@sacombank.com", font)
                                {
                                    Alignment = Element.ALIGN_LEFT
                                });

                                footerTable.AddCell(footerCell);
                                document.Add(footerTable);

                                document.Close();
                                writer.Close();
                            }

                            MessageBox.Show($"Hóa đơn đã được xuất thành công tại: {pdfPath}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi khi tạo file PDF tại {pdfPath}: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất hóa đơn PDF: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleDone()
        {
            try
            {
                Form mainForm = activeUC.FindForm();
                if (mainForm != null)
                {
                    mainForm.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hoàn tất giao dịch: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleCancel()
        {
            try
            {
                Form mainForm = activeUC.FindForm();
                if (mainForm != null)
                {
                    mainForm.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hủy nạp tiền: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private AccountModel GetAccountByCode(string accountCode)
        {
            try
            {
                using (var connection = dbContext.GetConnection())
                {
                    if (connection == null)
                    {
                        throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
                    }
                    connection.Open();
                    using (var command = new SqlCommand("SELECT * FROM ACCOUNT WHERE AccountCode = @AccountCode", connection))
                    {
                        command.Parameters.AddWithValue("@AccountCode", accountCode);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new AccountModel
                                {
                                    AccountID = reader.GetInt32("AccountID"),
                                    AccountCode = reader.GetString("AccountCode"),
                                    AccountName = reader.GetString("AccountName"),
                                    Balance = reader.GetDecimal("Balance"),
                                    AccountOpenDate = reader.GetDateTime("AccountOpenDate"),
                                    Username = reader.GetString("Username"),
                                    UserPassword = reader.GetString("UserPassword"),
                                    PINCode = reader.GetString("PINCode"),
                                    AccountStatus = reader.GetString("AccountStatus"),
                                    CustomerID = reader.GetInt32("CustomerID"),
                                    AccountTypeID = reader.GetInt32("AccountTypeID")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi truy vấn tài khoản: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
    }

    class DepositOTPControllerAdapter : IOTPController
    {
        private readonly AccountModel adapterAccount;
        private readonly DatabaseContext adapterDbContext;

        public DepositOTPControllerAdapter(AccountModel account, DatabaseContext dbContext)
        {
            this.adapterAccount = account;
            this.adapterDbContext = dbContext;
        }

        public string Phone
        {
            get
            {
                using (var connection = adapterDbContext.GetConnection())
                {
                    if (connection == null)
                    {
                        throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
                    }
                    connection.Open();
                    using (var command = new SqlCommand("SELECT Phone FROM CUSTOMER WHERE CustomerID = @CustomerID", connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", adapterAccount.CustomerID);
                        return command.ExecuteScalar()?.ToString() ?? "";
                    }
                }
            }
        }

        public string Email
        {
            get
            {
                using (var connection = adapterDbContext.GetConnection())
                {
                    if (connection == null)
                    {
                        throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
                    }
                    connection.Open();
                    using (var command = new SqlCommand("SELECT Email FROM CUSTOMER WHERE CustomerID = @CustomerID", connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", adapterAccount.CustomerID);
                        return command.ExecuteScalar()?.ToString() ?? "";
                    }
                }
            }
        }
    }
}