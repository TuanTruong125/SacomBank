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
    public interface ICustomerForgotPasswordView
    {
        event EventHandler ConfirmRequested;
        event EventHandler ReturnRequested; 

        string Phone { get; }
        string Email { get; }
        void ShowError(string message);
        void HideError();
    }

    public partial class UC_CustomerForgotPassword : UserControl, ICustomerForgotPasswordView
    {
        public event EventHandler ConfirmRequested;
        public event EventHandler ReturnRequested;

        public string Phone => textBoxPhone.Text;
        public string Email => textBoxEmail.Text;

        public UC_CustomerForgotPassword()
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
        }

        private void cyberButtonReturn_Click(object sender, EventArgs e)
        {
            ReturnRequested?.Invoke(this, EventArgs.Empty);
        }

        private void cyberButtonConfirm_Click(object sender, EventArgs e)
        {
            ConfirmRequested?.Invoke(this, EventArgs.Empty);
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
    }
}
