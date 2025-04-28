using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Data;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLyThongTinKhachHangSacomBank.Views.Common.CustomerLogin
{
    public interface ICustomerLoginView
    {
        event EventHandler ForgotPasswordRequested;
        event EventHandler SignUpRequested;
        event EventHandler<LoginEventArgs> LoginRequested;
        event EventHandler ShowPasswordRequested;

        void ShowError(string message);
        void HideError();

        void TogglePasswordVisibility(bool showPassword);
        void SetShowPasswordButtonImage(Image image);
    }

    public partial class UC_CustomerLogin : UserControl, ICustomerLoginView
    {
        private readonly IConfiguration configuration;
        private readonly DatabaseContext dbContext;

        public event EventHandler ForgotPasswordRequested;
        public event EventHandler SignUpRequested;
        public event EventHandler<LoginEventArgs> LoginRequested;
        public event EventHandler ShowPasswordRequested;

        public UC_CustomerLogin(IConfiguration configuration, DatabaseContext dbContext)
        {
            InitializeComponent();
            this.configuration = configuration;
            this.dbContext = dbContext;

            // Chỉ cho phép nhập số vào textBoxUsername
            textBoxUsername.KeyPress += (sender, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            };
        }

        private bool ContainsVietnameseDiacritics(string text)
        {
            // Regex kiểm tra ký tự có dấu tiếng Việt
            return Regex.IsMatch(text, @"[àáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹđ]");
        }

        private void linkLabelSignUpCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUpRequested?.Invoke(this, EventArgs.Empty);
        }

        private void linkLabelForgotPasswordCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPasswordRequested?.Invoke(this, EventArgs.Empty);
        }

        private void buttonShowPassword_Click(object sender, EventArgs e)
        {
            ShowPasswordRequested?.Invoke(this, EventArgs.Empty);
        }

        private void cyberButtonLoginCustomer_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text.Trim();

            // Kiểm tra xem mật khẩu có chứa ký tự có dấu không
            if (ContainsVietnameseDiacritics(password))
            {
                ShowError("Mật khẩu không được chứa ký tự có dấu!");
                return;
            }

            var loginArgs = new LoginEventArgs { Username = username, Password = password };
            LoginRequested?.Invoke(this, loginArgs);
        }

        public void ShowError(string message)
        {
            labelError.Text = message;
            labelError.Visible = true;
        }

        public void HideError()
        {
            labelError.Text = "";
            labelError.Visible = false;
        }

        public void TogglePasswordVisibility(bool showPassword)
        {
            textBoxPassword.PasswordChar = showPassword ? '\0' : '●';
        }

        public void SetShowPasswordButtonImage(Image image)
        {
            buttonShowPassword.Image = image;
        }
    }

    public class LoginEventArgs : EventArgs
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}