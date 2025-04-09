using System;
using System.Data;
using System.Windows.Forms;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Views.Common;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Transfer;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Layout; // Add this using directive
using iText.Layout.Element; // Ensure

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class TransferController
    {
        private ITransferView transferView;
        private UserControl activeUC;
        private readonly AccountModel currentAccount;
        private readonly EmployeeModel currentEmployee;
        private readonly DatabaseContext dbContext;
        private readonly IConfiguration configuration;

        // Lưu thông tin giao dịch để sử dụng khi xuất PDF
        private ITransferViewData lastTransferViewData;
        private AccountModel lastReceiverAccount;
        private bool lastIsEmployee;

        public TransferController(AccountModel account, EmployeeModel employee, DatabaseContext dbContext, IConfiguration configuration)
        {
            activeUC = null;
            currentAccount = account;
            currentEmployee = employee;
            this.dbContext = dbContext;
            this.configuration = configuration;
        }

        public void OpenTransfer(UserControl transferUC, bool isEmployee = false)
        {
            try
            {
                transferView = new FormTransfer();
                activeUC = transferUC; // Sử dụng transferUC được truyền vào

                if (activeUC is ITransferViewData transferViewData)
                {
                    // [Load thông tin người gửi (Sender)]
                    // Truy vấn thông tin Phone và CitizenID từ bảng CUSTOMER dựa trên CustomerID của currentAccount
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

                    // Gán thông tin người gửi lên giao diện
                    transferViewData.SetSenderInfo(currentAccount, senderPhone, senderCitizenID);

                    // Đăng ký các sự kiện
                    transferViewData.ConfirmRequested += (s, e) => HandleConfirm(isEmployee);
                    transferViewData.CancelRequested += (s, e) => HandleCancel();
                    transferViewData.ReceiverAccountIDLostFocus += (s, e) => HandleReceiverAccountIDLostFocus(transferViewData);
                }

                transferView.LoadUserControl(activeUC);
                transferView.ShowForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong TransferController.OpenTransfer: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleConfirm(bool isEmployee)
        {
            try
            {
                if (activeUC is ITransferViewData transferViewData)
                {
                    if (string.IsNullOrWhiteSpace(transferViewData.ReceiverAccountID) ||
                        string.IsNullOrWhiteSpace(transferViewData.Amount) ||
                        transferViewData.BankSelectedIndex == -1)
                    {
                        transferViewData.ShowError("Vui lòng nhập đầy đủ thông tin!");
                        return;
                    }

                    AccountModel receiverAccount = GetAccountByCode(transferViewData.ReceiverAccountID);
                    if (receiverAccount == null)
                    {
                        transferViewData.ShowError("Tài khoản người nhận không tồn tại!");
                        return;
                    }

                    // Kiểm tra trạng thái tài khoản người nhận trước khi mở form mã PIN/OTP
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

                    decimal amount = decimal.Parse(transferViewData.Amount);
                    if (amount > currentAccount.Balance)
                    {
                        transferViewData.ShowError("Số dư không đủ để thực hiện giao dịch!");
                        return;
                    }

                    transferViewData.HideError();

                    bool isVerified = false;
                    if (isEmployee)
                    {
                        FormOTP formOTP = new FormOTP();
                        var otpController = new OTPController(formOTP, formOTP, new OTPControllerAdapter(currentAccount, dbContext), configuration);
                        if (formOTP.ShowDialog() == DialogResult.OK)
                        {
                            isVerified = true;
                        }
                    }
                    else
                    {
                        FormPINCode formPINCode = new FormPINCode(currentAccount);
                        var pinController = new PINCodeController(formPINCode, formPINCode, currentAccount);
                        if (formPINCode.ShowDialog() == DialogResult.OK)
                        {
                            if (amount > 10000000) // Trên 10 triệu
                            {
                                FormOTP formOTP = new FormOTP();
                                var otpController = new OTPController(formOTP, formOTP, new OTPControllerAdapter(currentAccount, dbContext), configuration);
                                isVerified = formOTP.ShowDialog() == DialogResult.OK;
                            }
                            else
                            {
                                isVerified = true;
                            }
                        }
                    }

                    if (isVerified)
                    {
                        SaveTransaction(transferViewData, receiverAccount, isEmployee);
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
                            command.Parameters.AddWithValue("@HandledBy", isEmployee ? (object)currentEmployee?.EmployeeID : DBNull.Value);
                            command.Parameters.AddWithValue("@TransactionDescription", transferViewData.TransactionDescription);
                            command.Parameters.AddWithValue("@TransactionMethod", isEmployee ? "Tại quầy" : "Trực tuyến");
                            command.Parameters.AddWithValue("@ReceiverAccountName", receiverAccount.AccountName);
                            command.Parameters.AddWithValue("@AccountID", currentAccount.AccountID);
                            command.Parameters.AddWithValue("@TransactionTypeID", transactionTypeID);
                            command.ExecuteNonQuery();
                        }

                        // Cập nhật số dư tài khoản người gửi
                        using (var command = new SqlCommand("UPDATE ACCOUNT SET Balance = Balance - @Amount WHERE AccountID = @AccountID", connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Amount", decimal.Parse(transferViewData.Amount));
                            command.Parameters.AddWithValue("@AccountID", currentAccount.AccountID);
                            command.ExecuteNonQuery();
                        }

                        // Cập nhật số dư tài khoản người nhận
                        using (var command = new SqlCommand("UPDATE ACCOUNT SET Balance = Balance + @Amount WHERE AccountID = @AccountID", connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Amount", decimal.Parse(transferViewData.Amount));
                            command.Parameters.AddWithValue("@AccountID", receiverAccount.AccountID);
                            command.ExecuteNonQuery();
                        }

                        // Cập nhật số dư trong đối tượng currentAccount và receiverAccount
                        currentAccount.Balance -= decimal.Parse(transferViewData.Amount);
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
                    command.Parameters.AddWithValue("@CustomerID", currentAccount.CustomerID);
                    senderFullname = command.ExecuteScalar()?.ToString() ?? currentAccount.AccountName;
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
            view.Amount = formattedAmount; // Hiển thị số tiền đã chuyển, ví dụ: "200,000 VND"
            view.CustomerName = senderFullname; // Hiển thị Fullname của người gửi
            view.CustomerAccountID = currentAccount.AccountCode;
            view.AccountBalance = currentAccount.Balance.ToString("#,##0") + " VND";
            view.ReceiverName = receiverFullname; // Hiển thị Fullname của người nhận
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

                // Truy vấn lại Fullname của người gửi và người nhận
                string senderFullname = "";
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand("SELECT Fullname FROM CUSTOMER WHERE CustomerID = @CustomerID", connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", currentAccount.CustomerID);
                        senderFullname = command.ExecuteScalar()?.ToString() ?? currentAccount.AccountName;
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

                // Hiển thị hộp thoại để người dùng chọn vị trí lưu file PDF
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                    saveFileDialog.Title = "Chọn nơi lưu hóa đơn giao dịch";
                    saveFileDialog.FileName = $"Transaction_Receipt_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string pdfPath = saveFileDialog.FileName;

                        // Tạo font hỗ trợ Unicode (để hiển thị tiếng Việt)
                        PdfFont font = PdfFontFactory.CreateFont("C:/Windows/Fonts/times.ttf", PdfEncodings.IDENTITY_H, PdfFontFactory.EmbeddingStrategy.PREFER_EMBEDDED);
                        PdfFont boldFont = PdfFontFactory.CreateFont("C:/Windows/Fonts/timesbd.ttf", PdfEncodings.IDENTITY_H, PdfFontFactory.EmbeddingStrategy.PREFER_EMBEDDED);

                        // Tạo file PDF
                        using (var writer = new PdfWriter(pdfPath))
                        {
                            using (var pdf = new PdfDocument(writer))
                            {
                                var document = new Document(pdf);

                                // Tiêu đề hóa đơn
                                document.Add(new Paragraph("HÓA ĐƠN GIAO DỊCH")
                                    .SetTextAlignment(TextAlignment.CENTER)
                                    .SetFont(boldFont)
                                    .SetFontSize(20));

                                document.Add(new Paragraph("Ngân hàng Sacombank")
                                    .SetTextAlignment(TextAlignment.CENTER)
                                    .SetFont(font)
                                    .SetFontSize(14));

                                document.Add(new Paragraph($"Ngày giao dịch: {DateTime.Now:dd/MM/yyyy HH:mm:ss}")
                                    .SetTextAlignment(TextAlignment.CENTER)
                                    .SetFont(font)
                                    .SetFontSize(12));

                                document.Add(new Paragraph("---------------------------------------------")
                                    .SetTextAlignment(TextAlignment.CENTER)
                                    .SetFont(font));

                                // Thông tin người gửi
                                document.Add(new Paragraph("THÔNG TIN NGƯỜI GỬI")
                                    .SetFont(boldFont)
                                    .SetFontSize(14));
                                document.Add(new Paragraph($"Họ và tên: {senderFullname}")
                                    .SetFont(font));
                                document.Add(new Paragraph($"Mã tài khoản: {currentAccount.AccountCode}")
                                    .SetFont(font));
                                document.Add(new Paragraph($"Số dư sau giao dịch: {currentAccount.Balance.ToString("#,##0")} VND")
                                    .SetFont(font));

                                document.Add(new Paragraph("---------------------------------------------")
                                    .SetTextAlignment(TextAlignment.CENTER)
                                    .SetFont(font));

                                // Thông tin người nhận
                                document.Add(new Paragraph("THÔNG TIN NGƯỜI NHẬN")
                                    .SetFont(boldFont)
                                    .SetFontSize(14));
                                document.Add(new Paragraph($"Họ và tên: {receiverFullname}")
                                    .SetFont(font));
                                document.Add(new Paragraph($"Mã tài khoản: {lastReceiverAccount.AccountCode}")
                                    .SetFont(font));
                                document.Add(new Paragraph($"Ngân hàng: Sacombank")
                                    .SetFont(font));

                                document.Add(new Paragraph("---------------------------------------------")
                                    .SetTextAlignment(TextAlignment.CENTER)
                                    .SetFont(font));

                                // Thông tin giao dịch
                                document.Add(new Paragraph("THÔNG TIN GIAO DỊCH")
                                    .SetFont(boldFont)
                                    .SetFontSize(14));
                                document.Add(new Paragraph($"Số tiền: {formattedAmount}")
                                    .SetFont(font));
                                document.Add(new Paragraph($"Nội dung: {lastTransferViewData.TransactionDescription}")
                                    .SetFont(font));
                                document.Add(new Paragraph($"Phương thức: {(lastIsEmployee ? "Tại quầy" : "Trực tuyến")}")
                                    .SetFont(font));
                                document.Add(new Paragraph($"Người xử lý: {(lastIsEmployee ? currentEmployee?.EmployeeName : "Tự động")}")
                                    .SetFont(font));

                                document.Add(new Paragraph("---------------------------------------------")
                                    .SetTextAlignment(TextAlignment.CENTER)
                                    .SetFont(font));

                                document.Add(new Paragraph("Cảm ơn quý khách đã sử dụng dịch vụ của Sacombank!")
                                    .SetTextAlignment(TextAlignment.CENTER)
                                    .SetFont(font)
                                    .SetFontSize(12));

                                document.Close();
                            }
                        }

                        MessageBox.Show($"Hóa đơn đã được xuất thành công tại: {pdfPath}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    if (receiverAccount.AccountCode == currentAccount.AccountCode)
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

                    // [Load thông tin người nhận (Receiver)]
                    // Truy vấn thông tin Phone và CitizenID từ bảng CUSTOMER dựa trên CustomerID của receiverAccount
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

                    // Gán thông tin người nhận lên giao diện
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