using System;
using Microsoft.Data.SqlClient;
using System.Timers;
using QuanLyThongTinKhachHangSacomBank.Data;

namespace QuanLyThongTinKhachHangSacomBank.AutoTasks
{
    public class ProfitAutoTask
    {
        private readonly DatabaseContext dbContext;
        private System.Timers.Timer profitTimer;

        public ProfitAutoTask(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
            CreateDailyProfitAndLinkRevenue();
            StartProfitCheckTimer();
        }

        private void StartProfitCheckTimer()
        {
            DateTime now = DateTime.Now;
            DateTime nextMidnight = now.Date.AddDays(1);
            double millisecondsUntilMidnight = (nextMidnight - now).TotalMilliseconds;

            profitTimer = new System.Timers.Timer(millisecondsUntilMidnight);
            profitTimer.Elapsed += (s, e) =>
            {
                CreateDailyProfitAndLinkRevenue();
                profitTimer.Interval = 86400000;
            };
            profitTimer.AutoReset = true;
            profitTimer.Start();
            System.Diagnostics.Debug.WriteLine($"ProfitTimer sẽ chạy lần đầu vào {nextMidnight:dd/MM/yyyy HH:mm:ss}");
        }

        private void CreateDailyProfitAndLinkRevenue()
        {
            try
            {
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();

                    DateTime currentDate = DateTime.Today;
                    int profitId;

                    // Giả định ProfitDate là DATETIME, nhưng chỉ so sánh phần ngày
                    string checkProfitQuery = @"
                        SELECT ProfitID
                        FROM PROFIT
                        WHERE CAST(ProfitDate AS DATE) = @ProfitDate";

                    using (var checkCommand = new SqlCommand(checkProfitQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@ProfitDate", currentDate);
                        var result = checkCommand.ExecuteScalar();

                        if (result == null)
                        {
                            string insertProfitQuery = @"
                                INSERT INTO PROFIT (TotalRevenue, TotalExpense, NetProfit, ProfitDate)
                                VALUES (0, 0, 0, @ProfitDate);
                                SELECT SCOPE_IDENTITY();";

                            using (var insertCommand = new SqlCommand(insertProfitQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@ProfitDate", currentDate);
                                profitId = Convert.ToInt32(insertCommand.ExecuteScalar());
                            }
                            System.Diagnostics.Debug.WriteLine($"Đã tạo ProfitID {profitId} cho ngày {currentDate:dd/MM/yyyy}");
                        }
                        else
                        {
                            profitId = Convert.ToInt32(result);
                            System.Diagnostics.Debug.WriteLine($"ProfitID {profitId} đã tồn tại cho ngày {currentDate:dd/MM/yyyy}");
                        }
                    }

                    string updateRevenueQuery = @"
                        UPDATE REVENUE
                        SET ProfitID = @ProfitID
                        WHERE ProfitID IS NULL
                        AND CAST(RevenueDate AS DATE) = @CurrentDate";

                    using (var updateCommand = new SqlCommand(updateRevenueQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@ProfitID", profitId);
                        updateCommand.Parameters.AddWithValue("@CurrentDate", currentDate);
                        int rowsAffected = updateCommand.ExecuteNonQuery();
                        System.Diagnostics.Debug.WriteLine($"Đã cập nhật {rowsAffected} bản ghi REVENUE với ProfitID {profitId} cho ngày {currentDate:dd/MM/yyyy}");
                    }

                    string updateProfitQuery = @"
                        UPDATE PROFIT
                        SET TotalRevenue = (
                            SELECT COALESCE(SUM(TotalAmount), 0)
                            FROM REVENUE
                            WHERE ProfitID = @ProfitID
                        ),
                        NetProfit = (
                            SELECT COALESCE(SUM(TotalAmount), 0)
                            FROM REVENUE
                            WHERE ProfitID = @ProfitID
                        ) - TotalExpense
                        WHERE ProfitID = @ProfitID";

                    using (var updateProfitCommand = new SqlCommand(updateProfitQuery, connection))
                    {
                        updateProfitCommand.Parameters.AddWithValue("@ProfitID", profitId);
                        updateProfitCommand.ExecuteNonQuery();
                        System.Diagnostics.Debug.WriteLine($"Đã cập nhật TotalRevenue và NetProfit cho ProfitID {profitId}");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi khi tạo PROFIT và liên kết REVENUE: {ex.Message}\nStackTrace: {ex.StackTrace}");
            }
        }

        public void Stop()
        {
            profitTimer?.Stop();
            profitTimer?.Dispose();
        }
    }
}