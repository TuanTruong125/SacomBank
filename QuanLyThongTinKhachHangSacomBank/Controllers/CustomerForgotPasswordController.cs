using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Views.Common;
using QuanLyThongTinKhachHangSacomBank.Views.Common.CustomerLogin;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    // Thêm việc triển khai IOTPController
    class CustomerForgotPasswordController : IOTPController
    {
        private readonly FormCustomerLogin form;
        private readonly ICustomerForgotPasswordView view;
        private readonly IConfiguration configuration;
        private readonly DatabaseContext dbContext;

        private string phone; // Lưu số điện thoại
        private string email; // Lưu email

        public string Phone => phone; // Để FormOTP truy cập
        public string Email => email; // Để FormOTP truy cập

        public CustomerForgotPasswordController(FormCustomerLogin form, ICustomerForgotPasswordView view, IConfiguration configuration, DatabaseContext dbContext)
        {
            this.form = form;
            this.view = view;
            this.configuration = configuration;
            this.dbContext = dbContext;
            this.view.ConfirmRequested += View_ConfirmRequested;
            this.view.ReturnRequested += View_ReturnRequested;
        }

        private void View_ConfirmRequested(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(view.Phone) || string.IsNullOrWhiteSpace(view.Email))
            {
                view.ShowError("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            using (var connection = dbContext.GetConnection())
            {
                connection.Open();

                var phoneCommand = new SqlCommand("SELECT COUNT(1) FROM CUSTOMER WHERE Phone = @Phone", connection);
                phoneCommand.Parameters.AddWithValue("@Phone", view.Phone);
                int phoneCount = (int)phoneCommand.ExecuteScalar();

                if (phoneCount == 0)
                {
                    view.ShowError("Số điện thoại không tồn tại!");
                    return;
                }

                var emailCommand = new SqlCommand("SELECT COUNT(1) FROM CUSTOMER WHERE Email = @Email", connection);
                emailCommand.Parameters.AddWithValue("@Email", view.Email);
                int emailCount = (int)emailCommand.ExecuteScalar();

                if (emailCount == 0)
                {
                    view.ShowError("Email không tồn tại!");
                    return;
                }

                var command = new SqlCommand("SELECT COUNT(1) FROM CUSTOMER WHERE Phone = @Phone AND Email = @Email", connection);
                command.Parameters.AddWithValue("@Phone", view.Phone);
                command.Parameters.AddWithValue("@Email", view.Email);
                int matchCount = (int)command.ExecuteScalar();

                if (matchCount == 0)
                {
                    view.ShowError("Số điện thoại và email không thuộc cùng một người!");
                    return;
                }

                phone = view.Phone;
                email = view.Email;

                view.HideError();

                FormOTP formOTP = new FormOTP();
                var otpController = new OTPController(formOTP, formOTP, this, configuration);
                if (formOTP.ShowDialog() == DialogResult.OK)
                {
                    var changePasswordView = new UC_CustomerChangePassword();
                    var changePasswordController = new CustomerChangePasswordController(form, changePasswordView, configuration, dbContext, view.Phone, view.Email);
                    form.LoadUserControl(changePasswordView);
                }
            }
        }

        private void View_ReturnRequested(object sender, EventArgs e)
        {
            // Sẽ sửa ở bước tiếp theo
            var customerLoginView = new UC_CustomerLogin(configuration, dbContext);
            var customerLoginController = new CustomerLoginController(form, customerLoginView, configuration, dbContext);
            form.LoadUserControl(customerLoginView);
        }
    }
}