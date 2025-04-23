using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Data;
using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Views.Employee;
using QuanLyThongTinKhachHangSacomBank.Views.Common;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.Transactions;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    public class EmployeeServiceManagementController : IOTPController
    {
        private readonly IServiceManagementView view;
        private readonly IConfiguration configuration;
        private readonly DatabaseContext dbContext;
        private readonly EmployeeModel currentEmployee;
        private ServiceModel selectedService;
        private CustomerModel selectedCustomer;
        private CustomerTypeModel selectedCustomerType;
        private List<ServiceModel> services;
        private List<ServiceTypeModel> serviceTypes;
        private List<ServiceDisplayModel> currentServices;
        private bool isAdding;
        private bool isEditing;

        // Triển khai IOTPController
        public string Phone => selectedCustomer?.Phone;
        public string Email => selectedCustomer?.Email;

        public EmployeeServiceManagementController(IServiceManagementView view, IConfiguration configuration, DatabaseContext dbContext, EmployeeModel currentEmployee = null)
        {
            this.view = view;
            this.configuration = configuration;
            this.dbContext = dbContext;
            this.currentEmployee = currentEmployee;
            services = new List<ServiceModel>();
            serviceTypes = new List<ServiceTypeModel>();
            currentServices = new List<ServiceDisplayModel>();
            selectedService = null;
            selectedCustomer = null;
            selectedCustomerType = null;
            isAdding = false;
            isEditing = false;
        }

        public void InitializeControlState()
        {
            view.EnableInputControls(false);
            view.EnableButtons(true, false, false, false, false);
            view.ClearInputs();
        }

        public void LoadInitialData()
        {
            LoadServiceTypes();
            DateTime fromDate = new DateTime(2000, 1, 1);
            DateTime toDate = DateTime.Now;
            view.SetDateFilter(fromDate, toDate);
            LoadServices(fromDate, toDate, "Không áp dụng", "Không áp dụng", "Không áp dụng", "Không áp dụng");
        }

        private void LoadServiceTypes()
        {
            try
            {
                if (dbContext == null)
                {
                    view.ShowMessage("DatabaseContext không được khởi tạo!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM SERVICE_TYPE";
                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            serviceTypes.Clear();
                            while (reader.Read())
                            {
                                serviceTypes.Add(new ServiceTypeModel
                                {
                                    ServiceTypeID = reader.GetInt32(0),
                                    ServiceTypeCode = reader.GetString(1),
                                    ServiceTypeName = reader.GetString(2),
                                    ServiceTypeDescription = reader.GetString(3)
                                });
                            }
                            view.LoadServiceTypes(serviceTypes.Select(st => st.ServiceTypeName).ToList());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi tải danh sách loại dịch vụ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadServices(DateTime fromDate, DateTime toDate, string serviceTypeFilter, string durationFilter, string statusFilter, string approvalStatusFilter)
        {
            try
            {
                if (dbContext == null)
                {
                    view.ShowMessage("DatabaseContext không được khởi tạo!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    string query = @"
                    SELECT s.ServiceID, s.ServiceCode, s.TotalPrincipalAmount, s.Duration, s.InterestRate,
                           s.TotalInterestAmount, s.ServiceDescription, s.CreatedDate, s.ApplicableDate,
                           s.EndDate, s.ApprovalStatus, s.ServiceStatus, s.HandledBy,
                           s.CustomerID, s.AccountID, s.ServiceTypeID,
                           st.ServiceTypeName, a.AccountName, c.CustomerCode, a.AccountCode,
                           e.EmployeeName
                    FROM SERVICE s
                    JOIN SERVICE_TYPE st ON s.ServiceTypeID = st.ServiceTypeID
                    JOIN ACCOUNT a ON s.AccountID = a.AccountID
                    JOIN CUSTOMER c ON a.CustomerID = c.CustomerID
                    LEFT JOIN EMPLOYEE e ON s.HandledBy = e.EmployeeID
                    WHERE s.CreatedDate BETWEEN @FromDate AND @ToDate";

                    if (serviceTypeFilter != "Không áp dụng")
                        query += " AND st.ServiceTypeName = @ServiceType";
                    if (durationFilter != "Không áp dụng")
                        query += " AND s.Duration = @Duration";
                    if (statusFilter != "Không áp dụng")
                        query += " AND s.ServiceStatus = @Status";
                    if (approvalStatusFilter != "Không áp dụng")
                        query += " AND s.ApprovalStatus = @ApprovalStatus";

                    query += " ORDER BY s.CreatedDate DESC";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FromDate", fromDate);
                        command.Parameters.AddWithValue("@ToDate", toDate);
                        if (serviceTypeFilter != "Không áp dụng")
                            command.Parameters.AddWithValue("@ServiceType", serviceTypeFilter);
                        if (durationFilter != "Không áp dụng")
                            command.Parameters.AddWithValue("@Duration", durationFilter);
                        if (statusFilter != "Không áp dụng")
                            command.Parameters.AddWithValue("@Status", statusFilter);
                        if (approvalStatusFilter != "Không áp dụng")
                            command.Parameters.AddWithValue("@ApprovalStatus", approvalStatusFilter);

                        using (var reader = command.ExecuteReader())
                        {
                            services.Clear();
                            currentServices.Clear();
                            while (reader.Read())
                            {
                                var service = new ServiceModel
                                {
                                    ServiceID = reader.GetInt32(0),
                                    ServiceCode = reader.GetString(1),
                                    TotalPrincipalAmount = reader.GetDecimal(2),
                                    Duration = reader.GetString(3),
                                    InterestRate = reader.GetDecimal(4),
                                    TotalInterestAmount = reader.IsDBNull(5) ? null : reader.GetDecimal(5),
                                    ServiceDescription = reader.IsDBNull(6) ? null : reader.GetString(6),
                                    CreatedDate = reader.GetDateTime(7),
                                    ApplicableDate = reader.IsDBNull(8) ? null : reader.GetDateTime(8),
                                    EndDate = reader.IsDBNull(9) ? null : reader.GetDateTime(9),
                                    ApprovalStatus = reader.GetString(10),
                                    ServiceStatus = reader.GetString(11),
                                    HandledBy = reader.IsDBNull(12) ? null : reader.GetInt32(12),
                                    CustomerID = reader.GetInt32(13),
                                    AccountID = reader.GetInt32(14),
                                    ServiceTypeID = reader.GetInt32(15)
                                };
                                services.Add(service);

                                string serviceCode = reader.GetString(1);
                                if (!serviceCode.StartsWith("DV"))
                                    serviceCode = "DV" + serviceCode;

                                currentServices.Add(new ServiceDisplayModel
                                {
                                    ServiceID = service.ServiceID,
                                    CustomerCode = reader.GetString(18),
                                    AccountName = reader.GetString(17),
                                    AccountCode = reader.GetString(19),
                                    ServiceTypeName = reader.GetString(16),
                                    ServiceCode = serviceCode,
                                    TotalPrincipalAmount = service.TotalPrincipalAmount.ToString("N0"),
                                    Duration = service.Duration,
                                    InterestRate = service.InterestRate.ToString("F2") + " %/năm",
                                    TotalInterestAmount = service.TotalInterestAmount?.ToString("N0") ?? "0",
                                    CreatedDate = service.CreatedDate.ToString("dd/MM/yyyy HH:mm:ss"),
                                    ApplicableDate = service.ApplicableDate?.ToString("dd/MM/yyyy HH:mm:ss") ?? "",
                                    EndDate = service.EndDate?.ToString("dd/MM/yyyy HH:mm:ss") ?? "",
                                    ApprovalStatus = service.ApprovalStatus,
                                    ServiceStatus = service.ServiceStatus,
                                    ServiceDescription = service.ServiceDescription ?? "",
                                    HandledBy = reader.IsDBNull(20) ? "" : reader.GetString(20)
                                });
                            }
                            view.UpdateDataGridView(currentServices);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi tải danh sách dịch vụ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void OnServiceSelected(ServiceModel service)
        {
            if (!isAdding && !isEditing)
            {
                selectedService = service;
                selectedCustomer = new CustomerModel
                {
                    CustomerID = service.CustomerID
                };
                selectedCustomerType = new CustomerTypeModel
                {
                    CustomerTypeName = GetCustomerType(service.CustomerID)
                };
                view.SetServiceID(service.ServiceCode);
                view.SetTotalPrincipalAmount(service.TotalPrincipalAmount);
                view.SetInterestRate(service.InterestRate);
                view.SetTotalInterestAmount(service.TotalInterestAmount ?? 0);
                view.SetDuration(service.Duration);
                view.SetCreatedDate(service.CreatedDate.ToString("dd/MM/yyyy HH:mm:ss"));
                view.SetApplicableDate(service.ApplicableDate?.ToString("dd/MM/yyyy HH:mm:ss") ?? "");
                view.SetEndDate(service.EndDate?.ToString("dd/MM/yyyy HH:mm:ss") ?? "");
                view.SetApprovalStatus(service.ApprovalStatus);
                view.SetStatus(service.ServiceStatus);
                view.SetServiceDescription(service.ServiceDescription ?? "");
                view.EnableInputControls(false);
                bool isPendingApproval = service.ApprovalStatus == "Chờ duyệt";
                view.EnableButtons(false, isPendingApproval, isPendingApproval, true, false);
            }
        }

        public void OnServiceDeselected()
        {
            if (!isAdding && !isEditing)
            {
                selectedService = null;
                view.ClearInputs();
                view.EnableInputControls(false);
                view.EnableButtons(true, false, false, false, false);
            }
        }

        private string GetCustomerType(int customerID)
        {
            try
            {
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    string query = @"
                SELECT ct.CustomerTypeName
                FROM CUSTOMER c
                JOIN CUSTOMER_TYPE ct ON c.CustomerTypeID = ct.CustomerTypeID
                WHERE c.CustomerID = @CustomerID";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", customerID);
                        var result = command.ExecuteScalar();
                        return result?.ToString() ?? "Cá nhân";
                    }
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi lấy loại khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Cá nhân";
            }
        }

        public int? GetEmployeeIDFromName(string employeeName)
        {
            if (string.IsNullOrWhiteSpace(employeeName))
                return null;

            try
            {
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT EmployeeID FROM EMPLOYEE WHERE EmployeeName = @EmployeeName";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeName", employeeName);
                        var result = command.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : null;
                    }
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi lấy EmployeeID từ EmployeeName: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public void CalculateInterestRate()
        {
            string serviceType = view.GetServiceTypeName();
            string duration = view.GetDuration();
            string customerCode = view.GetCustomerID();

            if (string.IsNullOrEmpty(serviceType) || string.IsNullOrEmpty(duration) || string.IsNullOrEmpty(customerCode) || selectedCustomerType == null)
            {
                view.SetInterestRate(0);
                view.SetTotalInterestAmount(0);
                return;
            }

            try
            {
                decimal interestRate = 0;
                string customerType = selectedCustomerType.CustomerTypeName;

                if (serviceType == "Vay vốn")
                {
                    switch (customerType)
                    {
                        case "Cá nhân": interestRate = 6.00m; break;
                        case "Doanh nghiệp": interestRate = 5.00m; break;
                        case "VIP Cá nhân": interestRate = 5.00m; break;
                        case "VIP Doanh nghiệp": interestRate = 4.00m; break;
                        default: interestRate = 6.00m; break;
                    }
                }
                else if (serviceType == "Gửi tiết kiệm")
                {
                    string durationValue = duration.Replace(" tháng", "");
                    switch (durationValue)
                    {
                        case "12":
                            interestRate = customerType == "VIP Cá nhân" ? 5.40m : 5.27m;
                            break;
                        case "24":
                            interestRate = customerType == "VIP Cá nhân" ? 5.70m : 5.41m;
                            break;
                        case "36":
                            interestRate = customerType == "VIP Cá nhân" ? 5.70m : 5.27m;
                            break;
                        default:
                            interestRate = 5.27m;
                            break;
                    }
                }

                view.SetInterestRate(interestRate);
                CalculateTotalInterest();
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi tính lãi suất: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                view.SetInterestRate(0);
                view.SetTotalInterestAmount(0);
            }
        }

        public void CalculateTotalInterest()
        {
            decimal principal = view.GetTotalPrincipalAmount();
            decimal interestRate = view.GetInterestRate() / 100; // Chuyển % thành số thập phân
            string durationStr = view.GetDuration();

            if (principal <= 0 || interestRate <= 0 || string.IsNullOrEmpty(durationStr))
            {
                view.SetTotalInterestAmount(0);
                return;
            }

            int durationMonths = int.Parse(durationStr.Replace(" tháng", ""));
            decimal durationYears = durationMonths / 12m;

            decimal totalInterest = principal * interestRate * durationYears;
            view.SetTotalInterestAmount(totalInterest);
        }

        public void OnAccountIDChanged()
        {
            string accountCode = view.GetAccountID().Replace("TK", "").Trim();
            if (string.IsNullOrWhiteSpace(accountCode) || !int.TryParse(accountCode, out int accountID))
            {
                view.ShowMessage("Mã tài khoản không hợp lệ (ví dụ: TK1, TK2)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                view.ClearInputs();
                view.EnableInputControls(true, false);
                view.EnableButtons(false, false, false, true, true);
                selectedCustomer = null;
                selectedCustomerType = null;
                return;
            }

            try
            {
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    string query = @"
                SELECT a.AccountID, a.AccountCode, a.AccountName, c.CustomerID, c.CustomerCode, c.Phone, c.Email,
                       ct.CustomerTypeName, a.Balance
                FROM ACCOUNT a
                JOIN CUSTOMER c ON a.CustomerID = c.CustomerID
                JOIN CUSTOMER_TYPE ct ON c.CustomerTypeID = ct.CustomerTypeID
                WHERE a.AccountID = @AccountID";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AccountID", accountID);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                selectedCustomer = new CustomerModel
                                {
                                    CustomerID = reader.GetInt32(3),
                                    CustomerCode = reader.GetString(4), // Sửa từ GetDecimal sang GetString
                                    Phone = reader.GetString(5),
                                    Email = reader.GetString(6)
                                };
                                selectedCustomerType = new CustomerTypeModel
                                {
                                    CustomerTypeName = reader.GetString(7)
                                };
                                view.SetCustomerID(reader.GetString(4)); // Sửa từ GetDecimal sang GetString
                                view.SetAccountID(reader.GetString(1).StartsWith("TK") ? reader.GetString(1) : "TK" + reader.GetString(1));
                                view.SetAccountName(reader.GetString(2));
                                view.EnableInputControls(true, false);
                                view.EnableButtons(false, false, false, true, true);
                                if (!string.IsNullOrEmpty(view.GetServiceTypeName()) && !string.IsNullOrEmpty(view.GetDuration()))
                                {
                                    CalculateInterestRate();
                                }
                            }
                            else
                            {
                                view.ShowMessage("Không tìm thấy tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                view.SetCustomerID("");
                                view.SetAccountName("");
                                view.EnableInputControls(true, false);
                                view.EnableButtons(false, false, false, true, true);
                                selectedCustomer = null;
                                selectedCustomerType = null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi tải thông tin tài khoản: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                view.SetCustomerID("");
                view.SetAccountName("");
                view.EnableInputControls(true, false);
                view.EnableButtons(false, false, false, true, true);
                selectedCustomer = null;
                selectedCustomerType = null;
            }
        }

        public void AddService()
        {
            isAdding = true;
            isEditing = false;
            selectedService = null;
            selectedCustomer = null;
            selectedCustomerType = null;
            view.ClearInputs();
            view.EnableInputControls(true, false); // Bật tất cả các trường: mã tài khoản, loại dịch vụ, số tiền, kỳ hạn, mô tả
            view.EnableButtons(false, false, false, true, true); // Bật nút Hủy và Lưu
        }

        public void EditService()
        {
            if (selectedService == null)
            {
                view.ShowMessage("Vui lòng chọn một dịch vụ để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem dịch vụ có tồn tại trong CSDL không
            try
            {
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    string query = @"
                        SELECT COUNT(*)
                        FROM SERVICE
                        WHERE ServiceID = @ServiceID";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ServiceID", selectedService.ServiceID);
                        int count = (int)command.ExecuteScalar();
                        if (count == 0)
                        {
                            view.ShowMessage("Dịch vụ không tồn tại trong cơ sở dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            view.ClearInputs();
                            view.EnableInputControls(false);
                            view.EnableButtons(true, false, false, false, false);
                            selectedService = null;
                            LoadServices(view.GetDateFrom(), view.GetDateTo(), view.GetServiceTypeFilter(), view.GetDurationFilter(), view.GetStatusFilter(), view.GetApprovalStatusFilter());
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi kiểm tra dịch vụ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            isEditing = true;
            isAdding = false;
            selectedCustomerType = new CustomerTypeModel
            {
                CustomerTypeName = GetCustomerType(selectedCustomer?.CustomerID ?? 0)
            };
            view.EnableInputControls(true, false, true);
            view.EnableButtons(false, false, false, true, true);
        }

        public void CancelService()
        {
            isAdding = false;
            isEditing = false;
            view.ClearInputs();
            view.EnableInputControls(false);
            view.EnableButtons(true, false, false, false, false);
        }

        public void SaveService()
        {
            // Kiểm tra mã tài khoản
            string accountCode = view.GetAccountID().Replace("TK", "").Trim();
            if (string.IsNullOrWhiteSpace(accountCode) || !int.TryParse(accountCode, out int accountID))
            {
                view.ShowMessage("Mã tài khoản không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra các trường bắt buộc
            string customerCode = view.GetCustomerID();
            string serviceTypeName = view.GetServiceTypeName();
            decimal totalPrincipalAmount = view.GetTotalPrincipalAmount();
            string duration = view.GetDuration();
            string description = view.GetServiceDescription();

            if (string.IsNullOrEmpty(customerCode) || string.IsNullOrEmpty(serviceTypeName) ||
                totalPrincipalAmount <= 0 || string.IsNullOrEmpty(duration) || string.IsNullOrEmpty(description))
            {
                view.ShowMessage("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra currentEmployee
            if (currentEmployee == null || currentEmployee.EmployeeID == 0)
            {
                view.ShowMessage("Không thể xác định nhân viên xử lý! Vui lòng đăng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int customerID;
                string customerType;
                decimal balance;
                int serviceTypeID;
                string customerPhone = null;
                string customerEmail = null;

                // Sử dụng một kết nối duy nhất cho toàn bộ phương thức
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();

                    // Lấy thông tin khách hàng và số dư tài khoản
                    string query = @"
            SELECT c.CustomerID, ct.CustomerTypeName, a.Balance, c.Phone, c.Email
            FROM CUSTOMER c
            JOIN CUSTOMER_TYPE ct ON c.CustomerTypeID = ct.CustomerTypeID
            JOIN ACCOUNT a ON a.CustomerID = c.CustomerID
            WHERE c.CustomerCode = @CustomerCode AND a.AccountID = @AccountID";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerCode", customerCode);
                        command.Parameters.AddWithValue("@AccountID", accountID);
                        using (var reader = command.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                view.ShowMessage("Không tìm thấy khách hàng hoặc tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            customerID = reader.GetInt32(0);
                            customerType = reader.GetString(1);
                            balance = reader.GetDecimal(2);
                            customerPhone = reader.IsDBNull(3) ? null : reader.GetString(3);
                            customerEmail = reader.IsDBNull(4) ? null : reader.GetString(4);

                            // Cập nhật selectedCustomer với Phone và Email
                            selectedCustomer = new CustomerModel
                            {
                                CustomerID = customerID,
                                CustomerCode = customerCode,
                                Phone = customerPhone,
                                Email = customerEmail
                            };
                        }
                    }

                    // Lấy ServiceTypeID
                    if (isAdding)
                    {
                        var serviceType = serviceTypes.FirstOrDefault(st => st.ServiceTypeName == serviceTypeName);
                        if (serviceType == null)
                        {
                            view.ShowMessage("Loại dịch vụ không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        serviceTypeID = serviceType.ServiceTypeID;
                    }
                    else if (isEditing)
                    {
                        // Trong chế độ sửa, sử dụng ServiceTypeID của dịch vụ hiện tại
                        if (selectedService == null)
                        {
                            view.ShowMessage("Không có dịch vụ nào được chọn để chỉnh sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        serviceTypeID = selectedService.ServiceTypeID;

                        // Kiểm tra trạng thái dịch vụ
                        string statusQuery = @"
                SELECT ApprovalStatus, ServiceStatus
                FROM SERVICE
                WHERE ServiceID = @ServiceID";
                        using (var statusCommand = new SqlCommand(statusQuery, connection))
                        {
                            statusCommand.Parameters.AddWithValue("@ServiceID", selectedService.ServiceID);
                            using (var statusReader = statusCommand.ExecuteReader())
                            {
                                if (statusReader.Read())
                                {
                                    string approvalStatus = statusReader.GetString(0);
                                    string serviceStatus = statusReader.GetString(1);
                                    if (approvalStatus != "Chờ duyệt" || serviceStatus != "Chờ hoạt động")
                                    {
                                        view.ShowMessage("Không thể chỉnh sửa dịch vụ đã duyệt hoặc đang hoạt động!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                                else
                                {
                                    view.ShowMessage("Không tìm thấy dịch vụ để chỉnh sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        view.ShowMessage("Trạng thái không hợp lệ để lưu dịch vụ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Kiểm tra hợp lệ số tiền vay hoặc gửi tiết kiệm
                    if (serviceTypeName == "Vay vốn" && !ValidateLoan(totalPrincipalAmount, customerType))
                        return;
                    if (serviceTypeName == "Gửi tiết kiệm" && !ValidateSavings(totalPrincipalAmount, balance, customerType))
                        return;

                    // Xác nhận từ người dùng
                    string message = isAdding ? "Bạn có chắc chắn muốn đăng ký dịch vụ cho khách hàng này?" : "Bạn có chắc chắn muốn cập nhật dịch vụ tài chính?";
                    if (view.ShowConfirmation(message, "Xác nhận") != DialogResult.Yes)
                        return;

                    // Kiểm tra Phone và Email trước khi gọi ShowOTPForm
                    if (string.IsNullOrEmpty(selectedCustomer?.Phone) && string.IsNullOrEmpty(selectedCustomer?.Email))
                    {
                        view.ShowMessage("Không thể gửi OTP vì không có thông tin số điện thoại hoặc email của khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Xác nhận OTP
                    if (!ShowOTPForm())
                    {
                        view.ShowMessage("Xác nhận OTP không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    decimal interestRate = view.GetInterestRate();
                    decimal totalInterest = view.GetTotalInterestAmount();

                    // Logic lưu dịch vụ
                    if (isAdding)
                    {
                        // Thêm dịch vụ mới
                        string insertQuery = @"
                INSERT INTO SERVICE (TotalPrincipalAmount, Duration, InterestRate, 
                    TotalInterestAmount, ServiceDescription, CreatedDate, ApprovalStatus, 
                    ServiceStatus, HandledBy, CustomerID, AccountID, ServiceTypeID)
                VALUES (@TotalPrincipalAmount, @Duration, @InterestRate, 
                    @TotalInterestAmount, @ServiceDescription, @CreatedDate, @ApprovalStatus, 
                    @ServiceStatus, @HandledBy, @CustomerID, @AccountID, @ServiceTypeID)";
                        using (var command = new SqlCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@TotalPrincipalAmount", totalPrincipalAmount);
                            command.Parameters.AddWithValue("@Duration", duration);
                            command.Parameters.AddWithValue("@InterestRate", interestRate);
                            command.Parameters.AddWithValue("@TotalInterestAmount", totalInterest);
                            command.Parameters.AddWithValue("@ServiceDescription", description ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                            command.Parameters.AddWithValue("@ApprovalStatus", "Chờ duyệt");
                            command.Parameters.AddWithValue("@ServiceStatus", "Chờ hoạt động");
                            command.Parameters.AddWithValue("@HandledBy", currentEmployee.EmployeeID);
                            command.Parameters.AddWithValue("@CustomerID", customerID);
                            command.Parameters.AddWithValue("@AccountID", accountID);
                            command.Parameters.AddWithValue("@ServiceTypeID", serviceTypeID);
                            command.ExecuteNonQuery();
                        }
                    }
                    else if (isEditing)
                    {
                        // Cập nhật dịch vụ hiện tại
                        string updateQuery = @"
                UPDATE SERVICE
                SET TotalPrincipalAmount = @TotalPrincipalAmount, 
                    Duration = @Duration, 
                    InterestRate = @InterestRate, 
                    TotalInterestAmount = @TotalInterestAmount,
                    ServiceDescription = @ServiceDescription
                WHERE ServiceID = @ServiceID";
                        using (var command = new SqlCommand(updateQuery, connection))
                        {
                            command.Parameters.AddWithValue("@ServiceID", selectedService.ServiceID);
                            command.Parameters.AddWithValue("@TotalPrincipalAmount", totalPrincipalAmount);
                            command.Parameters.AddWithValue("@Duration", duration);
                            command.Parameters.AddWithValue("@InterestRate", interestRate);
                            command.Parameters.AddWithValue("@TotalInterestAmount", totalInterest);
                            command.Parameters.AddWithValue("@ServiceDescription", description ?? (object)DBNull.Value);
                            command.ExecuteNonQuery();
                        }
                    }
                }

                view.ShowMessage("Đăng ký yêu cầu dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isAdding = false;
                isEditing = false;
                view.ClearInputs();
                view.EnableInputControls(false);
                view.EnableButtons(true, false, false, false, false);
                LoadServices(view.GetDateFrom(), view.GetDateTo(), view.GetServiceTypeFilter(), view.GetDurationFilter(), view.GetStatusFilter(), view.GetApprovalStatusFilter());
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi lưu dịch vụ: {ex.Message}\nStack Trace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateLoan(decimal amount, string customerType)
        {
            if (customerType.Contains("Cá nhân"))
            {
                if (amount < 5_000_000)
                {
                    view.ShowMessage("Số tiền vay tối thiểu cho khách hàng cá nhân là 5,000,000 VND!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (customerType == "Cá nhân" && amount > 100_000_000)
                {
                    view.ShowMessage("Số tiền vay tối đa cho khách hàng cá nhân là 100,000,000 VND!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (customerType == "VIP Cá nhân" && amount > 200_000_000)
                {
                    view.ShowMessage("Số tiền vay tối đa cho khách hàng VIP cá nhân là 200,000,000 VND!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else if (customerType.Contains("Doanh nghiệp"))
            {
                if (amount < 50_000_000)
                {
                    view.ShowMessage("Số tiền vay tối thiểu cho khách hàng doanh nghiệp là 50,000,000 VND!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (customerType == "Doanh nghiệp" && amount > 5_000_000_000)
                {
                    view.ShowMessage("Số tiền vay tối đa cho khách hàng doanh nghiệp là 5,000,000,000 VND!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (customerType == "VIP Doanh nghiệp" && amount > 10_000_000_000)
                {
                    view.ShowMessage("Số tiền vay tối đa cho khách hàng VIP doanh nghiệp là 10,000,000,000 VND!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private bool ValidateSavings(decimal amount, decimal balance, string customerType)
        {
            
            if (customerType.Contains("Cá nhân"))
            {
                if (amount > balance)
                {
                    view.ShowMessage("Số dư tài khoản không đủ để gửi tiết kiệm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (amount < 1_000_000)
                {
                    view.ShowMessage("Số tiền gửi của tài khoản cá nhân phải từ 1.000.000 VND", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (customerType == "Cá nhân" && amount > 20_000_000_000)
                {
                    view.ShowMessage("Số tiền gửi của tài khoản cá nhân không được vượt quá 20.000.000.000 VND!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (customerType == "VIP Cá nhân" && amount > 30_000_000_000)
                {
                    view.ShowMessage("Số tiền gửi của tài khoản VIP cá nhân không được vượt quá 30.000.000.000 VND!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else if (customerType.Contains("Doanh nghiệp"))
            {
                view.ShowMessage("Dịch vụ gửi tiết kiệm không áp dụng cho khách hàng Doanh nghiệp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            } 
            

            return true;
        }

        private bool ShowOTPForm()
        {
            using (var form = new FormOTP())
            {
                var otpController = new OTPController(form, form, this, configuration);
                return form.ShowDialog() == DialogResult.OK;
            }
        }

        public void DeleteService()
        {
            if (selectedService == null)
            {
                view.ShowMessage("Vui lòng chọn một dịch vụ để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cập nhật lại selectedCustomer với thông tin Phone và Email
            try
            {
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    string query = @"
                SELECT COUNT(*)
                FROM SERVICE
                WHERE ServiceID = @ServiceID";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ServiceID", selectedService.ServiceID);
                        int count = (int)command.ExecuteScalar();
                        if (count == 0)
                        {
                            view.ShowMessage("Dịch vụ không tồn tại trong cơ sở dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            view.ClearInputs();
                            view.EnableInputControls(false);
                            view.EnableButtons(true, false, false, false, false);
                            selectedService = null;
                            LoadServices(view.GetDateFrom(), view.GetDateTo(), view.GetServiceTypeFilter(), view.GetDurationFilter(), view.GetStatusFilter(), view.GetApprovalStatusFilter());
                            return;
                        }
                    }

                    // Kiểm tra trạng thái dịch vụ
                    string statusQuery = @"
                SELECT ApprovalStatus, ServiceStatus
                FROM SERVICE
                WHERE ServiceID = @ServiceID";
                    using (var statusCommand = new SqlCommand(statusQuery, connection))
                    {
                        statusCommand.Parameters.AddWithValue("@ServiceID", selectedService.ServiceID);
                        using (var statusReader = statusCommand.ExecuteReader())
                        {
                            if (statusReader.Read())
                            {
                                string approvalStatus = statusReader.GetString(0);
                                string serviceStatus = statusReader.GetString(1);
                                if (approvalStatus != "Chờ duyệt" || serviceStatus != "Chờ hoạt động")
                                {
                                    view.ShowMessage("Chỉ có thể xóa dịch vụ đang ở trạng thái 'Chờ duyệt' và 'Chờ hoạt động'!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                        }
                    }

                    // Lấy thông tin Phone và Email của khách hàng
                    string customerQuery = @"
                SELECT c.Phone, c.Email
                FROM CUSTOMER c
                JOIN SERVICE s ON s.CustomerID = c.CustomerID
                WHERE s.ServiceID = @ServiceID";
                    using (var customerCommand = new SqlCommand(customerQuery, connection))
                    {
                        customerCommand.Parameters.AddWithValue("@ServiceID", selectedService.ServiceID);
                        using (var customerReader = customerCommand.ExecuteReader())
                        {
                            if (customerReader.Read())
                            {
                                selectedCustomer = new CustomerModel
                                {
                                    CustomerID = selectedService.CustomerID,
                                    Phone = customerReader.GetString(0),
                                    Email = customerReader.GetString(1)
                                };
                            }
                            else
                            {
                                view.ShowMessage("Không tìm thấy thông tin khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi kiểm tra dịch vụ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra Phone và Email trước khi gọi ShowOTPForm
            if (string.IsNullOrEmpty(selectedCustomer?.Phone) && string.IsNullOrEmpty(selectedCustomer?.Email))
            {
                view.ShowMessage("Không thể gửi OTP vì không có thông tin số điện thoại hoặc email của khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hiển thị MessageBox Yes/No để xác nhận xóa
            if (view.ShowConfirmation("Bạn có chắc chắn muốn xóa dịch vụ này?", "Xác nhận") != DialogResult.Yes)
                return;

            // Xác nhận OTP
            if (!ShowOTPForm())
            {
                view.ShowMessage("Xác nhận OTP không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xóa dịch vụ trong CSDL
            try
            {
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    string deleteQuery = @"
                DELETE FROM SERVICE
                WHERE ServiceID = @ServiceID";
                    using (var command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ServiceID", selectedService.ServiceID);
                        command.ExecuteNonQuery();
                    }
                }

                view.ShowMessage("Bạn đã xóa thành công dịch vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                selectedService = null;
                view.ClearInputs();
                view.EnableInputControls(false);
                view.EnableButtons(true, false, false, false, false);
                LoadServices(view.GetDateFrom(), view.GetDateTo(), view.GetServiceTypeFilter(), view.GetDurationFilter(), view.GetStatusFilter(), view.GetApprovalStatusFilter());
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi xóa dịch vụ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SearchServices()
        {
            string searchText = view.GetSearchText().Trim().ToLower();

            // Nếu không có nội dung tìm kiếm, load lại toàn bộ dữ liệu với các bộ lọc hiện tại
            if (string.IsNullOrEmpty(searchText))
            {
                LoadServices(
                    view.GetDateFrom(),
                    view.GetDateTo(),
                    view.GetServiceTypeFilter(),
                    view.GetDurationFilter(),
                    view.GetStatusFilter(),
                    view.GetApprovalStatusFilter()
                );
                return;
            }

            try
            {
                if (dbContext == null)
                {
                    view.ShowMessage("DatabaseContext không được khởi tạo!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    string query = @"
            SELECT s.ServiceID, s.ServiceCode, s.TotalPrincipalAmount, s.Duration, s.InterestRate,
                   s.TotalInterestAmount, s.ServiceDescription, s.CreatedDate, s.ApplicableDate,
                   s.EndDate, s.ApprovalStatus, s.ServiceStatus, s.HandledBy,
                   s.CustomerID, s.AccountID, s.ServiceTypeID,
                   st.ServiceTypeName, a.AccountName, c.CustomerCode, a.AccountCode,
                   e.EmployeeName
            FROM SERVICE s
            JOIN SERVICE_TYPE st ON s.ServiceTypeID = st.ServiceTypeID
            JOIN ACCOUNT a ON s.AccountID = a.AccountID
            JOIN CUSTOMER c ON a.CustomerID = c.CustomerID
            LEFT JOIN EMPLOYEE e ON s.HandledBy = e.EmployeeID
            WHERE s.CreatedDate BETWEEN @FromDate AND @ToDate";

                    // Thêm điều kiện tìm kiếm
                    query += " AND (LOWER(c.CustomerCode) LIKE @SearchText OR LOWER(a.AccountName) LIKE @SearchText OR LOWER(a.AccountCode) LIKE @SearchText OR LOWER(s.ServiceCode) LIKE @SearchText)";

                    // Thêm các bộ lọc khác
                    string serviceTypeFilter = view.GetServiceTypeFilter();
                    string durationFilter = view.GetDurationFilter();
                    string statusFilter = view.GetStatusFilter();
                    string approvalStatusFilter = view.GetApprovalStatusFilter();

                    if (serviceTypeFilter != "Không áp dụng")
                        query += " AND st.ServiceTypeName = @ServiceType";
                    if (durationFilter != "Không áp dụng")
                        query += " AND s.Duration = @Duration";
                    if (statusFilter != "Không áp dụng")
                        query += " AND s.ServiceStatus = @Status";
                    if (approvalStatusFilter != "Không áp dụng")
                        query += " AND s.ApprovalStatus = @ApprovalStatus";

                    query += " ORDER BY s.CreatedDate DESC";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FromDate", view.GetDateFrom());
                        command.Parameters.AddWithValue("@ToDate", view.GetDateTo());
                        command.Parameters.AddWithValue("@SearchText", $"%{searchText}%");
                        if (serviceTypeFilter != "Không áp dụng")
                            command.Parameters.AddWithValue("@ServiceType", serviceTypeFilter);
                        if (durationFilter != "Không áp dụng")
                            command.Parameters.AddWithValue("@Duration", durationFilter);
                        if (statusFilter != "Không áp dụng")
                            command.Parameters.AddWithValue("@Status", statusFilter);
                        if (approvalStatusFilter != "Không áp dụng")
                            command.Parameters.AddWithValue("@ApprovalStatus", approvalStatusFilter);

                        using (var reader = command.ExecuteReader())
                        {
                            services.Clear();
                            currentServices.Clear();
                            while (reader.Read())
                            {
                                var service = new ServiceModel
                                {
                                    ServiceID = reader.GetInt32(0),
                                    ServiceCode = reader.GetString(1),
                                    TotalPrincipalAmount = reader.GetDecimal(2),
                                    Duration = reader.GetString(3),
                                    InterestRate = reader.GetDecimal(4),
                                    TotalInterestAmount = reader.IsDBNull(5) ? null : reader.GetDecimal(5),
                                    ServiceDescription = reader.IsDBNull(6) ? null : reader.GetString(6),
                                    CreatedDate = reader.GetDateTime(7),
                                    ApplicableDate = reader.IsDBNull(8) ? null : reader.GetDateTime(8),
                                    EndDate = reader.IsDBNull(9) ? null : reader.GetDateTime(9),
                                    ApprovalStatus = reader.GetString(10),
                                    ServiceStatus = reader.GetString(11),
                                    HandledBy = reader.IsDBNull(12) ? null : reader.GetInt32(12),
                                    CustomerID = reader.GetInt32(13),
                                    AccountID = reader.GetInt32(14),
                                    ServiceTypeID = reader.GetInt32(15)
                                };
                                services.Add(service);

                                string serviceCode = reader.GetString(1);
                                if (!serviceCode.StartsWith("DV"))
                                    serviceCode = "DV" + serviceCode;

                                currentServices.Add(new ServiceDisplayModel
                                {
                                    ServiceID = service.ServiceID,
                                    CustomerCode = reader.GetString(18),
                                    AccountName = reader.GetString(17),
                                    AccountCode = reader.GetString(19),
                                    ServiceTypeName = reader.GetString(16),
                                    ServiceCode = serviceCode,
                                    TotalPrincipalAmount = service.TotalPrincipalAmount.ToString("N0"),
                                    Duration = service.Duration,
                                    InterestRate = service.InterestRate.ToString("F2") + " %/năm",
                                    TotalInterestAmount = service.TotalInterestAmount?.ToString("N0") ?? "0",
                                    CreatedDate = service.CreatedDate.ToString("dd/MM/yyyy HH:mm:ss"),
                                    ApplicableDate = service.ApplicableDate?.ToString("dd/MM/yyyy HH:mm:ss") ?? "",
                                    EndDate = service.EndDate?.ToString("dd/MM/yyyy HH:mm:ss") ?? "",
                                    ApprovalStatus = service.ApprovalStatus,
                                    ServiceStatus = service.ServiceStatus,
                                    ServiceDescription = service.ServiceDescription ?? "",
                                    HandledBy = reader.IsDBNull(20) ? "" : reader.GetString(20)
                                });
                            }
                            view.UpdateDataGridView(currentServices);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi tìm kiếm dịch vụ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExportToPDF()
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF files (*.pdf)|*.pdf",
                    FileName = "ServiceList.pdf"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Document document = new Document(PageSize.A4.Rotate(), 36, 36, 36, 36);
                    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));
                    document.Open();

                    // Thiết lập font tiếng Việt
                    BaseFont baseFontNormal = BaseFont.CreateFont(@"Resources/fonts/ARIAL.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    BaseFont baseFontBold = BaseFont.CreateFont(@"Resources/fonts/ARIALBD.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font vietnameseFont = new iTextSharp.text.Font(baseFontNormal, 10);
                    iTextSharp.text.Font vietnameseFontBold = new iTextSharp.text.Font(baseFontBold, 10);
                    iTextSharp.text.Font headerFont = new iTextSharp.text.Font(baseFontBold, 18, iTextSharp.text.Font.ITALIC, new BaseColor(0, 102, 204));
                    iTextSharp.text.Font subHeaderFont = new iTextSharp.text.Font(baseFontBold, 12);
                    iTextSharp.text.Font footerHighlightFont = new iTextSharp.text.Font(baseFontBold, 10, iTextSharp.text.Font.NORMAL, new BaseColor(255, 147, 0));

                    // Header
                    document.Add(new Paragraph("Sacombank", headerFont)
                    {
                        Alignment = Element.ALIGN_LEFT
                    });

                    document.Add(new Paragraph("DANH SÁCH DỊCH VỤ", subHeaderFont)
                    {
                        Alignment = Element.ALIGN_LEFT
                    });

                    document.Add(new Paragraph($"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}", vietnameseFont)
                    {
                        Alignment = Element.ALIGN_LEFT
                    });

                    // Thêm đường kẻ ngang màu xanh dưới header
                    PdfPTable lineTable = new PdfPTable(1);
                    lineTable.WidthPercentage = 100;
                    PdfPCell lineCell = new PdfPCell() { Border = PdfPCell.BOTTOM_BORDER, BorderColor = new BaseColor(0, 102, 204), FixedHeight = 5f };
                    lineTable.AddCell(lineCell);
                    document.Add(lineTable);

                    document.Add(new Paragraph("\n"));

                    // Bảng dữ liệu
                    PdfPTable pdfTable = new PdfPTable(16); // 16 cột (dựa trên ServiceDisplayModel)
                    pdfTable.WidthPercentage = 100;
                    pdfTable.SetWidths(new float[] { 1f, 1.5f, 1f, 1f, 1f, 1f, 1.5f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f });

                    // Thêm tiêu đề cột với màu nền
                    string[] headers = {
                "Mã khách hàng", "Tên tài khoản", "Mã tài khoản", "Loại dịch vụ", "Mã dịch vụ", "Số tiền gốc",
                "Mô tả", "Kỳ hạn", "Lãi suất", "Tiền lãi", "Ngày tạo", "Ngày áp dụng", "Ngày kết thúc",
                "Xử lý bởi", "Trạng thái duyệt", "Trạng thái dịch vụ"
            };
                    foreach (var header in headers)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(header, vietnameseFontBold))
                        {
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            BackgroundColor = new BaseColor(200, 220, 255),
                            Padding = 5f
                        };
                        pdfTable.AddCell(cell);
                    }

                    // Thêm dữ liệu từ danh sách currentServices
                    foreach (var service in currentServices)
                    {
                        pdfTable.AddCell(new Phrase(service.CustomerCode, vietnameseFont));
                        pdfTable.AddCell(new Phrase(service.AccountName, vietnameseFont));
                        pdfTable.AddCell(new Phrase(service.AccountCode, vietnameseFont));
                        pdfTable.AddCell(new Phrase(service.ServiceTypeName, vietnameseFont));
                        pdfTable.AddCell(new Phrase(service.ServiceCode, vietnameseFont));
                        pdfTable.AddCell(new Phrase(service.TotalPrincipalAmount, vietnameseFont));
                        pdfTable.AddCell(new Phrase(service.ServiceDescription, vietnameseFont));
                        pdfTable.AddCell(new Phrase(service.Duration, vietnameseFont));
                        pdfTable.AddCell(new Phrase(service.InterestRate, vietnameseFont));
                        pdfTable.AddCell(new Phrase(service.TotalInterestAmount, vietnameseFont));
                        pdfTable.AddCell(new Phrase(service.CreatedDate, vietnameseFont));
                        pdfTable.AddCell(new Phrase(service.ApplicableDate, vietnameseFont));
                        pdfTable.AddCell(new Phrase(service.EndDate, vietnameseFont));
                        pdfTable.AddCell(new Phrase(service.HandledBy, vietnameseFont));
                        pdfTable.AddCell(new Phrase(service.ApprovalStatus, vietnameseFont));
                        pdfTable.AddCell(new Phrase(service.ServiceStatus, vietnameseFont));
                    }

                    document.Add(pdfTable);

                    // Footer
                    document.Add(new Paragraph("\n\n"));
                    PdfPTable footerTable = new PdfPTable(1);
                    footerTable.WidthPercentage = 100;
                    PdfPCell footerCell = new PdfPCell();
                    footerCell.Border = PdfPCell.NO_BORDER;
                    footerCell.HorizontalAlignment = Element.ALIGN_LEFT;

                    footerCell.AddElement(new Paragraph("NGÂN HÀNG THƯƠNG MẠI CỔ PHẦN SÀI GÒN THƯƠNG TÍN", footerHighlightFont)
                    {
                        Alignment = Element.ALIGN_LEFT
                    });
                    footerCell.AddElement(new Paragraph("•  266 - 268 Nam Kỳ Khởi Nghĩa, Q.3, TP.HCM", vietnameseFont)
                    {
                        Alignment = Element.ALIGN_LEFT
                    });
                    footerCell.AddElement(new Paragraph("•  1800 5858 88/+84 28 3526 6060", vietnameseFont)
                    {
                        Alignment = Element.ALIGN_LEFT
                    });
                    footerCell.AddElement(new Paragraph("•  sacombank.com.vn/ask@sacombank.com", vietnameseFont)
                    {
                        Alignment = Element.ALIGN_LEFT
                    });

                    footerTable.AddCell(footerCell);
                    document.Add(footerTable);

                    document.Close();
                    view.ShowMessage("Xuất PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi xuất PDF: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExportToExcel()
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    FileName = "ServiceList.xlsx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Khởi tạo ứng dụng Excel
                    excelApp = new Excel.Application();
                    if (excelApp == null)
                    {
                        throw new Exception("Không thể khởi tạo ứng dụng Excel. Vui lòng kiểm tra cài đặt Microsoft Excel trên máy.");
                    }

                    excelApp.Visible = false; // Không hiển thị Excel khi chạy
                    excelApp.DisplayAlerts = false; // Tắt các cảnh báo của Excel

                    // Tạo workbook và worksheet mới
                    workbook = excelApp.Workbooks.Add();
                    worksheet = (Excel.Worksheet)workbook.Sheets[1];
                    worksheet.Name = "ServiceList";

                    // Header "Sacombank" màu đỏ đậm, in nghiêng, font lớn, gộp ô (2 hàng, 2 cột), không có border
                    Excel.Range headerRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[2, 2]];
                    headerRange.Merge();
                    headerRange.Value = "Sacombank";
                    headerRange.Font.Name = "Arial";
                    headerRange.Font.Bold = true; // Arial Bold
                    headerRange.Font.Size = 16;
                    headerRange.Font.Color = System.Drawing.Color.DarkRed.ToArgb(); // Màu đỏ đậm
                    headerRange.Font.Italic = true;
                    headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter; // Căn giữa
                    headerRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter; // Căn giữa theo chiều dọc

                    // Tiêu đề "DANH SÁCH DỊCH VỤ" (hàng 3)
                    Excel.Range subHeaderRange = worksheet.Range[worksheet.Cells[3, 1], worksheet.Cells[3, 2]];
                    subHeaderRange.Merge();
                    subHeaderRange.Value = "DANH SÁCH DỊCH VỤ";
                    subHeaderRange.Font.Name = "Arial";
                    subHeaderRange.Font.Bold = true;
                    subHeaderRange.Font.Size = 12;
                    subHeaderRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                    // Ngày xuất (hàng 4)
                    Excel.Range dateRange = worksheet.Range[worksheet.Cells[4, 1], worksheet.Cells[4, 2]];
                    dateRange.Merge();
                    dateRange.Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
                    dateRange.Font.Name = "Arial";
                    dateRange.Font.Size = 10;
                    dateRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                    // Tiêu đề cột (bắt đầu từ hàng 6)
                    string[] headers = {
                "Mã khách hàng", "Tên tài khoản", "Mã tài khoản", "Loại dịch vụ", "Mã dịch vụ", "Số tiền gốc",
                "Mô tả", "Kỳ hạn", "Lãi suất", "Tiền lãi", "Ngày tạo", "Ngày áp dụng", "Ngày kết thúc",
                "Xử lý bởi", "Trạng thái duyệt", "Trạng thái dịch vụ"
            };
                    for (int i = 0; i < headers.Length; i++)
                    {
                        Excel.Range headerCell = worksheet.Cells[6, i + 1];
                        headerCell.Value = headers[i];
                        headerCell.Font.Bold = true; // In đậm chữ
                        headerCell.Interior.Color = System.Drawing.Color.FromArgb(252, 186, 3).ToArgb(); // Tô màu nền
                        headerCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous; // Thêm border
                        headerCell.Borders.Weight = Excel.XlBorderWeight.xlThin;
                    }

                    // Thêm dữ liệu từ danh sách currentServices (bắt đầu từ hàng 7)
                    for (int i = 0; i < currentServices.Count; i++)
                    {
                        var service = currentServices[i];
                        Excel.Range rowRange = worksheet.Range[worksheet.Cells[i + 7, 1], worksheet.Cells[i + 7, 16]];
                        worksheet.Cells[i + 7, 1] = service.CustomerCode;
                        worksheet.Cells[i + 7, 2] = service.AccountName;
                        worksheet.Cells[i + 7, 3] = service.AccountCode;
                        worksheet.Cells[i + 7, 4] = service.ServiceTypeName;
                        worksheet.Cells[i + 7, 5] = service.ServiceCode;
                        worksheet.Cells[i + 7, 6] = service.TotalPrincipalAmount;
                        worksheet.Cells[i + 7, 7] = service.ServiceDescription;
                        worksheet.Cells[i + 7, 8] = service.Duration;
                        worksheet.Cells[i + 7, 9] = service.InterestRate;
                        worksheet.Cells[i + 7, 10] = service.TotalInterestAmount;
                        worksheet.Cells[i + 7, 11] = service.CreatedDate;
                        worksheet.Cells[i + 7, 12] = service.ApplicableDate;
                        worksheet.Cells[i + 7, 13] = service.EndDate;
                        worksheet.Cells[i + 7, 14] = service.HandledBy;
                        worksheet.Cells[i + 7, 15] = service.ApprovalStatus;
                        worksheet.Cells[i + 7, 16] = service.ServiceStatus;

                        // Thêm border cho các ô dữ liệu
                        rowRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        rowRange.Borders.Weight = Excel.XlBorderWeight.xlThin;
                    }

                    // Footer (thêm vào sau dữ liệu)
                    int lastRow = currentServices.Count + 8; // +8 để cách 1 dòng sau dữ liệu
                    Excel.Range footerRange1 = worksheet.Cells[lastRow, 1];
                    footerRange1.Value = "NGÂN HÀNG THƯƠNG MẠI CỔ PHẦN SÀI GÒN THƯƠNG TÍN";
                    footerRange1.Font.Name = "Arial";
                    footerRange1.Font.Bold = true;
                    footerRange1.Font.Size = 10;
                    footerRange1.Font.Color = System.Drawing.Color.FromArgb(255, 147, 0).ToArgb(); // Màu cam

                    Excel.Range footerRange2 = worksheet.Cells[lastRow + 1, 1];
                    footerRange2.Value = "•  266 - 268 Nam Kỳ Khởi Nghĩa, Q.3, TP.HCM";
                    footerRange2.Font.Name = "Arial";
                    footerRange2.Font.Size = 10;

                    Excel.Range footerRange3 = worksheet.Cells[lastRow + 2, 1];
                    footerRange3.Value = "•  1800 5858 88/+84 28 3526 6060";
                    footerRange3.Font.Name = "Arial";
                    footerRange3.Font.Size = 10;

                    Excel.Range footerRange4 = worksheet.Cells[lastRow + 3, 1];
                    footerRange4.Value = "•  sacombank.com.vn/ask@sacombank.com";
                    footerRange4.Font.Name = "Arial";
                    footerRange4.Font.Size = 10;

                    // Autosize cột dựa trên dữ liệu
                    for (int i = 1; i <= 16; i++)
                    {
                        worksheet.Columns[i].AutoFit();
                    }

                    // Lưu file
                    workbook.SaveAs(saveFileDialog.FileName, Excel.XlFileFormat.xlOpenXMLWorkbook);
                    view.ShowMessage("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đóng workbook và Excel
                if (worksheet != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                }
                if (workbook != null)
                {
                    workbook.Close(false);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                }
                if (excelApp != null)
                {
                    excelApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                }
            }
        }

        public void ExportToCSV()
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv",
                    FileName = "ServiceList.csv"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder csvContent = new StringBuilder();

                    // Tiêu đề cột
                    string[] headers = {
                        "Mã khách hàng", "Tên tài khoản", "Mã tài khoản", "Loại dịch vụ", "Mã dịch vụ", "Số tiền gốc",
                        "Mô tả", "Kỳ hạn", "Lãi suất", "Tiền lãi", "Ngày tạo", "Ngày áp dụng", "Ngày kết thúc",
                        "Xử lý bởi", "Trạng thái duyệt", "Trạng thái dịch vụ"
                    };
                    csvContent.AppendLine(string.Join(",", headers.Select(h => $"\"{h}\"")));

                    // Thêm dữ liệu từ danh sách currentServices
                    foreach (var service in currentServices)
                    {
                        string[] rowData = new string[]
                        {
                            service.CustomerCode?.Replace("\"", "\"\"") ?? "",
                            service.AccountName?.Replace("\"", "\"\"") ?? "",
                            service.AccountCode?.Replace("\"", "\"\"") ?? "",
                            service.ServiceTypeName?.Replace("\"", "\"\"") ?? "",
                            service.ServiceCode?.Replace("\"", "\"\"") ?? "",
                            service.TotalPrincipalAmount?.Replace("\"", "\"\"") ?? "",
                            service.ServiceDescription?.Replace("\"", "\"\"") ?? "",
                            service.Duration?.Replace("\"", "\"\"") ?? "",
                            service.InterestRate?.Replace("\"", "\"\"") ?? "",
                            service.TotalInterestAmount?.Replace("\"", "\"\"") ?? "",
                            service.CreatedDate?.Replace("\"", "\"\"") ?? "",
                            service.ApplicableDate?.Replace("\"", "\"\"") ?? "",
                            service.EndDate?.Replace("\"", "\"\"") ?? "",
                            service.HandledBy?.Replace("\"", "\"\"") ?? "",
                            service.ApprovalStatus?.Replace("\"", "\"\"") ?? "",
                            service.ServiceStatus?.Replace("\"", "\"\"") ?? ""
                        };
                        csvContent.AppendLine(string.Join(",", rowData.Select(d => $"\"{d}\"")));
                    }

                    // Sử dụng UTF-16 LE (Unicode) để đảm bảo Excel hiển thị tiếng Việt đúng
                    var utf16Le = new UnicodeEncoding(false, true); // UTF-16 LE với BOM
                    File.WriteAllBytes(saveFileDialog.FileName, utf16Le.GetBytes(csvContent.ToString()));
                    view.ShowMessage("Xuất CSV thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi xuất CSV: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CancelSavings()
        {
            // Chưa triển khai
        }

        public void LoanPrepayment()
        {
            if (selectedService == null)
            {
                view.ShowMessage("Vui lòng chọn một dịch vụ để tất toán khoản vay!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra trạng thái dịch vụ
            if (selectedService.ServiceStatus != "Đang hoạt động" && selectedService.ServiceStatus != "Trễ hạn thanh toán")
            {
                view.ShowMessage("Chỉ có thể tất toán khoản vay ở trạng thái 'Đang hoạt động' hoặc 'Trễ hạn thanh toán'!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra loại dịch vụ (chỉ áp dụng cho "Vay vốn")
            var serviceType = serviceTypes.FirstOrDefault(st => st.ServiceTypeID == selectedService.ServiceTypeID);
            if (serviceType == null || serviceType.ServiceTypeName != "Vay vốn")
            {
                view.ShowMessage("Chức năng tất toán chỉ áp dụng cho dịch vụ 'Vay vốn'!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                decimal remainingDebt = 0;
                decimal lateFee = 0;
                decimal balance = 0;
                string accountName = "";

                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();

                    // 1. Truy vấn bản ghi LOAN_PAYMENT gần nhất dựa trên ServiceID
                    string loanPaymentQuery = @"
                SELECT TOP 1 RemainingDebt, LateFee
                FROM LOAN_PAYMENT
                WHERE ServiceID = @ServiceID
                ORDER BY DueDate DESC";
                    using (var command = new SqlCommand(loanPaymentQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ServiceID", selectedService.ServiceID);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                remainingDebt = reader.GetDecimal(0);
                                lateFee = reader.GetDecimal(1);
                            }
                            else
                            {
                                view.ShowMessage("Không tìm thấy thông tin thanh toán khoản vay cho dịch vụ này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }

                    // 2. Lấy số dư tài khoản và tên tài khoản
                    string accountQuery = @"
                SELECT a.Balance, a.AccountName
                FROM ACCOUNT a
                WHERE a.AccountID = @AccountID";
                    using (var command = new SqlCommand(accountQuery, connection))
                    {
                        command.Parameters.AddWithValue("@AccountID", selectedService.AccountID);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                balance = reader.GetDecimal(0);
                                accountName = reader.GetString(1);
                            }
                            else
                            {
                                view.ShowMessage("Không tìm thấy thông tin tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }

                    // 3. Tính phí tất toán trước hạn và tổng số tiền để tất toán
                    decimal prepaymentFee = remainingDebt * 0.02m; // Phí tất toán trước hạn = 2% số nợ còn lại
                    decimal totalPrepaymentAmount = remainingDebt + lateFee + prepaymentFee; // Tổng số tiền để tất toán

                    // 4. Hiển thị thông báo xác nhận
                    string message = "Bạn có chắc chắn tất toán cho khoản vay này?\n\n" +
                                    $"- Số dư tài khoản của khách hàng: {balance:N0} VND\n" +
                                    $"- Tổng số tiền để tất toán: {totalPrepaymentAmount:N0} VND\n" +
                                    "Bao gồm:\n" +
                                    $"  + Số nợ còn lại: {remainingDebt:N0} VND\n" +
                                    $"  + Phí trễ hạn: {lateFee:N0} VND\n" +
                                    $"  + Phí tất toán trước hạn: {prepaymentFee:N0} VND";
                    if (view.ShowConfirmation(message, "Xác nhận tất toán") != DialogResult.Yes)
                        return;

                    // 5. Kiểm tra số dư tài khoản
                    if (balance < totalPrepaymentAmount)
                    {
                        view.ShowMessage("Số dư tài khoản không đủ để tất toán khoản vay!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 6. Xác nhận OTP
                    // Cập nhật thông tin khách hàng trước khi gọi OTP
                    string customerQuery = @"
                SELECT c.Phone, c.Email
                FROM CUSTOMER c
                JOIN SERVICE s ON s.CustomerID = c.CustomerID
                WHERE s.ServiceID = @ServiceID";
                    using (var customerCommand = new SqlCommand(customerQuery, connection))
                    {
                        customerCommand.Parameters.AddWithValue("@ServiceID", selectedService.ServiceID);
                        using (var customerReader = customerCommand.ExecuteReader())
                        {
                            if (customerReader.Read())
                            {
                                selectedCustomer = new CustomerModel
                                {
                                    CustomerID = selectedService.CustomerID,
                                    Phone = customerReader.IsDBNull(0) ? null : customerReader.GetString(0),
                                    Email = customerReader.IsDBNull(1) ? null : customerReader.GetString(1)
                                };
                            }
                            else
                            {
                                view.ShowMessage("Không tìm thấy thông tin khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }

                    if (string.IsNullOrEmpty(selectedCustomer?.Phone) && string.IsNullOrEmpty(selectedCustomer?.Email))
                    {
                        view.ShowMessage("Không thể gửi OTP vì không có thông tin số điện thoại hoặc email của khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!ShowOTPForm())
                    {
                        view.ShowMessage("Xác nhận OTP không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 6.1. Cập nhật trạng thái PaymentStatus của bản ghi LOAN_PAYMENT gần nhất
                    string updateLoanPaymentQuery = @"
                UPDATE LOAN_PAYMENT
                SET PaymentStatus = @PaymentStatus
                WHERE ServiceID = @ServiceID
                AND DueDate = (SELECT MAX(DueDate) FROM LOAN_PAYMENT WHERE ServiceID = @ServiceID)";
                    using (var command = new SqlCommand(updateLoanPaymentQuery, connection))
                    {
                        command.Parameters.AddWithValue("@PaymentStatus", "Đã thanh toán");
                        command.Parameters.AddWithValue("@ServiceID", selectedService.ServiceID);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            view.ShowMessage("Không tìm thấy bản ghi LOAN_PAYMENT gần nhất để cập nhật trạng thái!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // 6.2. Thêm bản ghi vào bảng REVENUE
                    DateTime currentDateTime = DateTime.Now;
                    DateTime currentDate = currentDateTime.Date;

                    string insertRevenueQuery = @"
                        INSERT INTO REVENUE (PrincipalAmount, InterestAmount, LateFee, TotalAmount, RevenueDate, PayLoanID, ProfitID)
                        VALUES (@PrincipalAmount, @InterestAmount, @LateFee, @TotalAmount, @RevenueDate, NULL, NULL)";
                    using (var command = new SqlCommand(insertRevenueQuery, connection))
                    {
                        command.Parameters.AddWithValue("@PrincipalAmount", remainingDebt);
                        command.Parameters.AddWithValue("@InterestAmount", 0m); // Lãi = 0 (hoặc tính nếu có)
                        command.Parameters.AddWithValue("@LateFee", lateFee + prepaymentFee);
                        command.Parameters.AddWithValue("@TotalAmount", totalPrepaymentAmount);
                        command.Parameters.AddWithValue("@RevenueDate", currentDateTime);
                        command.ExecuteNonQuery();
                    }

                    // 6.3. Cập nhật bảng PROFIT
                    int profitId = 0;
                    decimal currentTotalRevenue = 0;
                    decimal currentTotalExpense = 0;

                    string checkProfitQuery = @"
                        SELECT ProfitID, TotalRevenue, TotalExpense
                        FROM PROFIT
                        WHERE CAST(ProfitDate AS DATE) = @ProfitDate";
                    using (var command = new SqlCommand(checkProfitQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ProfitDate", currentDate);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                profitId = reader.GetInt32(0);
                                currentTotalRevenue = reader.IsDBNull(1) ? 0 : reader.GetDecimal(1);
                                currentTotalExpense = reader.IsDBNull(2) ? 0 : reader.GetDecimal(2);
                            }
                        }
                    }

                    if (profitId == 0)
                    {
                        string insertProfitQuery = @"
                            INSERT INTO PROFIT (TotalRevenue, TotalExpense, NetProfit, ProfitDate)
                            VALUES (@TotalRevenue, @TotalExpense, @NetProfit, @ProfitDate);
                            SELECT SCOPE_IDENTITY();";
                        using (var command = new SqlCommand(insertProfitQuery, connection))
                        {
                            command.Parameters.AddWithValue("@TotalRevenue", totalPrepaymentAmount);
                            command.Parameters.AddWithValue("@TotalExpense", 0m);
                            command.Parameters.AddWithValue("@NetProfit", totalPrepaymentAmount);
                            command.Parameters.AddWithValue("@ProfitDate", currentDate);
                            profitId = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }
                    else
                    {
                        decimal newTotalRevenue = currentTotalRevenue + totalPrepaymentAmount;
                        decimal newNetProfit = newTotalRevenue - currentTotalExpense;

                        string updateProfitQuery = @"
                            UPDATE PROFIT
                            SET TotalRevenue = @TotalRevenue,
                                NetProfit = @NetProfit
                            WHERE ProfitID = @ProfitID";
                        using (var command = new SqlCommand(updateProfitQuery, connection))
                        {
                            command.Parameters.AddWithValue("@TotalRevenue", newTotalRevenue);
                            command.Parameters.AddWithValue("@NetProfit", newNetProfit);
                            command.Parameters.AddWithValue("@ProfitID", profitId);
                            command.ExecuteNonQuery();
                        }
                    }

                    // 7. Cập nhật số dư tài khoản
                    string updateBalanceQuery = @"
                UPDATE ACCOUNT
                SET Balance = Balance - @TotalPrepaymentAmount
                WHERE AccountID = @AccountID";
                    using (var command = new SqlCommand(updateBalanceQuery, connection))
                    {
                        command.Parameters.AddWithValue("@TotalPrepaymentAmount", totalPrepaymentAmount);
                        command.Parameters.AddWithValue("@AccountID", selectedService.AccountID);
                        command.ExecuteNonQuery();
                    }

                    // 8. Tạo bản ghi giao dịch trong TRANSACTION
                    string insertTransactionQuery = @"
                INSERT INTO [TRANSACTION] (Amount, TransactionDate, TransactionStatus, HandledBy, TransactionDescription, TransactionMethod, AccountID, TransactionTypeID)
                VALUES (@Amount, @TransactionDate, @TransactionStatus, @HandledBy, @TransactionDescription, @TransactionMethod, @AccountID, @TransactionTypeID)";
                    using (var command = new SqlCommand(insertTransactionQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Amount", totalPrepaymentAmount);
                        command.Parameters.AddWithValue("@TransactionDate", DateTime.Now);
                        command.Parameters.AddWithValue("@TransactionStatus", "Hoàn tất");
                        command.Parameters.AddWithValue("@HandledBy", currentEmployee.EmployeeID);
                        command.Parameters.AddWithValue("@TransactionDescription", $"{accountName} tat toan khoan vay cho dich vu {selectedService.ServiceCode}");
                        command.Parameters.AddWithValue("@TransactionMethod", "Tại quầy");
                        command.Parameters.AddWithValue("@AccountID", selectedService.AccountID);
                        command.Parameters.AddWithValue("@TransactionTypeID", 4); // TransactionTypeID = 4 (Thanh toán khoản vay)
                        command.ExecuteNonQuery();
                    }

                    // 9. Cập nhật trạng thái dịch vụ và ngày kết thúc
                    string updateServiceQuery = @"
                UPDATE [SERVICE]
                SET ServiceStatus = @ServiceStatus, EndDate = @EndDate
                WHERE ServiceID = @ServiceID";
                    using (var command = new SqlCommand(updateServiceQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ServiceStatus", "Đã tất toán");
                        command.Parameters.AddWithValue("@EndDate", DateTime.Now);
                        command.Parameters.AddWithValue("@ServiceID", selectedService.ServiceID);
                        command.ExecuteNonQuery();
                    }

                    // 10. Hiển thị thông báo tất toán thành công với mã dịch vụ
                    view.ShowMessage($"Đã tất toán thành công cho Mã dịch vụ {selectedService.ServiceCode}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    selectedService = null;
                    view.ClearInputs();
                    view.EnableInputControls(false);
                    view.EnableButtons(true, false, false, false, false);
                    LoadServices(view.GetDateFrom(), view.GetDateTo(), view.GetServiceTypeFilter(), view.GetDurationFilter(), view.GetStatusFilter(), view.GetApprovalStatusFilter());
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi tất toán khoản vay: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}