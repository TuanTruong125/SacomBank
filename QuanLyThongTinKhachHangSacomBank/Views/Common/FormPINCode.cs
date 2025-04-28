using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QuanLyThongTinKhachHangSacomBank.Controllers;
using QuanLyThongTinKhachHangSacomBank.Models;
using ReaLTaiizor.Controls;

namespace QuanLyThongTinKhachHangSacomBank.Views.Common
{
    public interface IPINCodeView
    {
        event EventHandler VerifyPINRequested; // Sự kiện khi nhấn nút xác thực PIN
        string EnteredPIN { get; } // Mã PIN người dùng nhập
        void ShowError(string message); // Hiển thị lỗi
        void HideError(); // Ẩn label lỗi
        void ClearPINTextBoxes(); // Làm trống các TextBox
        void FocusFirstTextBox(); // Focus vào TextBox đầu tiên
    }

    public partial class FormPINCode : Form, IPINCodeView
    {
        private List<TextBox> pinCodeTextBoxes;

        public event EventHandler VerifyPINRequested;

        public string EnteredPIN => string.Concat(pinCodeTextBoxes.Select(tb => tb.Text));

        public FormPINCode(AccountModel account)
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
            int index = pinCodeTextBoxes.IndexOf(currentBox);

            if (!string.IsNullOrEmpty(currentBox.Text))
            {
                // Nếu nhập số, chuyển focus sang ô tiếp theo
                if (index < pinCodeTextBoxes.Count - 1)
                {
                    pinCodeTextBoxes[index + 1].Focus();
                }
            }
            else
            {
                // Nếu xóa số (ô hiện tại rỗng), chuyển focus về ô phía trước
                if (index > 0)
                {
                    pinCodeTextBoxes[index - 1].Focus();
                }
            }
        }

        public void ShowError(string message)
        {
            labelErrorOTP.Text = message;
            labelErrorOTP.Visible = true;
        }

        public void HideError()
        {
            labelErrorOTP.Visible = false;
        }

        public void ClearPINTextBoxes()
        {
            foreach (var textBox in pinCodeTextBoxes)
            {
                textBox.Text = string.Empty;
            }
        }

        public void FocusFirstTextBox()
        {
            if (pinCodeTextBoxes.Count > 0)
            {
                pinCodeTextBoxes[0].Focus();
            }
        }

        private void cyberButtonVerifyPINCode_Click(object sender, EventArgs e)
        {
            VerifyPINRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}