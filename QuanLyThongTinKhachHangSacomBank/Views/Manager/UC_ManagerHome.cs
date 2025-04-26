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
using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Data;

namespace QuanLyThongTinKhachHangSacomBank.Views.Manager
{
    public interface IManagerHomeView
    {
        string GetNotificationType();
        string GetTitle();
        string GetMessage();
        void ClearInputs();
        void PopulateNotificationTypes(List<string> notificationTypes);
        void ShowMessage(string message, string caption, MessageBoxButtons buttons, MessageBoxIcon icon);
    }

    public partial class UC_ManagerHome : UserControl, IManagerHomeView
    {
        private readonly NotificationController notificationController;
        private readonly ManagerHomeController managerHomeController;
        private readonly EmployeeModel currentEmployee;
        private readonly DatabaseContext dbContext;
        private readonly IConfiguration configuration;

        public UC_ManagerHome(EmployeeModel employee, IConfiguration configuration, DatabaseContext dbContext)
        {
            try
            {
                this.currentEmployee = employee;
                this.configuration = configuration;
                this.dbContext = dbContext;
                InitializeComponent();
                notificationController = new NotificationController();
                managerHomeController = new ManagerHomeController(this, configuration, dbContext, currentEmployee);

                if (currentEmployee != null)
                {
                    labelEmployeeName.Text = currentEmployee.EmployeeName.ToUpper();
                }

                // Load danh sách loại thông báo khi khởi tạo
                managerHomeController.LoadNotificationTypes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo UC_ManagerHome: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        // Triển khai IManagerHomeView
        public string GetNotificationType()
        {
            return comboBoxNotificationTypeName.SelectedItem?.ToString() ?? string.Empty;
        }

        public string GetTitle()
        {
            return textBoxTitle.Text.Trim();
        }

        public string GetMessage()
        {
            return richTextBoxMessage.Text.Trim();
        }

        public void ClearInputs()
        {
            comboBoxNotificationTypeName.SelectedIndex = -1;
            textBoxTitle.Text = string.Empty;
            richTextBoxMessage.Text = string.Empty;
        }

        public void PopulateNotificationTypes(List<string> notificationTypes)
        {
            comboBoxNotificationTypeName.Items.Clear();
            comboBoxNotificationTypeName.Items.AddRange(notificationTypes.ToArray());
        }

        public void ShowMessage(string message, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            MessageBox.Show(message, caption, buttons, icon);
        }



        private void buttonNotification_Click(object sender, EventArgs e)
        {
            try
            {
                notificationController.OpenNotification(new UC_ManagerNotification());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở FormNotification: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cyberButtonCancel_Click(object sender, EventArgs e)
        {
            try
            {
                managerHomeController.CancelNotification();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hủy thông báo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cyberButtonSend_Click(object sender, EventArgs e)
        {
            try
            {
                managerHomeController.SendNotification();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi thông báo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
