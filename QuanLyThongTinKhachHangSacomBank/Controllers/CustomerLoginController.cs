using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Views.Customer;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using QuanLyThongTinKhachHangSacomBank.Views.Common.CustomerLogin;
using System.Configuration;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class CustomerLoginController
    {
        private readonly FormCustomerLogin form;
        private readonly ICustomerLoginView view;
        private readonly DatabaseContext dbContext;
        private readonly IConfiguration configuration;
        private bool isPasswordVisible = false; // Trạng thái hiển thị mật khẩu
        private Image eyeOpenImage; // Hình ảnh "mắt mở"
        private Image eyeClosedImage; // Hình ảnh "mắt nhắm"

        private AccountModel loggedInAccount; // Lưu thông tin tài khoản đã đăng nhập
        public AccountModel LoggedInAccount => loggedInAccount; // Thuộc tính để truy cập tài khoản đã đăng nhập

        public CustomerLoginController(FormCustomerLogin form, ICustomerLoginView view, IConfiguration configuration, DatabaseContext dbContext)
        {
            this.form = form;
            this.view = view;
            this.configuration = configuration;
            this.dbContext = dbContext;


            // Load hình ảnh cho nút ShowPassword
            eyeOpenImage = Properties.Resources.ShowPassword;
            eyeClosedImage = Properties.Resources.HidePassword;
            view.SetShowPasswordButtonImage(eyeClosedImage);

            // Đăng ký sự kiện
            this.view.ForgotPasswordRequested += View_ForgotPasswordRequested;
            this.view.SignUpRequested += View_SignUpRequested;
            this.view.LoginRequested += View_LoginRequested;
            this.view.ShowPasswordRequested += View_ShowPasswordRequested;
            LoadCustomerLogin();
        }

        private void LoadCustomerLogin()
        {
            form.LoadUserControl((UserControl)view);
        }

        private void View_ForgotPasswordRequested(object sender, EventArgs e)
        {
            var customerForgotPasswordView = new UC_CustomerForgotPassword();
            var customerForgotPasswordController = new CustomerForgotPasswordController(form, customerForgotPasswordView, configuration, dbContext);
            form.LoadUserControl(customerForgotPasswordView);
        }

        private void View_SignUpRequested(object sender, EventArgs e)
        {
            FormCustomerRegister formCustomerRegister = new FormCustomerRegister(configuration, dbContext);
            formCustomerRegister.ShowDialog();
        }

        private void View_ShowPasswordRequested(object sender, EventArgs e)
        {
            // Đổi trạng thái hiển thị mật khẩu
            isPasswordVisible = !isPasswordVisible;
            view.TogglePasswordVisibility(isPasswordVisible);
            view.SetShowPasswordButtonImage(isPasswordVisible ? eyeOpenImage : eyeClosedImage);
        }

        private void View_LoginRequested(object sender, LoginEventArgs e)
        {
            string username = e.Username;
            string password = e.Password;

            // Kiểm tra điều kiện và hiển thị lỗi bằng labelError
            if (string.IsNullOrWhiteSpace(username) && string.IsNullOrWhiteSpace(password))
            {
                view.ShowError("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            // Kiểm tra đăng nhập
            bool isValid = ValidateLogin(username, password);
            if (isValid)
            {
                loggedInAccount = GetAccountDetails(username); // Lấy thông tin tài khoản
                form.Tag = loggedInAccount; // Truyền thông tin qua Tag của Form
                form.DialogResult = DialogResult.OK; // Đánh dấu đăng nhập thành công
                form.Close(); // Đóng FormCustomerLogin
            }
        }

        private bool ValidateLogin(string username, string password)
        {
            using (var connection = dbContext.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT COUNT(1) FROM ACCOUNT WHERE Username = @Username AND UserPassword = @Password", connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                int count = (int)command.ExecuteScalar();

                if (count == 0)
                {
                    // Kiểm tra username tồn tại không
                    command = new SqlCommand("SELECT COUNT(1) FROM ACCOUNT WHERE Username = @Username", connection);
                    command.Parameters.AddWithValue("@Username", username);
                    int userCount = (int)command.ExecuteScalar();

                    if (userCount == 0)
                    {
                        view.ShowError("Tên đăng nhập không tồn tại hoặc nhập sai!");
                    }
                    else
                    {
                        view.ShowError("Nhập sai mật khẩu!");
                    }
                    return false;
                }

                // Kiểm tra trạng thái tài khoản
                command = new SqlCommand("SELECT AccountStatus FROM ACCOUNT WHERE Username = @Username", connection);
                command.Parameters.AddWithValue("@Username", username);
                string accountStatus = command.ExecuteScalar()?.ToString();

                if (accountStatus == "Khóa")
                {
                    view.ShowError("Tài khoản này đang bị khóa!");
                    return false;
                }
                if (accountStatus == "Đóng")
                {
                    view.ShowError("Tài khoản này đã bị đóng!");
                    return false;
                }

                return true;
            }
        }

        private AccountModel GetAccountDetails(string username)
        {
            using (var connection = dbContext.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT AccountID, AccountCode, AccountName, Balance, AccountOpenDate, Username, UserPassword, PINCode, AccountStatus, CustomerID, AccountTypeID FROM ACCOUNT WHERE Username = @Username", connection);
                command.Parameters.AddWithValue("@Username", username);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new AccountModel
                        {
                            AccountID = reader.GetInt32(0),
                            AccountCode = reader.GetString(1),
                            AccountName = reader.GetString(2),
                            Balance = reader.GetDecimal(3),
                            AccountOpenDate = reader.GetDateTime(4),
                            Username = reader.GetString(5),
                            UserPassword = reader.GetString(6),
                            PINCode = reader.GetString(7),
                            AccountStatus = reader.GetString(8),
                            CustomerID = reader.GetInt32(9),
                            AccountTypeID = reader.GetInt32(10)
                        };
                    }
                }
            }
            return null;
        }
    }
}
