using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Timers;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Models;

namespace QuanLyThongTinKhachHangSacomBank.AutoTasks
{
    public class LoanPaymentAutoTask
    {
        private readonly DatabaseContext dbContext;
        private System.Timers.Timer loanPaymentTimer;

        public LoanPaymentAutoTask(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
            // Gọi ngay lần đầu tiên khi khởi tạo
            CheckAndCreateNextLoanPayment();
            StartLoanPaymentCheckTimer();
        }

        private void StartLoanPaymentCheckTimer()
        {
            // Tính thời gian đến 00:00 ngày hôm sau để chạy đúng thời điểm
            DateTime now = DateTime.Now;
            DateTime nextMidnight = now.Date.AddDays(1);
            double millisecondsUntilMidnight = (nextMidnight - now).TotalMilliseconds;

            loanPaymentTimer = new System.Timers.Timer(millisecondsUntilMidnight);
            loanPaymentTimer.Elapsed += (s, e) =>
            {
                CheckAndCreateNextLoanPayment();
                // Đặt lại timer để chạy mỗi 24 giờ
                loanPaymentTimer.Interval = 86400000; // 24 giờ
            };
            loanPaymentTimer.AutoReset = true;
            loanPaymentTimer.Start();
            System.Diagnostics.Debug.WriteLine($"LoanPaymentTimer sẽ chạy lần đầu vào {nextMidnight:dd/MM/yyyy HH:mm:ss}");
        }

