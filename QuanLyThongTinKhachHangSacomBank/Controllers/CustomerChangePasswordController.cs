using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Views.Common.CustomerLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class CustomerChangePasswordController
    {
        private readonly FormCustomerLogin form;
        private readonly ICustomerChangePasswordView view;
        private readonly IConfiguration configuration;
        private readonly DatabaseContext dbContext;
        private readonly string phone;
        private readonly string email;
        private bool isNewPasswordVisible = false;
        private bool isConfirmNewPasswordVisible = false;
        private Image eyeOpenImage;
        private Image eyeClosedImage;

        public CustomerChangePasswordController(FormCustomerLogin form, ICustomerChangePasswordView view, IConfiguration configuration, DatabaseContext dbContext, string phone, string email)
        {
            this.form = form;
            this.view = view;
            this.configuration = configuration;
            this.dbContext = dbContext;
            this.phone = phone;
            this.email = email;

            eyeOpenImage = Properties.Resources.ShowPassword;
            eyeClosedImage = Properties.Resources.HidePassword;
            view.SetShowNewPasswordButtonImage(eyeClosedImage);
            view.SetShowConfirmNewPasswordButtonImage(eyeClosedImage);

            this.view.ConfirmRequested += View_ConfirmRequested;
            this.view.ReturnRequested += View_ReturnRequested;
            this.view.ShowNewPasswordRequested += View_ShowNewPasswordRequested;
            this.view.ShowConfirmNewPasswordRequested += View_ShowConfirmNewPasswordRequested;
        }

        private void View_ConfirmRequested(object sender, EventArgs e)
        {
            string newPassword = view.NewPassword;
            string confirmNewPassword = view.ConfirmNewPassword;

            if (string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmNewPassword))
            {
                view.ShowError("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (newPassword.Length < 6)
            {
                view.ShowError("Mật khẩu mới phải có ít nhất 6 ký tự!");
                return;
            }

            if (newPassword != confirmNewPassword)
            {
                view.ShowError("Mật khẩu xác nhận không khớp!");
                return;
            }

            using (var connection = dbContext.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT UserPassword FROM ACCOUNT WHERE CustomerID = (SELECT CustomerID FROM CUSTOMER WHERE Phone = @Phone AND Email = @Email)", connection);
                command.Parameters.AddWithValue("@Phone", phone);
                command.Parameters.AddWithValue("@Email", email);
                string oldPassword = (string)command.ExecuteScalar();

                if (oldPassword == newPassword)
                {
                    view.ShowError("Mật khẩu mới không được trùng với mật khẩu cũ!");
                    return;
                }

                command = new SqlCommand("UPDATE ACCOUNT SET UserPassword = @NewPassword WHERE CustomerID = (SELECT CustomerID FROM CUSTOMER WHERE Phone = @Phone AND Email = @Email)", connection);
                command.Parameters.AddWithValue("@NewPassword", newPassword);
                command.Parameters.AddWithValue("@Phone", phone);
                command.Parameters.AddWithValue("@Email", email);
                command.ExecuteNonQuery();

                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var customerLoginView = new UC_CustomerLogin(configuration, dbContext);
                var customerLoginController = new CustomerLoginController(form, customerLoginView, configuration, dbContext);
                form.LoadUserControl(customerLoginView);
            }
        }

        private void View_ReturnRequested(object sender, EventArgs e)
        {
            var customerLoginView = new UC_CustomerLogin(configuration, dbContext);
            var customerLoginController = new CustomerLoginController(form, customerLoginView, configuration, dbContext);
            form.LoadUserControl(customerLoginView);
        }

        private void View_ShowNewPasswordRequested(object sender, EventArgs e)
        {
            isNewPasswordVisible = !isNewPasswordVisible;
            view.ToggleNewPasswordVisibility(isNewPasswordVisible);
            view.SetShowNewPasswordButtonImage(isNewPasswordVisible ? eyeOpenImage : eyeClosedImage);
        }

        private void View_ShowConfirmNewPasswordRequested(object sender, EventArgs e)
        {
            isConfirmNewPasswordVisible = !isConfirmNewPasswordVisible;
            view.ToggleConfirmNewPasswordVisibility(isConfirmNewPasswordVisible);
            view.SetShowConfirmNewPasswordButtonImage(isConfirmNewPasswordVisible ? eyeOpenImage : eyeClosedImage);
        }
    }
}
