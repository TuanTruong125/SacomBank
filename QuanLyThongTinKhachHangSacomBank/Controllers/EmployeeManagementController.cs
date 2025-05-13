using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using iTextSharp.text;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Views.Manager;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Runtime.InteropServices;
using System.Net.Mail;


namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    public class EmployeeManagementController
    {

        private readonly IEmployeeManagementView view;
        private readonly DatabaseContext dbContext;
        private readonly IConfiguration configuration;
        private readonly EmployeeModel currentManager;
        private bool isEditMode = false;
        private int currentEditingEmployeeID = -1;

        public bool IsEditMode
        {
            get { return isEditMode; }
        }

        public EmployeeManagementController(IEmployeeManagementView view, EmployeeModel currentManager, DatabaseContext dbContext, IConfiguration configuration)
        {
            this.view = view;
            this.currentManager = currentManager;
            this.dbContext = dbContext;
            this.configuration = configuration;

            // Đăng ký các sự kiện
            this.view.AddButtonClicked += View_AddButtonClicked;
            this.view.EditButtonClicked += View_EditButtonClicked;
            this.view.DeleteButtonClicked += View_DeleteButtonClicked;
            this.view.SaveButtonClicked += View_SaveButtonClicked;
            this.view.CancelButtonClicked += View_CancelButtonClicked;
            this.view.SearchButtonClicked += View_SearchButtonClicked;
            this.view.GenderFilterChanged += View_GenderFilterChanged;
            this.view.ExportToExcelButtonClicked += View_ExportToExcelButtonClicked;
            this.view.ExportToPDFButtonClicked += View_ExportToPDFButtonClicked;

            // Tải danh sách nhân viên khi controller được khởi tạo
            LoadEmployeeList();
        }

        public void LoadEmployeeList(string searchKeyword = "", string genderFilter = "")
        {
            try
            {
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT EmployeeID, EmployeeCode, EmployeeName, EmployeeGender, " +
                                  "EmployeeDateOfBirth, EmployeeCitizenID, EmployeeAddress, EmployeeRole, " +
                                  "EmployeePhone, EmployeeEmail, HireDate, Salary FROM EMPLOYEE WHERE 1=1";

                    // Áp dụng bộ lọc tìm kiếm
                    if (!string.IsNullOrWhiteSpace(searchKeyword))
                    {
                        query += " AND (" +
                                 "EmployeeCode LIKE @Keyword OR " +
                                 "EmployeeName LIKE @Keyword OR " +
                                 "EmployeeGender LIKE @Keyword OR " +
                                 "CONVERT(VARCHAR, EmployeeDateOfBirth, 103) LIKE @Keyword OR " + // Chuyển đổi ngày sinh thành chuỗi (dd/MM/yyyy)
                                 "EmployeeCitizenID LIKE @Keyword OR " +
                                 "EmployeeAddress LIKE @Keyword OR " +
                                 "EmployeeRole LIKE @Keyword OR " +
                                 "EmployeePhone LIKE @Keyword OR " +
                                 "EmployeeEmail LIKE @Keyword OR " +
                                 "CONVERT(VARCHAR, HireDate, 103) LIKE @Keyword OR " + // Chuyển đổi ngày vào làm thành chuỗi (dd/MM/yyyy)
                                 "CONVERT(VARCHAR, Salary) LIKE @Keyword" + // Chuyển đổi lương thành chuỗi
                                 ")";
                    }

                    // Áp dụng bộ lọc giới tính
                    if (!string.IsNullOrWhiteSpace(genderFilter) && genderFilter != "Không áp dụng")
                    {
                        query += " AND EmployeeGender = @Gender";
                    }

                    // Sắp xếp theo ID
                    query += " ORDER BY EmployeeID";

                    using (var command = new SqlCommand(query, connection))
                    {
                        if (!string.IsNullOrWhiteSpace(searchKeyword))
                        {
                            command.Parameters.AddWithValue("@Keyword", "%" + searchKeyword + "%");
                        }

                        if (!string.IsNullOrWhiteSpace(genderFilter) && genderFilter != "Không áp dụng")
                        {
                            command.Parameters.AddWithValue("@Gender", genderFilter);
                        }

                        System.Data.DataTable employeeTable = new System.Data.DataTable();
                        using (var adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(employeeTable);
                        }

                        view.LoadEmployeeList(employeeTable);
                    }
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi tải danh sách nhân viên: {ex.Message}", "Lỗi", MessageBoxIcon.Error);
            }
        }

        public void AddEmployee(EmployeeModel employee)
        {
            try
            {
                // Kiểm tra tính hợp lệ của dữ liệu
                string validationMessage = ValidateEmployeeData(employee);
                if (!string.IsNullOrEmpty(validationMessage))
                {
                    view.ShowMessage(validationMessage, "Lỗi", MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra trùng lặp
                if (IsCitizenIDExists(employee.EmployeeCitizenID))
                {
                    view.ShowMessage("CCCD này đã tồn tại trong hệ thống!", "Lỗi", MessageBoxIcon.Warning);
                    return;
                }

                if (IsPhoneExists(employee.EmployeePhone))
                {
                    view.ShowMessage("Số điện thoại này đã được sử dụng làm tên đăng nhập!", "Lỗi", MessageBoxIcon.Warning);
                    return;
                }

                if (IsEmailExists(employee.EmployeeEmail))
                {
                    view.ShowMessage("Email này đã tồn tại trong hệ thống!", "Lỗi", MessageBoxIcon.Warning);
                    return;
                }

                // Hỏi xác nhận trước khi thêm
                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn thêm nhân viên {employee.EmployeeName} không?",
                    "Xác nhận thêm nhân viên",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    return;
                }

                // Xác định AccessLevel dựa trên EmployeeRole
                int accessLevel = 1; // Mặc định là nhân viên
                if (employee.EmployeeRole.Equals("Quản lý", StringComparison.OrdinalIgnoreCase))
                {
                    accessLevel = 2; // Quản lý
                }

                // Ghi log để debug
                Console.WriteLine($"Adding employee with role '{employee.EmployeeRole}' and AccessLevel {accessLevel}");

                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    string query = @"INSERT INTO EMPLOYEE 
            (EmployeeName, EmployeeGender, EmployeeDateOfBirth, 
             EmployeeCitizenID, EmployeeAddress, EmployeeRole, EmployeePhone, 
             EmployeeEmail, HireDate, Salary, EmployeeUsername, 
             EmployeePassword, AccessLevel, ManagerID) 
            VALUES 
            (@EmployeeName, @EmployeeGender, @EmployeeDateOfBirth, 
             @EmployeeCitizenID, @EmployeeAddress, @EmployeeRole, @EmployeePhone, 
             @EmployeeEmail, @HireDate, @Salary, @EmployeeUsername, 
             @EmployeePassword, @AccessLevel, @ManagerID);
            SELECT SCOPE_IDENTITY()";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                        command.Parameters.AddWithValue("@EmployeeGender", employee.EmployeeGender);
                        command.Parameters.AddWithValue("@EmployeeDateOfBirth", employee.EmployeeDateOfBirth);
                        command.Parameters.AddWithValue("@EmployeeCitizenID", employee.EmployeeCitizenID);
                        command.Parameters.AddWithValue("@EmployeeAddress", employee.EmployeeAddress);
                        command.Parameters.AddWithValue("@EmployeeRole", employee.EmployeeRole);
                        command.Parameters.AddWithValue("@EmployeePhone", employee.EmployeePhone);
                        command.Parameters.AddWithValue("@EmployeeEmail", employee.EmployeeEmail);
                        command.Parameters.AddWithValue("@HireDate", employee.HireDate);
                        command.Parameters.AddWithValue("@Salary", employee.Salary);
                        command.Parameters.AddWithValue("@EmployeeUsername", employee.EmployeePhone); // Dùng số điện thoại làm username
                        command.Parameters.AddWithValue("@EmployeePassword", employee.EmployeePassword); // Mật khẩu ngẫu nhiên
                        command.Parameters.AddWithValue("@AccessLevel", accessLevel);

                        // Gán ManagerID từ currentManager.EmployeeID
                        if (currentManager != null && currentManager.EmployeeID > 0)
                        {
                            command.Parameters.AddWithValue("@ManagerID", currentManager.EmployeeID);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@ManagerID", DBNull.Value);
                        }

                        // Lấy ID của nhân viên mới thêm
                        int newEmployeeId = Convert.ToInt32(command.ExecuteScalar());

                        // Lấy mã nhân viên tự động sinh
                        string employeeCode = GetEmployeeCodeById(newEmployeeId, connection);

                        // Gửi email thông báo cho nhân viên mới
                        SendWelcomeEmail(employee, employeeCode);

                        // Hiển thị thông báo kèm thông tin đăng nhập (không hiển thị mật khẩu)
                        view.ShowMessage(
                            $"Đã thêm nhân viên thành công!\n" +
                            $"Mã nhân viên: {employeeCode}\n" +
                            $"Tên đăng nhập: {employee.EmployeePhone}\n" +
                            $"Mật khẩu đã được gửi cho nhân viên qua email.",
                            "Thông báo", MessageBoxIcon.Information);
                    }
                }

                view.ClearInputFields();
                LoadEmployeeList();
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi thêm nhân viên: {ex.Message}", "Lỗi", MessageBoxIcon.Error);
            }
        }

        private void SendWelcomeEmail(EmployeeModel employee, string employeeCode)
        {
            try
            {
                string smtpServer = configuration["EmailSettings:SmtpServer"];
                int smtpPort = int.Parse(configuration["EmailSettings:SmtpPort"]);
                string senderEmail = configuration["EmailSettings:SenderEmail"];
                string senderPassword = configuration["EmailSettings:SenderPassword"];
                string senderName = configuration["EmailSettings:SenderName"];

                using (var smtpClient = new SmtpClient(smtpServer, smtpPort))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = new System.Net.NetworkCredential(senderEmail, senderPassword);

                    string htmlBody = @"
                <html>
                <body style='font-family: Arial, sans-serif; color: #333;'>
                    <table width='100%' cellpadding='0' cellspacing='0' border='0'>
                        <tr>
                            <td align='center' bgcolor='#f4f4f4' style='padding: 20px;'>
                                <table width='600' cellpadding='0' cellspacing='0' border='0' style='background-color: #ffffff; border-radius: 8px; box-shadow: 0 2px 4px rgba(0,0,0,0.1);'>
                                    <tr>
                                        <td align='center' style='padding: 20px;'>
                                            <h1 style='color: #1a73e8;'>Thông Tin Tài Khoản Mới</h1>
                                            <h2 style='color: #1a73e8; margin: 5px 0 20px 0;'>Sacombank</h2>
                                            <p>Xin chào <strong>" + employee.EmployeeName + @"</strong>,</p>
                                            <p>Chúc mừng bạn đã trở thành nhân viên mới của Sacombank. Dưới đây là thông tin tài khoản của bạn:</p>
                                            
                                            <table style='width: 80%; margin: 20px auto; border-collapse: collapse;'>
                                                <tr style='background-color: #f2f2f2;'>
                                                    <td style='padding: 10px; border: 1px solid #ddd; font-weight: bold;'>Mã nhân viên:</td>
                                                    <td style='padding: 10px; border: 1px solid #ddd;'>" + employeeCode + @"</td>
                                                </tr>
                                                <tr>
                                                    <td style='padding: 10px; border: 1px solid #ddd; font-weight: bold;'>Họ và tên:</td>
                                                    <td style='padding: 10px; border: 1px solid #ddd;'>" + employee.EmployeeName + @"</td>
                                                </tr>
                                                <tr style='background-color: #f2f2f2;'>
                                                    <td style='padding: 10px; border: 1px solid #ddd; font-weight: bold;'>CCCD:</td>
                                                    <td style='padding: 10px; border: 1px solid #ddd;'>" + employee.EmployeeCitizenID + @"</td>
                                                </tr>
                                                <tr>
                                                    <td style='padding: 10px; border: 1px solid #ddd; font-weight: bold;'>Chức vụ:</td>
                                                    <td style='padding: 10px; border: 1px solid #ddd;'>" + employee.EmployeeRole + @"</td>
                                                </tr>
                                                <tr style='background-color: #f2f2f2;'>
                                                    <td style='padding: 10px; border: 1px solid #ddd; font-weight: bold;'>Tên đăng nhập:</td>
                                                    <td style='padding: 10px; border: 1px solid #ddd;'>" + employee.EmployeeUsername + @"</td>
                                                </tr>
                                                <tr>
                                                    <td style='padding: 10px; border: 1px solid #ddd; font-weight: bold;'>Mật khẩu:</td>
                                                    <td style='padding: 10px; border: 1px solid #ddd;'>" + employee.EmployeePassword + @"</td>
                                                </tr>
                                            </table>
                                            
                                            <div style='background-color: #fff4e5; border-left: 4px solid #ff9800; padding: 15px; margin: 20px 0; text-align: left;'>
                                                <p style='margin: 0; color: #e65100;'><strong>Lưu ý quan trọng:</strong></p>
                                                <p style='margin: 10px 0 0 0;'>Vì lý do bảo mật, vui lòng đổi mật khẩu của bạn ngay sau lần đăng nhập đầu tiên.</p>
                                            </div>
                                            
                                            <p>Nếu bạn có bất kỳ câu hỏi nào, vui lòng liên hệ với phòng Nhân sự hoặc email: <a href='mailto:hr@sacombank.com'>hr@sacombank.com</a>.</p>
                                            <hr style='border: 0; border-top: 1px solid #eee; margin: 20px 0;' />
                                            <p style='font-size: 12px; color: #777;'>© 2025 Sacombank. All rights reserved.</p>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </body>
                </html>";

                    var mailMessage = new System.Net.Mail.MailMessage
                    {
                        From = new System.Net.Mail.MailAddress(senderEmail, senderName),
                        Subject = "Thông tin tài khoản mới - Sacombank",
                        Body = htmlBody,
                        IsBodyHtml = true
                    };
                    mailMessage.To.Add(employee.EmployeeEmail);

                    smtpClient.Send(mailMessage);
                    Console.WriteLine($"Email thông báo đã được gửi tới {employee.EmployeeEmail}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi gửi email: {ex.Message}");
                // Ghi log lỗi nhưng không hiển thị cho người dùng vì đây không phải lỗi quan trọng
                // Email có thể gửi lại sau nếu cần thiết
            }
        }



        // Phương thức kiểm tra số điện thoại đã tồn tại chưa
        private bool IsPhoneExists(string phone)
        {
            using (var connection = dbContext.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT COUNT(1) FROM EMPLOYEE WHERE EmployeeUsername = @Phone OR EmployeePhone = @Phone", connection);
                command.Parameters.AddWithValue("@Phone", phone);
                return (int)command.ExecuteScalar() > 0;
            }
        }


        private string GetEmployeeCodeById(int employeeId, SqlConnection connection)
        {
            string query = "SELECT EmployeeCode FROM EMPLOYEE WHERE EmployeeID = @EmployeeID";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@EmployeeID", employeeId);
                return (string)command.ExecuteScalar();
            }
        }

        public void UpdateEmployee(EmployeeModel employee)
        {
            try
            {
                if (currentEditingEmployeeID <= 0)
                {
                    view.ShowMessage("Không có nhân viên nào được chọn để cập nhật!", "Lỗi", MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra tính hợp lệ của dữ liệu
                string validationMessage = ValidateEmployeeData(employee);
                if (!string.IsNullOrEmpty(validationMessage))
                {
                    view.ShowMessage(validationMessage, "Lỗi", MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra trùng lặp (loại trừ chính nhân viên đang chỉnh sửa)
                if (IsCitizenIDExists(employee.EmployeeCitizenID, currentEditingEmployeeID))
                {
                    view.ShowMessage("CCCD này đã tồn tại trong hệ thống!", "Lỗi", MessageBoxIcon.Warning);
                    return;
                }

                if (IsPhoneExists(employee.EmployeePhone, currentEditingEmployeeID))
                {
                    view.ShowMessage("Số điện thoại này đã được sử dụng làm tên đăng nhập!", "Lỗi", MessageBoxIcon.Warning);
                    return;
                }

                if (IsEmailExists(employee.EmployeeEmail, currentEditingEmployeeID))
                {
                    view.ShowMessage("Email này đã tồn tại trong hệ thống!", "Lỗi", MessageBoxIcon.Warning);
                    return;
                }

                // Hỏi xác nhận trước khi cập nhật
                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn cập nhật thông tin nhân viên {employee.EmployeeName} không?",
                    "Xác nhận cập nhật nhân viên",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    return;
                }

                // LẤY MẬT KHẨU HIỆN TẠI từ cơ sở dữ liệu
                string currentPassword = GetCurrentPassword(currentEditingEmployeeID);
                if (string.IsNullOrEmpty(currentPassword))
                {
                    view.ShowMessage("Không thể lấy mật khẩu hiện tại của nhân viên!", "Lỗi", MessageBoxIcon.Warning);
                    return;
                }

                // Xác định AccessLevel dựa trên EmployeeRole
                int accessLevel = 1; // Mặc định là nhân viên
                if (employee.EmployeeRole.Equals("Quản lý", StringComparison.OrdinalIgnoreCase))
                {
                    accessLevel = 2; // Quản lý
                }

                // Ghi log để debug
                Console.WriteLine($"Setting AccessLevel to {accessLevel} based on EmployeeRole: '{employee.EmployeeRole}'");
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    string query = @"UPDATE EMPLOYEE SET 
                    EmployeeName = @EmployeeName, 
                    EmployeeGender = @EmployeeGender, 
                    EmployeeDateOfBirth = @EmployeeDateOfBirth, 
                    EmployeeCitizenID = @EmployeeCitizenID, 
                    EmployeeAddress = @EmployeeAddress, 
                    EmployeeRole = @EmployeeRole, 
                    EmployeePhone = @EmployeePhone, 
                    EmployeeEmail = @EmployeeEmail, 
                    HireDate = @HireDate, 
                    Salary = @Salary, 
                    EmployeeUsername = @EmployeeUsername, 
                    EmployeePassword = @EmployeePassword, 
                    AccessLevel = @AccessLevel, 
                    ManagerID = @ManagerID 
                    WHERE EmployeeID = @EmployeeID";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", currentEditingEmployeeID);
                        command.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                        command.Parameters.AddWithValue("@EmployeeGender", employee.EmployeeGender);
                        command.Parameters.AddWithValue("@EmployeeDateOfBirth", employee.EmployeeDateOfBirth);
                        command.Parameters.AddWithValue("@EmployeeCitizenID", employee.EmployeeCitizenID);
                        command.Parameters.AddWithValue("@EmployeeAddress", employee.EmployeeAddress);
                        command.Parameters.AddWithValue("@EmployeeRole", employee.EmployeeRole);
                        command.Parameters.AddWithValue("@EmployeePhone", employee.EmployeePhone);
                        command.Parameters.AddWithValue("@EmployeeEmail", employee.EmployeeEmail);
                        command.Parameters.AddWithValue("@HireDate", employee.HireDate);
                        command.Parameters.AddWithValue("@Salary", employee.Salary);
                        command.Parameters.AddWithValue("@EmployeeUsername", employee.EmployeePhone);

                        // Sử dụng mật khẩu hiện tại đã lấy từ cơ sở dữ liệu
                        command.Parameters.AddWithValue("@EmployeePassword", currentPassword);

                        // Sử dụng accessLevel đã xác định
                        command.Parameters.AddWithValue("@AccessLevel", accessLevel);

                        if (employee.ManagerID.HasValue)
                            command.Parameters.AddWithValue("@ManagerID", employee.ManagerID.Value);
                        else
                            command.Parameters.AddWithValue("@ManagerID", DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                }

                view.ShowMessage("Cập nhật nhân viên thành công!", "Thông báo", MessageBoxIcon.Information);
                view.ClearInputFields();
                isEditMode = false;
                currentEditingEmployeeID = -1;
                view.SetButtonState(false);
                LoadEmployeeList();
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi cập nhật nhân viên: {ex.Message}", "Lỗi", MessageBoxIcon.Error);
            }
        }

        // Thêm phương thức để lấy mật khẩu hiện tại
        private string GetCurrentPassword(int employeeId)
        {
            try
            {
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT EmployeePassword FROM EMPLOYEE WHERE EmployeeID = @EmployeeID";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employeeId);
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            return result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetCurrentPassword: {ex.Message}");
            }

            // Trả về mật khẩu mặc định nếu không lấy được
            return "123456";
        }

        public void DeleteEmployee(int employeeID)
        {
            try
            {
                if (employeeID <= 0)
                {
                    view.ShowMessage("Không có nhân viên nào được chọn để xóa!", "Lỗi", MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra xem có phải đang cố gắng xóa chính mình không
                if (employeeID == currentManager.EmployeeID)
                {
                    view.ShowMessage("Không thể xóa tài khoản của chính mình!", "Lỗi", MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra xem nhân viên có dữ liệu liên quan trong các bảng TRANSACTION, REQUEST, SERVICE, NOTIFICATION hay không
                bool hasRelatedData = false;
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();

                    // Kiểm tra bảng TRANSACTION
                    string checkTransactionQuery = "SELECT COUNT(1) FROM [TRANSACTION] WHERE HandledBy = @EmployeeID";
                    using (var command = new SqlCommand(checkTransactionQuery, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employeeID);
                        if ((int)command.ExecuteScalar() > 0)
                        {
                            hasRelatedData = true;
                        }
                    }

                    // Kiểm tra bảng REQUEST
                    if (!hasRelatedData)
                    {
                        string checkRequestQuery = "SELECT COUNT(1) FROM REQUEST WHERE HandledBy = @EmployeeID";
                        using (var command = new SqlCommand(checkRequestQuery, connection))
                        {
                            command.Parameters.AddWithValue("@EmployeeID", employeeID);
                            if ((int)command.ExecuteScalar() > 0)
                            {
                                hasRelatedData = true;
                            }
                        }
                    }

                    // Kiểm tra bảng SERVICE
                    if (!hasRelatedData)
                    {
                        string checkServiceQuery = "SELECT COUNT(1) FROM [SERVICE] WHERE HandledBy = @EmployeeID";
                        using (var command = new SqlCommand(checkServiceQuery, connection))
                        {
                            command.Parameters.AddWithValue("@EmployeeID", employeeID);
                            if ((int)command.ExecuteScalar() > 0)
                            {
                                hasRelatedData = true;
                            }
                        }
                    }

                    // Kiểm tra bảng NOTIFICATION
                    if (!hasRelatedData)
                    {
                        string checkNotificationQuery = "SELECT COUNT(1) FROM NOTIFICATION WHERE EmployeeID = @EmployeeID";
                        using (var command = new SqlCommand(checkNotificationQuery, connection))
                        {
                            command.Parameters.AddWithValue("@EmployeeID", employeeID);
                            if ((int)command.ExecuteScalar() > 0)
                            {
                                hasRelatedData = true;
                            }
                        }
                    }

                    // Kiểm tra bảng EMPLOYEE (trường hợp nhân viên là quản lý của nhân viên khác)
                    if (!hasRelatedData)
                    {
                        string checkManagerQuery = "SELECT COUNT(1) FROM EMPLOYEE WHERE ManagerID = @EmployeeID";
                        using (var command = new SqlCommand(checkManagerQuery, connection))
                        {
                            command.Parameters.AddWithValue("@EmployeeID", employeeID);
                            if ((int)command.ExecuteScalar() > 0)
                            {
                                hasRelatedData = true;
                            }
                        }
                    }
                }

                // Nếu nhân viên có dữ liệu liên quan, hiển thị thông báo yêu cầu cập nhật lương
                if (hasRelatedData)
                {
                    view.ShowMessage(
                        "Nhân viên này liên quan đến nhiều dữ liệu khác! Nếu muốn cắt giảm nhân sự vui lòng cập nhật lương về 0 VND để hệ thống không thanh toán lương cho nhân viên này!",
                        "Thông báo",
                        MessageBoxIcon.Warning);
                    return;
                }

                // Nếu không có dữ liệu liên quan, tiến hành xóa nhân viên
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    using (var connection = dbContext.GetConnection())
                    {
                        connection.Open();
                        string deleteEmployeeQuery = "DELETE FROM EMPLOYEE WHERE EmployeeID = @EmployeeID";
                        using (var command = new SqlCommand(deleteEmployeeQuery, connection))
                        {
                            command.Parameters.AddWithValue("@EmployeeID", employeeID);
                            command.ExecuteNonQuery();
                        }
                    }

                    view.ShowMessage("Xóa nhân viên thành công!", "Thông báo", MessageBoxIcon.Information);
                    view.ClearInputFields();
                    LoadEmployeeList();
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi xóa nhân viên: {ex.Message}", "Lỗi", MessageBoxIcon.Error);
            }
        }

        private int GetInt32OrDefault(SqlDataReader reader, string columnName, int defaultValue)
        {
            int ordinal = GetOrdinalSafe(reader, columnName);
            if (ordinal == -1 || reader.IsDBNull(ordinal))
                return defaultValue;
            return reader.GetInt32(ordinal);
        }

        private DateTime GetDateTimeOrDefault(SqlDataReader reader, string columnName, DateTime defaultValue)
        {
            int ordinal = GetOrdinalSafe(reader, columnName);
            if (ordinal == -1 || reader.IsDBNull(ordinal))
                return defaultValue;
            return reader.GetDateTime(ordinal);
        }

        private decimal GetDecimalOrDefault(SqlDataReader reader, string columnName, decimal defaultValue)
        {
            int ordinal = GetOrdinalSafe(reader, columnName);
            if (ordinal == -1 || reader.IsDBNull(ordinal))
                return defaultValue;
            return reader.GetDecimal(ordinal);
        }

        // Sự kiện xử lý từ View
        private void View_ExportToExcelButtonClicked(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void View_ExportToPDFButtonClicked(object sender, EventArgs e)
        {
            ExportToPDF();
        }
        public void LoadEmployeeToView(int employeeID)
        {
            try
            {
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM EMPLOYEE WHERE EmployeeID = @EmployeeID";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employeeID);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var employee = new EmployeeModel
                                {
                                    EmployeeID = GetInt32OrDefault(reader, "EmployeeID", 0),
                                    EmployeeCode = GetStringOrDefault(reader, "EmployeeCode", string.Empty),
                                    EmployeeName = GetStringOrDefault(reader, "EmployeeName", string.Empty),
                                    EmployeeGender = GetStringOrDefault(reader, "EmployeeGender", string.Empty),
                                    EmployeeDateOfBirth = GetDateTimeOrDefault(reader, "EmployeeDateOfBirth", DateTime.Now),
                                    EmployeeCitizenID = GetStringOrDefault(reader, "EmployeeCitizenID", string.Empty),
                                    EmployeeAddress = GetStringOrDefault(reader, "EmployeeAddress", string.Empty),
                                    EmployeeRole = GetStringOrDefault(reader, "EmployeeRole", string.Empty),
                                    EmployeePhone = GetStringOrDefault(reader, "EmployeePhone", string.Empty),
                                    EmployeeEmail = GetStringOrDefault(reader, "EmployeeEmail", string.Empty),
                                    HireDate = GetDateTimeOrDefault(reader, "HireDate", DateTime.Now),
                                    Salary = GetDecimalOrDefault(reader, "Salary", 0),
                                    EmployeeUsername = GetStringOrDefault(reader, "EmployeeUsername", string.Empty),
                                    EmployeePassword = GetStringOrDefault(reader, "EmployeePassword", string.Empty),
                                    AccessLevel = GetInt32OrDefault(reader, "AccessLevel", 1),
                                    ManagerID = reader.IsDBNull(GetOrdinalSafe(reader, "ManagerID")) ?
                                        (int?)null : reader.GetInt32(reader.GetOrdinal("ManagerID"))
                                };

                                view.DisplayEmployeeInfo(employee);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi tải thông tin nhân viên: {ex.Message}", "Lỗi", MessageBoxIcon.Error);
            }
        }
        // Phương thức hỗ trợ đọc dữ liệu an toàn
        private int GetOrdinalSafe(SqlDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(columnName, StringComparison.OrdinalIgnoreCase))
                    return i;
            }
            return -1;
        }

        // Hàm hỗ trợ đọc dữ liệu an toàn
        private string GetStringOrDefault(SqlDataReader reader, string columnName, string defaultValue)
        {
            int ordinal = GetOrdinalSafe(reader, columnName);
            if (ordinal == -1 || reader.IsDBNull(ordinal))
                return defaultValue;
            return reader.GetString(ordinal);
        }

        public void LoadEmployeeToEdit(int employeeID)
        {
            try
            {
                if (employeeID <= 0)
                {
                    view.ShowMessage("Không có nhân viên nào được chọn để sửa!", "Lỗi", MessageBoxIcon.Warning);
                    return;
                }

                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM EMPLOYEE WHERE EmployeeID = @EmployeeID";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employeeID);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var employee = new EmployeeModel
                                {
                                    EmployeeID = reader.GetInt32(reader.GetOrdinal("EmployeeID")),
                                    EmployeeCode = reader.GetString(reader.GetOrdinal("EmployeeCode")),
                                    EmployeeName = reader.GetString(reader.GetOrdinal("EmployeeName")),
                                    EmployeeGender = reader.GetString(reader.GetOrdinal("EmployeeGender")),
                                    EmployeeDateOfBirth = reader.GetDateTime(reader.GetOrdinal("EmployeeDateOfBirth")),
                                    EmployeeCitizenID = reader.GetString(reader.GetOrdinal("EmployeeCitizenID")),
                                    EmployeeAddress = reader.GetString(reader.GetOrdinal("EmployeeAddress")),
                                    EmployeeRole = reader.GetString(reader.GetOrdinal("EmployeeRole")),
                                    EmployeePhone = reader.GetString(reader.GetOrdinal("EmployeePhone")),
                                    EmployeeEmail = reader.GetString(reader.GetOrdinal("EmployeeEmail")),
                                    HireDate = reader.GetDateTime(reader.GetOrdinal("HireDate")),
                                    Salary = reader.GetDecimal(reader.GetOrdinal("Salary")),
                                    EmployeeUsername = reader.GetString(reader.GetOrdinal("EmployeeUsername")),
                                    EmployeePassword = reader.GetString(reader.GetOrdinal("EmployeePassword")),
                                    AccessLevel = reader.GetInt32(reader.GetOrdinal("AccessLevel")),
                                    ManagerID = reader.IsDBNull(reader.GetOrdinal("ManagerID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("ManagerID"))
                                };

                                view.DisplayEmployeeForEdit(employee);
                                isEditMode = true;
                                currentEditingEmployeeID = employeeID;
                                view.SetButtonState(true);
                            }
                            else
                            {
                                view.ShowMessage("Không tìm thấy thông tin nhân viên!", "Lỗi", MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi tải thông tin nhân viên: {ex.Message}", "Lỗi", MessageBoxIcon.Error);
            }
        }

        private void View_AddButtonClicked(object sender, EventArgs e)
        {
            isEditMode = false;
            currentEditingEmployeeID = -1;
            view.ClearInputFields();

            // Hiển thị ComboBox chọn cấp bậc cho nhân viên mới
            ((UC_EmployeeManagement)view).SetAccessLevelOptions();

            // Thiết lập trạng thái ban đầu cho form thêm mới
            ((UC_EmployeeManagement)view).SetupAddEmployeeMode();
        }

        private void View_EditButtonClicked(object sender, EventArgs e)
        {

            int selectedEmployeeID = view.GetSelectedEmployeeID();
            if (selectedEmployeeID > 0)
            {
                LoadEmployeeToEdit(selectedEmployeeID);
            }
            else
            {
                view.ShowMessage("Vui lòng chọn nhân viên cần sửa!", "Thông báo", MessageBoxIcon.Information);
            }
        }

        private void View_DeleteButtonClicked(object sender, EventArgs e)
        {
            int selectedEmployeeID = view.GetSelectedEmployeeID();
            if (selectedEmployeeID > 0)
            {
                DeleteEmployee(selectedEmployeeID);
            }
            else
            {
                view.ShowMessage("Vui lòng chọn nhân viên cần xóa!", "Thông báo", MessageBoxIcon.Information);
            }
        }
        private EmployeeModel GetEmployeeById(int employeeId)
        {
            EmployeeModel employee = null;

            using (var connection = dbContext.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM EMPLOYEE WHERE EmployeeID = @EmployeeID";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employeeId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            employee = new EmployeeModel
                            {
                                EmployeeID = reader.GetInt32(reader.GetOrdinal("EmployeeID")),
                                EmployeeCode = reader.GetString(reader.GetOrdinal("EmployeeCode")),
                                EmployeeUsername = reader.GetString(reader.GetOrdinal("EmployeeUsername")),
                                EmployeePassword = reader.GetString(reader.GetOrdinal("EmployeePassword")),
                                // Các trường khác nếu cần
                            };
                        }
                    }
                }
            }

            return employee;
        }

        public void View_SaveButtonClicked(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ form
                var employee = view.GetEmployeeFromInputFields();

                // Ghi log để debug
                Console.WriteLine($"Save operation triggered - IsEditMode: {isEditMode}, EmployeeID: {currentEditingEmployeeID}");

                if (isEditMode)
                {
                    // Chế độ cập nhật
                    Console.WriteLine("Updating existing employee record");

                    // Kiểm tra nếu đang chỉnh sửa một nhân viên cụ thể
                    if (currentEditingEmployeeID <= 0)
                    {
                        view.ShowMessage("Không xác định được nhân viên cần cập nhật!", "Lỗi", MessageBoxIcon.Warning);
                        return;
                    }

                    // Kiểm tra nếu số điện thoại thay đổi (sẽ ảnh hưởng username)
                    string currentPhone = GetEmployeePhoneById(currentEditingEmployeeID);
                    if (currentPhone != employee.EmployeePhone)
                    {
                        DialogResult result = MessageBox.Show(
                            "Thay đổi số điện thoại sẽ cập nhật tên đăng nhập của nhân viên.\nBạn có muốn tiếp tục không?",
                            "Xác nhận thay đổi",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (result == DialogResult.No)
                        {
                            return;
                        }
                    }

                    // Thực hiện cập nhật
                    UpdateEmployee(employee);
                }
                else
                {
                    // Chế độ thêm mới
                    Console.WriteLine("Adding new employee record");

                    // Đảm bảo trường employee code là "(Tự động tạo)"
                    if (employee.EmployeeCode != "(Tự động tạo)")
                    {
                        view.ShowMessage("Mã nhân viên phải được tạo tự động khi thêm mới!", "Lỗi", MessageBoxIcon.Warning);
                        return;
                    }

                    // Kiểm tra bổ sung trước khi thêm mới
                    if (string.IsNullOrWhiteSpace(employee.EmployeePhone))
                    {
                        view.ShowMessage("Số điện thoại là bắt buộc vì sẽ được sử dụng làm tên đăng nhập!", "Lỗi", MessageBoxIcon.Warning);
                        return;
                    }

                    // Thực hiện thêm mới
                    AddEmployee(employee);
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi lưu thông tin nhân viên: {ex.Message}", "Lỗi", MessageBoxIcon.Error);
                Console.WriteLine($"Exception in View_SaveButtonClicked: {ex.Message}\nStackTrace: {ex.StackTrace}");
            }
        }

        // Thêm phương thức kiểm tra trùng CCCD
        private bool IsCitizenIDExists(string citizenID, int excludeEmployeeID = -1)
        {
            using (var connection = dbContext.GetConnection())
            {
                connection.Open();
                string query = excludeEmployeeID == -1
                    ? "SELECT COUNT(1) FROM EMPLOYEE WHERE EmployeeCitizenID = @CitizenID"
                    : "SELECT COUNT(1) FROM EMPLOYEE WHERE EmployeeCitizenID = @CitizenID AND EmployeeID != @EmployeeID";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CitizenID", citizenID);
                    if (excludeEmployeeID != -1)
                    {
                        command.Parameters.AddWithValue("@EmployeeID", excludeEmployeeID);
                    }
                    return (int)command.ExecuteScalar() > 0;
                }
            }
        }

        // Thêm phương thức kiểm tra trùng email
        private bool IsEmailExists(string email, int excludeEmployeeID = -1)
        {
            using (var connection = dbContext.GetConnection())
            {
                connection.Open();
                string query = excludeEmployeeID == -1
                    ? "SELECT COUNT(1) FROM EMPLOYEE WHERE EmployeeEmail = @Email"
                    : "SELECT COUNT(1) FROM EMPLOYEE WHERE EmployeeEmail = @Email AND EmployeeID != @EmployeeID";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    if (excludeEmployeeID != -1)
                    {
                        command.Parameters.AddWithValue("@EmployeeID", excludeEmployeeID);
                    }
                    return (int)command.ExecuteScalar() > 0;
                }
            }
        }

        // Cập nhật phương thức kiểm tra trùng số điện thoại để hỗ trợ loại trừ ID
        private bool IsPhoneExists(string phone, int excludeEmployeeID = -1)
        {
            using (var connection = dbContext.GetConnection())
            {
                connection.Open();
                string query = excludeEmployeeID == -1
                    ? "SELECT COUNT(1) FROM EMPLOYEE WHERE EmployeeUsername = @Phone OR EmployeePhone = @Phone"
                    : "SELECT COUNT(1) FROM EMPLOYEE WHERE (EmployeeUsername = @Phone OR EmployeePhone = @Phone) AND EmployeeID != @EmployeeID";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Phone", phone);
                    if (excludeEmployeeID != -1)
                    {
                        command.Parameters.AddWithValue("@EmployeeID", excludeEmployeeID);
                    }
                    return (int)command.ExecuteScalar() > 0;
                }
            }
        }

        // Hàm hỗ trợ để lấy số điện thoại hiện tại của nhân viên
        private string GetEmployeePhoneById(int employeeId)
        {
            try
            {
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT EmployeePhone FROM EMPLOYEE WHERE EmployeeID = @EmployeeID";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employeeId);
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            return result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetEmployeePhoneById: {ex.Message}");
            }

            return string.Empty;
        }

        private void View_CancelButtonClicked(object sender, EventArgs e)
        {
            view.ClearInputFields();
            isEditMode = false;
            currentEditingEmployeeID = -1;
            view.SetButtonState(false);
        }

        private void View_SearchButtonClicked(object sender, EventArgs e)
        {
            string searchKeyword = view.EmployeeSearchText;
            string genderFilter = view.SelectedGender;
            LoadEmployeeList(searchKeyword, genderFilter);
        }

        private void View_GenderFilterChanged(object sender, EventArgs e)
        {
            string searchKeyword = view.EmployeeSearchText;
            string genderFilter = view.SelectedGender;
            LoadEmployeeList(searchKeyword, genderFilter);
        }

        public void ExportToExcel()
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    Title = "Lưu báo cáo Excel",
                    FileName = "EmployeeList.xlsx"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy dữ liệu từ DataGridView (đã được lọc)
                    System.Data.DataTable employeeData = view.GetDataGridViewDataSource();

                    if (employeeData == null || employeeData.Rows.Count == 0)
                    {
                        view.ShowMessage("Không có dữ liệu để xuất!", "Thông báo", MessageBoxIcon.Warning);
                        return;
                    }

                    // Khởi tạo ứng dụng Excel
                    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                    excelApp.Visible = false;

                    // Tạo workbook mới
                    Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Add();
                    Microsoft.Office.Interop.Excel._Worksheet worksheet = workbook.ActiveSheet;

                    // Tiêu đề báo cáo
                    worksheet.Cells[1, 1] = "BÁO CÁO DANH SÁCH NHÂN VIÊN";
                    Microsoft.Office.Interop.Excel.Range titleRange = worksheet.Cells[1, 1];
                    titleRange.Font.Bold = true;
                    titleRange.Font.Size = 16;
                    titleRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 11]].Merge();

                    // Thêm tiêu đề cột
                    string[] columnHeaders = {
                "Mã NV", "Họ tên", "Giới tính", "Ngày sinh", "CCCD",
                "Địa chỉ", "Chức vụ", "SĐT", "Email", "Ngày vào làm", "Lương"
            };

                    for (int i = 0; i < columnHeaders.Length; i++)
                    {
                        worksheet.Cells[3, i + 1] = columnHeaders[i];
                        worksheet.Cells[3, i + 1].Font.Bold = true;
                        worksheet.Cells[3, i + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                    }

                    // Ánh xạ tên cột từ DataTable
                    string[] columnNames = {
                "EmployeeCode", "EmployeeName", "EmployeeGender", "EmployeeDateOfBirth",
                "EmployeeCitizenID", "EmployeeAddress", "EmployeeRole", "EmployeePhone",
                "EmployeeEmail", "HireDate", "Salary"
            };

                    // Thêm dữ liệu từ DataTable
                    for (int i = 0; i < employeeData.Rows.Count; i++)
                    {
                        for (int j = 0; j < columnHeaders.Length; j++)
                        {
                            string columnName = columnNames[j];
                            object value = employeeData.Rows[i][columnName];

                            if (columnName == "EmployeeDateOfBirth" || columnName == "HireDate")
                            {
                                if (value != DBNull.Value)
                                {
                                    worksheet.Cells[i + 4, j + 1] = Convert.ToDateTime(value).ToString("dd/MM/yyyy");
                                }
                                else
                                {
                                    worksheet.Cells[i + 4, j + 1] = string.Empty;
                                }
                            }
                            else if (columnName == "Salary")
                            {
                                if (value != DBNull.Value)
                                {
                                    worksheet.Cells[i + 4, j + 1] = Convert.ToDecimal(value);
                                }
                                else
                                {
                                    worksheet.Cells[i + 4, j + 1] = string.Empty;
                                }
                            }
                            else
                            {
                                worksheet.Cells[i + 4, j + 1] = value?.ToString() ?? string.Empty;
                            }
                        }
                    }

                    // Định dạng cột lương (cột thứ 11)
                    Microsoft.Office.Interop.Excel.Range salaryColumn = worksheet.Columns[11];
                    salaryColumn.NumberFormat = "#,##0";

                    // Tự động điều chỉnh độ rộng cột
                    worksheet.Columns.AutoFit();

                    // Lưu workbook
                    workbook.SaveAs(saveDialog.FileName);
                    workbook.Close();
                    excelApp.Quit();

                    // Giải phóng tài nguyên
                    ReleaseObject(worksheet);
                    ReleaseObject(workbook);
                    ReleaseObject(excelApp);

                    view.ShowMessage("Xuất Excel thành công!", "Thông báo", MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi xuất Excel: {ex.Message}", "Lỗi", MessageBoxIcon.Error);
            }
        }

        private System.Data.DataTable GetEmployeeDataForExport()
        {
            System.Data.DataTable dataTable = new System.Data.DataTable();

            using (var connection = dbContext.GetConnection())
            {
                connection.Open();
                string query = @"
            SELECT 
                EmployeeCode AS [Mã NV], 
                EmployeeName AS [Họ tên], 
                EmployeeGender AS [Giới tính], 
                CONVERT(VARCHAR, EmployeeDateOfBirth, 103) AS [Ngày sinh], 
                EmployeeCitizenID AS [CCCD], 
                EmployeeAddress AS [Địa chỉ], 
                EmployeeRole AS [Chức vụ], 
                EmployeePhone AS [SĐT], 
                EmployeeEmail AS [Email], 
                CONVERT(VARCHAR, HireDate, 103) AS [Ngày vào làm], 
                Salary AS [Lương] 
            FROM EMPLOYEE 
            ORDER BY EmployeeID";

                using (var command = new SqlCommand(query, connection))
                {
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        public void ExportToPDF()
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "PDF Files|*.pdf",
                    Title = "Lưu báo cáo PDF",
                    FileName = "EmployeeList.pdf"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy dữ liệu từ DataGridView (đã được lọc)
                    System.Data.DataTable employeeData = view.GetDataGridViewDataSource();

                    if (employeeData == null || employeeData.Rows.Count == 0)
                    {
                        view.ShowMessage("Không có dữ liệu để xuất!", "Thông báo", MessageBoxIcon.Warning);
                        return;
                    }

                    // Tạo document PDF
                    iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate());
                    iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(
                        document, new FileStream(saveDialog.FileName, FileMode.Create));

                    // Thiết lập metadata
                    document.AddTitle("Báo cáo danh sách nhân viên");
                    document.AddAuthor("Quản lý thông tin khách hàng Sacombank");
                    document.AddCreator("Hệ thống quản lý");

                    document.Open();

                    // Thiết lập font chữ hỗ trợ tiếng Việt
                    string fontPath = Path.Combine(Environment.GetFolderPath(
                        Environment.SpecialFolder.Fonts), "arial.ttf");
                    iTextSharp.text.pdf.BaseFont baseFont = iTextSharp.text.pdf.BaseFont.CreateFont(
                        fontPath, iTextSharp.text.pdf.BaseFont.IDENTITY_H, iTextSharp.text.pdf.BaseFont.EMBEDDED);

                    // Định nghĩa các font sẽ sử dụng
                    iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 16,
                        iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Font headerFont = new iTextSharp.text.Font(baseFont, 11,
                        iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Font normalFont = new iTextSharp.text.Font(baseFont, 10,
                        iTextSharp.text.Font.NORMAL);

                    // Tạo tiêu đề báo cáo
                    iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph(
                        "BÁO CÁO DANH SÁCH NHÂN VIÊN", titleFont);
                    title.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                    title.SpacingAfter = 20f;
                    document.Add(title);

                    // Tạo bảng dữ liệu với 11 cột (bỏ cột "NV1")
                    iTextSharp.text.pdf.PdfPTable table = new iTextSharp.text.pdf.PdfPTable(11); // Chỉ có 11 cột
                    table.WidthPercentage = 100;

                    // Thiết lập độ rộng tương đối của các cột
                    float[] widths = new float[11]; // 11 cột
                    for (int i = 0; i < 11; i++)
                    {
                        switch (i)
                        {
                            case 0: widths[i] = 2f; break; // Mã NV
                            case 1: widths[i] = 4f; break; // Họ tên
                            case 2: widths[i] = 2f; break; // Giới tính
                            case 3: widths[i] = 3f; break; // Ngày sinh
                            case 4: widths[i] = 3f; break; // CCCD
                            case 5: widths[i] = 5f; break; // Địa chỉ
                            case 6: widths[i] = 3f; break; // Chức vụ
                            case 7: widths[i] = 3f; break; // SĐT
                            case 8: widths[i] = 5f; break; // Email
                            case 9: widths[i] = 3f; break; // Ngày vào làm
                            case 10: widths[i] = 2f; break; // Lương
                        }
                    }
                    table.SetWidths(widths);

                    // Tạo header cho bảng (chỉ 11 cột, bỏ "NV1")
                    string[] columnHeaders = {
                "Mã NV", "Họ tên", "Giới tính", "Ngày sinh", "CCCD",
                "Địa chỉ", "Chức vụ", "SĐT", "Email", "Ngày vào làm", "Lương"
            };
                    for (int i = 0; i < columnHeaders.Length; i++)
                    {
                        iTextSharp.text.pdf.PdfPCell cell = new iTextSharp.text.pdf.PdfPCell(
                            new iTextSharp.text.Phrase(columnHeaders[i], headerFont));
                        cell.BackgroundColor = new iTextSharp.text.BaseColor(220, 220, 220);
                        cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        cell.Padding = 5;
                        table.AddCell(cell);
                    }

                    // Ánh xạ tên cột từ DataTable (bỏ qua cột EmployeeID)
                    string[] columnNames = {
                "EmployeeCode", "EmployeeName", "EmployeeGender", "EmployeeDateOfBirth",
                "EmployeeCitizenID", "EmployeeAddress", "EmployeeRole", "EmployeePhone",
                "EmployeeEmail", "HireDate", "Salary"
            };

                    // Thêm dữ liệu vào bảng
                    foreach (DataRow row in employeeData.Rows)
                    {
                        for (int i = 0; i < columnHeaders.Length; i++)
                        {
                            string columnName = columnNames[i];
                            object item = row[columnName];
                            string text;

                            if (columnName == "EmployeeDateOfBirth" || columnName == "HireDate")
                            {
                                if (item != DBNull.Value)
                                {
                                    text = Convert.ToDateTime(item).ToString("dd/MM/yyyy");
                                }
                                else
                                {
                                    text = string.Empty;
                                }
                            }
                            else if (columnName == "Salary" && item != null && decimal.TryParse(item.ToString(), out decimal salary))
                            {
                                text = string.Format("{0:#,##0}", salary);
                            }
                            else
                            {
                                text = item?.ToString() ?? string.Empty;
                            }

                            iTextSharp.text.pdf.PdfPCell cell = new iTextSharp.text.pdf.PdfPCell(
                                new iTextSharp.text.Phrase(text, normalFont));
                            cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                            cell.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                            cell.Padding = 5;
                            table.AddCell(cell);
                        }
                    }

                    document.Add(table);

                    // Thêm thông tin thời gian xuất báo cáo
                    iTextSharp.text.Paragraph footer = new iTextSharp.text.Paragraph(
                        $"Báo cáo được xuất ngày: {DateTime.Now:dd/MM/yyyy HH:mm:ss}", normalFont);
                    footer.Alignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    footer.SpacingBefore = 10f;
                    document.Add(footer);

                    document.Close();
                    writer.Close();

                    view.ShowMessage("Xuất PDF thành công!", "Thông báo", MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi xuất PDF: {ex.Message}", "Lỗi", MessageBoxIcon.Error);
            }
        }

        private void ReleaseObject(object obj)
        {
            try
            {
                if (obj != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }

        // Helper methods
        private string ValidateEmployeeData(EmployeeModel employee)
        {
            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrWhiteSpace(employee.EmployeeName))
                return "Tên nhân viên không được để trống!";

            if (string.IsNullOrWhiteSpace(employee.EmployeeGender))
                return "Giới tính không được để trống!";

            if (string.IsNullOrWhiteSpace(employee.EmployeeCitizenID))
                return "CCCD không được để trống!";

            if (string.IsNullOrWhiteSpace(employee.EmployeeAddress))
                return "Địa chỉ không được để trống!";

            if (string.IsNullOrWhiteSpace(employee.EmployeeRole))
                return "Chức vụ không được để trống!";

            if (string.IsNullOrWhiteSpace(employee.EmployeePhone))
                return "Số điện thoại không được để trống!";

            if (string.IsNullOrWhiteSpace(employee.EmployeeEmail))
                return "Email không được để trống!";

            // Ràng buộc mới: Kiểm tra tên nhân viên được viết hoa từng chữ cái đầu
            if (!IsProperCase(employee.EmployeeName))
                return "Tên nhân viên phải viết hoa chữ cái đầu mỗi từ!";

            // Ràng buộc mới: Kiểm tra CCCD
            if (employee.EmployeeCitizenID.Length != 12)
                return "CCCD phải có đúng 12 số!";

            // Kiểm tra CCCD chỉ chứa số
            if (!employee.EmployeeCitizenID.All(char.IsDigit))
                return "CCCD chỉ được chứa các chữ số!";

            // Kiểm tra CCCD phải bắt đầu bằng 0
            if (employee.EmployeeCitizenID.Length > 0 && employee.EmployeeCitizenID[0] != '0')
                return "Số đầu tiên của CCCD phải là số 0!";

            // Kiểm tra độ dài mật khẩu
            if (employee.EmployeePassword.Length < 6)
                return "Mật khẩu phải có ít nhất 6 ký tự!";

            // Kiểm tra định dạng email
            if (!IsValidEmail(employee.EmployeeEmail))
                return "Email không đúng định dạng!";

            // Kiểm tra định dạng và đầu số số điện thoại
            if (!IsValidPhone(employee.EmployeePhone))
                return "Số điện thoại không đúng định dạng!";
            if (!employee.EmployeePhone.StartsWith("03") && !employee.EmployeePhone.StartsWith("05") &&
                !employee.EmployeePhone.StartsWith("07") && !employee.EmployeePhone.StartsWith("08") &&
                !employee.EmployeePhone.StartsWith("09"))
            {
                return "Nhà mạng không phù hợp! Số điện thoại phải bắt đầu bằng 03, 05, 07, 08, hoặc 09.";
            }

            return string.Empty;
        }

        // Thêm hàm mới để kiểm tra tên có viết hoa từng chữ cái đầu không
        private bool IsProperCase(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            // Tách tên thành các từ
            string[] words = name.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Kiểm tra từng từ
            foreach (string word in words)
            {
                if (word.Length > 0)
                {
                    // Kiểm tra chữ cái đầu tiên của mỗi từ có viết hoa không
                    if (!char.IsUpper(word[0]))
                        return false;
                }
            }

            return true;
        }

        private bool IsEmployeeCodeExists(string employeeCode)
        {
            using (var connection = dbContext.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT COUNT(1) FROM EMPLOYEE WHERE EmployeeCode = @EmployeeCode", connection);
                command.Parameters.AddWithValue("@EmployeeCode", employeeCode);
                return (int)command.ExecuteScalar() > 0;
            }
        }

        private bool IsEmployeeCodeExistsForOthers(string employeeCode, int currentEmployeeID)
        {
            // Kiểm tra tham số đầu vào
            if (string.IsNullOrEmpty(employeeCode))
            {
                // Ghi log lỗi
                Console.WriteLine("WARNING: Empty employeeCode passed to IsEmployeeCodeExistsForOthers");
                return false; // Hoặc xử lý khác tùy thuộc vào logic nghiệp vụ
            }

            using (var connection = dbContext.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(1) FROM EMPLOYEE WHERE EmployeeCode = @EmployeeCode AND EmployeeID != @EmployeeID";

                    using (var command = new SqlCommand(query, connection))
                    {
                        // Đảm bảo thêm đầy đủ tham số
                        command.Parameters.AddWithValue("@EmployeeCode", employeeCode);
                        command.Parameters.AddWithValue("@EmployeeID", currentEmployeeID);

                        // Ghi log truy vấn để debug
                        Console.WriteLine($"Executing query: {query} with params: @EmployeeCode={employeeCode}, @EmployeeID={currentEmployeeID}");

                        return (int)command.ExecuteScalar() > 0;
                    }
                }
                catch (Exception ex)
                {
                    // Ghi log lỗi chi tiết
                    Console.WriteLine($"ERROR in IsEmployeeCodeExistsForOthers: {ex.Message}\nStackTrace: {ex.StackTrace}");
                    throw; // Chuyển tiếp ngoại lệ để xử lý ở tầng trên
                }
            }
        }

        private bool IsUsernameExists(string username)
        {
            using (var connection = dbContext.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT COUNT(1) FROM EMPLOYEE WHERE EmployeeUsername = @Username", connection);
                command.Parameters.AddWithValue("@Username", username);
                return (int)command.ExecuteScalar() > 0;
            }
        }

        private bool IsUsernameExistsForOthers(string username, int currentEmployeeID)
        {
            using (var connection = dbContext.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT COUNT(1) FROM EMPLOYEE WHERE EmployeeUsername = @Username AND EmployeeID != @EmployeeID", connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@EmployeeID", currentEmployeeID);
                return (int)command.ExecuteScalar() > 0;
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhone(string phone)
        {
            return phone.Length >= 10 && phone.All(char.IsDigit);
        }
    }

    public class SqlQueryExecutor
    {
        private readonly DatabaseContext dbContext;

        public SqlQueryExecutor(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int ExecuteNonQuery(string query, Dictionary<string, object> parameters)
        {
            using (var connection = dbContext.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    // Phân tích câu truy vấn để xác định các tham số cần thiết
                    HashSet<string> requiredParams = ExtractParametersFromQuery(query);

                    // Kiểm tra và cảnh báo về các tham số thiếu
                    foreach (string param in requiredParams)
                    {
                        if (!parameters.ContainsKey(param.Substring(1))) // Loại bỏ ký tự @ ở đầu
                        {
                            throw new ArgumentException($"Required parameter {param} was not supplied.");
                        }
                    }

                    // Thêm tham số vào câu lệnh
                    foreach (var param in parameters)
                    {
                        command.Parameters.AddWithValue($"@{param.Key}", param.Value ?? DBNull.Value);
                    }

                    return command.ExecuteNonQuery();
                }
            }
        }

        private HashSet<string> ExtractParametersFromQuery(string query)
        {
            HashSet<string> parameters = new HashSet<string>();
            // Biểu thức chính quy để tìm các tham số trong câu truy vấn SQL
            // (Đây là một triển khai đơn giản, cần cải thiện để xử lý các trường hợp phức tạp hơn)
            string pattern = @"@([A-Za-z0-9_]+)";
            System.Text.RegularExpressions.MatchCollection matches =
                System.Text.RegularExpressions.Regex.Matches(query, pattern);

            foreach (System.Text.RegularExpressions.Match match in matches)
            {
                parameters.Add(match.Value);
            }

            return parameters;
        }
        public string FormatCurrency(decimal value)
        {
            // Định dạng tiền tệ: 000,000,000 (không hiển thị đơn vị)
            return string.Format("{0:#,##0}", value);
        }
    }
}