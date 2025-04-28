using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Views.Common;
using QuanLyThongTinKhachHangSacomBank.Views.Common.EmployeeLogin;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class EmployeeLoginController
    {
        private readonly FormEmployeeLogin form;
        private readonly IEmployeeLoginView view;
        private readonly IConfiguration configuration;
        private readonly DatabaseContext dbContext;
        private bool isPasswordVisible = false;
        private Image eyeOpenImage;
        private Image eyeClosedImage;

        public EmployeeLoginController(FormEmployeeLogin form, IEmployeeLoginView view, IConfiguration configuration, DatabaseContext dbContext)
        {
            this.form = form;
            this.view = view;
            this.configuration = configuration;
            this.dbContext = dbContext;

            eyeOpenImage = Properties.Resources.ShowPassword;
            eyeClosedImage = Properties.Resources.HidePassword;
            view.SetShowPasswordButtonImage(eyeClosedImage);

            this.view.ForgotPasswordRequested += View_ForgotPasswordRequested;
            this.view.LoginRequested += View_LoginRequested;
            this.view.ShowPasswordRequested += View_ShowPasswordRequested;
            LoadEmployeeLogin();
        }

        private void LoadEmployeeLogin()
        {
            form.LoadUserControl((UserControl)view);
        }

        private void View_ForgotPasswordRequested(object sender, EventArgs e)
        {
            var employeeForgotPasswordView = new UC_EmployeeForgotPassword();
            var employeeForgotPasswordController = new EmployeeForgotPasswordController(form, employeeForgotPasswordView, configuration, dbContext);
            form.LoadUserControl(employeeForgotPasswordView);
        }

        private void View_ShowPasswordRequested(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;
            view.TogglePasswordVisibility(isPasswordVisible);
            view.SetShowPasswordButtonImage(isPasswordVisible ? eyeOpenImage : eyeClosedImage);
        }

        private void View_LoginRequested(object sender, LoginEventArgs e)
        {
            string username = e.Username;
            string password = e.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                view.ShowError("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            EmployeeModel employee = ValidateLogin(username, password);
            if (employee != null)
            {
                form.Tag = employee;
                form.DialogResult = DialogResult.OK;
                form.Close();
            }
        }

        private EmployeeModel ValidateLogin(string username, string password)
        {
            using (var connection = dbContext.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM EMPLOYEE WHERE EmployeeUsername = @Username AND EmployeePassword = @Password", connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new EmployeeModel
                        {
                            EmployeeID = reader.GetInt32(reader.GetOrdinal("EmployeeID")),
                            EmployeeCode = reader.GetString(reader.GetOrdinal("EmployeeCode")),
                            EmployeeName = reader.GetString(reader.GetOrdinal("EmployeeName")),
                            EmployeeGender = reader.GetString(reader.GetOrdinal("EmployeeGender")),
                            EmployeeDateOfBirth = reader.GetDateTime(reader.GetOrdinal("EmployeeDateOfBirth")),
                            EmployeeCitizenID = reader.GetString(reader.GetOrdinal("EmployeeCitizenID")),
                            EmployeeAddress = reader.GetString(reader.GetOrdinal("EmployeeAddress")),
                            EmployeeRole = reader.GetString(reader.GetOrdinal("EmployeeRole")),
                            EmployeePhone = reader.GetString(reader.GetOrdinal("EmployeePhone")),
                            EmployeeEmail = reader.GetString(reader.GetOrdinal("EmployeeEmail")),
                            HireDate = reader.GetDateTime(reader.GetOrdinal("HireDate")),
                            Salary = reader.GetDecimal(reader.GetOrdinal("Salary")),
                            EmployeeUsername = reader.GetString(reader.GetOrdinal("EmployeeUsername")),
                            EmployeePassword = reader.GetString(reader.GetOrdinal("EmployeePassword")),
                            AccessLevel = reader.GetInt32(reader.GetOrdinal("AccessLevel")),
                            ManagerID = reader.IsDBNull(reader.GetOrdinal("ManagerID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("ManagerID"))
                        };
                    }
                }

                command = new SqlCommand("SELECT COUNT(1) FROM EMPLOYEE WHERE EmployeeUsername = @Username", connection);
                command.Parameters.AddWithValue("@Username", username);
                int userCount = (int)command.ExecuteScalar();

                if (userCount == 0)
                {
                    view.ShowError("Tên đăng nhập không tồn tại!");
                }
                else
                {
                    view.ShowError("Mật khẩu không đúng!");
                }
                return null;
            }
        }
    }
}
