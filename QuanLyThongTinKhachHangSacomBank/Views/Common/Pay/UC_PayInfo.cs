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

namespace QuanLyThongTinKhachHangSacomBank.Views.Common.Pay
{
    public interface IPayViewData
    {
        string TransactionCode { get; set; }
        string AccountName { get; }
        string AccountID { get; set; }
        string Phone { get; }
        string CitizenID { get; }
        string Balance { get; }
        string PayLoanID { get; }
        string ServiceID { get; set; }
        string RemainingDebt { get; set; }
        string Amount { get; set; }
        string TransactionDescription { get; set; }
        void ShowError(string message);
        void HideError();
        void SetSenderInfo(AccountModel account, string phone, string citizenID);

        event EventHandler ConfirmRequested;
        event EventHandler CancelRequested;
        event EventHandler PayLoanIDLostFocus;
        event EventHandler SenderAccountIDLostFocus; // Thêm sự kiện cho mã tài khoản người gửi
    }

    public partial class UC_PayInfo : UserControl, IPayViewData
    {
        public event EventHandler ConfirmRequested;
        public event EventHandler CancelRequested;
        public event EventHandler PayLoanIDLostFocus;
        public event EventHandler SenderAccountIDLostFocus;

        private readonly AccountModel currentAccount;
        private readonly bool isEmployee;

        public UC_PayInfo(AccountModel currentAccount, bool isEmployee)
        {
            this.currentAccount = currentAccount;
            this.isEmployee = isEmployee;
            InitializeComponent();
            SetupControls();
        }

        private void SetupControls()
        {
            // Hạn chế các trường thông tin người gửi (trừ mã tài khoản nếu là nhân viên)
            textBoxAccountName.ReadOnly = true;
            textBoxPhone.ReadOnly = true;
            textBoxCitizenID.ReadOnly = true;
            textBoxBalance.ReadOnly = true;

            textBoxPhone.Enabled = false;
            textBoxCitizenID.Enabled = false;
            textBoxBalance.Enabled = false;

            // Đặt các trường liên quan đến thanh toán thành không chỉnh sửa được
            textBoxServiceID.Enabled = false;
            textBoxRemainingDebt.Enabled = false;
            textBoxAmount.Enabled = false;
            textBoxTransactionDescription.ReadOnly = true;

            // Chỉ cho phép nhập mã thanh toán
            textBoxPayLoanID.Enabled = true;
            textBoxPayLoanID.ReadOnly = false;

            // Nếu là nhân viên, cho phép nhập mã tài khoản
            if (isEmployee)
            {
                textBoxAccountID.ReadOnly = false;
                textBoxAccountID.Enabled = true;
                textBoxAccountID.LostFocus += TextBoxSenderAccountID_LostFocus;
            }
            else
            {
                textBoxAccountID.ReadOnly = true;
                textBoxAccountID.Enabled = false;
            }

            // Đăng ký sự kiện LostFocus cho textBoxPayLoanID
            textBoxPayLoanID.LostFocus += TextBoxPayLoanID_LostFocus;
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
        public string PayLoanID => textBoxPayLoanID.Text;
        public string ServiceID
        {
            get => textBoxServiceID.Text;
            set => textBoxServiceID.Text = value;
        }

        public string RemainingDebt
        {
            get => textBoxRemainingDebt.Text;
            set => textBoxRemainingDebt.Text = value;
        }

        public string Amount
        {
            get => textBoxAmount.Text;
            set => textBoxAmount.Text = value;
        }

        public string TransactionDescription
        {
            get => textBoxTransactionDescription.Text;
            set => textBoxTransactionDescription.Text = value;
        }



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

        public void ShowError(string message)
        {
            labelError.Text = message;
            labelError.Visible = true;
        }

        public void HideError()
        {
            labelError.Visible = false;
        }

        private void TextBoxSenderAccountID_LostFocus(object sender, EventArgs e)
        {
            SenderAccountIDLostFocus?.Invoke(this, EventArgs.Empty);
        }

        private void TextBoxPayLoanID_LostFocus(object sender, EventArgs e)
        {
            PayLoanIDLostFocus?.Invoke(this, EventArgs.Empty);
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
