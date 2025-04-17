using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Views.Common;
using QuanLyThongTinKhachHangSacomBank.Views.Customer;
using System;
using System.Windows.Forms;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class OpenSavingsController
    {
        private IOpenSavingsView view;
        private readonly AccountModel currentAccount;
        private readonly DatabaseContext dbContext;
        private readonly IConfiguration configuration;
        private int customerType;

        public OpenSavingsController(AccountModel currentAccount, DatabaseContext dbContext, IConfiguration configuration)
        {
            this.currentAccount = currentAccount;
            this.dbContext = dbContext;
            this.configuration = configuration;
        }

        public void OpenOpenSavings()
        {
            try
            {
                FormOpenSavings formOpenSavings = new FormOpenSavings();
                this.view = formOpenSavings;

                // Load thông tin khách hàng
                LoadCustomerInfo();

                // Đăng ký sự kiện
                view.SendRequestClicked += (s, e) => HandleSendRequest();
                view.CancelClicked += (s, e) => HandleCancel();

                formOpenSavings.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở FormOpenSavings: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                view.ServiceTypeName = "Gửi tiết kiệm";
                view.CreatedDate = DateTime.Now;

                // Cập nhật customerType cho view để dùng trong SetInterestRateBasedOnCustomerType
                ((FormOpenSavings)view).SetCustomerType(customerType);
            }
            catch (Exception ex)
            {
                view.ShowError($"Lỗi khi tải thông tin khách hàng: {ex.Message}");
            }
        }

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

        private decimal GetInterestRate(int customerType, string duration)
        {
            int months = int.Parse(duration.Split(' ')[0]); // Lấy số tháng từ "12 tháng", "24 tháng", "36 tháng"
            switch (customerType)
            {
                case 1: // Cá nhân thường
                    switch (months)
                    {
                        case 12: return 0.0527m; // 5.27%/năm
                        case 24: return 0.0541m; // 5.41%/năm
                        case 36: return 0.0527m; // 5.27%/năm
                        default: return 0m;
                    }
                case 3: // VIP Cá nhân
                    switch (months)
                    {
                        case 12: return 0.054m;   // 5.4%/năm
                        case 24: return 0.057m;   // 5.7%/năm
                        case 36: return 0.057m;   // 5.7%/năm
                        default: return 0m;
                    }
                case 2: // Doanh nghiệp
                case 4: // VIP Doanh nghiệp
                    return 0m; // Không hỗ trợ gửi tiết kiệm cho doanh nghiệp (đã vô hiệu hóa nút ở UC_CustomerService)
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

                // Kiểm tra số tiền gửi dựa trên loại khách hàng
                decimal principalAmount = decimal.Parse(view.TotalPrincipalAmount.Replace(",", ""));
                int customerType = GetCustomerType();

                if (customerType == -1)
                {
                    view.ShowError("Không thể xác định loại khách hàng!");
                    return;
                }

                // Kiểm tra giới hạn số tiền gửi
                switch (customerType)
                {
                    case 1: // Cá nhân
                        if (principalAmount < 1_000_000)
                        {
                            view.ShowError("Số tiền gửi của tài khoản cá nhân phải từ 1.000.000 VND!");
                            return;
                        }
                        else if (principalAmount > 20_000_000_000)
                        {
                            view.ShowError("Số tiền gửi của tài khoản cá nhân không được vượt quá 20.000.000.000 VND!");
                            return;
                        }
                        else
                        {
                            break;
                        }    
                    case 3: // VIP Cá nhân
                        if (principalAmount < 1_000_000)
                        {
                            view.ShowError("Số tiền gửi của tài khoản cá nhân phải từ 1.000.000 VND!");
                            return;
                        }
                        else if (principalAmount > 30_000_000_000)
                        {
                            view.ShowError("Số tiền gửi của tài khoản VIP cá nhân không được vượt quá 30.000.000.000 VND!");
                            return;
                        }
                        else
                        {
                            break;
                        }
                    case 2: // Doanh nghiệp
                    case 4: // VIP Doanh nghiệp
                        view.ShowError("Loại khách hàng này không được phép gửi tiết kiệm!");
                        return;
                    default:
                        view.ShowError("Loại khách hàng không hợp lệ!");
                        return;
                }

                // Kiểm tra số dư tài khoản
                if (principalAmount > currentAccount.Balance)
                {
                    view.ShowError("Số dư không đủ để gửi tiết kiệm!");
                    return;
                }

                view.HideError();

                // Xác nhận đăng ký gửi tiết kiệm
                DialogResult result = MessageBox.Show("Xác nhận đăng ký gửi tiết kiệm?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Mở FormOTP để xác nhận
                    FormOTP formOTP = new FormOTP();
                    var otpController = new OTPController(formOTP, formOTP, new SavingsOTPControllerAdapter(currentAccount, dbContext), configuration);
                    if (formOTP.ShowDialog() == DialogResult.OK)
                    {
                        // Lưu dữ liệu vào CSDL
                        SaveSavingsApplication();

                        // Hiển thị thông báo sau khi xác thực OTP thành công
                        MessageBox.Show("Đã gửi yêu cầu gửi tiết kiệm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form mainForm = (view as Form);
                        mainForm?.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi yêu cầu gửi tiết kiệm: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveSavingsApplication()
        {
            using (var connection = dbContext.GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Lấy ServiceTypeID cho "Gửi tiết kiệm"
                        int serviceTypeID;
                        using (var command = new SqlCommand("SELECT ServiceTypeID FROM SERVICE_TYPE WHERE ServiceTypeName = @ServiceTypeName", connection, transaction))
                        {
                            command.Parameters.AddWithValue("@ServiceTypeName", "Gửi tiết kiệm");
                            var result = command.ExecuteScalar();
                            if (result == null)
                            {
                                throw new Exception("Không tìm thấy ServiceTypeID cho 'Gửi tiết kiệm'.");
                            }
                            serviceTypeID = (int)result;
                        }

                        // Lấy loại khách hàng và lãi suất
                        int customerType = GetCustomerType();
                        decimal interestRate = GetInterestRate(customerType, view.Duration);

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
                            command.Parameters.AddWithValue("@InterestRate", interestRate * 100); // Lưu dưới dạng phần trăm (ví dụ: 0.0527 -> 5.27)
                            command.Parameters.AddWithValue("@TotalInterestAmount", totalInterestAmount);
                            command.Parameters.AddWithValue("@ServiceDescription", view.ServiceDescription);
                            command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                            command.Parameters.AddWithValue("@ApprovalStatus", "Chờ duyệt");
                            command.Parameters.AddWithValue("@ServiceStatus", "Chờ hoạt động");
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
                        throw new Exception($"Lỗi khi lưu yêu cầu gửi tiết kiệm: {ex.Message}");
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
                MessageBox.Show($"Lỗi khi hủy yêu cầu gửi tiết kiệm: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    class SavingsOTPControllerAdapter : IOTPController
    {
        private readonly AccountModel account;
        private readonly DatabaseContext dbContext;

        public SavingsOTPControllerAdapter(AccountModel account, DatabaseContext dbContext)
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