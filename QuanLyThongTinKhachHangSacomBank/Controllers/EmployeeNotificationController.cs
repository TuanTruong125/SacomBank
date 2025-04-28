using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Notification;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class EmployeeNotificationController
    {

        private readonly IEmployeeNotificationView view;
        private readonly int employeeId;
        private readonly DatabaseContext dbContext;
        private List<EmployeeNotificationDisplayModel> notifications;

        public EmployeeNotificationController(IEmployeeNotificationView view, int employeeId, DatabaseContext dbContext)
        {
            this.view = view;
            this.employeeId = employeeId;
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
                        WHERE n.EmployeeID = @EmployeeID
                        ORDER BY n.NotificationDate DESC";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employeeId);

                        using (var reader = command.ExecuteReader())
                        {
                            notifications = new List<EmployeeNotificationDisplayModel>();

                            while (reader.Read())
                            {
                                var notification = new EmployeeNotificationDisplayModel
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
                view.LoadNotifications(new List<EmployeeNotificationDisplayModel>());
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