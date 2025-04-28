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
    public interface ICustomerNotificationView
    {
        void LoadNotifications(List<CustomerNotificationDisplayModel> notifications);
        void SetNotificationDetails(string title, string message);

        event EventHandler<DataGridViewCellEventArgs> NotificationSelected;
    }

    public partial class UC_CustomerNotification: UserControl, ICustomerNotificationView
    {
        private readonly CustomerNotificationController controller;

        public event EventHandler<DataGridViewCellEventArgs> NotificationSelected;

        public UC_CustomerNotification(int customerId, DatabaseContext dbContext)
        {
            InitializeComponent();

            dataGridViewNotification.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewNotification.MultiSelect = false;
            dataGridViewNotification.CellClick += (s, e) => NotificationSelected?.Invoke(this, e);

            controller = new CustomerNotificationController(this, customerId, dbContext);
        }

        public void LoadNotifications(List<CustomerNotificationDisplayModel> notifications)
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

    public class CustomerNotificationDisplayModel
    {
        public string NotificationTypeName { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string NotificationDate { get; set; }
        public string NotificationStatus { get; set; }
    }
}
