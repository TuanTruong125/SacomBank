using System;
using System.Data;
using System.Windows.Forms;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Views.Common;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Transfer;
using QuanLyThongTinKhachHangSacomBank.Views.Customer;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class TransferController
    {
        private ITransferView transferView;
        private UserControl activeUC;
        private readonly AccountModel currentAccount; // Tài khoản người gửi (có thể null nếu là nhân viên)
        private AccountModel senderAccount; // Tài khoản người gửi thực tế (dùng khi nhân viên nhập mã tài khoản)
        private readonly EmployeeModel currentEmployee;
        private readonly DatabaseContext dbContext;
        private readonly IConfiguration configuration;
        private readonly ICustomerHomeView customerHomeView;
        private bool isTransactionSuccessful;

        // Lưu thông tin giao dịch để sử dụng khi xuất PDF
        private ITransferViewData lastTransferViewData;
        private AccountModel lastReceiverAccount;
        private bool lastIsEmployee;

        public TransferController(AccountModel account, EmployeeModel employee, DatabaseContext dbContext, IConfiguration configuration, ICustomerHomeView customerHomeView)
        {
            activeUC = null;
            currentAccount = account;
            currentEmployee = employee;
            this.dbContext = dbContext;
            this.configuration = configuration;
            this.customerHomeView = customerHomeView;
            this.isTransactionSuccessful = false;
        }

        public void OpenTransfer(UserControl transferUC, bool isEmployee = false)
        {
            try
            {
                transferView = new FormTransfer();
                activeUC = transferUC;

                if (activeUC is ITransferViewData transferViewData)
                {
                    // Nếu không phải nhân viên, load thông tin người gửi từ currentAccount
                    if (!isEmployee)
                    {
                        // [Load thông tin người gửi (Sender)]
                        string senderPhone = "";
                        string senderCitizenID = "";
                        using (var connection = dbContext.GetConnection())
                        {
                            connection.Open();
                            using (var command = new SqlCommand("SELECT Phone, CitizenID FROM CUSTOMER WHERE CustomerID = @CustomerID", connection))
                            {
                                command.Parameters.AddWithValue("@CustomerID", currentAccount.CustomerID);
                                using (var reader = command.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        senderPhone = reader["Phone"]?.ToString();
                                        senderCitizenID = reader["CitizenID"]?.ToString();
                                    }
                                }
                            }
                        }

                        transferViewData.SetSenderInfo(currentAccount, senderPhone, senderCitizenID);
                        senderAccount = currentAccount; // Gán senderAccount cho trường hợp khách hàng
                    }

                    // Đăng ký các sự kiện
                    transferViewData.ConfirmRequested += (s, e) => HandleConfirm(isEmployee);
                    transferViewData.CancelRequested += (s, e) => HandleCancel();
                    transferViewData.ReceiverAccountIDLostFocus += (s, e) => HandleReceiverAccountIDLostFocus(transferViewData);
                    transferViewData.SenderAccountIDLostFocus += (s, e) => HandleSenderAccountIDLostFocus(transferViewData); // Thêm sự kiện cho người gửi
                }

                // Đăng ký sự kiện FormClosing
                transferView.FormClosing += (s, e) =>
                {
                    if (isTransactionSuccessful && !isEmployee)
                    {
                        customerHomeView.SetBalance(senderAccount.Balance.ToString("#,##0") + " VND");
                    }
                };

                transferView.LoadUserControl(activeUC);
                transferView.ShowForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong TransferController.OpenTransfer: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleSenderAccountIDLostFocus(ITransferViewData transferViewData)
        {
            try
            {
                string senderAccountID = transferViewData.AccountID;
                if (!string.IsNullOrWhiteSpace(senderAccountID))
                {
                    senderAccount = GetAccountByCode(senderAccountID);
                    if (senderAccount == null)
                    {
                        transferViewData.ShowError("Tài khoản người gửi không tồn tại!");
                        transferViewData.SetSenderInfo(null, "", "");
                        return;
                    }

                    if (senderAccount.AccountStatus == "Khóa")
                    {
                        transferViewData.ShowError("Tài khoản người gửi đang bị khóa!");
                        transferViewData.SetSenderInfo(null, "", "");
                        return;
                    }

                    if (senderAccount.AccountStatus == "Đóng")
                    {
                        transferViewData.ShowError("Tài khoản người gửi đã bị đóng!");
                        transferViewData.SetSenderInfo(null, "", "");
                        return;
                    }

                    string senderPhone = "";
                    string senderCitizenID = "";
                    using (var connection = dbContext.GetConnection())
                    {
                        connection.Open();
                        using (var command = new SqlCommand("SELECT Phone, CitizenID FROM CUSTOMER WHERE CustomerID = @CustomerID", connection))
                        {
                            command.Parameters.AddWithValue("@CustomerID", senderAccount.CustomerID);
                            using (var reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    senderPhone = reader["Phone"]?.ToString();
                                    senderCitizenID = reader["CitizenID"]?.ToString();
                                }
                            }
                        }
                    }

                    transferViewData.SetSenderInfo(senderAccount, senderPhone, senderCitizenID);
                    transferViewData.EnableBankComboBox(); // Kích hoạt comboBoxBank nếu dữ liệu hợp lệ
                    transferViewData.HideError();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kiểm tra tài khoản người gửi: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleConfirm(bool isEmployee)
        {
            try
            {
                if (activeUC is ITransferViewData transferViewData)
                {
                    // Kiểm tra thông tin đầu vào
                    if (string.IsNullOrWhiteSpace(transferViewData.AccountID) ||
                        string.IsNullOrWhiteSpace(transferViewData.ReceiverAccountID) ||
                        string.IsNullOrWhiteSpace(transferViewData.Amount) ||
                        transferViewData.BankSelectedIndex == -1)
                    {
                        transferViewData.ShowError("Vui lòng nhập đầy đủ thông tin!");
                        return;
                    }

                    // Load tài khoản người gửi nếu chưa có (trường hợp nhân viên)
                    if (senderAccount == null)
                    {
                        senderAccount = GetAccountByCode(transferViewData.AccountID);
                        if (senderAccount == null)
                        {
                            transferViewData.ShowError("Tài khoản người gửi không tồn tại!");
                            return;
                        }
                    }

                    // Kiểm tra trạng thái tài khoản người gửi
                    if (senderAccount.AccountStatus == "Khóa")
                    {
                        transferViewData.ShowError("Tài khoản người gửi đang bị khóa!");
                        return;
                    }

                    if (senderAccount.AccountStatus == "Đóng")
                    {
                        transferViewData.ShowError("Tài khoản người gửi đã bị đóng!");
                        return;
                    }

                    // Load tài khoản người nhận
                    AccountModel receiverAccount = GetAccountByCode(transferViewData.ReceiverAccountID);
                    if (receiverAccount == null)
                    {
                        transferViewData.ShowError("Tài khoản người nhận không tồn tại!");
                        return;
                    }

                    // Kiểm tra nếu tài khoản người nhận trùng với tài khoản người gửi
                    if (receiverAccount.AccountCode == senderAccount.AccountCode)
                    {
                        transferViewData.ShowError("Tài khoản người nhận không hợp lệ!");
                        return;
                    }

                    // Kiểm tra trạng thái tài khoản người nhận
                    if (receiverAccount.AccountStatus == "Khóa")
                    {
                        transferViewData.ShowError("Tài khoản người nhận đang bị khóa!");
                        return;
                    }

                    if (receiverAccount.AccountStatus == "Đóng")
                    {
                        transferViewData.ShowError("Tài khoản người nhận đã bị đóng!");
                        return;
                    }

                    // Kiểm tra số dư tài khoản người gửi
                    decimal amount = decimal.Parse(transferViewData.Amount);
                    if (amount > senderAccount.Balance)
                    {
                        transferViewData.ShowError("Số dư không đủ để thực hiện giao dịch!");
                        return;
                    }

                    // Kiểm tra số tiền gửi tối thiểu
                    if (amount < 5000)
                    {
                        transferViewData.ShowError("Số tiền chuyển tối thiểu là 5,000 VND!");
                        return;
                    }

                    transferViewData.HideError();

                    // Xác nhận giao dịch
                    bool isVerified = false;

                    if (isEmployee)
                    {
                        // Trường hợp nhân viên: Chỉ cần xác nhận bằng OTP
                        FormOTP formOTP = new FormOTP();
                        var otpController = new OTPController(formOTP, formOTP, new OTPControllerAdapter(senderAccount, dbContext), configuration);
                        if (formOTP.ShowDialog() == DialogResult.OK)
                        {
                            isVerified = true;
                        }
                    }
                    else
                    {
                        // Trường hợp khách hàng: Kiểm tra số tiền giao dịch
                        if (amount < 10000000) // Dưới 10 triệu VND
                        {
                            // Chỉ cần xác nhận bằng mã PIN
                            FormPINCode formPINCode = new FormPINCode(senderAccount); // Truyền senderAccount
                            var pinController = new PINCodeController(formPINCode, formPINCode, senderAccount);
                            if (formPINCode.ShowDialog() == DialogResult.OK)
                            {
                                isVerified = true;
                            }
                        }
                        else // Từ 10 triệu VND trở lên
                        {
                            // Yêu cầu nhập mã PIN trước
                            FormPINCode formPINCode = new FormPINCode(senderAccount); // Truyền senderAccount
                            var pinController = new PINCodeController(formPINCode, formPINCode, senderAccount);
                            bool pinVerified = formPINCode.ShowDialog() == DialogResult.OK;

                            // Nếu mã PIN đúng, tiếp tục xác nhận bằng OTP
                            if (pinVerified)
                            {
                                FormOTP formOTP = new FormOTP();
                                var otpController = new OTPController(formOTP, formOTP, new OTPControllerAdapter(senderAccount, dbContext), configuration);
                                if (formOTP.ShowDialog() == DialogResult.OK)
                                {
                                    isVerified = true;
                                }
                            }
                        }
                    }

                    if (isVerified)
                    {
                        // Lưu thông tin giao dịch ngay khi xác nhận thành công
                        lastTransferViewData = transferViewData;
                        lastReceiverAccount = receiverAccount;
                        lastIsEmployee = isEmployee;

                        // Thực hiện giao dịch
                        SaveTransaction(transferViewData, receiverAccount, isEmployee);

                        // Đánh dấu giao dịch thành công
                        isTransactionSuccessful = true;

                        // Cập nhật số dư ngay lập tức sau khi giao dịch thành công
                        if (customerHomeView != null && !isEmployee)
                        {
                            customerHomeView.SetBalance(senderAccount.Balance.ToString("#,##0") + " VND");
                        }

                        // Chuyển sang giao diện thành công
                        activeUC = new UC_SuccessfulTransfer();
                        SetupSuccessfulTransfer(activeUC as ISuccessfulTransferView, transferViewData, receiverAccount, isEmployee);
                        transferView.LoadUserControl(activeUC);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xác nhận chuyển tiền: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveTransaction(ITransferViewData transferViewData, AccountModel receiverAccount, bool isEmployee)
        {
            using (var connection = dbContext.GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Lấy TransactionTypeID
                        int transactionTypeID;
                        using (var command = new SqlCommand("SELECT TransactionTypeID FROM TRANSACTION_TYPE WHERE TransactionTypeName = @TransactionTypeName", connection, transaction))
                        {
                            command.Parameters.AddWithValue("@TransactionTypeName", "Chuyển tiền");
                            transactionTypeID = (int)command.ExecuteScalar();
                        }

                        // Thêm giao dịch vào bảng TRANSACTION
                        using (var command = new SqlCommand(
                            "INSERT INTO [TRANSACTION] (Amount, TransactionDate, ReceiverAccountID, TransactionStatus, HandledBy, TransactionDescription, TransactionMethod, ReceiverAccountName, AccountID, TransactionTypeID) " +
                            "VALUES (@Amount, @TransactionDate, @ReceiverAccountID, @TransactionStatus, @HandledBy, @TransactionDescription, @TransactionMethod, @ReceiverAccountName, @AccountID, @TransactionTypeID)", connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Amount", decimal.Parse(transferViewData.Amount));
                            command.Parameters.AddWithValue("@TransactionDate", DateTime.Now);
                            command.Parameters.AddWithValue("@ReceiverAccountID", receiverAccount.AccountID);
                            command.Parameters.AddWithValue("@TransactionStatus", "Hoàn tất");
                            command.Parameters.AddWithValue("@HandledBy", isEmployee ? (object)currentEmployee.EmployeeID : DBNull.Value);
                            command.Parameters.AddWithValue("@TransactionDescription", transferViewData.TransactionDescription);
                            command.Parameters.AddWithValue("@TransactionMethod", isEmployee ? "Tại quầy" : "Trực tuyến");
                            command.Parameters.AddWithValue("@ReceiverAccountName", receiverAccount.AccountName);
                            command.Parameters.AddWithValue("@AccountID", senderAccount.AccountID);
                            command.Parameters.AddWithValue("@TransactionTypeID", transactionTypeID);
                            command.ExecuteNonQuery();
                        }

                        // Cập nhật số dư tài khoản người gửi
                        using (var command = new SqlCommand("UPDATE ACCOUNT SET Balance = Balance - @Amount WHERE AccountID = @AccountID", connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Amount", decimal.Parse(transferViewData.Amount));
                            command.Parameters.AddWithValue("@AccountID", senderAccount.AccountID);
                            command.ExecuteNonQuery();
                        }

                        // Cập nhật số dư tài khoản người nhận
                        using (var command = new SqlCommand("UPDATE ACCOUNT SET Balance = Balance + @Amount WHERE AccountID = @AccountID", connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Amount", decimal.Parse(transferViewData.Amount));
                            command.Parameters.AddWithValue("@AccountID", receiverAccount.AccountID);
                            command.ExecuteNonQuery();
                        }

                        // Cập nhật số dư trong đối tượng senderAccount và receiverAccount
                        senderAccount.Balance -= decimal.Parse(transferViewData.Amount);
                        receiverAccount.Balance += decimal.Parse(transferViewData.Amount);

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Lỗi khi lưu giao dịch: " + ex.Message);
                    }
                }
            }
        }

        private void SetupSuccessfulTransfer(ISuccessfulTransferView view, ITransferViewData transferViewData, AccountModel receiverAccount, bool isEmployee)
        {
            // Truy vấn Fullname của người gửi từ bảng CUSTOMER
            string senderFullname = "";
            using (var connection = dbContext.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT Fullname FROM CUSTOMER WHERE CustomerID = @CustomerID", connection))
                {
                    command.Parameters.AddWithValue("@CustomerID", senderAccount.CustomerID);
                    senderFullname = command.ExecuteScalar()?.ToString() ?? senderAccount.AccountName;
                }
            }

            // Truy vấn Fullname của người nhận từ bảng CUSTOMER
            string receiverFullname = "";
            using (var connection = dbContext.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT Fullname FROM CUSTOMER WHERE CustomerID = @CustomerID", connection))
                {
                    command.Parameters.AddWithValue("@CustomerID", receiverAccount.CustomerID);
                    receiverFullname = command.ExecuteScalar()?.ToString() ?? receiverAccount.AccountName;
                }
            }

            // Định dạng số tiền với dấu phẩy và thêm "VND"
            string formattedAmount = decimal.Parse(transferViewData.Amount).ToString("#,##0") + " VND";

            // Gán các giá trị vào giao diện
            view.Amount = formattedAmount;
            view.CustomerName = senderFullname;
            view.CustomerAccountID = senderAccount.AccountCode;
            view.AccountBalance = senderAccount.Balance.ToString("#,##0") + " VND";
            view.ReceiverName = receiverFullname;
            view.ReceiverAccountID = receiverAccount.AccountCode;
            view.ReceiverBank = "Sacombank";
            view.TransactionDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            view.EmployeeName = isEmployee ? currentEmployee?.EmployeeName : "Tự động";
            view.TransactionDescription = transferViewData.TransactionDescription;

            view.DoneClicked += (s, e) => transferView.FindForm()?.Close();
            view.InvoiceClicked += (s, e) => ExportToPDF();
        }

        private void ExportToPDF()
        {
            try
            {
                if (lastTransferViewData == null || lastReceiverAccount == null)
                {
                    MessageBox.Show("Không có thông tin giao dịch để xuất hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string senderFullname = "";
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand("SELECT Fullname FROM CUSTOMER WHERE CustomerID = @CustomerID", connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", senderAccount.CustomerID);
                        senderFullname = command.ExecuteScalar()?.ToString() ?? senderAccount.AccountName;
                    }
                }

                string receiverFullname = "";
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand("SELECT Fullname FROM CUSTOMER WHERE CustomerID = @CustomerID", connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", lastReceiverAccount.CustomerID);
                        receiverFullname = command.ExecuteScalar()?.ToString() ?? lastReceiverAccount.AccountName;
                    }
                }

                string formattedAmount = decimal.Parse(lastTransferViewData.Amount).ToString("#,##0") + " VND";

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                    saveFileDialog.Title = "Chọn nơi lưu hóa đơn giao dịch";
                    saveFileDialog.FileName = $"TransactionReceipt_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string pdfPath = saveFileDialog.FileName;

                        // Kiểm tra quyền truy cập và đảm bảo thư mục tồn tại
                        string directory = Path.GetDirectoryName(pdfPath);
                        if (!Directory.Exists(directory))
                        {
                            Directory.CreateDirectory(directory);
                        }

                        // Kiểm tra quyền ghi file
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

                        // Kiểm tra xem file có đang bị khóa không
                        if (File.Exists(pdfPath))
                        {
                            try
                            {
                                using (FileStream fs = new FileStream(pdfPath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                                {
                                    fs.Close();
                                }
                                File.Delete(pdfPath); // Xóa file cũ nếu tồn tại
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"File {pdfPath} đang bị khóa bởi một tiến trình khác.\nVui lòng đóng ứng dụng đang sử dụng file (nếu có) và thử lại.\nChi tiết lỗi: {ex.Message}", "Lỗi truy cập file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        // Nhúng font từ thư mục Resources/fonts trong dự án
                        string projectDir = AppDomain.CurrentDomain.BaseDirectory;
                        string arialFontPath = Path.Combine(projectDir, "Resources", "fonts", "ARIAL.TTF");
                        string arialBoldFontPath = Path.Combine(projectDir, "Resources", "fonts", "ARIALBD.TTF");

                        // Kiểm tra sự tồn tại của font
                        if (!File.Exists(arialFontPath) || !File.Exists(arialBoldFontPath))
                        {
                            MessageBox.Show($"Không tìm thấy file font tại:\n- {arialFontPath}\n- {arialBoldFontPath}\nVui lòng kiểm tra thư mục Resources/fonts trong dự án.", "Lỗi font", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        try
                        {
                            // Tạo font cho iTextSharp với encoding IDENTITY_H để hỗ trợ tiếng Việt
                            BaseFont arialBaseFont = BaseFont.CreateFont(arialFontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                            BaseFont arialBoldBaseFont = BaseFont.CreateFont(arialBoldFontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                            iTextSharp.text.Font font = new iTextSharp.text.Font(arialBaseFont, 10);
                            iTextSharp.text.Font boldFont = new iTextSharp.text.Font(arialBoldBaseFont, 10);
                            iTextSharp.text.Font headerFont = new iTextSharp.text.Font(arialBoldBaseFont, 18, iTextSharp.text.Font.ITALIC, new BaseColor(0, 102, 204));
                            iTextSharp.text.Font subHeaderFont = new iTextSharp.text.Font(arialBoldBaseFont, 12);
                            iTextSharp.text.Font footerHighlightFont = new iTextSharp.text.Font(arialBoldBaseFont, 10, iTextSharp.text.Font.NORMAL, new BaseColor(255, 147, 0));

                            // Tạo document với iTextSharp
                            using (FileStream fs = new FileStream(pdfPath, FileMode.Create, FileAccess.Write, FileShare.None))
                            {
                                Document document = new Document(PageSize.A4, 36, 36, 36, 36);
                                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                                document.Open();

                                // Header
                                document.Add(new Paragraph("Sacombank", headerFont)
                                {
                                    Alignment = Element.ALIGN_LEFT
                                });

                                document.Add(new Paragraph("HÓA ĐƠN GIAO DỊCH CHUYỂN TIỀN", subHeaderFont)
                                {
                                    Alignment = Element.ALIGN_LEFT
                                });

                                document.Add(new Paragraph($"Ngày giao dịch: {DateTime.Now:dd/MM/yyyy HH:mm:ss}", font)
                                {
                                    Alignment = Element.ALIGN_LEFT
                                });

                                // Thêm đường kẻ ngang màu xanh dưới header
                                PdfPTable lineTable = new PdfPTable(1);
                                lineTable.WidthPercentage = 100;
                                PdfPCell lineCell = new PdfPCell() { Border = PdfPCell.BOTTOM_BORDER, BorderColor = new BaseColor(0, 102, 204), FixedHeight = 5f };
                                lineTable.AddCell(lineCell);
                                document.Add(lineTable);

                                document.Add(new Paragraph("\n"));

                                // Bảng thông tin giao dịch
                                PdfPTable table = new PdfPTable(new float[] { 1, 3, 5 });
                                table.WidthPercentage = 100;
                                table.DefaultCell.Border = PdfPCell.BOX;

                                // Tiêu đề bảng với màu nền
                                table.AddCell(new PdfPCell(new Phrase("STT", boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = new BaseColor(200, 220, 255), Padding = 5f });
                                table.AddCell(new PdfPCell(new Phrase("Hạng mục", boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = new BaseColor(200, 220, 255), Padding = 5f });
                                table.AddCell(new PdfPCell(new Phrase("Nội dung", boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = new BaseColor(200, 220, 255), Padding = 5f });

                                // Dòng 1: Thông tin người gửi
                                table.AddCell(new PdfPCell(new Phrase("1", font)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5f });
                                table.AddCell(new PdfPCell(new Phrase("Thông tin người gửi", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5f });
                                PdfPTable subTableSender = new PdfPTable(new float[] { 1, 2 });
                                subTableSender.WidthPercentage = 100;
                                subTableSender.DefaultCell.Border = PdfPCell.NO_BORDER;
                                subTableSender.AddCell(new PdfPCell(new Phrase("Họ và tên", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableSender.AddCell(new PdfPCell(new Phrase(senderFullname, boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableSender.AddCell(new PdfPCell(new Phrase("Mã tài khoản", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableSender.AddCell(new PdfPCell(new Phrase(senderAccount.AccountCode, boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableSender.AddCell(new PdfPCell(new Phrase("Số dư sau giao dịch", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableSender.AddCell(new PdfPCell(new Phrase(senderAccount.Balance.ToString("#,##0") + " VND", boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                table.AddCell(new PdfPCell(subTableSender) { Border = PdfPCell.BOX, Padding = 5f });

                                // Dòng 2: Thông tin người nhận
                                table.AddCell(new PdfPCell(new Phrase("2", font)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5f });
                                table.AddCell(new PdfPCell(new Phrase("Thông tin người nhận", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5f });
                                PdfPTable subTableReceiver = new PdfPTable(new float[] { 1, 2 });
                                subTableReceiver.WidthPercentage = 100;
                                subTableReceiver.DefaultCell.Border = PdfPCell.NO_BORDER;
                                subTableReceiver.AddCell(new PdfPCell(new Phrase("Họ và tên", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableReceiver.AddCell(new PdfPCell(new Phrase(receiverFullname, boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableReceiver.AddCell(new PdfPCell(new Phrase("Mã tài khoản", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableReceiver.AddCell(new PdfPCell(new Phrase(lastReceiverAccount.AccountCode, boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableReceiver.AddCell(new PdfPCell(new Phrase("Ngân hàng", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableReceiver.AddCell(new PdfPCell(new Phrase("Sacombank", boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                table.AddCell(new PdfPCell(subTableReceiver) { Border = PdfPCell.BOX, Padding = 5f });

                                // Dòng 3: Thông tin giao dịch
                                table.AddCell(new PdfPCell(new Phrase("3", font)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5f });
                                table.AddCell(new PdfPCell(new Phrase("Thông tin giao dịch", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5f });
                                PdfPTable subTableTransaction = new PdfPTable(new float[] { 1, 2 });
                                subTableTransaction.WidthPercentage = 100;
                                subTableTransaction.DefaultCell.Border = PdfPCell.NO_BORDER;
                                subTableTransaction.AddCell(new PdfPCell(new Phrase("Số tiền", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableTransaction.AddCell(new PdfPCell(new Phrase(formattedAmount, boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableTransaction.AddCell(new PdfPCell(new Phrase("Nội dung", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableTransaction.AddCell(new PdfPCell(new Phrase(lastTransferViewData.TransactionDescription, boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableTransaction.AddCell(new PdfPCell(new Phrase("Phương thức", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableTransaction.AddCell(new PdfPCell(new Phrase(lastIsEmployee ? "Tại quầy" : "Trực tuyến", boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableTransaction.AddCell(new PdfPCell(new Phrase("Người xử lý", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableTransaction.AddCell(new PdfPCell(new Phrase(lastIsEmployee ? currentEmployee?.EmployeeName : "Tự động", boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                table.AddCell(new PdfPCell(subTableTransaction) { Border = PdfPCell.BOX, Padding = 5f });

                                document.Add(table);

                                // Footer
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
                MessageBox.Show($"Lỗi khi hủy chuyển tiền: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleReceiverAccountIDLostFocus(ITransferViewData transferViewData)
        {
            try
            {
                string receiverAccountID = transferViewData.ReceiverAccountID;
                if (!string.IsNullOrWhiteSpace(receiverAccountID))
                {
                    AccountModel receiverAccount = GetAccountByCode(receiverAccountID);
                    if (receiverAccount == null)
                    {
                        transferViewData.ShowError("Tài khoản người nhận không tồn tại!");
                        transferViewData.SetReceiverInfo(null, "", "");
                        return;
                    }

                    // Kiểm tra nếu tài khoản người nhận trùng với tài khoản người gửi
                    if (senderAccount != null && receiverAccount.AccountCode == senderAccount.AccountCode)
                    {
                        transferViewData.ShowError("Tài khoản người nhận không hợp lệ!");
                        transferViewData.SetReceiverInfo(null, "", "");
                        return;
                    }

                    // Kiểm tra trạng thái tài khoản người nhận
                    if (receiverAccount.AccountStatus == "Khóa")
                    {
                        transferViewData.ShowError("Tài khoản người nhận đang bị khóa!");
                        transferViewData.SetReceiverInfo(null, "", "");
                        return;
                    }

                    if (receiverAccount.AccountStatus == "Đóng")
                    {
                        transferViewData.ShowError("Tài khoản người nhận đã bị đóng!");
                        transferViewData.SetReceiverInfo(null, "", "");
                        return;
                    }

                    // Load thông tin người nhận
                    string receiverPhone = "";
                    string receiverCitizenID = "";
                    using (var connection = dbContext.GetConnection())
                    {
                        connection.Open();
                        using (var command = new SqlCommand("SELECT Phone, CitizenID FROM CUSTOMER WHERE CustomerID = @CustomerID", connection))
                        {
                            command.Parameters.AddWithValue("@CustomerID", receiverAccount.CustomerID);
                            using (var reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    receiverPhone = reader["Phone"]?.ToString();
                                    receiverCitizenID = reader["CitizenID"]?.ToString();
                                }
                            }
                        }
                    }

                    transferViewData.SetReceiverInfo(receiverAccount, receiverPhone, receiverCitizenID);
                    transferViewData.HideError();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kiểm tra tài khoản người nhận: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private AccountModel GetAccountByCode(string accountCode)
        {
            try
            {
                using (var connection = dbContext.GetConnection())
                {
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

    class OTPControllerAdapter : IOTPController
    {
        private readonly AccountModel account;
        private readonly DatabaseContext dbContext;

        public OTPControllerAdapter(AccountModel account, DatabaseContext dbContext)
        {
            this.account = account;
            this.dbContext = dbContext;
        }

        public string Phone
        {
            get
            {
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand("SELECT Phone FROM CUSTOMER WHERE CustomerID = @CustomerID", connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", account.CustomerID);
                        return command.ExecuteScalar()?.ToString();
                    }
                }
            }
        }

        public string Email
        {
            get
            {
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand("SELECT Email FROM CUSTOMER WHERE CustomerID = @CustomerID", connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", account.CustomerID);
                        return command.ExecuteScalar()?.ToString();
                    }
                }
            }
        }
    }
}