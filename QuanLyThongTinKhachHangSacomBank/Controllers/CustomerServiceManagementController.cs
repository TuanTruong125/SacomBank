using Microsoft.Data.SqlClient;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Views.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class CustomerServiceManagementController
    {
        private readonly ICustomerServiceManagementView view;
        private readonly DatabaseContext dbContext;
        private readonly AccountModel currentAccount;

        public CustomerServiceManagementController(ICustomerServiceManagementView view, AccountModel currentAccount, DatabaseContext dbContext)
        {
            this.view = view;
            this.currentAccount = currentAccount;
            this.dbContext = dbContext;

            // Đăng ký sự kiện SelectionChanged
            view.SelectionChanged += View_SelectionChanged;

            // Tải dữ liệu dịch vụ
            LoadServiceData();
        }

        public void OpenCustomerServiceManagement()
        {
            try
            {
                FormCustomerServiceManagement form = (FormCustomerServiceManagement)view;
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở FormCustomerServiceManagement: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tải dữ liệu dịch vụ từ bảng SERVICE
        private void LoadServiceData()
        {
            try
            {
                var services = new List<CustomerServiceManagementDisplayModel>();
                using (SqlConnection connection = dbContext.GetConnection())
                {
                    connection.Open();
                    string query = @"
                        SELECT 
                            st.ServiceTypeName, 
                            s.ServiceCode, 
                            s.TotalPrincipalAmount, 
                            s.Duration, 
                            s.InterestRate, 
                            s.TotalInterestAmount, 
                            s.ServiceDescription, 
                            s.CreatedDate, 
                            s.ApplicableDate, 
                            s.EndDate, 
                            e.EmployeeCode, 
                            s.ApprovalStatus, 
                            s.ServiceStatus
                        FROM SERVICE s
                        INNER JOIN SERVICE_TYPE st ON s.ServiceTypeID = st.ServiceTypeID
                        LEFT JOIN EMPLOYEE e ON s.HandledBy = e.EmployeeID
                        WHERE s.AccountID = @AccountID
                        ORDER BY s.CreatedDate DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AccountID", currentAccount.AccountID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var service = new CustomerServiceManagementDisplayModel
                                {
                                    ServiceTypeName = reader.GetString(0),
                                    ServiceCode = reader.GetString(1),
                                    TotalPrincipalAmount = reader.GetDecimal(2).ToString("N0") + " VND",
                                    Duration = reader.GetString(3),
                                    InterestRate = reader.GetDecimal(4).ToString("F2") + " %/năm",
                                    TotalInterestAmount = reader.IsDBNull(5) ? "0 VND" : reader.GetDecimal(5).ToString("N0") + " VND",
                                    ServiceDescription = reader.IsDBNull(6) ? "" : reader.GetString(6),
                                    CreatedDate = reader.GetDateTime(7).ToString("dd/MM/yyyy HH:mm:ss"),
                                    ApplicableDate = reader.IsDBNull(8) ? "" : reader.GetDateTime(8).ToString("dd/MM/yyyy HH:mm:ss"),
                                    EndDate = reader.IsDBNull(9) ? "" : reader.GetDateTime(9).ToString("dd/MM/yyyy HH:mm:ss"),
                                    HandledBy = reader.IsDBNull(10) ? "" : reader.GetString(10),
                                    ApprovalStatus = reader.GetString(11),
                                    ServiceStatus = reader.GetString(12)
                                };
                                services.Add(service);
                            }
                        }
                    }
                }

                // Cập nhật DataGridView thông qua View
                view.UpdateServiceDataGridView(services);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu dịch vụ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý sự kiện khi người dùng chọn một hàng trong DataGridView
        private void View_SelectionChanged(object sender, EventArgs e)
        {
            var rowData = view.GetSelectedRowData();
            if (rowData == null) return;

            var (serviceType, serviceCode, totalPrincipalAmount) = rowData.Value;
            string serviceID = serviceCode?.Replace("DV", "");

            // Lấy trạng thái dịch vụ từ View thông qua interface
            string serviceStatus = view.GetSelectedServiceStatus();

            // Đặt lại các label
            view.ResetLabels();

            if (string.IsNullOrEmpty(serviceType) || string.IsNullOrEmpty(serviceID)) return;

            try
            {
                // Kiểm tra trạng thái dịch vụ
                if (serviceStatus == "Chờ hoạt động" || serviceStatus == "Đã tất toán" || serviceStatus == "Hủy")
                {
                    if (serviceType == "Vay vốn")
                    {
                        view.UpdateLoanLabels(totalPrincipalAmount, serviceStatus);
                    }
                    else if (serviceType == "Gửi tiết kiệm")
                    {
                        view.UpdateSavingsLabels(totalPrincipalAmount, serviceStatus);
                    }
                }
                else
                {
                    using (SqlConnection connection = dbContext.GetConnection())
                    {
                        connection.Open();

                        if (serviceType == "Vay vốn")
                        {
                            // Truy vấn RemainingDebt từ LOAN_PAYMENT
                            string loanQuery = @"
                                SELECT TOP 1 RemainingDebt
                                FROM LOAN_PAYMENT
                                WHERE ServiceID = @ServiceID
                                ORDER BY DueDate DESC";
                            using (SqlCommand command = new SqlCommand(loanQuery, connection))
                            {
                                command.Parameters.AddWithValue("@ServiceID", int.Parse(serviceID));
                                object result = command.ExecuteScalar();
                                string remainingDebt = result != null ? ((decimal)result).ToString("N0") : "0";
                                view.UpdateLoanLabels(totalPrincipalAmount, remainingDebt);
                            }
                        }
                        else if (serviceType == "Gửi tiết kiệm")
                        {
                            // Truy vấn TotalInterestPaid từ SAVINGS_PAYMENT
                            string savingsQuery = @"
                                SELECT TOP 1 TotalInterestPaid
                                FROM SAVINGS_PAYMENT
                                WHERE ServiceID = @ServiceID
                                ORDER BY LastInterestPaidDate DESC";
                            using (SqlCommand command = new SqlCommand(savingsQuery, connection))
                            {
                                command.Parameters.AddWithValue("@ServiceID", int.Parse(serviceID));
                                object result = command.ExecuteScalar();
                                string totalInterestPaid = result != null ? ((decimal)result).ToString("N0") : "0";
                                view.UpdateSavingsLabels(totalPrincipalAmount, totalInterestPaid);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật thông tin dịch vụ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
