using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Views.Common.Chat;
using QuanLyThongTinKhachHangSacomBank.Views.Employee;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    public class EmployeeCustomerCareController
    {
        private readonly ICustomerCareView view;
        private readonly DatabaseContext dbContext;
        private readonly EmployeeModel currentEmployee;
        private readonly ChatController chatController;
        private List<RequestDisplayModel> currentRequests;
        private List<RequestDisplayModel> allRequests;
        private RequestModel selectedRequest;

        public EmployeeCustomerCareController(ICustomerCareView view, DatabaseContext dbContext, EmployeeModel currentEmployee)
        {
            this.view = view;
            this.dbContext = dbContext;
            this.currentEmployee = currentEmployee;
            this.chatController = new ChatController(dbContext);
            this.currentRequests = new List<RequestDisplayModel>();
            this.allRequests = new List<RequestDisplayModel>();
            this.selectedRequest = null;
            LoadInitialData(); // Thêm phương thức khởi tạo ban đầu
        }

        private void LoadInitialData()
        {
            DateTime fromDate = new DateTime(2025, 1, 1); // Tương tự UC_AccountManagement
            DateTime toDate = DateTime.Now;
            view.SetDateFilter(fromDate, toDate);
            LoadRequests();
        }

        public void LoadRequests()
        {
            try
            {
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    string query = @"
                        SELECT r.RequestID, r.RequestCode, r.Title, r.RequestMessage, r.RequestDate, 
                               e.EmployeeName, r.RequestStatus, r.CustomerID, c.CustomerCode
                        FROM REQUEST r
                        LEFT JOIN EMPLOYEE e ON r.HandledBy = e.EmployeeID
                        JOIN CUSTOMER c ON r.CustomerID = c.CustomerID
                        WHERE r.RequestDate BETWEEN @DateFrom AND @DateTo";

                    string statusFilter = view.GetRequestStatusFilter();
                    if (statusFilter != "Không áp dụng")
                    {
                        query += " AND r.RequestStatus = @RequestStatus";
                    }

                    query += " ORDER BY r.RequestDate DESC";

                    using (var command = new SqlCommand(query, connection))
                    {
                        DateTime fromDate = view.GetFromDate();
                        DateTime toDate = view.GetToDate();

                        command.Parameters.AddWithValue("@DateFrom", fromDate);
                        command.Parameters.AddWithValue("@DateTo", toDate);
                        if (statusFilter != "Không áp dụng")
                        {
                            command.Parameters.AddWithValue("@RequestStatus", statusFilter);
                        }

                        using (var reader = command.ExecuteReader())
                        {
                            currentRequests.Clear();
                            allRequests.Clear();
                            while (reader.Read())
                            {
                                var request = new RequestModel
                                {
                                    RequestID = reader.GetInt32(0),
                                    RequestCode = reader.GetString(1),
                                    Title = reader.GetString(2),
                                    RequestMessage = reader.GetString(3),
                                    RequestDate = reader.GetDateTime(4),
                                    EmployeeName = reader.IsDBNull(5) ? null : reader.GetString(5),
                                    RequestStatus = reader.GetString(6),
                                    CustomerID = reader.GetInt32(7)
                                };
                                var displayModel = new RequestDisplayModel(request, reader.GetString(8));
                                currentRequests.Add(displayModel);
                                allRequests.Add(displayModel);
                            }
                            view.LoadRequests(currentRequests);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi tải danh sách yêu cầu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SearchRequests()
        {
            string searchText = view.GetSearchText().ToLower();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                view.LoadRequests(allRequests);
                return;
            }

            var filteredRequests = allRequests.Where(request =>
                (request.CustomerCode?.ToLower().Contains(searchText) == true) ||
                (request.RequestCode?.ToLower().Contains(searchText) == true) ||
                (request.Title?.ToLower().Contains(searchText) == true)
            ).ToList();

            if (searchText.StartsWith("kh"))
            {
                filteredRequests = allRequests.Where(request =>
                    request.CustomerCode?.ToLower().Contains(searchText) == true
                ).ToList();
            }
            else if (searchText.StartsWith("yc"))
            {
                filteredRequests = allRequests.Where(request =>
                    request.RequestCode?.ToLower().Contains(searchText) == true
                ).ToList();
            }

            view.LoadRequests(filteredRequests);
        }

        public void OnRequestSelected()
        {
            if (view.GetSelectedRowCount() > 0)
            {
                var selectedRequestModel = view.GetSelectedRequestModel();
                if (selectedRequestModel != null)
                {
                    selectedRequest = new RequestModel
                    {
                        RequestID = int.Parse(selectedRequestModel.RequestCode.Replace("YC", "")),
                        Title = selectedRequestModel.Title,
                        RequestMessage = selectedRequestModel.RequestMessage,
                        RequestStatus = selectedRequestModel.RequestStatus,
                        EmployeeName = selectedRequestModel.EmployeeName // Thêm thông tin nhân viên xử lý
                    };
                    UpdateButtonStates();
                }
                else
                {
                    selectedRequest = null;
                    view.SetControlState(false, false, false, false);
                }
            }
            else
            {
                selectedRequest = null;
                view.SetControlState(false, false, false, false);
            }
        }

        private void UpdateButtonStates()
        {
            if (selectedRequest == null)
            {
                view.SetControlState(false, false, false, false);
                return;
            }

            bool enableView = true; // Nút View luôn bật

            // Kiểm tra xem nhân viên hiện tại có đang xử lý yêu cầu nào không
            bool isHandlingOtherRequest = allRequests.Any(r =>
                r.EmployeeName == currentEmployee.EmployeeName &&
                r.RequestStatus == "Đang xử lý");

            // Nút Handle chỉ bật nếu trạng thái là "Chờ xử lý" và nhân viên chưa xử lý yêu cầu nào khác
            bool enableHandle = selectedRequest.RequestStatus == "Chờ xử lý" && !isHandlingOtherRequest;

            // Nút Done và Deny chỉ bật nếu:
            // - Trạng thái là "Chờ xử lý" hoặc "Đang xử lý"
            // - Nếu trạng thái là "Đang xử lý", chỉ bật khi nhân viên hiện tại là người xử lý
            bool isCurrentEmployeeHandling = selectedRequest.EmployeeName == currentEmployee.EmployeeName;
            bool enableDone = (selectedRequest.RequestStatus == "Chờ xử lý") ||
                             (selectedRequest.RequestStatus == "Đang xử lý" && isCurrentEmployeeHandling);
            bool enableDeny = (selectedRequest.RequestStatus == "Chờ xử lý") ||
                             (selectedRequest.RequestStatus == "Đang xử lý" && isCurrentEmployeeHandling);

            view.SetControlState(enableView, enableHandle, enableDone, enableDeny);
        }

        public void OnViewRequest()
        {
            if (selectedRequest != null)
            {
                chatController.OpenChat(new UC_EmployeeChat(), null, currentEmployee, selectedRequest);
            }
            else
            {
                view.ShowMessage("Vui lòng chọn một yêu cầu để xem!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void OnHandleRequest()
        {
            if (selectedRequest != null && selectedRequest.RequestStatus == "Chờ xử lý")
            {
                var result = view.ShowConfirmation("Xác nhận việc tiếp nhận yêu cầu này?", "Xác nhận");
                if (result == DialogResult.Yes)
                {
                    chatController.HandleRequest(selectedRequest, currentEmployee);
                    LoadRequests();
                }
            }
        }

        public void OnCompleteRequest()
        {
            if (selectedRequest != null && (selectedRequest.RequestStatus == "Chờ xử lý" || selectedRequest.RequestStatus == "Đang xử lý"))
            {
                var result = view.ShowConfirmation("Xác nhận hoàn thành yêu cầu này?", "Xác nhận");
                if (result == DialogResult.Yes)
                {
                    chatController.CompleteRequest(selectedRequest);
                    LoadRequests();
                }
            }
        }

        public void OnDenyRequest()
        {
            if (selectedRequest != null && (selectedRequest.RequestStatus == "Chờ xử lý" || selectedRequest.RequestStatus == "Đang xử lý"))
            {
                var result = view.ShowConfirmation("Xác nhận từ chối yêu cầu này?", "Xác nhận");
                if (result == DialogResult.Yes)
                {
                    chatController.DenyRequest(selectedRequest, currentEmployee);
                    LoadRequests();
                }
            }
        }
    }
}