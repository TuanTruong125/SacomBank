using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLyThongTinKhachHangSacomBank.Views.Common.CustomerLogin
{
    public interface IAccountInfoRegisterView
    {
        event EventHandler ConfirmRequested;
        event EventHandler ShowPasswordRegisterRequested;
        event EventHandler ShowConfirmPasswordRegisterRequested;

        string Username { get; }
        string Password { get; }
        string ConfirmPassword { get; }
        string PinCode { get; }

        void ShowError(string message);
        void HideError();
        void ToggleNewPasswordVisibility(bool show);
        void ToggleConfirmNewPasswordVisibility(bool show);
        void SetShowPasswordButtonImage(Image image);
        void SetShowConfirmPasswordButtonImage(Image image);
    }

    public partial class UC_AccountInfoRegister : UserControl, IAccountInfoRegisterView
    {
        private List<TextBox> pinCodeTextBoxes = new List<TextBox>();

        public event EventHandler ConfirmRequested;
        public event EventHandler ShowPasswordRegisterRequested;
        public event EventHandler ShowConfirmPasswordRegisterRequested;

        public string Username => textBoxUsernameRegister.Text;
        public string Password => textBoxPasswordRegister.Text;
        public string ConfirmPassword => textBoxConfirmPasswordRegister.Text;
        public string PinCode => $"{textBoxPINCode1.Text}{textBoxPINCode2.Text}{textBoxPINCode3.Text}{textBoxPINCode4.Text}{textBoxPINCode5.Text}{textBoxPINCode6.Text}";

        public UC_AccountInfoRegister()
        {
            InitializeComponent();
            pinCodeTextBoxes = new List<TextBox> { textBoxPINCode1, textBoxPINCode2, textBoxPINCode3, textBoxPINCode4, textBoxPINCode5, textBoxPINCode6 };
            foreach (var textBox in pinCodeTextBoxes)
            {
                textBox.MaxLength = 1; // Giới hạn chỉ nhập 1 ký tự
                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.KeyPress += TextBox_KeyPress; // Chặn nhập ký tự không phải số
                textBox.TextChanged += TextBox_TextChanged; // Chuyển ô sau khi nhập
                textBox.GotFocus += (s, e) => ((TextBox)s).SelectAll(); // Chọn hết khi focus vào
            }

            // Ẩn mật khẩu ban đầu
            textBoxPasswordRegister.PasswordChar = '●';
            textBoxConfirmPasswordRegister.PasswordChar = '●';

        }

        private bool ContainsVietnameseDiacritics(string text)
        {
            // Regex kiểm tra ký tự có dấu tiếng Việt
            return Regex.IsMatch(text, @"[àáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹđ]");
        }

        // Ngăn nhập ký tự không phải số
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }
        }

        // Tự động chuyển sang ô tiếp theo sau khi nhập số
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox currentBox = sender as TextBox;
            if (!string.IsNullOrEmpty(currentBox.Text))
            {
                int index = pinCodeTextBoxes.IndexOf(currentBox);
                if (index < pinCodeTextBoxes.Count - 1)
                {
                    pinCodeTextBoxes[index + 1].Focus();
                }
            }
        }

        

        // Phương thức để điền Username từ Controller
        public void SetUsername(string username)
        {
            textBoxUsernameRegister.Text = username;
            textBoxUsernameRegister.Enabled = false; // Không cho chỉnh sửa Username
        }


        private void cyberButtonConfirm_Click(object sender, EventArgs e)
        {
            string newPassword = Password.Trim();
            string confirmPassword = ConfirmPassword.Trim();

            // Kiểm tra ký tự có dấu tiếng Việt
            if (ContainsVietnameseDiacritics(newPassword) || ContainsVietnameseDiacritics(confirmPassword))
            {
                ShowError("Mật khẩu không được chứa ký tự có dấu tiếng Việt!");
                return;
            }

            ConfirmRequested?.Invoke(this, EventArgs.Empty);
        }

        private void buttonShowPasswordRegister_Click(object sender, EventArgs e)
        {
            ShowPasswordRegisterRequested?.Invoke(this, EventArgs.Empty);
        }

        private void buttonShowConfirmPasswordRegister_Click(object sender, EventArgs e)
        {
            ShowConfirmPasswordRegisterRequested?.Invoke(this, EventArgs.Empty);
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
            textBoxPasswordRegister.PasswordChar = show ? '\0' : '●';
        }

        public void ToggleConfirmNewPasswordVisibility(bool show)
        {
            textBoxConfirmPasswordRegister.PasswordChar = show ? '\0' : '●';
        }

        public void SetShowPasswordButtonImage(Image image)
        {
            buttonShowPasswordRegister.Image = image;
        }

        public void SetShowConfirmPasswordButtonImage(Image image)
        {
            buttonShowConfirmPasswordRegister.Image = image;
        }
    }
}