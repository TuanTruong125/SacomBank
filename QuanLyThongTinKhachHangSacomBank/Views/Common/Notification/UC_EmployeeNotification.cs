using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThongTinKhachHangSacomBank.Controllers;
using QuanLyThongTinKhachHangSacomBank.Data;

namespace QuanLyThongTinKhachHangSacomBank.Views.Common.Notification
{
    public interface IEmployeeNotificationView
    {
        void LoadNotifications(List<EmployeeNotificationDisplayModel> notifications);
        void SetNotificationDetails(string title, string message);
        event EventHandler<DataGridViewCellEventArgs> NotificationSelected;
    }

    public partial class UC_EmployeeNotification : UserControl, IEmployeeNotificationView
    {
        private readonly EmployeeNotificationController controller;

        public event EventHandler<DataGridViewCellEventArgs> NotificationSelected;

        public UC_EmployeeNotification(int employeeId, DatabaseContext dbContext)
        {
            InitializeComponent();

            dataGridViewNotification.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewNotification.MultiSelect = false;
            dataGridViewNotification.CellClick += (s, e) => NotificationSelected?.Invoke(this, e);

            controller = new EmployeeNotificationController(this, employeeId, dbContext);
        }

        public void LoadNotifications(List<EmployeeNotificationDisplayModel> notifications)
        {
            dataGridViewNotification.Rows.Clear();

            foreach (var notification in notifications)
            {
                dataGridViewNotification.Rows.Add(
                    notification.NotificationTypeName,
                    notification.Title,
                    notification.Message,
                    notification.NotificationDate,
                    notification.NotificationStatus
                );
            }
        }

        public void SetNotificationDetails(string title, string message)
        {
            textBoxTitle.Text = title;
            richTextBoxMessage.Text = message;
        }
    }

    public class EmployeeNotificationDisplayModel
    {
        public string NotificationTypeName { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string NotificationDate { get; set; }
        public string NotificationStatus { get; set; }
    }
}
