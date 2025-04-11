using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Notification;
using QuanLyThongTinKhachHangSacomBank.Controllers;
using QuanLyThongTinKhachHangSacomBank.Models;

namespace QuanLyThongTinKhachHangSacomBank.Views.Employee
{
    public partial class UC_Home : UserControl
    {
        private readonly NotificationController notificationController;
        private readonly EmployeeModel currentEmployee;

        public UC_Home(EmployeeModel employee)
        {
            try
            {
                this.currentEmployee = employee;
                InitializeComponent();
                notificationController = new NotificationController();

                if (currentEmployee != null)
                {
                    labelEmployeeName.Text = currentEmployee.EmployeeName?.ToUpper() ?? "N/A";
                }
                else
                {
                    labelEmployeeName.Text = "N/A";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo UC_Home: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void buttonNotification_Click(object sender, EventArgs e)
        {
            try
            {
                notificationController.OpenNotification(new UC_EmployeeNotification());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở FormNotification: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
