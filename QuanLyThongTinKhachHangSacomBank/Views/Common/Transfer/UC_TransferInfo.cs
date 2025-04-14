using System;
using System.Windows.Forms;
using QuanLyThongTinKhachHangSacomBank.Models;

namespace QuanLyThongTinKhachHangSacomBank.Views.Common.Transfer
{
    public interface ITransferViewData
    {
        string TransactionCode { get; set; }
        string AccountName { get; }
        string AccountID { get; set; } // Thêm setter để có thể cập nhật từ controller
        string Phone { get; }
        string CitizenID { get; }
        string Balance { get; }
        string ReceiverAccountName { get; }
        string ReceiverAccountID { get; }
        string ReceiverPhone { get; }
        string ReceiverCitizenID { get; }
        int BankSelectedIndex { get; }
        string Amount { get; }
        string TransactionDescription { get; }
        void ShowError(string message);
        void HideError();
        void SetSenderInfo(AccountModel account, string phone, string citizenID);
        void SetReceiverInfo(AccountModel account, string phone, string citizenID);
        void EnableBankComboBox();
        event EventHandler ConfirmRequested;
        event EventHandler CancelRequested;
        event EventHandler ReceiverAccountIDLostFocus;
        event EventHandler SenderAccountIDLostFocus; // Thêm sự kiện cho mã tài khoản người gửi
    }

    public partial class UC_TransferInfo : UserControl, ITransferViewData
    {
        public event EventHandler ConfirmRequested;
        public event EventHandler CancelRequested;
        public event EventHandler ReceiverAccountIDLostFocus;
        public event EventHandler SenderAccountIDLostFocus;

        private readonly AccountModel currentAccount;
        private readonly bool isEmployee;

        public UC_TransferInfo(AccountModel currentAccount, bool isEmployee)
        {
            this.currentAccount = currentAccount;
            this.isEmployee = isEmployee;
            InitializeComponent();
            SetupControls();
        }

        public void EnableBankComboBox()
        {
            comboBoxBank.Enabled = true;
        }

        private void SetupControls()
        {
            comboBoxBank.SelectedIndex = -1;
            
            textBoxReceiverAccountID.Enabled = false; // Khóa nhập mã tài khoản người nhận ban đầu

            // Hạn chế trường thông tin người gửi (trừ mã tài khoản) 
            textBoxAccountName.ReadOnly = true;
            textBoxPhone.ReadOnly = true;
            textBoxCitizenID.ReadOnly = true;
            textBoxBalance.ReadOnly = true;

            textBoxPhone.Enabled = false;
            textBoxCitizenID.Enabled = false;
            textBoxBalance.Enabled = false;

            // Hạn chế trường thông tin người nhận (trừ mã tài khoản) 
            textBoxReceiverAccountName.ReadOnly = true;
            textBoxReceiverPhone.ReadOnly = true;
            textBoxReceiverCitizenID.ReadOnly = true;

            textBoxReceiverPhone.Enabled = false;
            textBoxReceiverCitizenID.Enabled = false;

            // Nếu là nhân viên, cho phép nhập mã tài khoản người gửi
            if (isEmployee)
            {
                comboBoxBank.Enabled = false;
                textBoxAccountID.ReadOnly = false; // Cho phép chỉnh sửa mã tài khoản người gửi
                textBoxAccountID.Enabled = true; // Đảm bảo ô có thể nhập
                textBoxAccountID.LostFocus += TextBoxSenderAccountID_LostFocus;
            }
            else
            {
                textBoxAccountID.ReadOnly = true; // Khách hàng không được chỉnh sửa mã tài khoản
                textBoxAccountID.Enabled = false;
            }

            // Đặt giá trị mặc định cho comboBoxBank để kích hoạt textBoxReceiverAccountID
            if (comboBoxBank.Items.Count > 0)
            {
                comboBoxBank.SelectedIndex = -1; // Chọn "Sacombank" làm mặc định
                textBoxReceiverAccountID.Enabled = true; // Kích hoạt ô mã tài khoản người nhận
            }

            comboBoxBank.SelectedIndexChanged += ComboBoxBank_SelectedIndexChanged;
            textBoxReceiverAccountID.LostFocus += TextBoxReceiverAccountID_LostFocus;
            textBoxAmount.TextChanged += TextBoxAmount_TextChanged;
            textBoxAmount.KeyPress += TextBoxAmount_KeyPress;
        }


