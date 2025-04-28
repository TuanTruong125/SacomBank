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
using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Controllers;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyThongTinKhachHangSacomBank.Views.Customer
{
    public interface ICustomerPersonalView
    {
        void LoadCustomerData(CustomerModel customer, AccountModel account);
        void SetInitialState();
        void EnablePasswordEditing(bool enable, bool showPassword);
        void EnablePINEditing(bool enable);
        void FocusPasswordTextBox();
        void FocusPINTextBox();
    }

    public partial class UC_CustomerPersonal : UserControl, ICustomerPersonalView
    {
        private readonly CustomerPersonalController controller;

        public UC_CustomerPersonal(CustomerModel customer, AccountModel account, DatabaseContext dbContext, IConfiguration configuration)
        {
            InitializeComponent();
            controller = new CustomerPersonalController(this, customer, account, dbContext, configuration);

            // Chỉ cho phép nhập số vào textBoxPINCode
            textBoxPINCode.KeyPress += (sender, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (textBoxPINCode.Text.Length >= 6 && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            };
        }

        public void LoadCustomerData(CustomerModel customer, AccountModel account)
        {
            textBoxCustomerID.Text = customer.CustomerCode;
            textBoxFullName.Text = customer.FullName;
            textBoxGender.Text = customer.Gender;
            textBoxDateOfBirth.Text = customer.DateOfBirth.ToString("dd/MM/yyyy");
            textBoxCitizenID.Text = customer.CitizenID;
            textBoxNationality.Text = customer.Nationality;
            textBoxAddress.Text = customer.CustomerAddress;
            textBoxPhone.Text = customer.Phone;
            textBoxEmail.Text = customer.Email;
            textBoxRegistrationDate.Text = customer.RegistrationDate.ToString("dd/MM/yyyy");
            textBoxUsername.Text = account.Username;
            textBoxPassword.Text = account.UserPassword;
            textBoxPINCode.Text = account.PINCode ?? string.Empty;
        }

        public void SetInitialState()
        {
            // Tất cả TextBox đều không thể chỉnh sửa
            textBoxCustomerID.Enabled = false;
            textBoxFullName.Enabled = false;
            textBoxGender.Enabled = false;
            textBoxDateOfBirth.Enabled = false;
            textBoxCitizenID.Enabled = false;
            textBoxNationality.Enabled = false;
            textBoxAddress.Enabled = false;
            textBoxPhone.Enabled = false;
            textBoxEmail.Enabled = false;
            textBoxRegistrationDate.Enabled = false;
            textBoxUsername.Enabled = false;
            textBoxPassword.Enabled = false;
            textBoxPINCode.Enabled = false;

            // Ẩn mật khẩu và mã PIN
            textBoxPassword.UseSystemPasswordChar = true;
            textBoxPINCode.UseSystemPasswordChar = true;

            // Chỉ hiển thị nút Sửa
            cyberButtonEdit.Visible = true;
            cyberButtonCancel.Visible = false;
            cyberButtonConfirm.Visible = false;
        }

        public void EnablePasswordEditing(bool enable, bool showPassword)
        {
            textBoxPassword.Enabled = enable;
            textBoxPassword.ReadOnly = false;
            textBoxPassword.UseSystemPasswordChar = !showPassword;

            // Ẩn nút Sửa, hiển thị nút Lưu và Hủy
            cyberButtonEdit.Visible = !enable;
            cyberButtonCancel.Visible = enable;
            cyberButtonConfirm.Visible = enable;

            // Vô hiệu hóa chỉnh sửa mã PIN
            textBoxPINCode.Enabled = false;
        }

        public void EnablePINEditing(bool enable)
        {
            textBoxPINCode.Enabled = enable;
            textBoxPINCode.ReadOnly = false;
            textBoxPINCode.UseSystemPasswordChar = !enable;

            // Ẩn nút Sửa, hiển thị nút Lưu và Hủy
            cyberButtonEdit.Visible = !enable;
            cyberButtonCancel.Visible = enable;
            cyberButtonConfirm.Visible = enable;

            // Vô hiệu hóa chỉnh sửa mật khẩu
            textBoxPassword.Enabled = false;
        }

        public void FocusPasswordTextBox()
        {
            textBoxPassword.Focus();
        }

        public void FocusPINTextBox()
        {
            textBoxPINCode.Focus();
        }

        private void cyberButtonCancel_Click(object sender, EventArgs e)
        {
            controller.OnCancelButtonClicked();
        }

        private void cyberButtonEdit_Click(object sender, EventArgs e)
        {
            controller.OnEditButtonClicked();
        }

        private void cyberButtonConfirm_Click(object sender, EventArgs e)
        {
            controller.OnConfirmButtonClicked(textBoxPassword.Text, textBoxPINCode.Text);
        }
    }
}