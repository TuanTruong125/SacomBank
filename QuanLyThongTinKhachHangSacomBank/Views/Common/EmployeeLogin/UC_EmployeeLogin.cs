using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThongTinKhachHangSacomBank.Views.Common.CustomerLogin;
using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Data;
using System.Text.RegularExpressions;

namespace QuanLyThongTinKhachHangSacomBank.Views.Common.EmployeeLogin
{
    public interface IEmployeeLoginView
    {
        event EventHandler ForgotPasswordRequested;
        event EventHandler<LoginEventArgs> LoginRequested;
        event EventHandler ShowPasswordRequested;

        void ShowError(string message);
        void HideError();
        void TogglePasswordVisibility(bool show);
        void SetShowPasswordButtonImage(Image image);
    }

    public partial class UC_EmployeeLogin : UserControl, IEmployeeLoginView
    {
        private readonly IConfiguration configuration;
        private readonly DatabaseContext dbContext;

        public event EventHandler ForgotPasswordRequested;
        public event EventHandler<LoginEventArgs> LoginRequested;
        public event EventHandler ShowPasswordRequested;

        public UC_EmployeeLogin(IConfiguration configuration, DatabaseContext dbContext)
        {
            InitializeComponent();
            this.configuration = configuration;
            this.dbContext = dbContext;


        }

        private bool ContainsVietnameseDiacritics(string text)
        {
            // Regex kiểm tra ký tự có dấu tiếng Việt
            return Regex.IsMatch(text, @"[àáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹđ]");
        }


        private void linkLabelForgotPasswordEmployee_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPasswordRequested?.Invoke(this, EventArgs.Empty);
        }

        private void buttonShowPassword_Click(object sender, EventArgs e)
        {
            ShowPasswordRequested?.Invoke(this, EventArgs.Empty);
        }

        private void cyberButtonLoginEmployee_Click(object sender, EventArgs e)
        {
            string username = textBoxEmployeeUsername.Text.Trim();
            string password = textBoxEmployeePassword.Text.Trim();

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
            labelError.Visible = false;
        }

        public void TogglePasswordVisibility(bool show)
        {
            textBoxEmployeePassword.PasswordChar = show ? '\0' : '●';
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
