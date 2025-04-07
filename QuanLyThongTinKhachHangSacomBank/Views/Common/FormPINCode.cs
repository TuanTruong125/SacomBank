using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ReaLTaiizor.Controls;

namespace QuanLyThongTinKhachHangSacomBank.Views.Common
{
    public partial class FormPINCode : Form
    {
        private List<TextBox> pinCodeTextBoxes = new List<TextBox>();

        public FormPINCode()
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
            if (!string.IsNullOrEmpty(currentBox.Text))
            {
                int index = pinCodeTextBoxes.IndexOf(currentBox);
                if (index < pinCodeTextBoxes.Count - 1)
                {
                    pinCodeTextBoxes[index + 1].Focus();
                }
            }
        }
    }
}