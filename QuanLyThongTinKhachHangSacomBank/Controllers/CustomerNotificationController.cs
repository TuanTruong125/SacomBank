using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Notification;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class CustomerNotificationController
    {
        private readonly ICustomerNotificationView view;
        private readonly int customerId;
        private readonly DatabaseContext dbContext;
        private List<CustomerNotificationDisplayModel> notifications;

        public CustomerNotificationController(ICustomerNotificationView view, int customerId, DatabaseContext dbContext)
        {
            this.view = view;
            this.customerId = customerId;
            this.dbContext = dbContext;

            view.NotificationSelected += OnNotificationSelected;
            LoadNotifications();
        }

        private void LoadNotifications()
        {
            try
            {
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    string query = @"
                        SELECT nt.NotificationTypeName, n.Title, n.NotificationMessage, n.NotificationDate, n.NotificationStatus
                        FROM NOTIFICATION n
                        JOIN NOTIFICATION_TYPE nt ON n.NotificationTypeID = nt.NotificationTypeID
                        WHERE n.CustomerID = @CustomerID
                        ORDER BY n.NotificationDate DESC";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", customerId);

                        using (var reader = command.ExecuteReader())
                        {
                            notifications = new List<CustomerNotificationDisplayModel>();

                            while (reader.Read())
                            {
                                var notification = new CustomerNotificationDisplayModel
                                {
                                    NotificationTypeName = reader.GetString(0),
                                    Title = reader.GetString(1),
                                    Message = reader.GetString(2),
                                    NotificationDate = reader.GetDateTime(3).ToString("dd/MM/yyyy HH:mm:ss"),
                                    NotificationStatus = reader.GetString(4)
                                };
                                notifications.Add(notification);
                            }
                        }
                    }
                }

                view.LoadNotifications(notifications);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi khi tải thông báo: {ex.Message}");
                view.LoadNotifications(new List<CustomerNotificationDisplayModel>());
            }
        }

        private void OnNotificationSelected(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < notifications.Count)
            {
                var selectedNotification = notifications[e.RowIndex];
                view.SetNotificationDetails(selectedNotification.Title, selectedNotification.Message);
            }
        }
    }
}