        private void CheckAndCreateNextLoanPayment()
        {
            try
            {
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();

                    // Bước 1: Lấy tất cả dịch vụ trước
                    List<(int ServiceID, string ServiceCode, string Duration, decimal TotalPrincipalAmount,
                          decimal TotalInterestAmount, DateTime ApplicableDate, string ServiceStatus, int AccountID)> services = new List<(int, string, string, decimal, decimal, DateTime, string, int)>();

                    string serviceQuery = @"
                        SELECT 
                            s.ServiceID, s.ServiceCode, s.Duration, s.TotalPrincipalAmount, s.TotalInterestAmount, 
                            s.ApplicableDate, s.ServiceStatus, s.AccountID
                        FROM [SERVICE] s
                        WHERE s.ServiceStatus IN (N'Đang hoạt động', N'Trễ hạn thanh toán')";

                    using (var serviceCommand = new SqlCommand(serviceQuery, connection))
                    using (var serviceReader = serviceCommand.ExecuteReader())
                    {
                        while (serviceReader.Read())
                        {
                            services.Add((
                                serviceReader.GetInt32(0), // ServiceID
                                serviceReader.GetString(1), // ServiceCode
                                serviceReader.GetString(2), // Duration
                                serviceReader.GetDecimal(3), // TotalPrincipalAmount
                                serviceReader.GetDecimal(4), // TotalInterestAmount
                                serviceReader.GetDateTime(5), // ApplicableDate
                                serviceReader.GetString(6), // ServiceStatus
                                serviceReader.GetInt32(7) // AccountID
                            ));
                        }
                    }

                    // Bước 2: Xử lý từng dịch vụ
                    foreach (var service in services)
                    {
                        int serviceId = service.ServiceID;
                        string serviceCode = service.ServiceCode;
                        string durationStr = service.Duration;
                        decimal totalPrincipal = service.TotalPrincipalAmount;
                        decimal totalInterest = service.TotalInterestAmount;
                        DateTime applicableDate = service.ApplicableDate;
                        string serviceStatus = service.ServiceStatus;
                        int accountId = service.AccountID;

                        int duration = int.Parse(durationStr.Replace(" tháng", ""));

                        // Lấy bản ghi đầu tiên (có DueDate sớm nhất) để lấy giá trị PrincipalDue và InterestDue ban đầu
                        List<LoanPaymentModel> loanPayments = new List<LoanPaymentModel>();
                        string loanPaymentQuery = @"
                            SELECT 
                                PayLoanID, PayLoanCode, PrincipalDue, InterestDue, LateFee, TotalDue, 
                                RemainingDebt, PayNotification, DueDate, PaymentStatus, ServiceID
                            FROM LOAN_PAYMENT
                            WHERE ServiceID = @ServiceID
                            ORDER BY DueDate ASC"; // Sắp xếp theo DueDate tăng dần để lấy bản ghi đầu tiên

                        using (var loanPaymentCommand = new SqlCommand(loanPaymentQuery, connection))
                        {
                            loanPaymentCommand.Parameters.AddWithValue("@ServiceID", serviceId);
                            using (var loanPaymentReader = loanPaymentCommand.ExecuteReader())
                            {
                                while (loanPaymentReader.Read())
                                {
                                    loanPayments.Add(new LoanPaymentModel
                                    {
                                        PayLoanID = loanPaymentReader.GetInt32(0),
                                        PayLoanCode = loanPaymentReader.GetString(1),
                                        PrincipalDue = loanPaymentReader.GetDecimal(2),
                                        InterestDue = loanPaymentReader.GetDecimal(3),
                                        LateFee = loanPaymentReader.GetDecimal(4),
                                        TotalDue = loanPaymentReader.GetDecimal(5),
                                        RemainingDebt = loanPaymentReader.GetDecimal(6),
                                        PayNotification = loanPaymentReader.GetString(7),
                                        DueDate = loanPaymentReader.GetDateTime(8),
                                        PaymentStatus = loanPaymentReader.GetString(9),
                                        ServiceID = loanPaymentReader.GetInt32(10)
                                    });
                                }
                            }
                        }

                        if (loanPayments.Count == 0)
                        {
                            System.Diagnostics.Debug.WriteLine($"ServiceID {serviceId} không có bản ghi LOAN_PAYMENT nào.");
                            continue;
                        }

                        // Lấy giá trị từ bản ghi đầu tiên
                        var firstLoanPayment = loanPayments[0];
                        decimal monthlyPrincipalDue = firstLoanPayment.PrincipalDue; // Lấy từ bản ghi đầu tiên
                        decimal monthlyInterestDue = firstLoanPayment.InterestDue;   // Lấy từ bản ghi đầu tiên

                        // Sắp xếp lại loanPayments theo DueDate DESC để lấy latestLoanPayment
                        loanPayments.Sort((a, b) => b.DueDate.CompareTo(a.DueDate));
                        var latestLoanPayment = loanPayments[0];
                        DateTime dueDate = latestLoanPayment.DueDate;
                        DateTime now = DateTime.Now;

                        System.Diagnostics.Debug.WriteLine($"ServiceID {serviceId}: DueDate = {dueDate:dd/MM/yyyy HH:mm:ss}, Now = {now:dd/MM/yyyy HH:mm:ss}, PaymentStatus = {latestLoanPayment.PaymentStatus}");

                        // Kiểm tra trạng thái của latestLoanPayment để cập nhật ServiceStatus
                        int monthCount = loanPayments.Count;
                        if (latestLoanPayment.PaymentStatus == "Đã thanh toán")
                        {
                            string newServiceStatus = (monthCount == duration) ? "Đã tất toán" : "Đang hoạt động";
                            string updateServiceQuery = @"
                                UPDATE [SERVICE]
                                SET ServiceStatus = @ServiceStatus
                                WHERE ServiceID = @ServiceID";

                            using (var updateServiceCommand = new SqlCommand(updateServiceQuery, connection))
                            {
                                updateServiceCommand.Parameters.AddWithValue("@ServiceStatus", newServiceStatus);
                                updateServiceCommand.Parameters.AddWithValue("@ServiceID", serviceId);
                                updateServiceCommand.ExecuteNonQuery();
                            }

                            System.Diagnostics.Debug.WriteLine($"ServiceID {serviceId}: Đã cập nhật ServiceStatus thành '{newServiceStatus}' vì bản ghi gần nhất đã thanh toán.");
                        }

                        if (dueDate < now)
                        {
                            bool wasJustMarkedLate = false;
                            if (latestLoanPayment.PaymentStatus == "Chưa thanh toán" && monthCount < duration)
                            {
                                string updateLoanPaymentQuery = @"
                                    UPDATE LOAN_PAYMENT
                                    SET PaymentStatus = N'Trễ hạn'
                                    WHERE PayLoanID = @PayLoanID";

                                using (var updateCommand = new SqlCommand(updateLoanPaymentQuery, connection))
                                {
                                    updateCommand.Parameters.AddWithValue("@PayLoanID", latestLoanPayment.PayLoanID);
                                    updateCommand.ExecuteNonQuery();
                                }

                                string updateServiceQuery = @"
                                    UPDATE [SERVICE]
                                    SET ServiceStatus = N'Trễ hạn thanh toán'
                                    WHERE ServiceID = @ServiceID";

                                using (var updateServiceCommand = new SqlCommand(updateServiceQuery, connection))
                                {
                                    updateServiceCommand.Parameters.AddWithValue("@ServiceID", serviceId);
                                    updateServiceCommand.ExecuteNonQuery();
                                }

                                wasJustMarkedLate = true;
                                System.Diagnostics.Debug.WriteLine($"ServiceID {serviceId}: Đã cập nhật PaymentStatus thành 'Trễ hạn' và ServiceStatus thành 'Trễ hạn thanh toán'.");
                            }

                            if (monthCount < duration)
                            {
                                decimal accumulatedPrincipalDue = monthlyPrincipalDue;
                                decimal accumulatedInterestDue = monthlyInterestDue;
                                decimal lateFee = 0;
                                int lateCount = 0;

                                // Tích lũy tất cả các bản ghi trễ hạn, bao gồm cả latestLoanPayment
                                for (int i = 0; i < loanPayments.Count; i++)
                                {
                                    var payment = loanPayments[i];
                                    if (payment.PaymentStatus == "Trễ hạn" || (i == 0 && wasJustMarkedLate))
                                    {
                                        lateCount++;
                                        // Cộng dồn dựa trên giá trị ban đầu
                                        accumulatedPrincipalDue = monthlyPrincipalDue * (lateCount + 1);
                                        accumulatedInterestDue = monthlyInterestDue * (lateCount + 1);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                if (lateCount > 0)
                                {
                                    // Lấy LateFee của tháng trước (bản ghi gần nhất)
                                    decimal previousLateFee = latestLoanPayment.LateFee;

                                    // Tính LateFee mới dựa trên PrincipalDue + InterestDue của tháng trước
                                    decimal previousAmountDue = latestLoanPayment.PrincipalDue + latestLoanPayment.InterestDue;
                                    decimal newLateFee = previousAmountDue * 0.03m;

                                    // Làm tròn LateFee mới đến hàng đơn vị
                                    newLateFee = Math.Round(newLateFee, 0, MidpointRounding.AwayFromZero);

                                    // Áp dụng giới hạn cho LateFee mới
                                    if (newLateFee < 80000) newLateFee = 80000;
                                    if (newLateFee > 500000) newLateFee = 500000;

                                    // Cộng dồn LateFee mà không áp dụng lại giới hạn
                                    lateFee = previousLateFee + newLateFee;
                                }

                                // Lấy RemainingDebt từ bản ghi trước đó
                                decimal newRemainingDebt = latestLoanPayment.RemainingDebt;

                                // Nếu bản ghi mới đã thanh toán, giảm RemainingDebt đi monthlyPrincipalDue
                                // Ở đây bản ghi mới (được tạo) có PaymentStatus = "Chưa thanh toán", nên không cần giảm
                                // Nếu cần xử lý trường hợp thanh toán ngay khi tạo, có thể thêm logic tại đây

                                DateTime newDueDate = latestLoanPayment.DueDate.AddMonths(1);
                                string newPayNotification = $"Thanh toán khoản vay của mã dịch vụ '{serviceCode}' tháng thứ {monthCount + 1}";
                                decimal newTotalDue = accumulatedPrincipalDue + accumulatedInterestDue + lateFee;

                                string insertLoanPaymentQuery = @"
                                    INSERT INTO LOAN_PAYMENT (
                                        PrincipalDue, InterestDue, LateFee, TotalDue, RemainingDebt,
                                        PayNotification, DueDate, PaymentStatus, ServiceID
                                    )
                                    VALUES (
                                        @PrincipalDue, @InterestDue, @LateFee, @TotalDue, @RemainingDebt,
                                        @PayNotification, @DueDate, @PaymentStatus, @ServiceID
                                    );
                                    SELECT SCOPE_IDENTITY();";

                                using (var insertCommand = new SqlCommand(insertLoanPaymentQuery, connection))
                                {
                                    insertCommand.Parameters.AddWithValue("@PrincipalDue", accumulatedPrincipalDue);
                                    insertCommand.Parameters.AddWithValue("@InterestDue", accumulatedInterestDue);
                                    insertCommand.Parameters.AddWithValue("@LateFee", lateFee);
                                    insertCommand.Parameters.AddWithValue("@TotalDue", newTotalDue);
                                    insertCommand.Parameters.AddWithValue("@RemainingDebt", newRemainingDebt);
                                    insertCommand.Parameters.AddWithValue("@PayNotification", newPayNotification);
                                    insertCommand.Parameters.AddWithValue("@DueDate", newDueDate);
                                    insertCommand.Parameters.AddWithValue("@PaymentStatus", "Chưa thanh toán");
                                    insertCommand.Parameters.AddWithValue("@ServiceID", serviceId);
                                    var newPayLoanId = insertCommand.ExecuteScalar();
                                    System.Diagnostics.Debug.WriteLine($"ServiceID {serviceId}: Đã tạo mã thanh toán mới với PayLoanID {newPayLoanId}, DueDate = {newDueDate:dd/MM/yyyy}");
                                }
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine($"ServiceID {serviceId}: Đã đủ {monthCount}/{duration} kỳ thanh toán, không tạo thêm.");
                            }
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine($"ServiceID {serviceId}: DueDate chưa đến hạn, không cần tạo mã thanh toán mới.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi khi kiểm tra và tạo LOAN_PAYMENT: {ex.Message}\nStackTrace: {ex.StackTrace}");
            }
        }

        public void Stop()
        {
            loanPaymentTimer?.Stop();
            loanPaymentTimer?.Dispose();
        }
    }
}