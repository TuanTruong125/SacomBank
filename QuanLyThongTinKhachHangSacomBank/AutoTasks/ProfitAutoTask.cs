using System;
using Microsoft.Data.SqlClient;
using System.Timers;
using QuanLyThongTinKhachHangSacomBank.Data;
using System.Transactions;
using System.Data.Common;

namespace QuanLyThongTinKhachHangSacomBank.AutoTasks
{
    public class ProfitAutoTask
    {
        private readonly DatabaseContext dbContext;
        private System.Timers.Timer profitTimer;

        // Khởi tạo task tự động, gọi lần đầu và bắt đầu timer
        public ProfitAutoTask(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
            CreateDailyProfitAndLinkRecords();
            StartProfitCheckTimer();
        }

        // Khởi tạo timer chạy hàng ngày vào 00:00
        private void StartProfitCheckTimer()
        {
            DateTime now = DateTime.Now;
            DateTime nextMidnight = now.Date.AddDays(1);
            double millisecondsUntilMidnight = (nextMidnight - now).TotalMilliseconds;

            profitTimer = new System.Timers.Timer(millisecondsUntilMidnight);
            profitTimer.Elapsed += (s, e) =>
            {
                CreateDailyProfitAndLinkRecords();
                profitTimer.Interval = 86400000;
            };
            profitTimer.AutoReset = true;
            profitTimer.Start();
            System.Diagnostics.Debug.WriteLine($"ProfitTimer sẽ chạy lần đầu vào {nextMidnight:dd/MM/yyyy HH:mm:ss}");
        }

        // Tạo bản ghi PROFIT, gán ProfitID cho REVENUE, EXPENSE và SAVINGS_PAYMENT, tính TotalRevenue, TotalExpense, NetProfit
        private void CreateDailyProfitAndLinkRecords()
        {
            try
            {
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();

                    DateTime currentDate = DateTime.Today;
                    int profitId;

                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Kiểm tra hoặc tạo bản ghi PROFIT
                            string checkProfitQuery = @"
                                SELECT ProfitID
                                FROM PROFIT
                                WHERE CAST(ProfitDate AS DATE) = @ProfitDate";

                            using (var checkCommand = new SqlCommand(checkProfitQuery, connection, transaction))
                            {
                                checkCommand.Parameters.AddWithValue("@ProfitDate", currentDate);
                                var result = checkCommand.ExecuteScalar();

                                if (result == null)
                                {
                                    string insertProfitQuery = @"
                                        INSERT INTO PROFIT (TotalRevenue, TotalExpense, NetProfit, ProfitDate)
                                        VALUES (0, 0, 0, @ProfitDate);
                                        SELECT SCOPE_IDENTITY();";

                                    using (var insertCommand = new SqlCommand(insertProfitQuery, connection, transaction))
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

                            // Gán ProfitID cho các bản ghi REVENUE chưa được gán
                            string updateRevenueQuery = @"
                                UPDATE REVENUE
                                SET ProfitID = @ProfitID
                                WHERE ProfitID IS NULL
                                AND CAST(RevenueDate AS DATE) = @CurrentDate";

                            using (var updateCommand = new SqlCommand(updateRevenueQuery, connection, transaction))
                            {
                                updateCommand.Parameters.AddWithValue("@ProfitID", profitId);
                                updateCommand.Parameters.AddWithValue("@CurrentDate", currentDate);
                                int rowsAffected = updateCommand.ExecuteNonQuery();
                                System.Diagnostics.Debug.WriteLine($"Đã cập nhật {rowsAffected} bản ghi REVENUE với ProfitID {profitId} cho ngày {currentDate:dd/MM/yyyy}");
                            }

                            // Gán ProfitID cho các bản ghi EXPENSE chưa được gán
                            string updateExpenseQuery = @"
                                UPDATE EXPENSE
                                SET ProfitID = @ProfitID
                                WHERE ProfitID IS NULL
                                AND CAST(ExpenseDate AS DATE) = @CurrentDate";

                            using (var updateCommand = new SqlCommand(updateExpenseQuery, connection, transaction))
                            {
                                updateCommand.Parameters.AddWithValue("@ProfitID", profitId);
                                updateCommand.Parameters.AddWithValue("@CurrentDate", currentDate);
                                int rowsAffected = updateCommand.ExecuteNonQuery();
                                System.Diagnostics.Debug.WriteLine($"Đã cập nhật {rowsAffected} bản ghi EXPENSE với ProfitID {profitId} cho ngày {currentDate:dd/MM/yyyy}");
                            }

                            // Cập nhật TotalRevenue, TotalExpense, và NetProfit
                            string updateProfitQuery = @"
                                UPDATE PROFIT
                                SET TotalRevenue = (
                                    SELECT COALESCE(SUM(TotalAmount), 0)
                                    FROM REVENUE
                                    WHERE ProfitID = @ProfitID
                                ),
                                TotalExpense = (
                                    SELECT COALESCE(SUM(COALESCE(InterestPaid, 0) + COALESCE(EmployeeSalary, 0) + COALESCE(SystemMaintenanceFee, 0)), 0)
                                    FROM EXPENSE
                                    WHERE ProfitID = @ProfitID
                                ),
                                NetProfit = (
                                    SELECT COALESCE(SUM(TotalAmount), 0)
                                    FROM REVENUE
                                    WHERE ProfitID = @ProfitID
                                ) - (
                                    SELECT COALESCE(SUM(COALESCE(InterestPaid, 0) + COALESCE(EmployeeSalary, 0) + COALESCE(SystemMaintenanceFee, 0)), 0)
                                    FROM EXPENSE
                                    WHERE ProfitID = @ProfitID
                                )
                                WHERE ProfitID = @ProfitID";

                            using (var updateProfitCommand = new SqlCommand(updateProfitQuery, connection, transaction))
                            {
                                updateProfitCommand.Parameters.AddWithValue("@ProfitID", profitId);
                                updateProfitCommand.ExecuteNonQuery();

                                // Lấy TotalRevenue, TotalExpense, NetProfit để log
                                string getProfitQuery = @"
                                    SELECT TotalRevenue, TotalExpense, NetProfit
                                    FROM PROFIT
                                    WHERE ProfitID = @ProfitID";
                                using (var getProfitCommand = new SqlCommand(getProfitQuery, connection, transaction))
                                {
                                    getProfitCommand.Parameters.AddWithValue("@ProfitID", profitId);
                                    using (var reader = getProfitCommand.ExecuteReader())
                                    {
                                        if (reader.Read())
                                        {
                                            decimal totalRevenue = reader.GetDecimal(0);
                                            decimal totalExpense = reader.GetDecimal(1);
                                            decimal netProfit = reader.GetDecimal(2);
                                            System.Diagnostics.Debug.WriteLine($"ProfitID {profitId}: TotalRevenue = {totalRevenue}, TotalExpense = {totalExpense}, NetProfit = {netProfit} sau khi cập nhật PROFIT.");
                                        }
                                    }
                                }
                            }

                            // Commit transaction
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            System.Diagnostics.Debug.WriteLine($"Lỗi khi tạo PROFIT và liên kết REVENUE: {ex.Message}\nStackTrace: {ex.StackTrace}");
                            throw;
                        }
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