        public string TransactionCode { get; set; }
        public string AccountName => textBoxAccountName.Text;
        public string AccountID
        {
            get => textBoxAccountID.Text;
            set => textBoxAccountID.Text = value; // Thêm setter để controller có thể cập nhật
        }
        public string Phone => textBoxPhone.Text;
        public string CitizenID => textBoxCitizenID.Text;
        public string Balance => textBoxBalance.Text;
        public string ReceiverAccountName => textBoxReceiverAccountName.Text;
        public string ReceiverAccountID => textBoxReceiverAccountID.Text;
        public string ReceiverPhone => textBoxReceiverPhone.Text;
        public string ReceiverCitizenID => textBoxReceiverCitizenID.Text;
        public int BankSelectedIndex => comboBoxBank.SelectedIndex;
        public string Amount => textBoxAmount.Text;
        public string TransactionDescription => textBoxTransactionDescription.Text;

        public void SetSenderInfo(AccountModel account, string phone, string citizenID)
        {
            if (account != null)
            {
                textBoxAccountName.Text = account.AccountName;
                textBoxAccountID.Text = account.AccountCode;
                textBoxPhone.Text = phone;
                textBoxCitizenID.Text = citizenID;
                textBoxBalance.Text = account.Balance.ToString("N0") + " VND";
            }
            else
            {
                textBoxAccountName.Text = "";
                textBoxAccountID.Text = "";
                textBoxPhone.Text = "";
                textBoxCitizenID.Text = "";
                textBoxBalance.Text = "";
            }
        }

        public void SetReceiverInfo(AccountModel account, string phone, string citizenID)
        {
            if (account != null)
            {
                textBoxReceiverAccountName.Text = account.AccountName;
                textBoxReceiverPhone.Text = phone;
                textBoxReceiverCitizenID.Text = citizenID;
            }
            else
            {
                textBoxReceiverAccountName.Text = "";
                textBoxReceiverPhone.Text = "";
                textBoxReceiverCitizenID.Text = "";
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

        private void ComboBoxBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxReceiverAccountID.Enabled = comboBoxBank.SelectedIndex != -1;
            UpdateTransactionDescription();
        }

        private void TextBoxSenderAccountID_LostFocus(object sender, EventArgs e)
        {
            SenderAccountIDLostFocus?.Invoke(this, EventArgs.Empty);
        }

        private void TextBoxReceiverAccountID_LostFocus(object sender, EventArgs e)
        {
            ReceiverAccountIDLostFocus?.Invoke(this, EventArgs.Empty);
        }

        private void TextBoxAmount_TextChanged(object sender, EventArgs e)
        {
            // Định dạng số tiền: thêm dấu phẩy sau mỗi 3 chữ số
            string text = textBoxAmount.Text.Replace(",", ""); // Loại bỏ dấu phẩy hiện tại
            if (string.IsNullOrEmpty(text)) return;

            if (decimal.TryParse(text, out decimal number))
            {
                // Định dạng số với dấu phẩy
                textBoxAmount.TextChanged -= TextBoxAmount_TextChanged; // Ngắt sự kiện để tránh đệ quy
                textBoxAmount.Text = number.ToString("#,##0");
                textBoxAmount.SelectionStart = textBoxAmount.Text.Length; // Đặt con trỏ ở cuối
                textBoxAmount.TextChanged += TextBoxAmount_TextChanged; // Kích hoạt lại sự kiện
            }

            UpdateTransactionDescription();
        }

        private void TextBoxAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và phím Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Chặn ký tự không phải số
            }
        }

        private void UpdateTransactionDescription()
        {
            if (comboBoxBank.SelectedIndex != -1)
            {
                textBoxTransactionDescription.Text = $"{AccountName} chuyen tien tu {comboBoxBank.SelectedItem}";
            }
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