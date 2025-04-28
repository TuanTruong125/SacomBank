using System;
using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Views.Employee;
using Microsoft.Data.SqlClient;
using QuanLyThongTinKhachHangSacomBank.Data;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class EmployeeHomeController
    {
        private readonly IEmployeeHomeView view;
        private readonly EmployeeModel employee;
        private readonly DatabaseContext dbContext;

        public EmployeeHomeController(IEmployeeHomeView view, EmployeeModel employee, DatabaseContext dbContext)
        {
            this.view = view;
            this.employee = employee;
            this.dbContext = dbContext;

            InitializeView();
        }

        private void InitializeView()
        {
            if (employee != null)
            {
                view.SetEmployeeName(employee.EmployeeName?.ToUpper() ?? "N/A");
                UpdateNotificationIcon();
            }
            else
            {
                view.SetEmployeeName("N/A");
            }
        }

        public void UpdateNotificationIcon()
        {
            try
            {
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand("SELECT COUNT(*) FROM NOTIFICATION WHERE EmployeeID = @EmployeeID AND NotificationStatus = @Status", connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", view.EmployeeID);
                        command.Parameters.AddWithValue("@Status", "Chưa xem");
                        int unreadCount = (int)command.ExecuteScalar();

                        if (unreadCount > 0)
                        {
                            view.SetNotificationIcon(Properties.Resources.Alarm); // Chuông reng
                        }
                        else
                        {
                            view.SetNotificationIcon(Properties.Resources.Notification); // Chuông thường
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi khi kiểm tra trạng thái thông báo: {ex.Message}");
            }
        }

        public void UpdateNotificationStatus()
        {
            try
            {
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand("UPDATE NOTIFICATION SET NotificationStatus = @Status WHERE EmployeeID = @EmployeeID AND NotificationStatus = @OldStatus", connection))
                    {
                        command.Parameters.AddWithValue("@Status", "Đã xem");
                        command.Parameters.AddWithValue("@EmployeeID", view.EmployeeID);
                        command.Parameters.AddWithValue("@OldStatus", "Chưa xem");
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi khi cập nhật trạng thái thông báo: {ex.Message}");
            }
        }
    }
}