using Microsoft.Data.SqlClient;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Views.Customer;
using Microsoft.Extensions.Configuration;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    public class CustomerServiceController
    {
        private readonly UC_CustomerService view;
        private readonly AccountModel currentAccount;
        private readonly DatabaseContext dbContext;
        private readonly IConfiguration configuration;

        public CustomerServiceController(UC_CustomerService view, AccountModel currentAccount, DatabaseContext dbContext, IConfiguration configuration)
        {
            this.view = view;
            this.currentAccount = currentAccount;
            this.dbContext = dbContext;
            this.configuration = configuration;

            // Kiểm tra loại khách hàng và điều chỉnh trạng thái các nút
            AdjustButtonsBasedOnCustomerType();
        }

        private void AdjustButtonsBasedOnCustomerType()
        {
            try
            {
                // Lấy CustomerTypeID từ bảng CUSTOMER
                int customerTypeId = GetCustomerType();

                // Nếu CustomerTypeID là 2 (Doanh nghiệp) hoặc 4 (VIP Doanh nghiệp)
                if (customerTypeId == 2 || customerTypeId == 4)
                {
                    // Vô hiệu hóa các nút "Chi tiết tiết kiệm" và "Đăng ký tiết kiệm"
                    view.DisableSavingsButtons();
                }
                // Nếu là cá nhân (CustomerTypeID là 1 hoặc 3), các nút vẫn enable (mặc định)
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kiểm tra loại khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetCustomerType()
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
            return -1; // Trả về -1 nếu không lấy được loại khách hàng
        }
    }
}