using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace QuanLyThongTinKhachHangSacomBank.Views.Common.CustomerLogin
{
    public interface ICustomerChangePasswordView
    {
        event EventHandler ConfirmRequested;
        event EventHandler ReturnRequested;
        event EventHandler ShowNewPasswordRequested;
        event EventHandler ShowConfirmNewPasswordRequested;

        string NewPassword { get; }
        string ConfirmNewPassword { get; }
        void ShowError(string message);
        void HideError();
        void ToggleNewPasswordVisibility(bool show);
        void ToggleConfirmNewPasswordVisibility(bool show);
        void SetShowNewPasswordButtonImage(Image image);
        void SetShowConfirmNewPasswordButtonImage(Image image);
    }

    public partial class UC_CustomerChangePassword : UserControl, ICustomerChangePasswordView
    {
        public event EventHandler ConfirmRequested;
        public event EventHandler ReturnRequested;
        public event EventHandler ShowNewPasswordRequested;
        public event EventHandler ShowConfirmNewPasswordRequested;

        public string NewPassword => textBoxNewPassword.Text;
        public string ConfirmNewPassword => textBoxConfirmNewPassword.Text;

        public UC_CustomerChangePassword()
        {
            InitializeComponent();
        }

        private bool ContainsVietnameseDiacritics(string text)
        {
            // Regex kiểm tra ký tự có dấu tiếng Việt
            return Regex.IsMatch(text, @"[àáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹđ]");
        }

        private void cyberButtonReturn_Click(object sender, EventArgs e)
        {
            ReturnRequested?.Invoke(this, EventArgs.Empty);
        }

        private void cyberButtonConfirm_Click(object sender, EventArgs e)
        {
            string newPassword = NewPassword.Trim();
            string confirmNewPassword = ConfirmNewPassword.Trim();

            // Kiểm tra ký tự có dấu tiếng Việt
            if (ContainsVietnameseDiacritics(newPassword) || ContainsVietnameseDiacritics(confirmNewPassword))
            {
                ShowError("Mật khẩu không được chứa ký tự có dấu tiếng Việt!");
                return;
            }

            ConfirmRequested?.Invoke(this, EventArgs.Empty);
        }

        private void buttonShowNewPassword_Click(object sender, EventArgs e)
        {
            ShowNewPasswordRequested?.Invoke(this, EventArgs.Empty);
        }

        private void buttonShowConfirmNewPassword_Click(object sender, EventArgs e)
        {
            ShowConfirmNewPasswordRequested?.Invoke(this, EventArgs.Empty);
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

        public void ToggleNewPasswordVisibility(bool show)
        {
            textBoxNewPassword.PasswordChar = show ? '\0' : '●';
        }

        public void ToggleConfirmNewPasswordVisibility(bool show)
        {
            textBoxConfirmNewPassword.PasswordChar = show ? '\0' : '●';
        }

        public void SetShowNewPasswordButtonImage(Image image)
        {
            buttonShowNewPassword.Image = image;
        }

        public void SetShowConfirmNewPasswordButtonImage(Image image)
        {
            buttonShowConfirmNewPassword.Image = image;
        }
    }
}
