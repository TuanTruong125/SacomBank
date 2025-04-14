using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Controllers;

namespace QuanLyThongTinKhachHangSacomBank.Views.Employee
{
    public interface IEmployeeSettingView
    {
        void LoadEmployeeData(EmployeeModel employee);
        void SetInitialState();
        void EnablePasswordEditing(bool enable, bool showPassword);
        void FocusPasswordTextBox();
    }

    public partial class UC_Setting : UserControl, IEmployeeSettingView
    {
        private readonly EmployeeSettingController controller;

        public UC_Setting(EmployeeModel employee, DatabaseContext dbContext, IConfiguration configuration)
        {
            InitializeComponent();
            controller = new EmployeeSettingController(this, employee, dbContext, configuration);
        }

        private void UC_Setting_Load(object sender, EventArgs e)
        {

        }

        public void LoadEmployeeData(EmployeeModel employee)
        {
            textBoxEmployeeID.Text = employee.EmployeeCode;
            textBoxEmployeeName.Text = employee.EmployeeName;
            textBoxEmployeeGender.Text = employee.EmployeeGender;
            textBoxEmployeeDateOfBirth.Text = employee.EmployeeDateOfBirth.ToString("dd/MM/yyyy");
            textBoxEmployeeCitizenID.Text = employee.EmployeeCitizenID;
            textBoxEmployeeAddress.Text = employee.EmployeeAddress;
            textBoxRole.Text = employee.EmployeeRole;
            textBoxEmployeePhone.Text = employee.EmployeePhone;
            textBoxEmployeeEmail.Text = employee.EmployeeEmail;
            textBoxHireDate.Text = employee.HireDate.ToString("dd/MM/yyyy");
            textBoxEmployeeUsername.Text = employee.EmployeeUsername;
            textBoxEmployeePassword.Text = employee.EmployeePassword;
        }

        public void SetInitialState()
        {
            // Tất cả TextBox đều không thể tương tác (Enabled = false)
            textBoxEmployeeID.Enabled = false;
            textBoxEmployeeName.Enabled = false;
            textBoxEmployeeGender.Enabled = false;
            textBoxEmployeeDateOfBirth.Enabled = false;
            textBoxEmployeeCitizenID.Enabled = false;
            textBoxEmployeeAddress.Enabled = false;
            textBoxRole.Enabled = false;
            textBoxEmployeePhone.Enabled = false;
            textBoxEmployeeEmail.Enabled = false;
            textBoxHireDate.Enabled = false;
            textBoxEmployeeUsername.Enabled = false;
            textBoxEmployeePassword.Enabled = false;

            // Hiển thị mật khẩu dưới dạng ký hiệu che
            textBoxEmployeePassword.UseSystemPasswordChar = true;

            // Trạng thái các nút: Chỉ hiện nút Sửa, ẩn Cancel và Confirm
            cyberButtonEdit.Visible = true;
            cyberButtonCancel.Visible = false;
            cyberButtonConfirm.Visible = false;
        }

        public void EnablePasswordEditing(bool enable, bool showPassword)
        {
            textBoxEmployeePassword.Enabled = enable;
            textBoxEmployeePassword.ReadOnly = false;
            textBoxEmployeePassword.UseSystemPasswordChar = !showPassword;

            // Ẩn nút Sửa, hiện các nút Cancel và Confirm
            cyberButtonEdit.Visible = !enable;
            cyberButtonCancel.Visible = enable;
            cyberButtonConfirm.Visible = enable;
        }

        public void FocusPasswordTextBox()
        {
            textBoxEmployeePassword.Focus();
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
            controller.OnConfirmButtonClicked(textBoxEmployeePassword.Text);
        }
    }
}
