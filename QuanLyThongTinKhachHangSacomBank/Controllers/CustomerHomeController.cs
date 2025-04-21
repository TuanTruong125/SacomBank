using System;
using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Views.Customer;
using Microsoft.Data.SqlClient;
using QuanLyThongTinKhachHangSacomBank.Data;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class CustomerHomeController
    {
        private ICustomerHomeView view;
        private AccountModel account;
        private bool isBalanceVisible = true;
        private readonly DatabaseContext dbContext;

        public CustomerHomeController(ICustomerHomeView view, AccountModel account, DatabaseContext dbContext)
        {
            this.view = view;
            this.account = account;
            this.dbContext = dbContext;

            // Khởi tạo giao diện ban đầu
            InitializeView();

            // Đăng ký sự kiện
            view.ViewBalanceRequested += ToggleBalanceVisibility;

            LoadServiceNotifications();
        }

        private void InitializeView()
        {
            if (account != null)
            {
                view.SetAccountName(account.AccountName);
                view.SetAccountID(account.AccountCode);
                UpdateBalanceDisplay();
                view.SetEyeImage(Properties.Resources.ViewBalance); // Mắt mở mặc định
            }
        }

        private void UpdateBalanceDisplay()
        {
            if (account != null)
            {
                if (isBalanceVisible)
                {
                    view.SetBalance(string.Format("{0:N0} VND", account.Balance));
                }
                else
                {
                    view.SetBalance("******");
                }
            }
        }

        private void ToggleBalanceVisibility(object sender, EventArgs e)
        {
            isBalanceVisible = !isBalanceVisible;
            view.SetEyeImage(isBalanceVisible ? Properties.Resources.ViewBalance : Properties.Resources.HideBalance);
            UpdateBalanceDisplay();
        }

        // Phương thức load dữ liệu từ LOAN_PAYMENT
        private void LoadServiceNotifications()
        {
            try
            {
                if (dbContext == null || account == null)
                {
                    view.UpdateServiceNotifications(new List<ServiceNotificationDisplayModel>());
                    System.Diagnostics.Debug.WriteLine("DatabaseContext hoặc Account là null.");
                    return;
                }

                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    string query = @"
                SELECT 
                    lp.PayLoanID, lp.PayLoanCode, lp.PrincipalDue, lp.InterestDue, lp.LateFee, 
                    lp.TotalDue, lp.RemainingDebt, lp.PayNotification, lp.DueDate, lp.PaymentStatus,
                    s.ServiceID, s.ServiceCode, s.ServiceTypeID,
                    st.ServiceTypeName
                FROM LOAN_PAYMENT lp
                JOIN SERVICE s ON lp.ServiceID = s.ServiceID
                JOIN SERVICE_TYPE st ON s.ServiceTypeID = st.ServiceTypeID
                WHERE s.AccountID = @AccountID
                ORDER BY lp.DueDate DESC";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AccountID", account.AccountID);

                        using (var reader = command.ExecuteReader())
                        {
                            var notifications = new List<ServiceNotificationDisplayModel>();

                            while (reader.Read())
                            {
                                var displayModel = new ServiceNotificationDisplayModel
                                {
                                    PayLoanCode = reader.GetString(1), // PayLoanCode đã có tiền tố TTV
                                    ServiceCode = reader.GetString(11),
                                    ServiceTypeName = reader.GetString(13),
                                    PrincipalDue = reader.GetDecimal(2).ToString("N0") + " VND",
                                    InterestDue = reader.GetDecimal(3).ToString("N0") + " VND",
                                    LateFee = reader.GetDecimal(4).ToString("N0") + " VND",
                                    TotalDue = reader.GetDecimal(5).ToString("N0") + " VND",
                                    RemainingDebt = reader.GetDecimal(6).ToString("N0") + " VND",
                                    PayNotification = reader.GetString(7),
                                    DueDate = reader.GetDateTime(8).ToString("dd/MM/yyyy HH:mm:ss"),
                                    PaymentStatus = reader.GetString(9)
                                };
                                notifications.Add(displayModel);
                            }

                            // Log số lượng bản ghi để kiểm tra
                            System.Diagnostics.Debug.WriteLine($"Số bản ghi load được: {notifications.Count}");

                            // Cập nhật DataGridView
                            view.UpdateServiceNotifications(notifications);

                            // Nếu không có bản ghi, hiển thị thông báo
                            if (notifications.Count == 0)
                            {
                                System.Diagnostics.Debug.WriteLine("Không có bản ghi nào cho AccountID: " + account.AccountID);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi khi load thông báo: {ex.Message}");
                view.UpdateServiceNotifications(new List<ServiceNotificationDisplayModel>());
            }
        }
    }
}