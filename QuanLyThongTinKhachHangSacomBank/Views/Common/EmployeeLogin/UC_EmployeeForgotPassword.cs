using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThongTinKhachHangSacomBank.Views.Common.EmployeeLogin
{
    public interface IEmployeeForgotPasswordView
    {
        event EventHandler ConfirmRequested;
        event EventHandler ReturnRequested;

        string EmployeePhone { get; }
        string EmployeeEmail { get; }
        void ShowError(string message);
        void HideError();
    }

    public partial class UC_EmployeeForgotPassword : UserControl, IEmployeeForgotPasswordView
    {
        public event EventHandler ConfirmRequested;
        public event EventHandler ReturnRequested;

        public string EmployeePhone => textBoxEmployeePhone.Text;
        public string EmployeeEmail => textBoxEmployeeEmail.Text;

        public UC_EmployeeForgotPassword()
        {
            InitializeComponent();
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
