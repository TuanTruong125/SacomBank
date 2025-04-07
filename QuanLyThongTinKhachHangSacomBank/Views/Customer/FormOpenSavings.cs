using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThongTinKhachHangSacomBank.Views.Customer
{
    public interface IOpenSavingsView
    {
        string AccountName { get; }
        string AccountID { get; }
        string Phone { get; }
        string CitizenID { get; }
        string ServiceID { get; }
        string ServiceTypeName { get; }
        string InterestRate { get; }
        string Duration { get; }
        DateTime CreatedDate { get; }
        string TotalPrincipalAmount { get; }
        string Description { get; }
        void ShowError(string message);
        void HideError();
        event EventHandler SendRequestClicked;
        event EventHandler CancelClicked;
    }

    public partial class FormOpenSavings : Form, IOpenSavingsView
    {
        public event EventHandler SendRequestClicked;
        public event EventHandler CancelClicked;

        public FormOpenSavings()
        {
            InitializeComponent();
        }



        public string AccountName => textBoxAccountName.Text;
        public string AccountID => textBoxAccountID.Text;
        public string Phone => textBoxPhone.Text;
        public string CitizenID => textBoxCitizenID.Text;
        public string ServiceID => textBoxServiceID.Text;
        public string ServiceTypeName => comboBoxServiceTypeName.SelectedItem?.ToString();
        public string InterestRate => textBoxInterestRate.Text;
        public string Duration => comboBoxDuration.SelectedItem?.ToString();
        public DateTime CreatedDate => dateTimePickerCreatedDate.Value;
        public string TotalPrincipalAmount => textBoxTotalPrincipalAmount.Text;
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

        private void cyberButtonSendRequest_Click(object sender, EventArgs e)
        {
            SendRequestClicked?.Invoke(this, EventArgs.Empty);
        }

        private void cyberButtonCancel_Click(object sender, EventArgs e)
        {
            CancelClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
