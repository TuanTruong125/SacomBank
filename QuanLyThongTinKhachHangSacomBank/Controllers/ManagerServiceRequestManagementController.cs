using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using Excel = Microsoft.Office.Interop.Excel;
using QuanLyThongTinKhachHangSacomBank.Views.Manager;
using Microsoft.Office.Interop.Excel;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    

    class ManagerServiceRequestManagementController
    {
        private readonly IServiceRequestManagementView view;
        private readonly IConfiguration configuration;
        private readonly DatabaseContext dbContext;
        private List<ServiceModel> services;
        private ServiceModel selectedService; // Lưu dịch vụ được chọn
        private List<ServiceRequestDisplayModel> currentServiceRequests;

        public ManagerServiceRequestManagementController(IServiceRequestManagementView view, IConfiguration configuration, DatabaseContext dbContext)
        {
            this.view = view;
            this.configuration = configuration;
            this.dbContext = dbContext;
            this.services = new List<ServiceModel>();
            this.currentServiceRequests = new List<ServiceRequestDisplayModel>();
            this.selectedService = null;
        }

        public void LoadInitialData()
        {
            LoadServiceTypes();
            DateTime fromDate = DateTime.Now;
            DateTime toDate = DateTime.Now;
            view.SetDateFilter(fromDate, toDate);
            LoadServiceRequests(fromDate, toDate, "Không áp dụng", "Không áp dụng", "Không áp dụng", "Không áp dụng");
        }

        public void LoadServiceTypes()
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
                    string query = "SELECT ServiceTypeName FROM SERVICE_TYPE";
                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            List<string> serviceTypes = new List<string>();
                            while (reader.Read())
                            {
                                serviceTypes.Add(reader.GetString(0));
                            }
                            // Gọi phương thức trong view để cập nhật ComboBox
                            view.LoadServiceTypes(serviceTypes);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi tải danh sách loại dịch vụ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadServiceRequests(DateTime fromDate, DateTime toDate, string serviceTypeFilter, string durationFilter, string statusFilter, string approvalStatusFilter)
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
                        SELECT 
                            s.ServiceID, s.ServiceCode, s.TotalPrincipalAmount, s.Duration, s.InterestRate,
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
                            currentServiceRequests.Clear();
                            var serviceRequests = new List<ServiceRequestDisplayModel>();

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

                                var displayModel = new ServiceRequestDisplayModel
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
                                };
                                serviceRequests.Add(displayModel);
                                currentServiceRequests.Add(displayModel);
                            }

                            view.UpdateDataGridView(serviceRequests);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi tải danh sách yêu cầu dịch vụ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý khi chọn một yêu cầu dịch vụ từ DataGridView
        public void OnServiceRequestSelected(ServiceModel serviceRequest)
        {
            selectedService = serviceRequest;

            try
            {
                view.SetCustomerID($"KH{serviceRequest.CustomerID}");
                view.SetAccountID($"TK{serviceRequest.AccountID}");
                view.SetServiceTypeName(serviceRequest.ServiceTypeID == 1 ? "Vay vốn" : "Gửi tiết kiệm");
                view.SetServiceID(serviceRequest.ServiceCode);
                view.SetTotalPrincipalAmount(serviceRequest.TotalPrincipalAmount);
                view.SetInterestRate(serviceRequest.InterestRate);
                view.SetTotalInterestAmount(serviceRequest.TotalInterestAmount ?? 0);
                view.SetDuration(serviceRequest.Duration);
                view.SetCreatedDate(serviceRequest.CreatedDate.ToString("dd/MM/yyyy HH:mm:ss"));
                view.SetApplicableDate(serviceRequest.ApplicableDate?.ToString("dd/MM/yyyy HH:mm:ss") ?? "");
                view.SetEndDate(serviceRequest.EndDate?.ToString("dd/MM/yyyy HH:mm:ss") ?? "");
                view.SetHandledBy(GetEmployeeNameFromID(serviceRequest.HandledBy));
                view.SetApprovalStatus(serviceRequest.ApprovalStatus);
                view.SetServiceStatus(serviceRequest.ServiceStatus);
                view.SetServiceDescription(serviceRequest.ServiceDescription);

                bool isPendingApproval = serviceRequest.ApprovalStatus == "Chờ duyệt";
                view.EnableApproveButton(isPendingApproval);
                view.EnableDeclineButton(isPendingApproval);
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi hiển thị thông tin dịch vụ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                view.ClearInputs();
                view.EnableApproveButton(false);
                view.EnableDeclineButton(false);
                selectedService = null;
            }
        }

        // Xử lý khi bỏ chọn một yêu cầu dịch vụ
        public void OnServiceRequestDeselected()
        {
            selectedService = null;
            view.ClearInputs();
            view.EnableApproveButton(false);
            view.EnableDeclineButton(false);
        }

        // Lấy ID nhân viên từ tên nhân viên
        public int? GetEmployeeIDFromName(string employeeName)
        {
            if (string.IsNullOrEmpty(employeeName))
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
                        return result != null ? (int?)result : null;
                    }
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi lấy ID nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Lấy tên nhân viên từ ID
        private string GetEmployeeNameFromID(int? employeeID)
        {
            if (employeeID == null)
                return "";

            try
            {
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT EmployeeName FROM EMPLOYEE WHERE EmployeeID = @EmployeeID";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employeeID);
                        var result = command.ExecuteScalar();
                        return result?.ToString() ?? "";
                    }
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi lấy tên nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        // Phương thức tìm kiếm dịch vụ
        public void SearchServiceRequests()
        {
            string searchText = view.GetSearchText().Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                LoadServiceRequests(
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
                SELECT 
                    s.ServiceID, s.ServiceCode, s.TotalPrincipalAmount, s.Duration, s.InterestRate,
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
                WHERE s.CreatedDate BETWEEN @FromDate AND @ToDate
                AND (
                    LOWER(c.CustomerCode) LIKE @SearchText OR
                    LOWER(a.AccountName) LIKE @SearchText OR
                    LOWER(a.AccountCode) LIKE @SearchText OR
                    LOWER(st.ServiceTypeName) LIKE @SearchText OR
                    LOWER(s.ServiceCode) LIKE @SearchText OR
                    LOWER(s.Duration) LIKE @SearchText OR
                    LOWER(CAST(s.InterestRate AS NVARCHAR)) LIKE @SearchText OR
                    CONVERT(nvarchar, s.CreatedDate, 103) LIKE @SearchText OR
                    CONVERT(nvarchar, s.ApplicableDate, 103) LIKE @SearchText OR
                    CONVERT(nvarchar, s.EndDate, 103) LIKE @SearchText OR
                    LOWER(e.EmployeeName) LIKE @SearchText OR
                    LOWER(s.ApprovalStatus) LIKE @SearchText OR
                    LOWER(s.ServiceStatus) LIKE @SearchText
                )";

                    string serviceTypeFilter = view.GetServiceTypeFilter();
                    string durationFilter = view.GetDurationFilter();
                    string statusFilter = view.GetStatusFilter();
                    string approvalStatusFilter = view.GetApprovalStatusFilter();

                    if (serviceTypeFilter != "Không áp dụng")
                    {
                        query += " AND LOWER(TRIM(st.ServiceTypeName)) = @ServiceType";
                        serviceTypeFilter = serviceTypeFilter.Trim().ToLower();
                    }
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
                            currentServiceRequests.Clear();
                            var serviceRequests = new List<ServiceRequestDisplayModel>();

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

                                var displayModel = new ServiceRequestDisplayModel
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
                                };
                                serviceRequests.Add(displayModel);
                                currentServiceRequests.Add(displayModel);
                            }

                            view.UpdateDataGridView(serviceRequests);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi tìm kiếm dịch vụ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý từ chối yêu cầu dịch vụ
        public void DeclineServiceRequest()
        {
            if (selectedService == null)
            {
                view.ShowMessage("Vui lòng chọn một yêu cầu dịch vụ để từ chối!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedService.ApprovalStatus != "Chờ duyệt")
            {
                view.ShowMessage("Yêu cầu dịch vụ này đã được xử lý trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn từ chối yêu cầu dịch vụ này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            try
            {
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    string query = @"
                        UPDATE SERVICE
                        SET ApprovalStatus = @ApprovalStatus, ServiceStatus = @ServiceStatus
                        WHERE ServiceID = @ServiceID";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ApprovalStatus", "Từ chối");
                        command.Parameters.AddWithValue("@ServiceStatus", "Hủy");
                        command.Parameters.AddWithValue("@ServiceID", selectedService.ServiceID);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Tạo bản ghi thông báo cho khách hàng
                            int notificationTypeId;
                            using (var notificationCommand = new SqlCommand("SELECT NotificationTypeID FROM NOTIFICATION_TYPE WHERE NotificationTypeName = @NotificationTypeName", connection))
                            {
                                notificationCommand.Parameters.AddWithValue("@NotificationTypeName", "Dịch vụ");
                                var resultNotification = notificationCommand.ExecuteScalar();
                                if (resultNotification == null)
                                {
                                    view.ShowMessage("Không tìm thấy NotificationTypeID cho 'Dịch vụ'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                notificationTypeId = (int)resultNotification;
                            }

                            string notificationMessage;
                            if (selectedService.ServiceTypeID == 1) // Vay vốn
                            {
                                notificationMessage = $"Ngân hàng đã từ chối yêu cầu vay vốn với mã dịch vụ {selectedService.ServiceCode} từ bạn. Vui lòng liên hệ ngân hàng để biết thêm chi tiết!";
                            }
                            else // Gửi tiết kiệm (ServiceTypeID == 2)
                            {
                                notificationMessage = $"Ngân hàng đã từ chối yêu cầu gửi tiết kiệm với mã dịch vụ {selectedService.ServiceCode} từ bạn. Vui lòng liên hệ ngân hàng để biết thêm chi tiết!";
                            }

                            using (var notificationCommand = new SqlCommand(
                                "INSERT INTO [NOTIFICATION] (Title, NotificationMessage, NotificationDate, NotificationStatus, ReferenceID, CustomerID, EmployeeID, NotificationTypeID) " +
                                "VALUES (@Title, @NotificationMessage, @NotificationDate, @NotificationStatus, @ReferenceID, @CustomerID, @EmployeeID, @NotificationTypeID)", connection))
                            {
                                notificationCommand.Parameters.AddWithValue("@Title", "Yêu cầu dịch vụ đã bị từ chối!");
                                notificationCommand.Parameters.AddWithValue("@NotificationMessage", notificationMessage);
                                notificationCommand.Parameters.AddWithValue("@NotificationDate", DateTime.Now);
                                notificationCommand.Parameters.AddWithValue("@NotificationStatus", "Chưa xem");
                                notificationCommand.Parameters.AddWithValue("@ReferenceID", selectedService.ServiceID);
                                notificationCommand.Parameters.AddWithValue("@CustomerID", selectedService.CustomerID);
                                notificationCommand.Parameters.AddWithValue("@EmployeeID", DBNull.Value);
                                notificationCommand.Parameters.AddWithValue("@NotificationTypeID", notificationTypeId);
                                notificationCommand.ExecuteNonQuery();
                            }

                            view.ShowMessage("Đã từ chối duyệt yêu cầu dịch vụ này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            selectedService.ApprovalStatus = "Từ chối";
                            selectedService.ServiceStatus = "Hủy";
                            SearchServiceRequests();
                            view.ClearInputs();
                            view.EnableApproveButton(false);
                            view.EnableDeclineButton(false);
                        }
                        else
                        {
                            view.ShowMessage("Không thể từ chối yêu cầu dịch vụ này. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi từ chối yêu cầu dịch vụ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý duyệt yêu cầu dịch vụ
        public void ApproveServiceRequest()
        {
            if (selectedService == null)
            {
                view.ShowMessage("Vui lòng chọn một yêu cầu dịch vụ để duyệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedService.ApprovalStatus != "Chờ duyệt")
            {
                view.ShowMessage("Yêu cầu dịch vụ này đã được xử lý trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn duyệt yêu cầu dịch vụ này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            try
            {
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();

                    // Kiểm tra số dư tài khoản nếu là dịch vụ Gửi tiết kiệm (ServiceTypeID == 2)
                    if (selectedService.ServiceTypeID == 2)
                    {
                        string balanceQuery = "SELECT Balance FROM ACCOUNT WHERE AccountID = @AccountID";
                        using (var balanceCommand = new SqlCommand(balanceQuery, connection))
                        {
                            balanceCommand.Parameters.AddWithValue("@AccountID", selectedService.AccountID);
                            var balanceResult = balanceCommand.ExecuteScalar();
                            if (balanceResult == null)
                            {
                                view.ShowMessage("Không thể kiểm tra số dư tài khoản. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            decimal currentBalance = (decimal)balanceResult;
                            if (currentBalance < selectedService.TotalPrincipalAmount)
                            {
                                view.ShowMessage("Không thể duyệt yêu cầu này vì số dư của tài khoản hiện tại không đủ để gửi tiết kiệm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }

                    // Tính EndDate dựa trên ApplicableDate và Duration
                    DateTime applicableDate = DateTime.Now;
                    int durationMonths = int.Parse(selectedService.Duration.Replace(" tháng", ""));
                    DateTime endDate = applicableDate.AddMonths(durationMonths);

                    // Cập nhật thông tin dịch vụ
                    string serviceUpdateQuery = @"
                        UPDATE SERVICE
                        SET ApprovalStatus = @ApprovalStatus, 
                            ServiceStatus = @ServiceStatus, 
                            ApplicableDate = @ApplicableDate, 
                            EndDate = @EndDate
                        WHERE ServiceID = @ServiceID";

                    using (var command = new SqlCommand(serviceUpdateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ApprovalStatus", "Đã duyệt");
                        command.Parameters.AddWithValue("@ServiceStatus", "Đang hoạt động");
                        command.Parameters.AddWithValue("@ApplicableDate", applicableDate);
                        command.Parameters.AddWithValue("@EndDate", endDate);
                        command.Parameters.AddWithValue("@ServiceID", selectedService.ServiceID);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            view.ShowMessage("Không thể duyệt yêu cầu dịch vụ này. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Cập nhật số dư tài khoản dựa trên loại dịch vụ
                    decimal balanceChange = selectedService.TotalPrincipalAmount;
                    string accountUpdateQuery = @"
                        UPDATE ACCOUNT
                        SET Balance = Balance + @BalanceChange
                        WHERE AccountID = @AccountID";

                    if (selectedService.ServiceTypeID == 2) // Gửi tiết kiệm
                    {
                        balanceChange = -balanceChange; // Giảm số dư
                    }

                    // ServiceTypeID == 2 (Vay vốn) thì tăng số dư (balanceChange đã là dương)

                    using (var command = new SqlCommand(accountUpdateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@BalanceChange", balanceChange);
                        command.Parameters.AddWithValue("@AccountID", selectedService.AccountID);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            view.ShowMessage("Không thể cập nhật số dư tài khoản. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Tạo bản ghi LOAN_PAYMENT nếu là dịch vụ vay vốn (ServiceTypeID == 1)
                    if (selectedService.ServiceTypeID == 1)
                    {
                        // Tính toán các giá trị cho LOAN_PAYMENT
                        decimal principalDue = Math.Floor(selectedService.TotalPrincipalAmount / durationMonths); // Lấy nguyên phần nguyên
                        decimal interestDue = Math.Floor((selectedService.TotalInterestAmount ?? 0) / durationMonths); // Lấy nguyên phần nguyên
                        decimal lateFee = 0;
                        decimal totalDue = principalDue + interestDue + lateFee;
                        decimal remainingDebt = selectedService.TotalPrincipalAmount;
                        string payNotification = $"Thanh toán khoản vay của mã dịch vụ '{selectedService.ServiceCode}' tháng thứ 1";
                        DateTime dueDate = applicableDate.AddMonths(1);
                        string paymentStatus = "Chưa thanh toán";

                        // Chèn bản ghi vào LOAN_PAYMENT và lấy PayLoanID, PayLoanCode vừa tạo
                        string loanPaymentInsertQuery = @"
                    INSERT INTO LOAN_PAYMENT (ServiceID, PrincipalDue, InterestDue, LateFee, TotalDue, RemainingDebt, PayNotification, DueDate, PaymentStatus)
                    OUTPUT INSERTED.PayLoanID, INSERTED.PayLoanCode
                    VALUES (@ServiceID, @PrincipalDue, @InterestDue, @LateFee, @TotalDue, @RemainingDebt, @PayNotification, @DueDate, @PaymentStatus)";

                        string newPayLoanId = "";
                        string newPayLoanCode = "";

                        using (var command = new SqlCommand(loanPaymentInsertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@ServiceID", selectedService.ServiceID);
                            command.Parameters.AddWithValue("@PrincipalDue", principalDue);
                            command.Parameters.AddWithValue("@InterestDue", interestDue);
                            command.Parameters.AddWithValue("@LateFee", lateFee);
                            command.Parameters.AddWithValue("@TotalDue", totalDue);
                            command.Parameters.AddWithValue("@RemainingDebt", remainingDebt);
                            command.Parameters.AddWithValue("@PayNotification", payNotification);
                            command.Parameters.AddWithValue("@DueDate", dueDate);
                            command.Parameters.AddWithValue("@PaymentStatus", paymentStatus);

                            using (var reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    newPayLoanId = reader.GetInt32(0).ToString(); // Lấy PayLoanID
                                    newPayLoanCode = reader.GetString(1); // Lấy PayLoanCode
                                }
                                else
                                {
                                    view.ShowMessage("Không thể tạo bản ghi LOAN_PAYMENT. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        } 
                    }

                    // Tạo bản ghi thông báo cho khách hàng
                    int notificationTypeId;
                    using (var command = new SqlCommand("SELECT NotificationTypeID FROM NOTIFICATION_TYPE WHERE NotificationTypeName = @NotificationTypeName", connection))
                    {
                        command.Parameters.AddWithValue("@NotificationTypeName", "Dịch vụ");
                        var notificationTypeResult = command.ExecuteScalar(); // Đổi tên biến
                        if (notificationTypeResult == null)
                        {
                            view.ShowMessage("Không tìm thấy NotificationTypeID cho 'Dịch vụ'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        notificationTypeId = (int)notificationTypeResult;
                    }

                    string notificationMessage;
                    if (selectedService.ServiceTypeID == 1) // Vay vốn
                    {
                        notificationMessage = $"Ngân hàng đã duyệt yêu cầu vay vốn với mã dịch vụ {selectedService.ServiceCode} từ bạn. Số tiền: {selectedService.TotalPrincipalAmount.ToString("#,##0")} đã được gửi về tài khoản!";
                    }
                    else // Gửi tiết kiệm (ServiceTypeID == 2)
                    {
                        notificationMessage = $"Ngân hàng đã duyệt yêu cầu gửi tiết kiệm với mã dịch vụ {selectedService.ServiceCode} từ bạn. Số tiền: {selectedService.TotalPrincipalAmount.ToString("#,##0")} của tài khoản đã được chuyển vào dịch vụ gửi tiết kiệm thành công!";
                    }

                    using (var command = new SqlCommand(
                        "INSERT INTO [NOTIFICATION] (Title, NotificationMessage, NotificationDate, NotificationStatus, ReferenceID, CustomerID, EmployeeID, NotificationTypeID) " +
                        "VALUES (@Title, @NotificationMessage, @NotificationDate, @NotificationStatus, @ReferenceID, @CustomerID, @EmployeeID, @NotificationTypeID)", connection))
                    {
                        command.Parameters.AddWithValue("@Title", "Duyệt yêu đã được duyệt!");
                        command.Parameters.AddWithValue("@NotificationMessage", notificationMessage);
                        command.Parameters.AddWithValue("@NotificationDate", DateTime.Now);
                        command.Parameters.AddWithValue("@NotificationStatus", "Chưa xem");
                        command.Parameters.AddWithValue("@ReferenceID", selectedService.ServiceID);
                        command.Parameters.AddWithValue("@CustomerID", selectedService.CustomerID);
                        command.Parameters.AddWithValue("@EmployeeID", DBNull.Value);
                        command.Parameters.AddWithValue("@NotificationTypeID", notificationTypeId);
                        command.ExecuteNonQuery();
                    }

                    // Cập nhật trạng thái trong selectedService
                    selectedService.ApprovalStatus = "Đã duyệt";
                    selectedService.ServiceStatus = "Đang hoạt động";
                    selectedService.ApplicableDate = applicableDate;
                    selectedService.EndDate = endDate;

                    view.ShowMessage("Đã duyệt yêu cầu dịch vụ này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Làm mới DGV
                    SearchServiceRequests();
                    view.ClearInputs();
                    view.EnableApproveButton(false);
                    view.EnableDeclineButton(false);
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi duyệt yêu cầu dịch vụ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        // Xuất file
        public void ExportToPDF()
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF files (*.pdf)|*.pdf",
                    FileName = "ServiceRequestList.pdf"
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

                    document.Add(new Paragraph("DANH SÁCH YÊU CẦU DỊCH VỤ", subHeaderFont)
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
                    PdfPTable pdfTable = new PdfPTable(16); // 16 cột
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

                    // Thêm dữ liệu từ currentServiceRequests
                    foreach (var service in currentServiceRequests)
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
                    FileName = "ServiceRequestList.xlsx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Khởi tạo ứng dụng Excel
                    excelApp = new Excel.Application();
                    if (excelApp == null)
                    {
                        throw new Exception("Không thể khởi tạo ứng dụng Excel. Vui lòng kiểm tra cài đặt Microsoft Excel trên máy.");
                    }

                    excelApp.Visible = false;
                    excelApp.DisplayAlerts = false;

                    // Tạo workbook và worksheet mới
                    workbook = excelApp.Workbooks.Add();
                    worksheet = (Excel.Worksheet)workbook.Sheets[1];
                    worksheet.Name = "ServiceRequestList";

                    // Header "Sacombank" màu đỏ đậm, in nghiêng, font lớn, gộp ô (2 hàng, 2 cột), không có border
                    Excel.Range headerRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[2, 2]];
                    headerRange.Merge();
                    headerRange.Value = "Sacombank";
                    headerRange.Font.Name = "Arial";
                    headerRange.Font.Bold = true;
                    headerRange.Font.Size = 16;
                    headerRange.Font.Color = System.Drawing.Color.DarkRed.ToArgb();
                    headerRange.Font.Italic = true;
                    headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    headerRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    // Tiêu đề "DANH SÁCH YÊU CẦU DỊCH VỤ" (hàng 3)
                    Excel.Range subHeaderRange = worksheet.Range[worksheet.Cells[3, 1], worksheet.Cells[3, 2]];
                    subHeaderRange.Merge();
                    subHeaderRange.Value = "DANH SÁCH YÊU CẦU DỊCH VỤ";
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
                        headerCell.Font.Bold = true;
                        headerCell.Interior.Color = System.Drawing.Color.FromArgb(252, 186, 3).ToArgb();
                        headerCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        headerCell.Borders.Weight = Excel.XlBorderWeight.xlThin;
                    }

                    // Thêm dữ liệu từ currentServiceRequests (bắt đầu từ hàng 7)
                    int rowIndex = 7;
                    foreach (var service in currentServiceRequests)
                    {
                        Excel.Range rowRange = worksheet.Range[worksheet.Cells[rowIndex, 1], worksheet.Cells[rowIndex, 16]];
                        worksheet.Cells[rowIndex, 1] = service.CustomerCode;
                        worksheet.Cells[rowIndex, 2] = service.AccountName;
                        worksheet.Cells[rowIndex, 3] = service.AccountCode;
                        worksheet.Cells[rowIndex, 4] = service.ServiceTypeName;
                        worksheet.Cells[rowIndex, 5] = service.ServiceCode;
                        worksheet.Cells[rowIndex, 6] = service.TotalPrincipalAmount;
                        worksheet.Cells[rowIndex, 7] = service.ServiceDescription;
                        worksheet.Cells[rowIndex, 8] = service.Duration;
                        worksheet.Cells[rowIndex, 9] = service.InterestRate;
                        worksheet.Cells[rowIndex, 10] = service.TotalInterestAmount;
                        worksheet.Cells[rowIndex, 11] = service.CreatedDate;
                        worksheet.Cells[rowIndex, 12] = service.ApplicableDate;
                        worksheet.Cells[rowIndex, 13] = service.EndDate;
                        worksheet.Cells[rowIndex, 14] = service.HandledBy;
                        worksheet.Cells[rowIndex, 15] = service.ApprovalStatus;
                        worksheet.Cells[rowIndex, 16] = service.ServiceStatus;

                        // Thêm border cho các ô dữ liệu
                        rowRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        rowRange.Borders.Weight = Excel.XlBorderWeight.xlThin;
                        rowIndex++;
                    }

                    // Footer (thêm vào sau dữ liệu)
                    int lastRow = rowIndex + 1;
                    Excel.Range footerRange1 = worksheet.Cells[lastRow, 1];
                    footerRange1.Value = "NGÂN HÀNG THƯƠNG MẠI CỔ PHẦN SÀI GÒN THƯƠNG TÍN";
                    footerRange1.Font.Name = "Arial";
                    footerRange1.Font.Bold = true;
                    footerRange1.Font.Size = 10;
                    footerRange1.Font.Color = System.Drawing.Color.FromArgb(255, 147, 0).ToArgb();

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
                    FileName = "ServiceRequestList.csv"
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

                    // Thêm dữ liệu từ currentServiceRequests
                    foreach (var service in currentServiceRequests)
                    {
                        string[] rowData = new string[]
                        {
                            service.CustomerCode,
                            service.AccountName,
                            service.AccountCode,
                            service.ServiceTypeName,
                            service.ServiceCode,
                            service.TotalPrincipalAmount,
                            service.ServiceDescription,
                            service.Duration,
                            service.InterestRate,
                            service.TotalInterestAmount,
                            service.CreatedDate,
                            service.ApplicableDate,
                            service.EndDate,
                            service.HandledBy,
                            service.ApprovalStatus,
                            service.ServiceStatus
                        };
                        csvContent.AppendLine(string.Join(",", rowData.Select(d => $"\"{d.Replace("\"", "\"\"")}\"")));
                    }

                    // Sử dụng UTF-16 LE (Unicode) để đảm bảo Excel hiển thị tiếng Việt đúng
                    var utf16Le = new UnicodeEncoding(false, true);
                    File.WriteAllBytes(saveFileDialog.FileName, utf16Le.GetBytes(csvContent.ToString()));
                    view.ShowMessage("Xuất CSV thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi xuất CSV: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
