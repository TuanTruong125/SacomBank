using System;
using Microsoft.Data.SqlClient;
using System.Timers;
using QuanLyThongTinKhachHangSacomBank.Data;

namespace QuanLyThongTinKhachHangSacomBank.AutoTasks
{
    public class GeneralExpenseAutoTask
    {
        private readonly DatabaseContext dbContext;
        private System.Timers.Timer generalExpenseTimer;

        // Khởi tạo task tự động, gọi lần đầu và bắt đầu timer
        public GeneralExpenseAutoTask(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
            CheckAndCreateGeneralExpense();
            StartGeneralExpenseCheckTimer();
        }

        // Khởi tạo timer chạy kiểm tra hàng phút
        private void StartGeneralExpenseCheckTimer()
        {
            generalExpenseTimer = new System.Timers.Timer(60000); // Kiểm tra mỗi phút
            generalExpenseTimer.Elapsed += (s, e) =>
            {
                CheckAndCreateGeneralExpense();
            };
            generalExpenseTimer.AutoReset = true;
            generalExpenseTimer.Start();
            System.Diagnostics.Debug.WriteLine("GeneralExpenseTimer đã khởi động, kiểm tra mỗi phút.");
        }

        // Kiểm tra và tạo bản ghi chi phí cho lương nhân viên và phí duy trì hệ thống
        private void CheckAndCreateGeneralExpense()
        {
            try
            {
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();

                    DateTime now = DateTime.Now;
                    DateTime today = now.Date; // Ngày hiện tại không có giờ

                    // Kiểm tra xem hôm nay có phải ngày 24 không
                    if (now.Day != 24)
                    {
                        System.Diagnostics.Debug.WriteLine($"Hôm nay ({now:dd/MM/yyyy}) không phải ngày 24, bỏ qua tạo General Expense.");
                        return;
                    }

                    // Thời gian mục tiêu: ngày 24 lúc 18:00
                    DateTime targetTime = new DateTime(today.Year, today.Month, 24, 18, 0, 0);
                    if (now < targetTime)
                    {
                        System.Diagnostics.Debug.WriteLine($"Hôm nay ({now:dd/MM/yyyy HH:mm:ss}) chưa đến 18:00, bỏ qua tạo General Expense.");
                        return;
                    }

                    // Kiểm tra xem đã có bản ghi EXPENSE cho ngày 24 lúc 18:00 với SystemMaintenanceFee và EmployeeSalary không NULL chưa
                    string checkExpenseQuery = @"
                        SELECT COUNT(*)
                        FROM EXPENSE
                        WHERE ExpenseDate = @ExpenseDate
                        AND SystemMaintenanceFee IS NOT NULL
                        AND EmployeeSalary IS NOT NULL";

                    using (var checkCommand = new SqlCommand(checkExpenseQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@ExpenseDate", targetTime);
                        int existingRecords = (int)checkCommand.ExecuteScalar();

                        if (existingRecords > 0)
                        {
                            System.Diagnostics.Debug.WriteLine($"Đã tồn tại bản ghi EXPENSE cho ngày {targetTime:dd/MM/yyyy HH:mm:ss} với SystemMaintenanceFee và EmployeeSalary không NULL.");
                            return;
                        }
                    }

                    // Nếu chưa có bản ghi, tiến hành tạo mới
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Tính tổng lương của tất cả nhân viên từ bảng EMPLOYEE
                            decimal totalEmployeeSalary = 0;
                            string salaryQuery = @"
                                SELECT COALESCE(SUM(Salary), 0)
                                FROM EMPLOYEE";

                            using (var salaryCommand = new SqlCommand(salaryQuery, connection, transaction))
                            {
                                totalEmployeeSalary = (decimal)salaryCommand.ExecuteScalar();
                                System.Diagnostics.Debug.WriteLine($"Tổng lương nhân viên: {totalEmployeeSalary}");
                            }

                            // Phí duy trì hệ thống cố định
                            decimal systemMaintenanceFee = 100000000;

                            // Kiểm tra hoặc tạo bản ghi PROFIT cho ngày hiện tại
                            int profitId;
                            string checkProfitQuery = @"
                                SELECT ProfitID
                                FROM PROFIT
                                WHERE CAST(ProfitDate AS DATE) = @ProfitDate";

                            using (var checkProfitCommand = new SqlCommand(checkProfitQuery, connection, transaction))
                            {
                                checkProfitCommand.Parameters.AddWithValue("@ProfitDate", today);
                                var result = checkProfitCommand.ExecuteScalar();

                                if (result == null)
                                {
                                    string insertProfitQuery = @"
                                        INSERT INTO PROFIT (TotalRevenue, TotalExpense, NetProfit, ProfitDate)
                                        VALUES (0, 0, 0, @ProfitDate);
                                        SELECT SCOPE_IDENTITY();";

                                    using (var insertProfitCommand = new SqlCommand(insertProfitQuery, connection, transaction))
                                    {
                                        insertProfitCommand.Parameters.AddWithValue("@ProfitDate", today);
                                        profitId = Convert.ToInt32(insertProfitCommand.ExecuteScalar());
                                    }
                                    System.Diagnostics.Debug.WriteLine($"Đã tạo ProfitID {profitId} cho ngày {today:dd/MM/yyyy}");
                                }
                                else
                                {
                                    profitId = Convert.ToInt32(result);
                                    System.Diagnostics.Debug.WriteLine($"ProfitID {profitId} đã tồn tại cho ngày {today:dd/MM/yyyy}");
                                }
                            }

                            // Tạo bản ghi EXPENSE
                            string insertExpenseQuery = @"
                                INSERT INTO EXPENSE (
                                    InterestPaid, EmployeeSalary, SystemMaintenanceFee, ExpenseDate, PaySavingsID, ProfitID
                                )
                                VALUES (
                                    NULL, @EmployeeSalary, @SystemMaintenanceFee, @ExpenseDate, NULL, @ProfitID
                                );
                                SELECT SCOPE_IDENTITY();";

                            using (var insertCommand = new SqlCommand(insertExpenseQuery, connection, transaction))
                            {
                                insertCommand.Parameters.AddWithValue("@EmployeeSalary", totalEmployeeSalary);
                                insertCommand.Parameters.AddWithValue("@SystemMaintenanceFee", systemMaintenanceFee);
                                insertCommand.Parameters.AddWithValue("@ExpenseDate", targetTime);
                                insertCommand.Parameters.AddWithValue("@ProfitID", profitId);
                                var newExpenseId = insertCommand.ExecuteScalar();
                                System.Diagnostics.Debug.WriteLine($"Đã tạo bản ghi EXPENSE với ExpenseID {newExpenseId}, EmployeeSalary = {totalEmployeeSalary}, SystemMaintenanceFee = {systemMaintenanceFee}, ExpenseDate = {targetTime:dd/MM/yyyy HH:mm:ss}, ProfitID = {profitId}.");
                            }

                            // Cập nhật TotalExpense và NetProfit trong PROFIT
                            string updateProfitQuery = @"
                                UPDATE PROFIT
                                SET TotalExpense = (
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
                                            System.Diagnostics.Debug.WriteLine($"ProfitID {profitId}: TotalRevenue = {totalRevenue}, TotalExpense = {totalExpense}, NetProfit = {netProfit} sau khi cập nhật PROFIT trong GeneralExpenseAutoTask.");
                                            if (netProfit < 0)
                                            {
                                                System.Diagnostics.Debug.WriteLine($"Cảnh báo: NetProfit của ProfitID {profitId} là âm ({netProfit}).");
                                            }
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
                            System.Diagnostics.Debug.WriteLine($"Lỗi khi tạo General Expense: {ex.Message}\nStackTrace: {ex.StackTrace}");
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi khi kiểm tra và tạo General Expense: {ex.Message}\nStackTrace: {ex.StackTrace}");
            }
        }

        // Dừng timer khi ứng dụng thoát
        public void Stop()
        {
            generalExpenseTimer?.Stop();
            generalExpenseTimer?.Dispose();
        }
    }
}