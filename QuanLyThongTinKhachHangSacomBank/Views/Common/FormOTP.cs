using QuanLyThongTinKhachHangSacomBank.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThongTinKhachHangSacomBank.Views.Common
{
    public interface IOTPView
    {
        event EventHandler ConfirmMethodRequested; // Khi nhấn nút xác nhận phương thức
        event EventHandler VerifyOTPRequested; // Khi nhấn nút xác thực OTP
        event EventHandler RequestAgainRequested; // Khi nhấn link yêu cầu gửi lại mã

        string SelectedMethod { get; } // Phương thức gửi OTP (Email hoặc SMS)
        string EnteredOTP { get; } // Mã OTP người dùng nhập

        void ShowOTPInputControls(); // Hiển thị các thành phần nhập OTP
        void HideError(); // Ẩn label lỗi
        void ShowError(string message); // Hiển thị lỗi
        void UpdateCountdown(string time); // Cập nhật thời gian đếm ngược
        void EnableMethodSelection(bool enable); // Kích hoạt/vô hiệu hóa combobox và nút xác nhận phương thức
        void EnableRequestAgain(bool enable); // Kích hoạt/vô hiệu hóa link yêu cầu gửi lại
        void ClearOTPTextBoxes(); // Thêm phương thức để làm trống các TextBox
        void UnfocusTextBoxes(); // Thêm phương thức để bỏ focus khỏi các TextBox
        void FocusFirstTextBox(); // Thêm phương thức để focus vào TextBox đầu tiên
        void DisableSMSOption();
    }

    public partial class FormOTP : Form, IOTPView
    {
        private List<TextBox> otpTextBoxes = new List<TextBox>();

        public event EventHandler ConfirmMethodRequested;
        public event EventHandler VerifyOTPRequested;
        public event EventHandler RequestAgainRequested;

        public string SelectedMethod => comboBoxMethodOTP.SelectedItem?.ToString();
        public string EnteredOTP => string.Concat(otpTextBoxes.Select(tb => tb.Text));

        public FormOTP()
        {
            InitializeComponent();
            otpTextBoxes = new List<TextBox> { textBoxOTP1, textBoxOTP2, textBoxOTP3, textBoxOTP4, textBoxOTP5, textBoxOTP6 };
            foreach (var textBox in otpTextBoxes)
            {
                textBox.MaxLength = 1;
                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.KeyPress += TextBox_KeyPress;
                textBox.TextChanged += TextBox_TextChanged;
                textBox.GotFocus += (s, e) => ((TextBox)s).SelectAll();
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
            int index = otpTextBoxes.IndexOf(currentBox);

            if (!string.IsNullOrEmpty(currentBox.Text))
            {
                // Nếu nhập số, chuyển focus sang ô tiếp theo
                if (index < otpTextBoxes.Count - 1)
                {
                    otpTextBoxes[index + 1].Focus();
                }
            }
            else
            {
                // Nếu xóa số (ô hiện tại rỗng), chuyển focus về ô phía trước
                if (index > 0)
                {
                    otpTextBoxes[index - 1].Focus();
                }
            }
        }

        private void comboBoxMethodOTP_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Không thao tác
        }

        private void buttonMethodConfirmOTP_Click(object sender, EventArgs e)
        {
            ConfirmMethodRequested?.Invoke(this, EventArgs.Empty);
        }

        private void linkLabelRequestAgain_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RequestAgainRequested?.Invoke(this, EventArgs.Empty);
        }

        private void cyberButtonVerifyOTP_Click(object sender, EventArgs e)
        {
            VerifyOTPRequested?.Invoke(this, EventArgs.Empty);
        }



        public void ShowOTPInputControls()
        {
            textBoxOTP1.Visible = true;
            textBoxOTP2.Visible = true;
            textBoxOTP3.Visible = true;
            textBoxOTP4.Visible = true;
            textBoxOTP5.Visible = true;
            textBoxOTP6.Visible = true;
            labelGuideOTP.Visible = true;
            labelCountdown.Visible = true;
            labelQuestion.Visible = true;
            linkLabelRequestAgain.Visible = true;
            cyberButtonVerifyOTP.Visible = true;
        }

        public void HideError()
        {
            labelErrorOTP.Visible = false;
        }

        public void ShowError(string message)
        {
            labelErrorOTP.Text = message;
            labelErrorOTP.Visible = true;
        }

        public void UpdateCountdown(string time)
        {
            labelCountdown.Text = time;
        }

        public void EnableMethodSelection(bool enable)
        {
            comboBoxMethodOTP.Enabled = enable;
            buttonMethodConfirmOTP.Enabled = enable;
        }

        public void EnableRequestAgain(bool enable)
        {
            linkLabelRequestAgain.Enabled = enable;
        }

        public void ClearOTPTextBoxes()
        {
            foreach (var textBox in otpTextBoxes)
            {
                textBox.Text = string.Empty;
            }
        }

        public void UnfocusTextBoxes()
        {
            linkLabelRequestAgain.Focus();
        }

        public void FocusFirstTextBox()
        {
            if (otpTextBoxes.Count > 0)
            {
                otpTextBoxes[0].Focus();
            }
        }

        public void DisableSMSOption()
        {
            // Xóa tùy chọn SMS khỏi ComboBox
            if (comboBoxMethodOTP.Items.Contains("SMS"))
            {
                comboBoxMethodOTP.Items.Remove("SMS");
            }

            // Nếu không còn tùy chọn nào khác, chọn mặc định là Email
            if (comboBoxMethodOTP.Items.Count > 0 && !comboBoxMethodOTP.Items.Contains(comboBoxMethodOTP.SelectedItem))
            {
                comboBoxMethodOTP.SelectedItem = "Email";
            }
        }
    }
}
