using Microsoft.Data.SqlClient;
using QuanLyThongTinKhachHangSacomBank.Data;
using System;
using System.Timers;
using System.Collections.Generic;

namespace QuanLyThongTinKhachHangSacomBank.AutoTasks
{
    public class CustomerTypeUpdateAutoTask
    {
        private readonly DatabaseContext dbContext;
        private System.Timers.Timer customerTypeTimer;

        // Khởi tạo task tự động, gọi lần đầu và bắt đầu timer
        public CustomerTypeUpdateAutoTask(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
            UpdateCustomerTypes();
            StartCustomerTypeUpdateTimer();
        }

        // Khởi tạo timer chạy hàng ngày vào 00:00
        private void StartCustomerTypeUpdateTimer()
        {
            DateTime now = DateTime.Now;
            DateTime nextMidnight = now.Date.AddDays(1);
            double millisecondsUntilMidnight = (nextMidnight - now).TotalMilliseconds;

            customerTypeTimer = new System.Timers.Timer(millisecondsUntilMidnight);
            customerTypeTimer.Elapsed += (s, e) =>
            {
                UpdateCustomerTypes();
                customerTypeTimer.Interval = 86400000; // 24 giờ
            };
            customerTypeTimer.AutoReset = true;
            customerTypeTimer.Start();
            System.Diagnostics.Debug.WriteLine($"CustomerTypeUpdateTimer sẽ chạy lần đầu vào {nextMidnight:dd/MM/yyyy HH:mm:ss}");
        }

