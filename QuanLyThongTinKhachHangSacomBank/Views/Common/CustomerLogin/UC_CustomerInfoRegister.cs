using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThongTinKhachHangSacomBank.Views.Common.CustomerLogin
{
    public interface ICustomerInfoRegisterView
    {
        event EventHandler ConfirmRequested;
        event EventHandler ReturnRequested;

        string FullName { get; }
        string CitizenID { get; }
        string Gender { get; }
        DateTime DateOfBirth { get; }
        string Nationality { get; }
        string Address { get; }
        string Phone { get; }
        string Email { get; }
        string CustomerType { get; }

        void ShowError(string message);
        void HideError();
    }

    public partial class UC_CustomerInfoRegister : UserControl, ICustomerInfoRegisterView
    {
        public event EventHandler ConfirmRequested;
        public event EventHandler ReturnRequested;

        public string FullName => textBoxFullName.Text;
        public string CitizenID => textBoxCitizenID.Text;
        public string Gender => comboBoxGender.SelectedItem?.ToString();
        public DateTime DateOfBirth => dateTimePickerDateOfBirth.Value;
        public string Nationality => textBoxNationality.Text;
        public string Address => textBoxCustomerAddress.Text;
        public string Phone => textBoxPhone.Text;
        public string Email => textBoxEmail.Text;
        public string CustomerType => comboBoxCustomerTypeName.SelectedItem?.ToString();

        public UC_CustomerInfoRegister()
        {
            InitializeComponent();

            // Chỉ cho phép nhập số vào textBoxPhone
            textBoxPhone.KeyPress += (sender, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            };

            // Chỉ cho phép nhập số vào textBoxCitizenID
            textBoxCitizenID.KeyPress += (sender, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            };
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

        private void cyberButtonReturn_Click(object sender, EventArgs e)
        {
            ReturnRequested?.Invoke(this, EventArgs.Empty);
        }

        private void cyberButtonConfirm_Click(object sender, EventArgs e)
        {
            ConfirmRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
