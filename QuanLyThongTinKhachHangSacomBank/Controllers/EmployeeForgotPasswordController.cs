using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Views.Common;
using QuanLyThongTinKhachHangSacomBank.Views.Common.CustomerLogin;
using QuanLyThongTinKhachHangSacomBank.Views.Common.EmployeeLogin;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class EmployeeForgotPasswordController : IOTPController
    {
        private readonly FormEmployeeLogin form;
        private readonly IEmployeeForgotPasswordView view;
        private readonly IConfiguration configuration;
        private readonly DatabaseContext dbContext;

        private string phone; // Lưu số điện thoại
        private string email; // Lưu email

        public string Phone => phone; // Để FormOTP truy cập
        public string Email => email; // Để FormOTP truy cập

        public EmployeeForgotPasswordController(FormEmployeeLogin form, IEmployeeForgotPasswordView view, IConfiguration configuration, DatabaseContext dbContext)
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
            // Kiểm tra thông tin
            if (string.IsNullOrWhiteSpace(view.EmployeePhone) || string.IsNullOrWhiteSpace(view.EmployeeEmail))
            {
                view.ShowError("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            using (var connection = dbContext.GetConnection())
            {
                connection.Open();

                var phoneCommand = new SqlCommand("SELECT COUNT(1) FROM EMPLOYEE WHERE EmployeePhone = @Phone", connection);
                phoneCommand.Parameters.AddWithValue("@Phone", view.EmployeePhone);
                int phoneCount = (int)phoneCommand.ExecuteScalar();

                if (phoneCount == 0)
                {
                    view.ShowError("Số điện thoại không tồn tại!");
                    return;
                }

                var emailCommand = new SqlCommand("SELECT COUNT(1) FROM EMPLOYEE WHERE EmployeeEmail = @Email", connection);
                emailCommand.Parameters.AddWithValue("@Email", view.EmployeeEmail);
                int emailCount = (int)emailCommand.ExecuteScalar();

                if (emailCount == 0)
                {
                    view.ShowError("Email không tồn tại!");
                    return;
                }

                var command = new SqlCommand("SELECT COUNT(1) FROM EMPLOYEE WHERE EmployeePhone = @Phone AND EmployeeEmail = @Email", connection);
                command.Parameters.AddWithValue("@Phone", view.EmployeePhone);
                command.Parameters.AddWithValue("@Email", view.EmployeeEmail);
                int matchCount = (int)command.ExecuteScalar();

                if (matchCount == 0)
                {
                    view.ShowError("Số điện thoại và email không khớp!");
                    return;
                }

                phone = view.EmployeePhone;
                email = view.EmployeeEmail;

                view.HideError();

                FormOTP formOTP = new FormOTP();
                var otpController = new OTPController(formOTP, formOTP, this, configuration);
                if (formOTP.ShowDialog() == DialogResult.OK)
                {
                    var changePasswordView = new UC_EmployeeChangePassword();
                    var changePasswordController = new EmployeeChangePasswordController(form, changePasswordView, configuration, dbContext, view.EmployeePhone, view.EmployeeEmail);
                    form.LoadUserControl(changePasswordView);
                }
            }
        }

        private void View_ReturnRequested(object sender, EventArgs e)
        {
            var employeeLoginView = new UC_EmployeeLogin(configuration, dbContext);
            var employeeLoginController = new EmployeeLoginController(form, employeeLoginView, configuration, dbContext);
            form.LoadUserControl(employeeLoginView);
        }
    }        
}
