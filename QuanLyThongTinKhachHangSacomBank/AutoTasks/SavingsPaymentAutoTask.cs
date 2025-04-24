using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Timers;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Models;

namespace QuanLyThongTinKhachHangSacomBank.AutoTasks
{
    public class SavingsPaymentAutoTask
    {
        private readonly DatabaseContext dbContext;
        private System.Timers.Timer savingsPaymentTimer;

        // Khởi tạo task tự động, gọi lần đầu và bắt đầu timer
        public SavingsPaymentAutoTask(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
            CheckAndCreateSavingsPayment();
            StartSavingsPaymentCheckTimer();
        }

        // Khởi tạo timer chạy hàng ngày vào 00:00
        private void StartSavingsPaymentCheckTimer()
        {
            DateTime now = DateTime.Now;
            DateTime nextMidnight = now.Date.AddDays(1);
            double millisecondsUntilMidnight = (nextMidnight - now).TotalMilliseconds;

            savingsPaymentTimer = new System.Timers.Timer(millisecondsUntilMidnight);
            savingsPaymentTimer.Elapsed += (s, e) =>
            {
                CheckAndCreateSavingsPayment();
                savingsPaymentTimer.Interval = 86400000; // 24 giờ
            };
            savingsPaymentTimer.AutoReset = true;
            savingsPaymentTimer.Start();
            System.Diagnostics.Debug.WriteLine($"SavingsPaymentTimer sẽ chạy lần đầu vào {nextMidnight:dd/MM/yyyy HH:mm:ss}");
        }

