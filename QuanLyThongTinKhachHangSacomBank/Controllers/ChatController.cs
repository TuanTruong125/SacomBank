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
    public class ChatController
    {
        private readonly DatabaseContext dbContext;
        private IChatView chatView;
        private UserControl activeUC;
        private AccountModel currentAccount;
        private EmployeeModel currentEmployee;
        private RequestModel selectedRequest;
        private List<RequestDisplayModel> currentRequests;

        public ChatController(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
            activeUC = null;
            currentRequests = new List<RequestDisplayModel>();
        }

        public void OpenChat(UserControl chatUC, AccountModel currentAccount = null, EmployeeModel currentEmployee = null, RequestModel selectedRequest = null)
        {
            try
            {
                this.currentAccount = currentAccount;
                this.currentEmployee = currentEmployee;
                this.selectedRequest = selectedRequest;

                chatView = new FormChat();
                activeUC = chatUC;
                chatView.LoadUserControl(chatUC);
                InitializeChat(chatUC);  // Nếu có lỗi, sẽ throw exception và không gọi ShowForm()
                chatView.ShowForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở chat: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeChat(UserControl chatUC)
        {
            try
            {
                switch (chatUC)
                {
                    case UC_CustomerChat customerChat:
                        if (currentAccount == null)
                            throw new ArgumentNullException(nameof(currentAccount), "currentAccount không được null khi mở UC_CustomerChat.");
                        InitializeCustomerChat(customerChat);
                        break;

                    case UC_EmployeeChat employeeChat:
                        if (selectedRequest == null)
                            throw new ArgumentNullException(nameof(selectedRequest), "selectedRequest không được null khi mở UC_EmployeeChat.");
                        if (currentEmployee == null)
                            throw new ArgumentNullException(nameof(currentEmployee), "currentEmployee không được null khi mở UC_EmployeeChat.");
                        InitializeEmployeeChat(employeeChat);
                        break;

                    case UC_ChatBot _:
                        // UC_ChatBot được cấu hình đầy đủ trong constructor của nó
                        break;

                    default:
                        throw new NotSupportedException($"UserControl {chatUC.GetType().Name} không được hỗ trợ.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo chat: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void InitializeChatBot(UC_ChatBot chatBot)
        {
            // Cấu hình khởi tạo cho ChatBot
            // Hiện tại không có cấu hình đặc biệt cần thiết
        }
        private void InitializeCustomerChat(UC_CustomerChat customerChat)
        {
            customerChat.SetSendButtonEnable(true); // Cho phép gửi yêu cầu
            LoadCustomerRequests(customerChat);
            customerChat.SendRequestClicked += (sender, e) => HandleSendRequest(customerChat);
        }

        private void InitializeEmployeeChat(UC_EmployeeChat employeeChat)
        {
            employeeChat.DisplayRequest(selectedRequest.Title, selectedRequest.RequestMessage);
        }

        private void HandleSendRequest(ICustomerChatView view)
        {
            try
            {
                string title = view.GetTitle();
                string message = view.GetMessage();

                if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(message))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ tiêu đề và nội dung!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                view.ShowConfirmation("Bạn có chắc chắn gửi yêu cầu này?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, () =>
                    {
                        SaveRequest(title, message);
                        view.ClearInputs();
                        LoadCustomerRequests(view);
                    });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi yêu cầu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCustomerRequests(ICustomerChatView view)
        {
            try
            {
                if (currentAccount == null || currentAccount.CustomerID <= 0)
                {
                    MessageBox.Show("Không xác định được khách hàng hiện tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    string query = @"
                        SELECT r.RequestID, r.RequestCode, r.Title, r.RequestMessage, r.RequestDate, 
                               e.EmployeeName, r.RequestStatus, r.CustomerID, c.CustomerCode
                        FROM REQUEST r
                        LEFT JOIN EMPLOYEE e ON r.HandledBy = e.EmployeeID
                        JOIN CUSTOMER c ON r.CustomerID = c.CustomerID
                        WHERE r.CustomerID = @CustomerID
                        ORDER BY r.RequestDate DESC";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", currentAccount.CustomerID);

                        using (var reader = command.ExecuteReader())
                        {
                            currentRequests.Clear();
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
                                currentRequests.Add(new RequestDisplayModel(request, reader.GetString(8)));
                            }
                            view.LoadRequests(currentRequests);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải yêu cầu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveRequest(string title, string message)
        {
            try
            {
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    string insertQuery = @"
                        INSERT INTO REQUEST (Title, RequestMessage, RequestDate, RequestStatus, CustomerID)
                        VALUES (@Title, @RequestMessage, @RequestDate, @RequestStatus, @CustomerID)";

                    using (var command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Title", title);
                        command.Parameters.AddWithValue("@RequestMessage", message);
                        command.Parameters.AddWithValue("@RequestDate", DateTime.Now);
                        command.Parameters.AddWithValue("@RequestStatus", "Chờ xử lý");
                        command.Parameters.AddWithValue("@CustomerID", currentAccount.CustomerID);

                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Yêu cầu đã được gửi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu yêu cầu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void HandleRequest(RequestModel request, EmployeeModel employee)
        {
            try
            {
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    string updateQuery = @"
                        UPDATE REQUEST 
                        SET RequestStatus = N'Đang xử lý', HandledBy = @EmployeeID
                        WHERE RequestID = @RequestID";

                    using (var command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
                        command.Parameters.AddWithValue("@RequestID", request.RequestID);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Yêu cầu đã được tiếp nhận!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tiếp nhận yêu cầu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CompleteRequest(RequestModel request)
        {
            try
            {
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    string updateQuery = @"
                        UPDATE REQUEST 
                        SET RequestStatus = N'Đã xử lý'
                        WHERE RequestID = @RequestID";

                    using (var command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@RequestID", request.RequestID);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Yêu cầu đã được hoàn thành!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hoàn thành yêu cầu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DenyRequest(RequestModel request, EmployeeModel employee)
        {
            try
            {
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    string updateQuery = @"
                        UPDATE REQUEST 
                        SET RequestStatus = N'Từ chối xử lý', HandledBy = @EmployeeID
                        WHERE RequestID = @RequestID";

                    using (var command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
                        command.Parameters.AddWithValue("@RequestID", request.RequestID);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Yêu cầu đã bị từ chối!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi từ chối yêu cầu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}