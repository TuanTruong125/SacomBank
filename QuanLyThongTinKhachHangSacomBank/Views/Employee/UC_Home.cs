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
using QuanLyThongTinKhachHangSacomBank.Data;

namespace QuanLyThongTinKhachHangSacomBank.Views.Employee
{
    public interface IEmployeeHomeView
    {
        void SetEmployeeName(string name);
        void SetNotificationIcon(Image image);

        int EmployeeID { get; }
    }

    public partial class UC_Home : UserControl, IEmployeeHomeView
    {
        private readonly NotificationController notificationController;
        private readonly EmployeeModel currentEmployee;
        private readonly DatabaseContext dbContext;
        private readonly EmployeeHomeController employeeHomeController;

        public int EmployeeID => currentEmployee.EmployeeID;

        public UC_Home(EmployeeModel employee, DatabaseContext dbContext)
        {
            try
            {
                this.currentEmployee = employee;
                this.dbContext = dbContext;
                InitializeComponent();
                notificationController = new NotificationController();
                employeeHomeController = new EmployeeHomeController(this, employee, dbContext);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo UC_Home: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public void SetEmployeeName(string name)
        {
            labelEmployeeName.Text = name;
        }

        public void SetNotificationIcon(Image image)
        {
            buttonNotification.Image = image;
        }



        private void buttonNotification_Click(object sender, EventArgs e)
        {
            try
            {
                employeeHomeController.UpdateNotificationStatus();
                employeeHomeController.UpdateNotificationIcon();
                notificationController.OpenNotification(new UC_EmployeeNotification(currentEmployee.EmployeeID, dbContext));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở FormNotification: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
