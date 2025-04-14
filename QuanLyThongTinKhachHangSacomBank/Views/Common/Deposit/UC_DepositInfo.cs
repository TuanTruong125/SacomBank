using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThongTinKhachHangSacomBank.Models;

namespace QuanLyThongTinKhachHangSacomBank.Views.Common.Deposit
{
    public interface IDepositViewData
    {
        string TransactionCode { get; set; }
        string AccountName { get; }
        string AccountID { get; }
        string Phone { get; }
        string CitizenID { get; }
        string Balance { get; }
        string Amount { get; }
        string TransactionDescription { get; set; } // Thêm setter để tự động điền mô tả
        void ShowError(string message);
        void HideError();
        void SetAccountInfo(AccountModel account, string phone, string citizenID);
        event EventHandler ConfirmRequested;
        event EventHandler CancelRequested;
        event EventHandler AccountIDLostFocus;
    }

    public partial class UC_DepositInfo : UserControl, IDepositViewData
    {
        public event EventHandler ConfirmRequested;
        public event EventHandler CancelRequested;
        public event EventHandler AccountIDLostFocus;

        public UC_DepositInfo()
        {
            InitializeComponent();
            SetupControls();
        }

        private void SetupControls()
        {
            // Chỉ cho phép nhập mã tài khoản và số tiền, các ô còn lại disable
            textBoxAccountName.ReadOnly = true;
            textBoxPhone.Enabled = false;
            textBoxCitizenID.Enabled = false;
            textBoxBalance.Enabled = false;
            textBoxAmount.Enabled = true; // Nhân viên được phép nhập số tiền

            // Gắn sự kiện LostFocus cho textBoxAccountID
            textBoxAccountID.LostFocus += TextBoxAccountID_LostFocus;

            // Định dạng số tiền
            textBoxAmount.TextChanged += TextBoxAmount_TextChanged;
            textBoxAmount.KeyPress += TextBoxAmount_KeyPress;
        }

        private void TextBoxAccountID_LostFocus(object sender, EventArgs e)
        {
            AccountIDLostFocus?.Invoke(this, EventArgs.Empty);
        }

        private void TextBoxAmount_TextChanged(object sender, EventArgs e)
        {
            // Định dạng số tiền: thêm dấu phẩy sau mỗi 3 chữ số
            string text = textBoxAmount.Text.Replace(",", ""); // Loại bỏ dấu phẩy hiện tại
            if (string.IsNullOrEmpty(text)) return;

            if (decimal.TryParse(text, out decimal number))
            {
                textBoxAmount.TextChanged -= TextBoxAmount_TextChanged; // Ngắt sự kiện để tránh đệ quy
                textBoxAmount.Text = number.ToString("#,##0");
                textBoxAmount.SelectionStart = textBoxAmount.Text.Length; // Đặt con trỏ ở cuối
                textBoxAmount.TextChanged += TextBoxAmount_TextChanged; // Kích hoạt lại sự kiện
            }
        }

        private void TextBoxAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và phím Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Chặn ký tự không phải số
            }
        }

        public string TransactionCode { get; set; }
        public string AccountName => textBoxAccountName.Text;
        public string AccountID => textBoxAccountID.Text;
        public string Phone => textBoxPhone.Text;
        public string CitizenID => textBoxCitizenID.Text;
        public string Balance => textBoxBalance.Text;
        public string Amount => textBoxAmount.Text.Replace(",", ""); // Loại bỏ dấu phẩy khi lấy giá trị
        public string TransactionDescription
        {
            get => textBoxTransactionDescription.Text;
            set => textBoxTransactionDescription.Text = value;
        }



        public void SetAccountInfo(AccountModel account, string phone, string citizenID)
        {
            if (account != null)
            {
                textBoxAccountName.Text = account.AccountName;
                textBoxPhone.Text = phone;
                textBoxCitizenID.Text = citizenID;
                textBoxBalance.Text = account.Balance.ToString("#,##0") + " VND";
            }
            else
            {
                textBoxAccountName.Text = "";
                textBoxPhone.Text = "";
                textBoxCitizenID.Text = "";
                textBoxBalance.Text = "";
            }
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            CancelRequested?.Invoke(this, EventArgs.Empty);
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            ConfirmRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