        // Kiểm tra và tạo bản ghi trả lãi tiết kiệm, cập nhật ServiceStatus, Balance và tạo TRANSACTION nếu đủ kỳ hạn
        private void CheckAndCreateSavingsPayment()
        {
            try
            {
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();

                    // Lấy tất cả dịch vụ "Gửi tiết kiệm" đang hoạt động
                    List<(int ServiceID, string ServiceCode, string Duration, decimal TotalInterestAmount, decimal TotalPrincipalAmount, DateTime ApplicableDate, string ServiceStatus, int AccountID)> services = new List<(int, string, string, decimal, decimal, DateTime, string, int)>();

                    string serviceQuery = @"
                        SELECT 
                            s.ServiceID, s.ServiceCode, s.Duration, s.TotalInterestAmount, s.TotalPrincipalAmount,
                            s.ApplicableDate, s.ServiceStatus, s.AccountID
                        FROM [SERVICE] s
                        JOIN SERVICE_TYPE st ON s.ServiceTypeID = st.ServiceTypeID
                        WHERE st.ServiceTypeName = N'Gửi tiết kiệm'
                        AND s.ServiceStatus = N'Đang hoạt động'";

                    using (var serviceCommand = new SqlCommand(serviceQuery, connection))
                    using (var serviceReader = serviceCommand.ExecuteReader())
                    {
                        while (serviceReader.Read())
                        {
                            services.Add((
                                serviceReader.GetInt32(0), // ServiceID
                                serviceReader.GetString(1), // ServiceCode
                                serviceReader.GetString(2), // Duration
                                serviceReader.GetDecimal(3), // TotalInterestAmount
                                serviceReader.GetDecimal(4), // TotalPrincipalAmount
                                serviceReader.GetDateTime(5), // ApplicableDate
                                serviceReader.GetString(6), // ServiceStatus
                                serviceReader.GetInt32(7)  // AccountID
                            ));
                        }
                    }

                    // Xử lý từng dịch vụ
                    foreach (var service in services)
                    {
                        int serviceId = service.ServiceID;
                        string serviceCode = service.ServiceCode;
                        string durationStr = service.Duration;
                        decimal totalInterest = service.TotalInterestAmount;
                        decimal totalPrincipal = service.TotalPrincipalAmount;
                        DateTime applicableDate = service.ApplicableDate;
                        string serviceStatus = service.ServiceStatus;
                        int accountId = service.AccountID;

                        int duration = int.Parse(durationStr.Replace(" tháng", ""));

                        // Lấy tất cả bản ghi SAVINGS_PAYMENT của dịch vụ
                        List<SavingsPaymentModel> savingsPayments = new List<SavingsPaymentModel>();
                        string savingsPaymentQuery = @"
                            SELECT 
                                PaySavingsID, PaySavingsCode, MonthlyInterestAmount, TotalInterestPaid, 
                                LastInterestPaidDate, ServiceID
                            FROM SAVINGS_PAYMENT
                            WHERE ServiceID = @ServiceID
                            ORDER BY LastInterestPaidDate ASC";

                        using (var savingsPaymentCommand = new SqlCommand(savingsPaymentQuery, connection))
                        {
                            savingsPaymentCommand.Parameters.AddWithValue("@ServiceID", serviceId);
                            using (var savingsPaymentReader = savingsPaymentCommand.ExecuteReader())
                            {
                                while (savingsPaymentReader.Read())
                                {
                                    savingsPayments.Add(new SavingsPaymentModel
                                    {
                                        PaySavingsID = savingsPaymentReader.GetInt32(0),
                                        PaySavingsCode = savingsPaymentReader.GetString(1),
                                        MonthlyInterestAmount = savingsPaymentReader.GetDecimal(2),
                                        TotalInterestPaid = savingsPaymentReader.GetDecimal(3),
                                        LastInterestPaidDate = savingsPaymentReader.GetDateTime(4),
                                        ServiceID = savingsPaymentReader.GetInt32(5)
                                    });
                                }
                            }
                        }

                        DateTime now = DateTime.Today; // Chỉ lấy ngày để so sánh
                        decimal monthlyInterestAmount = 0;
                        decimal totalInterestPaid = 0;
                        DateTime newLastInterestPaidDate;

                        // Kiểm tra và tạo bản ghi SAVINGS_PAYMENT
                        if (savingsPayments.Count == 0)
                        {
                            // Chưa có bản ghi, kiểm tra thời gian từ ApplicableDate
                            DateTime firstInterestDueDate = applicableDate.AddMonths(1).Date; // Chỉ lấy ngày để so sánh
                            if (now >= firstInterestDueDate)
                            {
                                monthlyInterestAmount = totalInterest / duration;
                                monthlyInterestAmount = Math.Floor(monthlyInterestAmount);
                                totalInterestPaid = monthlyInterestAmount;
                                newLastInterestPaidDate = applicableDate.AddMonths(1); // Lấy từ ApplicableDate + 1 tháng

                                string insertSavingsPaymentQuery = @"
                                    INSERT INTO SAVINGS_PAYMENT (
                                        MonthlyInterestAmount, TotalInterestPaid, LastInterestPaidDate, ServiceID
                                    )
                                    VALUES (
                                        @MonthlyInterestAmount, @TotalInterestPaid, @LastInterestPaidDate, @ServiceID
                                    );
                                    SELECT SCOPE_IDENTITY();";

                                using (var insertCommand = new SqlCommand(insertSavingsPaymentQuery, connection))
                                {
                                    insertCommand.Parameters.AddWithValue("@MonthlyInterestAmount", monthlyInterestAmount);
                                    insertCommand.Parameters.AddWithValue("@TotalInterestPaid", totalInterestPaid);
                                    insertCommand.Parameters.AddWithValue("@LastInterestPaidDate", newLastInterestPaidDate);
                                    insertCommand.Parameters.AddWithValue("@ServiceID", serviceId);
                                    var newPaySavingsId = insertCommand.ExecuteScalar();
                                    System.Diagnostics.Debug.WriteLine($"ServiceID {serviceId}: Đã tạo bản ghi trả lãi đầu tiên với PaySavingsID {newPaySavingsId}, LastInterestPaidDate = {newLastInterestPaidDate:dd/MM/yyyy HH:mm:ss}");

                                    CreateExpenseRecord(connection, Convert.ToInt32(newPaySavingsId), monthlyInterestAmount, false, 0, totalPrincipal);

                                    // Cập nhật danh sách savingsPayments để kiểm tra bản ghi cuối cùng
                                    savingsPayments.Add(new SavingsPaymentModel
                                    {
                                        PaySavingsID = Convert.ToInt32(newPaySavingsId),
                                        MonthlyInterestAmount = monthlyInterestAmount,
                                        TotalInterestPaid = totalInterestPaid,
                                        LastInterestPaidDate = newLastInterestPaidDate,
                                        ServiceID = serviceId
                                    });
                                }
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine($"ServiceID {serviceId}: Chưa đến hạn trả lãi đầu tiên (Due: {firstInterestDueDate:dd/MM/yyyy}).");
                            }
                        }
                        else
                        {
                            // Đã có bản ghi, kiểm tra thời gian từ bản ghi gần nhất
                            savingsPayments.Sort((a, b) => b.LastInterestPaidDate.CompareTo(a.LastInterestPaidDate));
                            var latestSavingsPayment = savingsPayments[0];
                            DateTime lastInterestPaidDate = latestSavingsPayment.LastInterestPaidDate.Date; // Chỉ lấy ngày để so sánh
                            DateTime nextInterestDueDate = lastInterestPaidDate.AddMonths(1).Date; // Chỉ lấy ngày để so sánh

                            System.Diagnostics.Debug.WriteLine($"ServiceID {serviceId}: LastInterestPaidDate = {lastInterestPaidDate:dd/MM/yyyy}, NextDue = {nextInterestDueDate:dd/MM/yyyy}, Now = {now:dd/MM/yyyy}");

                            bool createdNewRecord = false;

                            if (now >= nextInterestDueDate && savingsPayments.Count < duration)
                            {
                                monthlyInterestAmount = latestSavingsPayment.MonthlyInterestAmount;
                                totalInterestPaid = latestSavingsPayment.TotalInterestPaid + monthlyInterestAmount;
                                newLastInterestPaidDate = latestSavingsPayment.LastInterestPaidDate.AddMonths(1); // Dựa trên LastInterestPaidDate của bản ghi trước

                                string insertSavingsPaymentQuery = @"
                                    INSERT INTO SAVINGS_PAYMENT (
                                        MonthlyInterestAmount, TotalInterestPaid, LastInterestPaidDate, ServiceID
                                    )
                                    VALUES (
                                        @MonthlyInterestAmount, @TotalInterestPaid, @LastInterestPaidDate, @ServiceID
                                    );
                                    SELECT SCOPE_IDENTITY();";

                                using (var insertCommand = new SqlCommand(insertSavingsPaymentQuery, connection))
                                {
                                    insertCommand.Parameters.AddWithValue("@MonthlyInterestAmount", monthlyInterestAmount);
                                    insertCommand.Parameters.AddWithValue("@TotalInterestPaid", totalInterestPaid);
                                    insertCommand.Parameters.AddWithValue("@LastInterestPaidDate", newLastInterestPaidDate);
                                    insertCommand.Parameters.AddWithValue("@ServiceID", serviceId);
                                    var newPaySavingsId = insertCommand.ExecuteScalar();
                                    System.Diagnostics.Debug.WriteLine($"ServiceID {serviceId}: Đã tạo bản ghi trả lãi mới với PaySavingsID {newPaySavingsId}, LastInterestPaidDate = {newLastInterestPaidDate:dd/MM/yyyy HH:mm:ss}");

                                    bool isLastRecord = (savingsPayments.Count + 1 == duration);

                                    // Tạo bản ghi EXPENSE
                                    CreateExpenseRecord(connection, Convert.ToInt32(newPaySavingsId), monthlyInterestAmount, isLastRecord, totalInterestPaid, totalPrincipal);

                                    // Cập nhật danh sách savingsPayments
                                    savingsPayments.Add(new SavingsPaymentModel
                                    {
                                        PaySavingsID = Convert.ToInt32(newPaySavingsId),
                                        MonthlyInterestAmount = monthlyInterestAmount,
                                        TotalInterestPaid = totalInterestPaid,
                                        LastInterestPaidDate = newLastInterestPaidDate,
                                        ServiceID = serviceId
                                    });

                                    createdNewRecord = true;
                                }
                            }

                            // Kiểm tra bản ghi cuối cùng
                            if (savingsPayments.Count == duration)
                            {
                                // Nếu vừa tạo bản ghi cuối cùng hoặc đã đủ kỳ hạn từ trước, thực hiện các bước tất toán
                                // Cập nhật ServiceStatus thành 'Đã tất toán'
                                string updateServiceQuery = @"
                                    UPDATE [SERVICE]
                                    SET ServiceStatus = N'Đã tất toán',
                                        EndDate = @EndDate
                                    WHERE ServiceID = @ServiceID";

                                using (var updateServiceCommand = new SqlCommand(updateServiceQuery, connection))
                                {
                                    updateServiceCommand.Parameters.AddWithValue("@EndDate", savingsPayments[savingsPayments.Count - 1].LastInterestPaidDate);
                                    updateServiceCommand.Parameters.AddWithValue("@ServiceID", serviceId);
                                    updateServiceCommand.ExecuteNonQuery();
                                    System.Diagnostics.Debug.WriteLine($"ServiceID {serviceId}: Đã cập nhật ServiceStatus thành 'Đã tất toán' vì đã đủ {duration} kỳ trả lãi.");
                                }

                                // Cập nhật Balance của tài khoản
                                decimal amountToAdd = savingsPayments[savingsPayments.Count - 1].TotalInterestPaid + totalPrincipal;
                                string updateBalanceQuery = @"
                                    UPDATE ACCOUNT
                                    SET Balance = Balance + @Amount
                                    WHERE AccountID = @AccountID";

                                using (var updateBalanceCommand = new SqlCommand(updateBalanceQuery, connection))
                                {
                                    updateBalanceCommand.Parameters.AddWithValue("@Amount", amountToAdd);
                                    updateBalanceCommand.Parameters.AddWithValue("@AccountID", accountId);
                                    updateBalanceCommand.ExecuteNonQuery();
                                    System.Diagnostics.Debug.WriteLine($"AccountID {accountId}: Đã cập nhật Balance, tăng thêm {amountToAdd}.");
                                }

                                // Lấy AccountName để tạo TransactionDescription
                                string accountNameQuery = @"
                                    SELECT AccountName
                                    FROM ACCOUNT
                                    WHERE AccountID = @AccountID";

                                string accountName;
                                using (var accountNameCommand = new SqlCommand(accountNameQuery, connection))
                                {
                                    accountNameCommand.Parameters.AddWithValue("@AccountID", accountId);
                                    accountName = accountNameCommand.ExecuteScalar()?.ToString();
                                }

                                // Lấy TransactionTypeID cho loại giao dịch "Nạp tiền"
                                int transactionTypeId = 0;
                                string transactionTypeQuery = @"
                                    SELECT TransactionTypeID
                                    FROM TRANSACTION_TYPE
                                    WHERE TransactionTypeName = N'Nạp tiền'";

                                using (var transactionTypeCommand = new SqlCommand(transactionTypeQuery, connection))
                                {
                                    var result = transactionTypeCommand.ExecuteScalar();
                                    if (result != null)
                                    {
                                        transactionTypeId = Convert.ToInt32(result);
                                    }
                                    else
                                    {
                                        throw new Exception("Không tìm thấy TransactionTypeID cho 'Nạp tiền'.");
                                    }
                                }

                                // Tạo bản ghi TRANSACTION
                                string transactionDescription = $"Tat toan gui tiet kiem cho {accountName} voi ma dich vu {serviceCode}";
                                string insertTransactionQuery = @"
                                    INSERT INTO [TRANSACTION] (
                                        Amount, TransactionDate, ReceiverAccountID, ReceiverAccountName,
                                        TransactionStatus, HandledBy, TransactionDescription, TransactionMethod,
                                        AccountID, TransactionTypeID
                                    )
                                    VALUES (
                                        @Amount, @TransactionDate, NULL, NULL,
                                        N'Hoàn tất', NULL, @TransactionDescription, N'Trực tuyến',
                                        @AccountID, @TransactionTypeID
                                    );
                                    SELECT SCOPE_IDENTITY();";

                                using (var insertTransactionCommand = new SqlCommand(insertTransactionQuery, connection))
                                {
                                    insertTransactionCommand.Parameters.AddWithValue("@Amount", amountToAdd);
                                    insertTransactionCommand.Parameters.AddWithValue("@TransactionDate", savingsPayments[savingsPayments.Count - 1].LastInterestPaidDate);
                                    insertTransactionCommand.Parameters.AddWithValue("@TransactionDescription", transactionDescription);
                                    insertTransactionCommand.Parameters.AddWithValue("@AccountID", accountId);
                                    insertTransactionCommand.Parameters.AddWithValue("@TransactionTypeID", transactionTypeId);
                                    var newTransactionId = insertTransactionCommand.ExecuteScalar();
                                    System.Diagnostics.Debug.WriteLine($"ServiceID {serviceId}: Đã tạo bản ghi TRANSACTION với TransactionID {newTransactionId}, Amount = {amountToAdd}.");
                                }
                            }
                            else if (!createdNewRecord)
                            {
                                System.Diagnostics.Debug.WriteLine($"ServiceID {serviceId}: Chưa đến hạn trả lãi tiếp theo (Due: {nextInterestDueDate:dd/MM/yyyy}).");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi khi kiểm tra và tạo SAVINGS_PAYMENT: {ex.Message}\nStackTrace: {ex.StackTrace}");
            }
        }

        // Tạo bản ghi chi phí trong bảng EXPENSE và gán ProfitID ngay lập tức
        private void CreateExpenseRecord(SqlConnection connection, int paySavingsId, decimal monthlyInterestAmount, bool isLastRecord, decimal totalInterestPaid, decimal totalPrincipal)
        {
            DateTime currentDate = DateTime.Now; // Sử dụng thời gian hiện tại cho ExpenseDate
            int profitId = 0;

            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    // Kiểm tra xem đã có bản ghi PROFIT cho ngày hiện tại chưa
                    string checkProfitQuery = @"
                        SELECT ProfitID
                        FROM PROFIT
                        WHERE CAST(ProfitDate AS DATE) = @ProfitDate";

                    using (var checkCommand = new SqlCommand(checkProfitQuery, connection, transaction))
                    {
                        checkCommand.Parameters.AddWithValue("@ProfitDate", currentDate.Date);
                        var result = checkCommand.ExecuteScalar();

                        if (result == null)
                        {
                            // Nếu chưa có, tạo bản ghi PROFIT mới
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

                    // Tính InterestPaid: Nếu là bản ghi cuối cùng, InterestPaid = MonthlyInterestAmount + TotalPrincipalAmount
                    decimal interestPaid = isLastRecord ? (monthlyInterestAmount + totalPrincipal) : monthlyInterestAmount;

                    // Tạo bản ghi EXPENSE với ProfitID vừa lấy hoặc tạo
                    string insertExpenseQuery = @"
                        INSERT INTO EXPENSE (
                            InterestPaid, EmployeeSalary, SystemMaintenanceFee, ExpenseDate, PaySavingsID, ProfitID
                        )
                        VALUES (
                            @InterestPaid, NULL, NULL, @ExpenseDate, @PaySavingsID, @ProfitID
                        )";

                    using (var insertCommand = new SqlCommand(insertExpenseQuery, connection, transaction))
                    {
                        insertCommand.Parameters.AddWithValue("@InterestPaid", interestPaid);
                        insertCommand.Parameters.AddWithValue("@ExpenseDate", currentDate);
                        insertCommand.Parameters.AddWithValue("@PaySavingsID", paySavingsId);
                        insertCommand.Parameters.AddWithValue("@ProfitID", profitId);
                        insertCommand.ExecuteNonQuery();
                        System.Diagnostics.Debug.WriteLine($"PaySavingsID {paySavingsId}: Đã tạo bản ghi EXPENSE với InterestPaid = {interestPaid}, ExpenseDate = {currentDate:dd/MM/yyyy HH:mm:ss}, ProfitID = {profitId}.");
                    }

                    // Cập nhật TotalExpense và NetProfit trong PROFIT ngay lập tức
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
                                    System.Diagnostics.Debug.WriteLine($"ProfitID {profitId}: TotalRevenue = {totalRevenue}, TotalExpense = {totalExpense}, NetProfit = {netProfit} sau khi cập nhật PROFIT trong CreateExpenseRecord.");
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
                    System.Diagnostics.Debug.WriteLine($"Lỗi khi tạo EXPENSE cho PaySavingsID {paySavingsId}: {ex.Message}\nStackTrace: {ex.StackTrace}");
                    throw; // Ném lỗi để dừng xử lý nếu cần
                }
            }
        }

        // Dừng timer khi ứng dụng thoát
        public void Stop()
        {
            savingsPaymentTimer?.Stop();
            savingsPaymentTimer?.Dispose();
        }
    }
}