using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Views.Common;
using QuanLyThongTinKhachHangSacomBank.Views.Customer;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class LoanApplicationController
    {
        private ILoanApplicationView view;
        private readonly AccountModel currentAccount;
        private readonly DatabaseContext dbContext;
        private readonly IConfiguration configuration;
        private int customerType;

        public LoanApplicationController(AccountModel currentAccount, DatabaseContext dbContext, IConfiguration configuration)
        {
            this.currentAccount = currentAccount;
            this.dbContext = dbContext;
            this.configuration = configuration;
        }

        public void OpenLoanApplication()
        {
            try
            {
                FormLoanApplication formLoanApplication = new FormLoanApplication();
                this.view = formLoanApplication;

                // Load thông tin khách hàng
                LoadCustomerInfo();

                // Đăng ký sự kiện
                view.SendRequestClicked += (s, e) => HandleSendRequest();
                view.CancelClicked += (s, e) => HandleCancel();

                formLoanApplication.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở FormLoanApplication: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCustomerInfo()
        {
            try
            {
                if (currentAccount == null)
                {
                    view.ShowError("Không tìm thấy thông tin khách hàng!");
                    return;
                }

                // Load thông tin từ currentAccount
                view.ShowError(""); // Ẩn lỗi nếu có
                view.AccountID = currentAccount.AccountCode;

                // Truy vấn SĐT và CCCD từ bảng CUSTOMER
                string phone = "";
                string citizenID = "";
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand("SELECT Phone, CitizenID, CustomerTypeID FROM CUSTOMER WHERE CustomerID = @CustomerID", connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", currentAccount.CustomerID);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                phone = reader["Phone"]?.ToString();
                                citizenID = reader["CitizenID"]?.ToString();
                                customerType = (int)reader["CustomerTypeID"];
                            }
                        }
                    }
                }

                view.Phone = phone;
                view.AccountName = currentAccount.AccountName;
                view.CitizenID = citizenID;

                // Đặt mặc định các giá trị khác
                view.ServiceTypeName = "Vay vốn";
                view.CreatedDate = DateTime.Now;

                // Cập nhật customerType cho view để dùng trong SetInterestRateBasedOnCustomerType
                ((FormLoanApplication)view).SetCustomerType(customerType);
            }
            catch (Exception ex)
            {
                view.ShowError($"Lỗi khi tải thông tin khách hàng: {ex.Message}");
            }
        }

        // Lấy loại khách hàng (cá nhân, doanh nghiệp, VIP cá nhân, VIP doanh nghiệp)
        private int GetCustomerType()
        {
            try
            {
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand("SELECT CustomerTypeID FROM CUSTOMER WHERE CustomerID = @CustomerID", connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", currentAccount.CustomerID);
                        var result = command.ExecuteScalar();
                        if (result != null)
                        {
                            return (int)result;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                view.ShowError($"Lỗi khi lấy loại khách hàng: {ex.Message}");
            }
            return -1; // Trả về -1 nếu có lỗi
        }

        // Lấy lãi suất dựa trên loại khách hàng
        private decimal GetInterestRate(int customerType)
        {
            switch (customerType)
            {
                case 1: // Cá nhân
                    return 0.06m; // 6%/năm
                case 2: // Doanh nghiệp
                    return 0.05m; // 5%/năm
                case 3: // VIP Cá nhân
                    return 0.05m; // 5%/năm
                case 4: // VIP Doanh nghiệp
                    return 0.04m; // 4%/năm
                default:
                    throw new Exception("Loại khách hàng không hợp lệ!");
            }
        }

        private void HandleSendRequest()
        {
            try
            {
                // Kiểm tra thông tin
                if (string.IsNullOrWhiteSpace(view.AccountName) ||
                    string.IsNullOrWhiteSpace(view.AccountID) ||
                    string.IsNullOrWhiteSpace(view.Phone) ||
                    string.IsNullOrWhiteSpace(view.CitizenID) ||
                    string.IsNullOrWhiteSpace(view.ServiceTypeName) ||
                    string.IsNullOrWhiteSpace(view.InterestRate) ||
                    string.IsNullOrWhiteSpace(view.Duration) ||
                    string.IsNullOrWhiteSpace(view.TotalPrincipalAmount) ||
                    string.IsNullOrWhiteSpace(view.ServiceDescription))
                {
                    view.ShowError("Vui lòng nhập đầy đủ thông tin!");
                    return;
                }

                // Kiểm tra số tiền vay dựa trên loại khách hàng
                decimal principalAmount = decimal.Parse(view.TotalPrincipalAmount.Replace(",", ""));
                int customerType = GetCustomerType();

                if (customerType == -1)
                {
                    view.ShowError("Không thể xác định loại khách hàng!");
                    return;
                }

                // Kiểm tra giới hạn số tiền vay
                switch (customerType)
                {
                    case 1: // Cá nhân
                        if (principalAmount < 5_000_000)
                        {
                            view.ShowError("Số tiền vay của tài khoản cá nhân phải từ 5.000.000 VND!");
                            return;
                        }
                        else if (principalAmount > 100_000_000)
                        {
                            view.ShowError("Số tiền vay của tài khoản cá nhân không được vượt quá 100.000.000 VND!");
                            return;
                        }
                        else
                        {
                            break;
                        }

                    case 2: // Doanh nghiệp
                        if (principalAmount < 50_000_000)
                        {
                            view.ShowError("Số tiền vay của tài khoản doanh nghiệp phải từ 50.000.000 VND!");
                            return;
                        }
                        else if (principalAmount > 5_000_000_000)
                        {
                            view.ShowError("Số tiền vay của tài khoản doanh nghiệp không được vượt quá 5.000.000.000 VND!");
                            return;
                        }
                        else
                        {
                            break;
                        }

                    case 3: // VIP Cá nhân
                        if (principalAmount < 5_000_000)
                        {
                            view.ShowError("Số tiền vay của tài khoản cá nhân phải từ 5.000.000 VND!");
                            return;
                        }
                        else if (principalAmount > 200_000_000)
                        {
                            view.ShowError("Số tiền vay của tài khoản VIP cá nhân không được vượt quá 200.000.000 VND!");
                            return;
                        }
                        else
                        {
                            break;
                        }

                    case 4: // VIP Doanh nghiệp
                        if (principalAmount < 50_000_000)
                        {
                            view.ShowError("Số tiền vay của tài khoản doanh nghiệp phải từ 50.000.000 VND!");
                            return;
                        }
                        else if (principalAmount > 10_000_000_000)
                        {
                            view.ShowError("Số tiền vay của tài khoản VIP doanh nghiệp không được vượt quá 10.000.000.000 VND!");
                            return;
                        }
                        else
                        {
                            break;
                        }

                    default:
                        view.ShowError("Loại khách hàng không hợp lệ!");
                        return;
                }

                view.HideError();

                // Xác nhận đăng ký vay vốn
                DialogResult result = MessageBox.Show("Xác nhận đăng ký vay vốn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Mở FormOTP để xác nhận
                    FormOTP formOTP = new FormOTP();
                    var otpController = new OTPController(formOTP, formOTP, new LoanOTPControllerAdapter(currentAccount, dbContext), configuration);
                    if (formOTP.ShowDialog() == DialogResult.OK)
                    {
                        // Lưu dữ liệu vào CSDL
                        SaveLoanApplication();

                        // Hiển thị thông báo mới sau khi xác thực OTP thành công
                        MessageBox.Show("Đã gửi yêu cầu vay vốn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form mainForm = (view as Form);
                        mainForm?.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi yêu cầu vay vốn: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveLoanApplication()
        {
            using (var connection = dbContext.GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Lấy ServiceTypeID cho "Vay vốn"
                        int serviceTypeID;
                        using (var command = new SqlCommand("SELECT ServiceTypeID FROM SERVICE_TYPE WHERE ServiceTypeName = @ServiceTypeName", connection, transaction))
                        {
                            command.Parameters.AddWithValue("@ServiceTypeName", "Vay vốn");
                            var result = command.ExecuteScalar();
                            if (result == null)
                            {
                                throw new Exception("Không tìm thấy ServiceTypeID cho 'Vay vốn'.");
                            }
                            serviceTypeID = (int)result;
                        }

                        // Lấy loại khách hàng và lãi suất
                        int customerType = GetCustomerType();
                        decimal interestRate = GetInterestRate(customerType);

                        // Tính TotalInterestAmount
                        decimal principalAmount = decimal.Parse(view.TotalPrincipalAmount.Replace(",", ""));
                        string durationText = view.Duration; // Ví dụ: "12 tháng"
                        int durationInMonths = int.Parse(durationText.Split(' ')[0]); // Lấy "12" từ "12 tháng"
                        decimal totalInterestAmount = principalAmount * interestRate * (durationInMonths / 12m);

                        // Thêm dữ liệu vào bảng SERVICE
                        using (var command = new SqlCommand(
                            "INSERT INTO [SERVICE] (TotalPrincipalAmount, Duration, InterestRate, TotalInterestAmount, ServiceDescription, CreatedDate, ApprovalStatus, ServiceStatus, CustomerID, AccountID, ServiceTypeID) " +
                            "VALUES (@TotalPrincipalAmount, @Duration, @InterestRate, @TotalInterestAmount, @ServiceDescription, @CreatedDate, @ApprovalStatus, @ServiceStatus, @CustomerID, @AccountID, @ServiceTypeID)", connection, transaction))
                        {
                            command.Parameters.AddWithValue("@TotalPrincipalAmount", principalAmount);
                            command.Parameters.AddWithValue("@Duration", view.Duration);
                            command.Parameters.AddWithValue("@InterestRate", interestRate * 100); // Lưu dưới dạng phần trăm (ví dụ: 0.06 -> 6)
                            command.Parameters.AddWithValue("@TotalInterestAmount", totalInterestAmount);
                            command.Parameters.AddWithValue("@ServiceDescription", view.ServiceDescription);
                            command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                            command.Parameters.AddWithValue("@ApprovalStatus", "Chờ duyệt"); // Loại bỏ khoảng trắng thừa
                            command.Parameters.AddWithValue("@ServiceStatus", "Chờ hoạt động"); // Loại bỏ khoảng trắng thừa
                            command.Parameters.AddWithValue("@CustomerID", currentAccount.CustomerID);
                            command.Parameters.AddWithValue("@AccountID", currentAccount.AccountID);
                            command.Parameters.AddWithValue("@ServiceTypeID", serviceTypeID);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"Lỗi khi lưu yêu cầu vay vốn: {ex.Message}");
                    }
                }
            }
        }

        private void HandleCancel()
        {
            try
            {
                Form mainForm = (view as Form);
                mainForm?.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hủy yêu cầu vay vốn: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    class LoanOTPControllerAdapter : IOTPController
    {
        private readonly AccountModel account;
        private readonly DatabaseContext dbContext;

        public LoanOTPControllerAdapter(AccountModel account, DatabaseContext dbContext)
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