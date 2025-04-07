using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThongTinKhachHangSacomBank.Views.Common.Withdraw
{
    public interface IWithdrawViewData
    {
        string AccountName { get; }
        string AccountID { get; }
        string Phone { get; }
        string CitizenID { get; }
        string Balance { get; }
        string Amount { get; }
        string Description { get; }
        void ShowError(string message);
        void HideError();
        event EventHandler ConfirmRequested;
        event EventHandler CancelRequested;
    }

    public partial class UC_WithdrawInfo : UserControl, IWithdrawViewData
    {
        public event EventHandler ConfirmRequested;
        public event EventHandler CancelRequested;

        public UC_WithdrawInfo()
        {
            InitializeComponent();
        }



        public string AccountName => textBoxAccountName.Text;
        public string AccountID => textBoxAccountID.Text;
        public string Phone => textBoxPhone.Text;
        public string CitizenID => textBoxCitizenID.Text;
        public string Balance => textBoxBalance.Text;
        public string Amount => textBoxAmount.Text;
        public string Description => textBoxDescription.Text;



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
