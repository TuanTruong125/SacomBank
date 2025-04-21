using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Views.Common;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Pay;
using QuanLyThongTinKhachHangSacomBank.Views.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThongTinKhachHangSacomBank.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Policy;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class PayController
    {
        public event EventHandler TransactionCompleted;

        private IPayView payView;
        private UserControl activeUC;
        private readonly AccountModel currentAccount;
        private AccountModel senderAccount;
        private readonly EmployeeModel currentEmployee;
        private readonly DatabaseContext dbContext;
        private readonly IConfiguration configuration;
        private readonly ICustomerHomeView customerHomeView; // Thêm biến để lưu ICustomerHomeView
        private bool isTransactionSuccessful; // Thêm biến để đánh dấu giao dịch thành công
        private IPayViewData lastPayViewData; // Lưu thông tin giao dịch để xuất PDF
        private bool lastIsEmployee; // Lưu trạng thái giao dịch (nhân viên hay khách hàng)

        public PayController(AccountModel account, EmployeeModel employee, DatabaseContext dbContext, IConfiguration configuration, ICustomerHomeView customerHomeView)
        {
            activeUC = null;
            this.currentAccount = account;
            this.currentEmployee = employee;
            this.dbContext = dbContext;
            this.configuration = configuration;
            this.customerHomeView = customerHomeView; // Gán ICustomerHomeView
            this.isTransactionSuccessful = false; // Khởi tạo giá trị mặc định
        }

        public void OpenPay(UserControl payUC, bool isEmployee = false)
        {
            try
            {
                payView = new FormPay();
                activeUC = payUC;

                if (activeUC is IPayViewData payViewData)
                {
                    // Nếu không phải nhân viên, load thông tin khách hàng từ currentAccount
                    if (!isEmployee)
                    {
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

                        payViewData.SetSenderInfo(currentAccount, senderPhone, senderCitizenID);
                        senderAccount = currentAccount; // Gán senderAccount cho trường hợp khách hàng
                    }

                    payViewData.ConfirmRequested += (s, e) => HandleConfirm(isEmployee);
                    payViewData.CancelRequested += (s, e) => HandleCancel();
                    payViewData.SenderAccountIDLostFocus += (s, e) => HandleSenderAccountIDLostFocus(payViewData);
                    payViewData.PayLoanIDLostFocus += (s, e) => HandlePayLoanIDLostFocus(payViewData);
                }

                // Đăng ký sự kiện FormClosing để cập nhật số dư khi form đóng
                payView.FormClosing += (s, e) =>
                {
                    if (isTransactionSuccessful && !isEmployee)
                    {
                        customerHomeView?.SetBalance(senderAccount.Balance.ToString("#,##0") + " VND");
                    }
                };

                payView.LoadUserControl(payUC);
                payView.ShowForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong PayController.OpenPay: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleSenderAccountIDLostFocus(IPayViewData payViewData)
        {
            try
            {
                string senderAccountID = payViewData.AccountID;
                if (!string.IsNullOrWhiteSpace(senderAccountID))
                {
                    senderAccount = GetAccountByCode(senderAccountID);
                    if (senderAccount == null)
                    {
                        payViewData.ShowError("Tài khoản không tồn tại!");
                        payViewData.SetSenderInfo(null, "", "");
                        return;
                    }

                    if (senderAccount.AccountStatus == "Khóa")
                    {
                        payViewData.ShowError("Tài khoản đang bị khóa!");
                        payViewData.SetSenderInfo(null, "", "");
                        return;
                    }

                    if (senderAccount.AccountStatus == "Đóng")
                    {
                        payViewData.ShowError("Tài khoản đã bị đóng!");
                        payViewData.SetSenderInfo(null, "", "");
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

                    payViewData.SetSenderInfo(senderAccount, senderPhone, senderCitizenID);
                    payViewData.HideError();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kiểm tra tài khoản: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandlePayLoanIDLostFocus(IPayViewData payViewData)
        {
            try
            {
                string payLoanID = payViewData.PayLoanID;
                if (!string.IsNullOrWhiteSpace(payLoanID))
                {
                    using (var connection = dbContext.GetConnection())
                    {
                        connection.Open();

                        // Bước 1: Lấy ServiceID từ LOAN_PAYMENT
                        int serviceID;
                        decimal remainingDebt;
                        decimal totalDue;
                        string paymentStatus;
                        using (var command = new SqlCommand("SELECT ServiceID, RemainingDebt, TotalDue, PaymentStatus FROM LOAN_PAYMENT WHERE PayLoanCode = @PayLoanCode", connection))
                        {
                            command.Parameters.AddWithValue("@PayLoanCode", payLoanID);
                            using (var reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    serviceID = reader.GetInt32("ServiceID");
                                    remainingDebt = reader.GetDecimal("RemainingDebt");
                                    totalDue = reader.GetDecimal("TotalDue");
                                    paymentStatus = reader["PaymentStatus"]?.ToString();
                                }
                                else
                                {
                                    payViewData.ShowError("Mã thanh toán không tồn tại!");
                                    payViewData.ServiceID = "";
                                    payViewData.RemainingDebt = "";
                                    payViewData.Amount = "";
                                    payViewData.TransactionDescription = "";
                                    return;
                                }
                            }
                        }

                        // Bước 2: Lấy CustomerID từ SERVICE
                        int serviceCustomerID;
                        using (var command = new SqlCommand("SELECT CustomerID FROM SERVICE WHERE ServiceID = @ServiceID", connection))
                        {
                            command.Parameters.AddWithValue("@ServiceID", serviceID);
                            var result = command.ExecuteScalar();
                            if (result == null)
                            {
                                payViewData.ShowError("Không tìm thấy thông tin dịch vụ liên quan đến mã thanh toán!");
                                payViewData.ServiceID = "";
                                payViewData.RemainingDebt = "";
                                payViewData.Amount = "";
                                payViewData.TransactionDescription = "";
                                return;
                            }
                            serviceCustomerID = (int)result;
                        }

                        // Bước 3: Kiểm tra xem mã thanh toán có thuộc về tài khoản người gửi hay không
                        // Nếu là nhân viên, cần kiểm tra senderAccount thay vì currentAccount
                        if (senderAccount == null)
                        {
                            // Nếu senderAccount chưa được gán, lấy từ payViewData.AccountID
                            string senderAccountID = payViewData.AccountID;
                            if (string.IsNullOrWhiteSpace(senderAccountID))
                            {
                                payViewData.ShowError("Vui lòng nhập mã tài khoản trước khi nhập mã thanh toán!");
                                payViewData.ServiceID = "";
                                payViewData.RemainingDebt = "";
                                payViewData.Amount = "";
                                payViewData.TransactionDescription = "";
                                return;
                            }

                            senderAccount = GetAccountByCode(senderAccountID);
                            if (senderAccount == null)
                            {
                                payViewData.ShowError("Tài khoản không tồn tại!");
                                payViewData.ServiceID = "";
                                payViewData.RemainingDebt = "";
                                payViewData.Amount = "";
                                payViewData.TransactionDescription = "";
                                return;
                            }
                        }

                        // So sánh CustomerID từ SERVICE với CustomerID của senderAccount
                        if (serviceCustomerID != senderAccount.CustomerID)
                        {
                            payViewData.ShowError("Mã thanh toán không thuộc về tài khoản này! Không thể thanh toán khoản vay này.");
                            payViewData.ServiceID = "";
                            payViewData.RemainingDebt = "";
                            payViewData.Amount = "";
                            payViewData.TransactionDescription = "";
                            return;
                        }

                        // Bước 4: Kiểm tra trạng thái thanh toán
                        if (paymentStatus != "Chưa thanh toán")
                        {
                            payViewData.ShowError("Mã thanh toán không ở trạng thái 'Chưa thanh toán'!");
                            payViewData.ServiceID = "";
                            payViewData.RemainingDebt = "";
                            payViewData.Amount = "";
                            payViewData.TransactionDescription = "";
                            return;
                        }

                        // Bước 5: Lấy ServiceCode và Duration từ bảng SERVICE
                        string serviceCode = "";
                        string durationStr;
                        using (var command = new SqlCommand("SELECT ServiceCode, Duration FROM SERVICE WHERE ServiceID = @ServiceID", connection))
                        {
                            command.Parameters.AddWithValue("@ServiceID", serviceID);
                            using (var reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    serviceCode = reader.GetString("ServiceCode");
                                    durationStr = reader.GetString("Duration");
                                }
                                else
                                {
                                    payViewData.ShowError("Không tìm thấy thông tin dịch vụ!");
                                    payViewData.ServiceID = "";
                                    payViewData.RemainingDebt = "";
                                    payViewData.Amount = "";
                                    payViewData.TransactionDescription = "";
                                    return;
                                }
                            }
                        }

                        // Chuyển Duration từ chuỗi sang số nguyên
                        string durationNumberStr = durationStr.Replace(" tháng", "").Trim();
                        if (!int.TryParse(durationNumberStr, out int duration))
                        {
                            payViewData.ShowError("Kỳ hạn dịch vụ không hợp lệ!");
                            payViewData.ServiceID = "";
                            payViewData.RemainingDebt = "";
                            payViewData.Amount = "";
                            payViewData.TransactionDescription = "";
                            return;
                        }

                        // Bước 6: Đếm số lần đã thanh toán cho ServiceID này
                        int paidCount;
                        using (var command = new SqlCommand("SELECT COUNT(*) FROM LOAN_PAYMENT WHERE ServiceID = @ServiceID AND PaymentStatus = @PaymentStatus", connection))
                        {
                            command.Parameters.AddWithValue("@ServiceID", serviceID);
                            command.Parameters.AddWithValue("@PaymentStatus", "Đã thanh toán");
                            paidCount = (int)command.ExecuteScalar();
                        }

                        // Kiểm tra nếu đã thanh toán đủ số lần theo Duration
                        if (paidCount >= duration)
                        {
                            payViewData.ShowError($"Dịch vụ {serviceCode} đã thanh toán đủ {duration} lần theo kỳ hạn. Không thể thanh toán thêm!");
                            payViewData.ServiceID = "";
                            payViewData.RemainingDebt = "";
                            payViewData.Amount = "";
                            payViewData.TransactionDescription = "";
                            return;
                        }

                        // Lần thanh toán hiện tại sẽ là paidCount + 1
                        int currentPaymentNumber = paidCount + 1;

                        // Gán các giá trị vào giao diện
                        payViewData.ServiceID = serviceCode;
                        payViewData.RemainingDebt = remainingDebt.ToString("N0") + " VND";
                        payViewData.Amount = totalDue.ToString("N0");
                        payViewData.TransactionDescription = $"{payViewData.AccountName} thanh toan khoan vay lan thu {currentPaymentNumber} cho dich vu {serviceCode}";

                        payViewData.HideError();
                    }
                }
                else
                {
                    payViewData.ShowError("Vui lòng nhập mã thanh toán!");
                    payViewData.ServiceID = "";
                    payViewData.RemainingDebt = "";
                    payViewData.Amount = "";
                    payViewData.TransactionDescription = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kiểm tra mã thanh toán: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleConfirm(bool isEmployee)
        {
            try
            {
                if (activeUC is IPayViewData payViewData)
                {
                    // Kiểm tra nếu có ô nào bị trống
                    if (string.IsNullOrWhiteSpace(payViewData.AccountName) ||
                        string.IsNullOrWhiteSpace(payViewData.AccountID) ||
                        string.IsNullOrWhiteSpace(payViewData.Phone) ||
                        string.IsNullOrWhiteSpace(payViewData.CitizenID) ||
                        string.IsNullOrWhiteSpace(payViewData.Balance) ||
                        string.IsNullOrWhiteSpace(payViewData.PayLoanID) ||
                        string.IsNullOrWhiteSpace(payViewData.ServiceID) ||
                        string.IsNullOrWhiteSpace(payViewData.RemainingDebt) ||
                        string.IsNullOrWhiteSpace(payViewData.Amount) ||
                        string.IsNullOrWhiteSpace(payViewData.TransactionDescription))
                    {
                        payViewData.ShowError("Vui lòng nhập đầy đủ thông tin!");
                        return;
                    }

                    if (senderAccount == null)
                    {
                        senderAccount = GetAccountByCode(payViewData.AccountID);
                        if (senderAccount == null)
                        {
                            payViewData.ShowError("Tài khoản không tồn tại!");
                            return;
                        }
                    }

                    if (senderAccount.AccountStatus == "Khóa")
                    {
                        payViewData.ShowError("Tài khoản đang bị khóa!");
                        return;
                    }

                    if (senderAccount.AccountStatus == "Đóng")
                    {
                        payViewData.ShowError("Tài khoản đã bị đóng!");
                        return;
                    }

                    string payLoanID = payViewData.PayLoanID;
                    decimal totalDue = 0;
                    decimal remainingDebt = 0;
                    int serviceID;
                    using (var connection = dbContext.GetConnection())
                    {
                        connection.Open();
                        // Lấy thông tin từ LOAN_PAYMENT, bao gồm ServiceID
                        using (var command = new SqlCommand("SELECT ServiceID, TotalDue, RemainingDebt FROM LOAN_PAYMENT WHERE PayLoanCode = @PayLoanCode", connection))
                        {
                            command.Parameters.AddWithValue("@PayLoanCode", payLoanID);
                            using (var reader = command.ExecuteReader())
                            {
                                if (!reader.Read())
                                {
                                    payViewData.ShowError("Mã thanh toán không tồn tại!");
                                    return;
                                }
                                serviceID = reader.GetInt32("ServiceID");
                                totalDue = reader.GetDecimal("TotalDue");
                                remainingDebt = reader.GetDecimal("RemainingDebt");
                            }
                        }

                        // Kiểm tra xem mã thanh toán có thuộc về tài khoản người gửi hay không
                        int serviceCustomerID;
                        using (var command = new SqlCommand("SELECT CustomerID FROM SERVICE WHERE ServiceID = @ServiceID", connection))
                        {
                            command.Parameters.AddWithValue("@ServiceID", serviceID);
                            var result = command.ExecuteScalar();
                            if (result == null)
                            {
                                payViewData.ShowError("Không tìm thấy thông tin dịch vụ liên quan đến mã thanh toán!");
                                return;
                            }
                            serviceCustomerID = (int)result;
                        }

                        // So sánh CustomerID từ SERVICE với CustomerID của senderAccount
                        if (serviceCustomerID != senderAccount.CustomerID)
                        {
                            payViewData.ShowError("Mã thanh toán không thuộc về tài khoản này! Không thể thanh toán khoản vay này.");
                            return;
                        }
                    }

                    decimal amount = decimal.Parse(payViewData.Amount);

                    // Kiểm tra xem amount có khớp với TotalDue hay không
                    if (amount != totalDue)
                    {
                        payViewData.ShowError($"Số tiền thanh toán ({amount.ToString("N0")} VND) không khớp với số tiền phải trả ({totalDue.ToString("N0")} VND)!");
                        return;
                    }

                    if (amount > senderAccount.Balance)
                    {
                        payViewData.ShowError("Số dư không đủ để thực hiện thanh toán!");
                        return;
                    }

                    payViewData.HideError();

                    // Xác nhận giao dịch
                    bool isVerified = false;

                    if (isEmployee)
                    {
                        FormOTP formOTP = new FormOTP();
                        var otpController = new OTPController(formOTP, formOTP, new PayOTPControllerAdapter(senderAccount, dbContext), configuration);
                        if (formOTP.ShowDialog() == DialogResult.OK)
                        {
                            isVerified = true;
                        }
                    }
                    else
                    {
                        FormPINCode formPINCode = new FormPINCode(senderAccount);
                        var pinController = new PINCodeController(formPINCode, formPINCode, senderAccount);
                        if (formPINCode.ShowDialog() == DialogResult.OK)
                        {
                            isVerified = true;
                        }
                    }

                    if (isVerified)
                    {
                        // Thực hiện giao dịch và lưu vào cơ sở dữ liệu
                        string transactionCode = SaveTransaction(payViewData, isEmployee, remainingDebt);
                        payViewData.TransactionCode = transactionCode;

                        // Lưu thông tin giao dịch để xuất PDF
                        lastPayViewData = payViewData;
                        lastIsEmployee = isEmployee;

                        isTransactionSuccessful = true;

                        if (customerHomeView != null && !isEmployee)
                        {
                            customerHomeView.SetBalance(senderAccount.Balance.ToString("#,##0") + " VND");
                        }

                        // Tạo UC_SuccessfulPay và hiển thị thông tin giao dịch
                        var successfulPayView = new UC_SuccessfulPay();
                        SetupSuccessfulPay(successfulPayView, payViewData, isEmployee, remainingDebt);

                        activeUC = successfulPayView;
                        payView.LoadUserControl(activeUC);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xác nhận thanh toán: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string SaveTransaction(IPayViewData payViewData, bool isEmployee, decimal remainingDebtFromCaller)
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
                            command.Parameters.AddWithValue("@TransactionTypeName", "Thanh toán khoản vay");
                            var result = command.ExecuteScalar();
                            if (result == null)
                            {
                                throw new Exception("Không tìm thấy TransactionTypeID cho 'Thanh toán khoản vay'.");
                            }
                            transactionTypeID = (int)result;
                        }

                        // Thêm giao dịch và lấy TransactionID
                        int newTransactionId;
                        decimal amount;
                        if (!decimal.TryParse(payViewData.Amount, out amount))
                        {
                            throw new Exception("Số tiền không hợp lệ!");
                        }
                        using (var command = new SqlCommand(
                            "INSERT INTO [TRANSACTION] (Amount, TransactionDate, TransactionStatus, HandledBy, TransactionDescription, TransactionMethod, AccountID, TransactionTypeID) " +
                            "OUTPUT INSERTED.TransactionID " +
                            "VALUES (@Amount, @TransactionDate, @TransactionStatus, @HandledBy, @TransactionDescription, @TransactionMethod, @AccountID, @TransactionTypeID)", connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Amount", amount);
                            command.Parameters.AddWithValue("@TransactionDate", DateTime.Now);
                            command.Parameters.AddWithValue("@TransactionStatus", "Hoàn tất");
                            command.Parameters.AddWithValue("@HandledBy", isEmployee ? (object)currentEmployee.EmployeeID : DBNull.Value);
                            command.Parameters.AddWithValue("@TransactionDescription", payViewData.TransactionDescription);
                            command.Parameters.AddWithValue("@TransactionMethod", isEmployee ? "Tại quầy" : "Trực tuyến");
                            command.Parameters.AddWithValue("@AccountID", senderAccount.AccountID); // Sửa lỗi đánh máy
                            command.Parameters.AddWithValue("@TransactionTypeID", transactionTypeID);
                            newTransactionId = (int)command.ExecuteScalar();
                        }

                        // Lấy TransactionCode
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

                        // Cập nhật số dư tài khoản
                        using (var command = new SqlCommand("UPDATE ACCOUNT SET Balance = Balance - @Amount WHERE AccountID = @AccountID", connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Amount", amount);
                            command.Parameters.AddWithValue("@AccountID", senderAccount.AccountID);
                            command.ExecuteNonQuery();
                        }

                        // Kiểm tra lại PaymentStatus và lấy thông tin RemainingDebt, PrincipalDue
                        string paymentStatus;
                        decimal remainingDebt;
                        decimal principalDue;
                        using (var command = new SqlCommand(
                            "SELECT PaymentStatus, RemainingDebt, PrincipalDue FROM LOAN_PAYMENT WITH (UPDLOCK) WHERE PayLoanCode = @PayLoanCode",
                            connection, transaction))
                        {
                            command.Parameters.AddWithValue("@PayLoanCode", payViewData.PayLoanID);
                            using (var reader = command.ExecuteReader())
                            {
                                if (!reader.Read())
                                {
                                    throw new Exception("Mã thanh toán không tồn tại!");
                                }
                                paymentStatus = reader["PaymentStatus"].ToString();
                                remainingDebt = reader.GetDecimal("RemainingDebt");
                                principalDue = reader.GetDecimal("PrincipalDue");
                            }
                        }

                        // Kiểm tra trạng thái thanh toán
                        string pendingStatus = "Chưa thanh toán";
                        string paidStatus = "Đã thanh toán";
                        if (paymentStatus != pendingStatus)
                        {
                            throw new Exception($"Mã thanh toán không ở trạng thái '{pendingStatus}'!");
                        }

                        // So sánh RemainingDebt với giá trị từ HandleConfirm để đảm bảo dữ liệu không bị thay đổi
                        if (remainingDebt != remainingDebtFromCaller)
                        {
                            throw new Exception("Dữ liệu khoản vay đã thay đổi! Vui lòng thử lại.");
                        }

                        // Tính toán số nợ còn lại: chỉ trừ PrincipalDue
                        decimal newRemainingDebt = remainingDebt - principalDue;

                        // Kiểm tra nếu newRemainingDebt hoặc newPrincipalDue âm
                        if (newRemainingDebt < 0)
                        {
                            throw new Exception($"Số nợ còn lại không thể âm! Số tiền thanh toán ({amount.ToString("N0")} VND) lớn hơn số nợ còn lại ({remainingDebt.ToString("N0")} VND).");
                        }

                        using (var command = new SqlCommand(
                            "UPDATE LOAN_PAYMENT SET PaymentStatus = @PaymentStatus, RemainingDebt = @RemainingDebt WHERE PayLoanCode = @PayLoanCode",
                            connection, transaction))
                        {
                            command.Parameters.AddWithValue("@PayLoanCode", payViewData.PayLoanID);
                            command.Parameters.AddWithValue("@PaymentStatus", paidStatus);
                            command.Parameters.AddWithValue("@RemainingDebt", newRemainingDebt);
                            command.ExecuteNonQuery();
                        }

                        // Cập nhật số dư trong đối tượng senderAccount
                        senderAccount.Balance -= amount;

                        // Cập nhật DataGridView trên UC_CustomerHome
                        if (customerHomeView != null && !isEmployee)
                        {
                            customerHomeView.UpdateServiceNotificationRow(
                                payViewData.PayLoanID,
                                paidStatus,
                                newRemainingDebt.ToString("N0") + " VND"
                            );
                        }

                        
                        transaction.Commit();
                        TransactionCompleted?.Invoke(this, EventArgs.Empty); // Gọi sự kiện Load lại DataGridView Nhân Viên
                        return transactionCode;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Lỗi khi lưu giao dịch: " + ex.Message);
                    }
                }
            }
        }

        private void SetupSuccessfulPay(ISuccessfulPayView view, IPayViewData payViewData, bool isEmployee, decimal remainingDebt)
        {
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

            // Lấy RemainingDebt đã được cập nhật từ cơ sở dữ liệu sau giao dịch
            decimal newRemainingDebt;
            using (var connection = dbContext.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT RemainingDebt FROM LOAN_PAYMENT WHERE PayLoanCode = @PayLoanCode", connection))
                {
                    command.Parameters.AddWithValue("@PayLoanCode", payViewData.PayLoanID);
                    newRemainingDebt = (decimal)command.ExecuteScalar();
                }
            }

            view.CustomerName = senderFullname;
            view.CustomerAccountID = senderAccount.AccountCode;
            view.AccountBalance = senderAccount.Balance.ToString("#,##0") + " VND";
            view.Amount = decimal.Parse(payViewData.Amount).ToString("#,##0") + " VND";
            view.PayLoanID = payViewData.PayLoanID;
            view.ServiceID = payViewData.ServiceID;
            view.CustomerRemainingDebt = newRemainingDebt.ToString("#,##0") + " VND";
            view.TransactionDescription = payViewData.TransactionDescription;
            view.TransactionDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            view.EmployeeName = isEmployee ? currentEmployee?.EmployeeName : "Tự động";

            view.DoneClicked += (s, e) => payView.FindForm()?.Close();
            view.InvoiceClicked += (s, e) => ExportToPDF();
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
                MessageBox.Show($"Lỗi khi hủy thanh toán: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ExportToPDF()
        {
            try
            {
                if (lastPayViewData == null)
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

                string formattedAmount = decimal.Parse(lastPayViewData.Amount).ToString("#,##0") + " VND";

                // Lấy RemainingDebt từ cơ sở dữ liệu sau giao dịch
                decimal newRemainingDebt;
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand("SELECT RemainingDebt FROM LOAN_PAYMENT WHERE PayLoanCode = @PayLoanCode", connection))
                    {
                        command.Parameters.AddWithValue("@PayLoanCode", lastPayViewData.PayLoanID);
                        newRemainingDebt = (decimal)command.ExecuteScalar();
                    }
                }

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                    saveFileDialog.Title = "Chọn nơi lưu hóa đơn giao dịch";
                    saveFileDialog.FileName = $"PaymentReceipt_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

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

                                document.Add(new Paragraph("HÓA ĐƠN THANH TOÁN KHOẢN VAY", subHeaderFont)
                                {
                                    Alignment = Element.ALIGN_LEFT
                                });

                                document.Add(new Paragraph($"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}", font)
                                {
                                    Alignment = Element.ALIGN_LEFT
                                });

                                document.Add(new Paragraph($"Mã giao dịch: {lastPayViewData.TransactionCode}", font)
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

                                // Dòng 1: Thông tin khách hàng
                                table.AddCell(new PdfPCell(new Phrase("1", font)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5f });
                                table.AddCell(new PdfPCell(new Phrase("Thông tin khách hàng", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5f });
                                PdfPTable subTableSender = new PdfPTable(new float[] { 1, 2 });
                                subTableSender.WidthPercentage = 100;
                                subTableSender.DefaultCell.Border = PdfPCell.NO_BORDER;
                                subTableSender.AddCell(new PdfPCell(new Phrase("Khách hàng", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableSender.AddCell(new PdfPCell(new Phrase(senderFullname, boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableSender.AddCell(new PdfPCell(new Phrase("Mã tài khoản", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableSender.AddCell(new PdfPCell(new Phrase(senderAccount.AccountCode, boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableSender.AddCell(new PdfPCell(new Phrase("Số dư sau giao dịch", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableSender.AddCell(new PdfPCell(new Phrase(senderAccount.Balance.ToString("#,##0") + " VND", boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                table.AddCell(new PdfPCell(subTableSender) { Border = PdfPCell.BOX, Padding = 5f });

                                // Dòng 2: Thông tin dịch vụ
                                table.AddCell(new PdfPCell(new Phrase("2", font)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5f });
                                table.AddCell(new PdfPCell(new Phrase("Thông tin dịch vụ", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5f });
                                PdfPTable subTableService = new PdfPTable(new float[] { 1, 2 });
                                subTableService.WidthPercentage = 100;
                                subTableService.DefaultCell.Border = PdfPCell.NO_BORDER;
                                subTableService.AddCell(new PdfPCell(new Phrase("Mã dịch vụ", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableService.AddCell(new PdfPCell(new Phrase(lastPayViewData.ServiceID, boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableService.AddCell(new PdfPCell(new Phrase("Mã thanh toán", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableService.AddCell(new PdfPCell(new Phrase(lastPayViewData.PayLoanID, boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableService.AddCell(new PdfPCell(new Phrase("Số nợ còn lại", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableService.AddCell(new PdfPCell(new Phrase(newRemainingDebt.ToString("#,##0") + " VND", boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                table.AddCell(new PdfPCell(subTableService) { Border = PdfPCell.BOX, Padding = 5f });

                                // Dòng 3: Thông tin giao dịch
                                table.AddCell(new PdfPCell(new Phrase("3", font)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5f });
                                table.AddCell(new PdfPCell(new Phrase("Thông tin giao dịch", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5f });
                                PdfPTable subTableTransaction = new PdfPTable(new float[] { 1, 2 });
                                subTableTransaction.WidthPercentage = 100;
                                subTableTransaction.DefaultCell.Border = PdfPCell.NO_BORDER;
                                subTableTransaction.AddCell(new PdfPCell(new Phrase("Số tiền", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableTransaction.AddCell(new PdfPCell(new Phrase(formattedAmount, boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableTransaction.AddCell(new PdfPCell(new Phrase("Nội dung", font)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
                                subTableTransaction.AddCell(new PdfPCell(new Phrase(lastPayViewData.TransactionDescription, boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2f });
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
    }

    class PayOTPControllerAdapter : IOTPController
    {
        private readonly AccountModel account;
        private readonly DatabaseContext dbContext;

        public PayOTPControllerAdapter(AccountModel account, DatabaseContext dbContext)
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
