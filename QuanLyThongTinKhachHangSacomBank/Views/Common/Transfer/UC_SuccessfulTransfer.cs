using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThongTinKhachHangSacomBank.Views.Common.Transfer
{
    public interface ISuccessfulTransferView
    {
        string Amount { set; }
        string CustomerName { set; }
        string CustomerAccountID { set; }
        string AccountBalance { set; }
        string ReceiverName { set; }
        string ReceiverAccountID { set; }
        string ReceiverBank { set; }
        string TransactionDate { set; }
        string EmployeeName { set; }
        string TransactionDescription { set; }

        event EventHandler DoneClicked;
        event EventHandler InvoiceClicked;
    }

    public partial class UC_SuccessfulTransfer : UserControl, ISuccessfulTransferView
    {
        public event EventHandler DoneClicked;
        public event EventHandler InvoiceClicked;

        public UC_SuccessfulTransfer()
        {
            InitializeComponent();
            buttonDone.Click += (s, e) => DoneClicked?.Invoke(this, EventArgs.Empty);
            buttonInvoice.Click += (s, e) => InvoiceClicked?.Invoke(this, EventArgs.Empty);
        }

        public string Amount
        {
            set => labelAmount.Text = value;
        }

        public string CustomerName
        {
            set => labelCustomerName.Text = value;
        }

        public string CustomerAccountID
        {
            set => labelCustomerAccountID.Text = value;
        }

        public string AccountBalance
        {
            set => labelAccountBalance.Text = value;
        }

        public string ReceiverName
        {
            set => labelReceiverName.Text = value;
        }

        public string ReceiverAccountID
        {
            set => labelReceiverAccountID.Text = value;
        }

        public string ReceiverBank
        {
            set => labelReceiverBank.Text = value;
        }

        public string TransactionDate
        {
            set => labelTransactionDate.Text = value;
        }

        public string EmployeeName
        {
            set => labelEmployeeName.Text = value;
        }

        public string TransactionDescription
        {
            set => labelTransactionDescription.Text = value;
        }

        private void UC_SuccessfulTransfer_Load(object sender, EventArgs e)
        {

        }
    }
}
