using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThongTinKhachHangSacomBank.Views.Common.Pay
{
    public interface ISuccessfulPayView
    {
        string Amount { set; }
        string CustomerName { set; }
        string CustomerAccountID { set; }
        string AccountBalance { set; }
        string ServiceID { set; }
        string PayLoanID { set; }
        string CustomerRemainingDebt { set; }
        string TransactionDate { set; }
        string EmployeeName { set; }
        string TransactionDescription { set; }
        
        event EventHandler DoneClicked;
        event EventHandler InvoiceClicked;
    }

    public partial class UC_SuccessfulPay: UserControl, ISuccessfulPayView
    {
        public event EventHandler DoneClicked;
        public event EventHandler InvoiceClicked;

        public UC_SuccessfulPay()
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

        public string ServiceID
        {
            set => labelServiceID.Text = value;
        }

        public string PayLoanID
        {
            set => labelPayLoanID.Text = value;
        }

        public string CustomerRemainingDebt
        {
            set => labelCustomerRemainingDebt.Text = value;
        }

        public string TransactionDate
        {
            set => labelCustomerTransactionDate.Text = value;
        }

        public string EmployeeName
        {
            set => labelEmployeeName.Text = value;
        }

        public string TransactionDescription
        {
            set => labelTransactionDescription.Text = value;
        }   
    }
}