        // Cập nhật loại khách hàng dựa trên số dư tài khoản và tạo thông báo
        private void UpdateCustomerTypes()
        {
            try
            {
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();

                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Lấy CustomerTypeID và NotificationTypeID
                            int individualTypeId, vipIndividualTypeId, businessTypeId, vipBusinessTypeId, notificationTypeId;

                            // Lấy CustomerTypeID
                            string getCustomerTypesQuery = @"
                                SELECT CustomerTypeID, CustomerTypeName
                                FROM CUSTOMER_TYPE
                                WHERE CustomerTypeName IN (N'Cá nhân', N'VIP Cá nhân', N'Doanh nghiệp', N'VIP Doanh nghiệp')";

                            using (var command = new SqlCommand(getCustomerTypesQuery, connection, transaction))
                            {
                                using (var reader = command.ExecuteReader())
                                {
                                    individualTypeId = vipIndividualTypeId = businessTypeId = vipBusinessTypeId = -1;

                                    while (reader.Read())
                                    {
                                        int typeId = reader.GetInt32(0);
                                        string typeName = reader.GetString(1);

                                        switch (typeName)
                                        {
                                            case "Cá nhân":
                                                individualTypeId = typeId;
                                                break;
                                            case "VIP Cá nhân":
                                                vipIndividualTypeId = typeId;
                                                break;
                                            case "Doanh nghiệp":
                                                businessTypeId = typeId;
                                                break;
                                            case "VIP Doanh nghiệp":
                                                vipBusinessTypeId = typeId;
                                                break;
                                        }
                                    }

                                    if (individualTypeId == -1 || vipIndividualTypeId == -1 || businessTypeId == -1 || vipBusinessTypeId == -1)
                                    {
                                        throw new Exception("Không tìm thấy đầy đủ các loại khách hàng (Cá nhân, VIP Cá nhân, Doanh nghiệp, VIP Doanh nghiệp) trong bảng CUSTOMER_TYPE.");
                                    }
                                }
                            }

                            // Lấy NotificationTypeID cho loại thông báo "Khuyến mãi" hoặc tương tự
                            string getNotificationTypeQuery = @"
                                SELECT NotificationTypeID
                                FROM NOTIFICATION_TYPE
                                WHERE NotificationTypeName = N'Hệ thống'";

                            using (var command = new SqlCommand(getNotificationTypeQuery, connection, transaction))
                            {
                                var result = command.ExecuteScalar();
                                if (result == null)
                                {
                                    throw new Exception("Không tìm thấy loại thông báo 'Hệ thống' trong bảng NOTIFICATION_TYPE.");
                                }
                                notificationTypeId = Convert.ToInt32(result);
                            }

                            // Lưu danh sách khách hàng được cập nhật để tạo thông báo
                            List<(int CustomerID, string CustomerTypeName)> updatedCustomers = new List<(int, string)>();

                            // B1: Cập nhật loại khách hàng Cá nhân thành VIP Cá nhân nếu số dư > 10 tỷ
                            string updateIndividualQuery = @"
                                UPDATE CUSTOMER
                                SET CustomerTypeID = @VipIndividualTypeID
                                OUTPUT INSERTED.CustomerID
                                FROM CUSTOMER c
                                INNER JOIN ACCOUNT a ON c.CustomerID = a.CustomerID
                                WHERE c.CustomerTypeID = @IndividualTypeID
                                AND a.Balance > 10000000000";

                            using (var command = new SqlCommand(updateIndividualQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@VipIndividualTypeID", vipIndividualTypeId);
                                command.Parameters.AddWithValue("@IndividualTypeID", individualTypeId);

                                using (var reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        int customerId = reader.GetInt32(0);
                                        updatedCustomers.Add((customerId, "VIP Cá nhân"));
                                    }
                                }
                            }
                            System.Diagnostics.Debug.WriteLine($"Đã cập nhật {updatedCustomers.Count} khách hàng Cá nhân thành VIP Cá nhân (số dư > 10 tỷ).");

                            // B2: Cập nhật loại khách hàng Doanh nghiệp thành VIP Doanh nghiệp nếu số dư > 30 tỷ
                            string updateBusinessQuery = @"
                                UPDATE CUSTOMER
                                SET CustomerTypeID = @VipBusinessTypeID
                                OUTPUT INSERTED.CustomerID
                                FROM CUSTOMER c
                                INNER JOIN ACCOUNT a ON c.CustomerID = a.CustomerID
                                WHERE c.CustomerTypeID = @BusinessTypeID
                                AND a.Balance > 30000000000";

                            using (var command = new SqlCommand(updateBusinessQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@VipBusinessTypeID", vipBusinessTypeId);
                                command.Parameters.AddWithValue("@BusinessTypeID", businessTypeId);

                                using (var reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        int customerId = reader.GetInt32(0);
                                        updatedCustomers.Add((customerId, "VIP Doanh nghiệp"));
                                    }
                                }
                            }
                            System.Diagnostics.Debug.WriteLine($"Đã cập nhật {updatedCustomers.Count - updatedCustomers.FindAll(c => c.CustomerTypeName == "VIP Cá nhân").Count} khách hàng Doanh nghiệp thành VIP Doanh nghiệp (số dư > 30 tỷ).");

                            // B3: Tạo thông báo cho các khách hàng được cập nhật
                            foreach (var (customerId, customerTypeName) in updatedCustomers)
                            {
                                string title = "Chúc mừng bạn đã trở thành khách hàng VIP!";
                                string message = customerTypeName == "VIP Cá nhân"
                                    ? "Chúc mừng bạn đã trở thành khách hàng VIP Cá nhân của Sacombank! Với số dư tài khoản vượt 10 tỷ, bạn sẽ được hưởng nhiều đặc quyền ưu đãi hấp dẫn. Liên hệ với chúng tôi để biết thêm chi tiết."
                                    : "Chúc mừng quý doanh nghiệp đã trở thành khách hàng VIP Doanh nghiệp của Sacombank! Với số dư tài khoản vượt 30 tỷ, quý doanh nghiệp sẽ nhận được nhiều ưu đãi đặc biệt. Vui lòng liên hệ để được hỗ trợ thêm.";

                                string insertNotificationQuery = @"
                                    INSERT INTO [NOTIFICATION] (Title, NotificationMessage, NotificationDate, NotificationStatus, CustomerID, NotificationTypeID)
                                    VALUES (@Title, @Message, @NotificationDate, N'Chưa xem', @CustomerID, @NotificationTypeID)";

                                using (var command = new SqlCommand(insertNotificationQuery, connection, transaction))
                                {
                                    command.Parameters.AddWithValue("@Title", title);
                                    command.Parameters.AddWithValue("@Message", message);
                                    command.Parameters.AddWithValue("@NotificationDate", DateTime.Now);
                                    command.Parameters.AddWithValue("@CustomerID", customerId);
                                    command.Parameters.AddWithValue("@NotificationTypeID", notificationTypeId);
                                    command.ExecuteNonQuery();
                                }
                            }
                            System.Diagnostics.Debug.WriteLine($"Đã tạo {updatedCustomers.Count} thông báo cho khách hàng được nâng cấp thành VIP.");

                            // Commit transaction
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            System.Diagnostics.Debug.WriteLine($"Lỗi khi cập nhật loại khách hàng và tạo thông báo: {ex.Message}\nStackTrace: {ex.StackTrace}");
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi khi cập nhật loại khách hàng và tạo thông báo: {ex.Message}\nStackTrace: {ex.StackTrace}");
            }
        }

        public void Stop()
        {
            customerTypeTimer?.Stop();
            customerTypeTimer?.Dispose();
        }
    }
}