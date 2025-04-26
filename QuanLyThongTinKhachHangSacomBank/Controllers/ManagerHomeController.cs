using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Views.Manager;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    public class ManagerHomeController
    {
        private readonly IManagerHomeView view;
        private readonly DatabaseContext dbContext;
        private readonly IConfiguration configuration;
        private readonly EmployeeModel currentEmployee;

        public ManagerHomeController(IManagerHomeView view, IConfiguration configuration, DatabaseContext dbContext, EmployeeModel currentEmployee = null)
        {
            this.view = view;
            this.configuration = configuration;
            this.dbContext = dbContext;
            this.currentEmployee = currentEmployee;
        }

        public void LoadNotificationTypes()
        {
            try
            {
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT NotificationTypeName FROM NOTIFICATION_TYPE WHERE NotificationTypeName IN (N'Hệ thống', N'Nội bộ')";
                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            List<string> notificationTypes = new List<string>();
                            while (reader.Read())
                            {
                                notificationTypes.Add(reader.GetString(0));
                            }
                            view.PopulateNotificationTypes(notificationTypes);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi tải danh sách loại thông báo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CancelNotification()
        {
            view.ClearInputs();
        }

        public void SendNotification()
        {
            string notificationType = view.GetNotificationType();
            string title = view.GetTitle();
            string message = view.GetMessage();

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(notificationType) || string.IsNullOrEmpty(title) || string.IsNullOrEmpty(message))
            {
                view.ShowMessage("Vui lòng điền đầy đủ thông tin thông báo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận gửi thông báo
            DialogResult result = MessageBox.Show("Bạn có muốn gửi thông báo không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            try
            {
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();

                    // Lấy NotificationTypeID
                    int notificationTypeId = 0;
                    string typeQuery = "SELECT NotificationTypeID FROM NOTIFICATION_TYPE WHERE NotificationTypeName = @NotificationTypeName";
                    using (var typeCommand = new SqlCommand(typeQuery, connection))
                    {
                        typeCommand.Parameters.AddWithValue("@NotificationTypeName", notificationType);
                        var typeResult = typeCommand.ExecuteScalar();
                        if (typeResult != null)
                            notificationTypeId = (int)typeResult;
                        else
                        {
                            view.ShowMessage("Không tìm thấy loại thông báo!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Nếu là thông báo Hệ thống: Gửi cho tất cả khách hàng và nhân viên
                    if (notificationType == "Hệ thống")
                    {
                        // Lấy danh sách CustomerID trước
                        List<int> customerIds = new List<int>();
                        string getCustomers = "SELECT CustomerID FROM CUSTOMER";
                        using (var customerReaderCommand = new SqlCommand(getCustomers, connection))
                        {
                            using (var reader = customerReaderCommand.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    customerIds.Add(reader.GetInt32(0));
                                }
                            }
                        }

                        // Gửi thông báo cho khách hàng
                        string customerQuery = @"
                            INSERT INTO [NOTIFICATION] (Title, NotificationMessage, NotificationDate, NotificationStatus, ReferenceID, CustomerID, EmployeeID, NotificationTypeID)
                            VALUES (@Title, @Message, @Date, N'Chưa xem', NULL, @CustomerID, NULL, @TypeID)";

                        using (var customerCommand = new SqlCommand(customerQuery, connection))
                        {
                            foreach (int customerId in customerIds)
                            {
                                customerCommand.Parameters.Clear();
                                customerCommand.Parameters.AddWithValue("@Title", title);
                                customerCommand.Parameters.AddWithValue("@Message", message);
                                customerCommand.Parameters.AddWithValue("@Date", DateTime.Now);
                                customerCommand.Parameters.AddWithValue("@TypeID", notificationTypeId);
                                customerCommand.Parameters.AddWithValue("@CustomerID", customerId);
                                customerCommand.ExecuteNonQuery();
                            }
                        }

                        // Lấy danh sách EmployeeID trước
                        List<int> employeeIds = new List<int>();
                        string getEmployees = "SELECT EmployeeID FROM EMPLOYEE";
                        using (var employeeReaderCommand = new SqlCommand(getEmployees, connection))
                        {
                            using (var reader = employeeReaderCommand.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    employeeIds.Add(reader.GetInt32(0));
                                }
                            }
                        }

                        // Gửi thông báo cho nhân viên
                        string employeeQuery = @"
                            INSERT INTO [NOTIFICATION] (Title, NotificationMessage, NotificationDate, NotificationStatus, ReferenceID, CustomerID, EmployeeID, NotificationTypeID)
                            VALUES (@Title, @Message, @Date, N'Chưa xem', NULL, NULL, @EmployeeID, @TypeID)";

                        using (var employeeCommand = new SqlCommand(employeeQuery, connection))
                        {
                            foreach (int employeeId in employeeIds)
                            {
                                employeeCommand.Parameters.Clear();
                                employeeCommand.Parameters.AddWithValue("@Title", title);
                                employeeCommand.Parameters.AddWithValue("@Message", message);
                                employeeCommand.Parameters.AddWithValue("@Date", DateTime.Now);
                                employeeCommand.Parameters.AddWithValue("@TypeID", notificationTypeId);
                                employeeCommand.Parameters.AddWithValue("@EmployeeID", employeeId);
                                employeeCommand.ExecuteNonQuery();
                            }
                        }
                    }
                    // Nếu là thông báo Nội bộ: Gửi cho tất cả nhân viên
                    else if (notificationType == "Nội bộ")
                    {
                        // Lấy danh sách EmployeeID trước
                        List<int> employeeIds = new List<int>();
                        string getEmployees = "SELECT EmployeeID FROM EMPLOYEE";
                        using (var employeeReaderCommand = new SqlCommand(getEmployees, connection))
                        {
                            using (var reader = employeeReaderCommand.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    employeeIds.Add(reader.GetInt32(0));
                                }
                            }
                        }

                        // Gửi thông báo cho nhân viên
                        string employeeQuery = @"
                            INSERT INTO [NOTIFICATION] (Title, NotificationMessage, NotificationDate, NotificationStatus, ReferenceID, CustomerID, EmployeeID, NotificationTypeID)
                            VALUES (@Title, @Message, @Date, N'Chưa xem', NULL, NULL, @EmployeeID, @TypeID)";

                        using (var employeeCommand = new SqlCommand(employeeQuery, connection))
                        {
                            foreach (int employeeId in employeeIds)
                            {
                                employeeCommand.Parameters.Clear();
                                employeeCommand.Parameters.AddWithValue("@Title", title);
                                employeeCommand.Parameters.AddWithValue("@Message", message);
                                employeeCommand.Parameters.AddWithValue("@Date", DateTime.Now);
                                employeeCommand.Parameters.AddWithValue("@TypeID", notificationTypeId);
                                employeeCommand.Parameters.AddWithValue("@EmployeeID", employeeId);
                                employeeCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    view.ShowMessage("Gửi thông báo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    view.ClearInputs();
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi gửi thông báo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}