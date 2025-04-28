using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Views.Employee;
using Excel = Microsoft.Office.Interop.Excel;
using QuanLyThongTinKhachHangSacomBank.Views.Common;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    public class EmployeeCustomerManagementController : IOTPController
    {
        private readonly IEmployeeCustomerManagementView view;
        private readonly DatabaseContext dbContext;
        private readonly IConfiguration configuration;
        private List<CustomerModel> customers;
        private List<CustomerTypeModel> customerTypes;
        private List<CustomerDisplayModel> currentCustomers; // Lưu trữ danh sách hiển thị
        private CustomerModel selectedCustomer;
        private bool isAdding;

        // Triển khai IOTPController để cung cấp thông tin cho OTPController 
        // Luôn trả về thông tin từ textbox trong chế độ sửa
        public string Phone => view.GetPhone();
        public string Email => view.GetEmail();

        public EmployeeCustomerManagementController(IEmployeeCustomerManagementView view, DatabaseContext dbContext, IConfiguration configuration)
        {
            this.view = view;
            this.dbContext = dbContext;
            this.configuration = configuration;
            customers = new List<CustomerModel>();
            customerTypes = new List<CustomerTypeModel>();
            currentCustomers = new List<CustomerDisplayModel>();
            selectedCustomer = null;
            isAdding = false;
        }

        public void InitializeControlState()
        {
            view.EnableCustomerInfoControls(false, false);
            view.EnableButtons(true, false, false, false);
            view.ClearCustomerInfo();
        }

        public void LoadInitialData()
        {
            try
            {
                // Load danh sách loại khách hàng trước
                LoadCustomerTypes();

                // Load dữ liệu khách hàng với bộ lọc mặc định (tất cả khách hàng)
                DateTime toDate = DateTime.Now;
                DateTime fromDate = new DateTime(2000, 1, 1); // Một ngày xa để bao gồm tất cả khách hàng
                view.SetDateFilter(fromDate, toDate);
                LoadCustomers(fromDate, toDate, "Không áp dụng");
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi load dữ liệu ban đầu: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCustomerTypes()
        {
            try
            {
                customerTypes.Clear();
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT CustomerTypeID, CustomerTypeName FROM CUSTOMER_TYPE";
                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var customerType = new CustomerTypeModel
                                {
                                    CustomerTypeID = reader.GetInt32(0),
                                    CustomerTypeName = reader.GetString(1)
                                };
                                customerTypes.Add(customerType);
                                Console.WriteLine($"Loaded CustomerType: {customerType.CustomerTypeName}");
                            }
                            view.SetCustomerTypeList(customerTypes);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi load loại khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadCustomers(DateTime fromDate, DateTime toDate, string customerTypeFilter)
        {
            try
            {
                customers.Clear();
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    string query = @"
                        SELECT c.CustomerID, c.CustomerCode, c.FullName, c.Gender, c.DateOfBirth, c.Nationality, 
                               c.CitizenID, c.CustomerAddress, c.Phone, c.Email, c.RegistrationDate, ct.CustomerTypeName
                        FROM CUSTOMER c
                        JOIN CUSTOMER_TYPE ct ON c.CustomerTypeID = ct.CustomerTypeID
                        WHERE c.RegistrationDate BETWEEN @FromDate AND @ToDate";

                    if (customerTypeFilter != "Không áp dụng")
                    {
                        query += " AND ct.CustomerTypeName = @CustomerTypeName";
                    }

                    query += " ORDER BY c.RegistrationDate DESC"; // Sắp xếp theo ngày đăng ký giảm dần

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FromDate", fromDate);
                        command.Parameters.AddWithValue("@ToDate", toDate);
                        if (customerTypeFilter != "Không áp dụng")
                        {
                            command.Parameters.AddWithValue("@CustomerTypeName", customerTypeFilter);
                        }

                        Console.WriteLine($"Executing query: {query}");
                        Console.WriteLine($"FromDate: {fromDate}, ToDate: {toDate}, CustomerTypeFilter: {customerTypeFilter}");

                        using (var reader = command.ExecuteReader())
                        {
                            int rowCount = 0;
                            while (reader.Read())
                            {
                                customers.Add(new CustomerModel
                                {
                                    CustomerID = reader.GetInt32(0),
                                    CustomerCode = reader.GetString(1),
                                    FullName = reader.GetString(2),
                                    Gender = reader.GetString(3),
                                    DateOfBirth = reader.GetDateTime(4),
                                    Nationality = reader.GetString(5),
                                    CitizenID = reader.GetString(6),
                                    CustomerAddress = reader.GetString(7),
                                    Phone = reader.GetString(8),
                                    Email = reader.GetString(9),
                                    RegistrationDate = reader.GetDateTime(10),
                                    CustomerTypeID = GetCustomerTypeIdByName(reader.GetString(11))
                                });
                                rowCount++;
                            }
                            Console.WriteLine($"Loaded {rowCount} customers.");
                        }
                    }
                }

                // Cập nhật danh sách currentCustomers
                UpdateDataGridView();
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi load khách hàng: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetCustomerTypeIdByName(string customerTypeName)
        {
            var customerType = customerTypes.FirstOrDefault(ct => ct.CustomerTypeName == customerTypeName);
            return customerType?.CustomerTypeID ?? 0;
        }

        private string GetCustomerTypeNameById(int customerTypeId)
        {
            var customerType = customerTypes.FirstOrDefault(ct => ct.CustomerTypeID == customerTypeId);
            return customerType?.CustomerTypeName ?? "Không xác định";
        }

        private void UpdateDataGridView()
        {
            // Chuyển đổi từ CustomerModel sang CustomerDisplayModel
            currentCustomers.Clear();
            foreach (var customer in customers)
            {
                currentCustomers.Add(new CustomerDisplayModel
                {
                    CustomerCode = customer.CustomerCode,
                    CustomerTypeName = GetCustomerTypeNameById(customer.CustomerTypeID),
                    FullName = customer.FullName,
                    Gender = customer.Gender,
                    DateOfBirth = customer.DateOfBirth.ToString("dd/MM/yyyy"),
                    Nationality = customer.Nationality,
                    CitizenID = customer.CitizenID,
                    CustomerAddress = customer.CustomerAddress,
                    Phone = customer.Phone,
                    Email = customer.Email,
                    RegistrationDate = customer.RegistrationDate.ToString("dd/MM/yyyy HH:mm:ss") // Hiển thị cả thời gian
                });
            }

            // Truyền danh sách đã xử lý vào view
            view.UpdateDataGridView(currentCustomers);
        }

        public void OnAddCustomer()
        {
            isAdding = true;
            selectedCustomer = null;

            view.EnableCustomerInfoControls(true, true);
            view.EnableButtons(false, false, true, true);
            view.ClearCustomerInfo();
        }

        public void OnEditCustomer()
        {
            if (selectedCustomer == null)
            {
                view.ShowMessage("Vui lòng chọn một khách hàng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isAdding = false;
            view.EnableCustomerInfoControls(true, false);
            view.EnableButtons(false, false, true, true);
        }

        public void OnCancelCustomer()
        {
            isAdding = false;
            selectedCustomer = null;
            view.EnableCustomerInfoControls(false, false);
            view.EnableButtons(true, false, false, false);
            view.ClearCustomerInfo();
        }

        public void OnSaveCustomer()
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(view.GetFullName()) ||
                string.IsNullOrWhiteSpace(view.GetGender()) ||
                string.IsNullOrWhiteSpace(view.GetNationality()) ||
                string.IsNullOrWhiteSpace(view.GetCitizenID()) ||
                string.IsNullOrWhiteSpace(view.GetAddress()) ||
                string.IsNullOrWhiteSpace(view.GetPhone()) ||
                string.IsNullOrWhiteSpace(view.GetEmail()))
            {
                view.ShowMessage("Vui lòng điền đầy đủ thông tin khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra định dạng tên
            string fullName = view.GetFullName();
            string[] words = fullName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
            {
                if (word.Length > 0)
                {
                    if (!char.IsUpper(word[0]) || (word.Length > 1 && word.Substring(1).Any(char.IsUpper)))
                    {
                        view.ShowMessage("Tên khách hàng phải viết hoa chữ cái đầu mỗi từ, các chữ còn lại viết thường (ví dụ: Nguyễn Văn A)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            // Kiểm tra số điện thoại
            string phone = view.GetPhone();
            if (phone.Length != 10 || !phone.All(char.IsDigit))
            {
                view.ShowMessage("Số điện thoại phải gồm đúng 10 chữ số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra 2 số đầu tiên của số điện thoại
            string phonePrefix = phone.Substring(0, 2);
            string[] validPrefixes = { "03", "08", "07", "05", "09" };
            if (!validPrefixes.Contains(phonePrefix))
            {
                view.ShowMessage("Nhà mạng không phù hợp! Số điện thoại phải bắt đầu bằng 03, 08, 07, 05, hoặc 09.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra CCCD
            string citizenID = view.GetCitizenID();
            if (citizenID.Length != 12 || !citizenID.All(char.IsDigit))
            {
                view.ShowMessage("CCCD phải gồm đúng 12 chữ số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra CCCD phải bắt đầu bằng số 0
            if (!citizenID.StartsWith("0"))
            {
                view.ShowMessage("CCCD phải bắt đầu bằng số 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra định dạng Email
            string email = view.GetEmail();
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[a-zA-Z0-9.@]+$"))
            {
                view.ShowMessage("Email chỉ được chứa các ký tự (a-z), (A-Z), (0-9), dấu chấm (.) và ký tự (@)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!email.Contains("@"))
            {
                view.ShowMessage("Email phải chứa ký tự (@)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra trùng lặp CitizenID, Phone, Email
            try
            {
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();

                    string checkQuery;
                    if (isAdding)
                    {
                        // Chế độ thêm mới: Kiểm tra xem CitizenID, Phone, Email đã tồn tại chưa
                        checkQuery = @"
                            SELECT 
                                (SELECT COUNT(*) FROM CUSTOMER WHERE CitizenID = @CitizenID) AS CitizenIDCount,
                                (SELECT COUNT(*) FROM CUSTOMER WHERE Phone = @Phone) AS PhoneCount,
                                (SELECT COUNT(*) FROM CUSTOMER WHERE LOWER(Email) = LOWER(@Email)) AS EmailCount";
                    }
                    else
                    {
                        // Chế độ chỉnh sửa: Kiểm tra trùng lặp, nhưng loại trừ chính khách hàng đang chỉnh sửa
                        checkQuery = @"
                            SELECT 
                                (SELECT COUNT(*) FROM CUSTOMER WHERE CitizenID = @CitizenID AND CustomerID != @CustomerID) AS CitizenIDCount,
                                (SELECT COUNT(*) FROM CUSTOMER WHERE Phone = @Phone AND CustomerID != @CustomerID) AS PhoneCount,
                                (SELECT COUNT(*) FROM CUSTOMER WHERE LOWER(Email) = LOWER(@Email) AND CustomerID != @CustomerID) AS EmailCount";
                    }

                    using (var checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@CitizenID", citizenID);
                        checkCommand.Parameters.AddWithValue("@Phone", phone);
                        checkCommand.Parameters.AddWithValue("@Email", view.GetEmail());
                        if (!isAdding)
                        {
                            checkCommand.Parameters.AddWithValue("@CustomerID", selectedCustomer.CustomerID);
                        }

                        using (var reader = checkCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int citizenIDCount = reader.GetInt32(0);
                                int phoneCount = reader.GetInt32(1);
                                int emailCount = reader.GetInt32(2);

                                if (citizenIDCount > 0)
                                {
                                    view.ShowMessage("CCCD này đã được đăng ký!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                if (phoneCount > 0)
                                {
                                    view.ShowMessage("Số điện thoại này đã được đăng ký!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                if (emailCount > 0)
                                {
                                    view.ShowMessage("Email này đã được đăng ký!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi kiểm tra trùng lặp: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra số điện thoại có trùng với bất kỳ nhân viên nào không
            try
            {
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();

                    string checkEmployeePhoneQuery = "SELECT COUNT(*) FROM EMPLOYEE WHERE EmployeePhone = @Phone";
                    using (var command = new SqlCommand(checkEmployeePhoneQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Phone", phone);
                        int employeePhoneCount = (int)command.ExecuteScalar();

                        if (employeePhoneCount > 0)
                        {
                            view.ShowMessage("Số điện thoại này đã được sử dụng bởi một nhân viên trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi kiểm tra số điện thoại nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            // Nếu không có lỗi, tiến hành thêm hoặc sửa khách hàng
            if (isAdding)
            {
                // Xác nhận thêm khách hàng
                var result = view.ShowConfirmation("Bạn có chắc chắn muốn thêm khách hàng?", "Xác nhận");
                if (result == DialogResult.No)
                {
                    return;
                }

                // Tạo đối tượng khách hàng mới
                var customer = new CustomerModel
                {
                    FullName = view.GetFullName(),
                    Gender = view.GetGender(),
                    DateOfBirth = view.GetDateOfBirth(),
                    Nationality = view.GetNationality(),
                    CitizenID = view.GetCitizenID(),
                    CustomerAddress = view.GetAddress(),
                    Phone = view.GetPhone(),
                    Email = view.GetEmail(),
                    RegistrationDate = view.GetRegistrationDate(),
                    CustomerTypeID = view.GetCustomerTypeID()
                };

                AddCustomer(customer);
            }
            else
            {
                // Xác nhận sửa khách hàng
                var result = view.ShowConfirmation("Bạn có chắc chắn muốn cập nhật thông tin khách hàng?", "Xác nhận");
                if (result == DialogResult.No)
                {
                    return;
                }

                // Hiển thị Form OTP để xác nhận
                using (var formOTP = new FormOTP())
                {
                    var otpController = new OTPController(formOTP, formOTP, this, configuration);

                    // Cho phép cả hai phương thức gửi OTP (SMS và Email), gửi đến thông tin mới
                    if (formOTP.ShowDialog() == DialogResult.OK)
                    {
                        // Cập nhật thông tin khách hàng
                        selectedCustomer.FullName = view.GetFullName();
                        selectedCustomer.Gender = view.GetGender();
                        selectedCustomer.DateOfBirth = view.GetDateOfBirth();
                        selectedCustomer.Nationality = view.GetNationality();
                        selectedCustomer.CitizenID = view.GetCitizenID();
                        selectedCustomer.CustomerAddress = view.GetAddress();
                        selectedCustomer.Phone = view.GetPhone();
                        selectedCustomer.Email = view.GetEmail();

                        UpdateCustomer(selectedCustomer);
                    }
                    else
                    {
                        view.ShowMessage("Xác nhận OTP thất bại. Thông tin khách hàng chưa được cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        public void OnCustomerSelected(CustomerModel customer)
        {
            // Nếu đang ở trạng thái chỉnh sửa (isAdding == false và các control đang enable)
            if (!isAdding && view.GetDataGridView().Enabled) // Kiểm tra xem DGV có enable không (để tránh trường hợp khác)
            {
                // Đặt lại trạng thái giao diện: disable các control nhập liệu và đặt lại trạng thái nút
                InitializeControlState();
            }

            selectedCustomer = customer;
            view.SetCustomerInfo(customer);
            view.EnableButtons(false, true, true, false);
        }

        public void AddCustomer(CustomerModel customer)
        {
            try
            {
                // Hiển thị Form OTP để xác nhận
                using (var formOTP = new FormOTP())
                {
                    var otpController = new OTPController(formOTP, formOTP, this, configuration);

                    // Cho phép cả hai phương thức gửi OTP (SMS và Email), sử dụng thông tin từ textbox
                    if (formOTP.ShowDialog() == DialogResult.OK)
                    {
                        // Nếu OTP được xác nhận thành công, tiến hành thêm khách hàng
                        using (var connection = dbContext.GetConnection())
                        {
                            connection.Open();

                            // Thêm khách hàng
                            string insertQuery = @"
                        INSERT INTO CUSTOMER (FullName, Gender, DateOfBirth, Nationality, CitizenID, CustomerAddress, 
                                             Phone, Email, RegistrationDate, CustomerTypeID)
                        VALUES (@FullName, @Gender, @DateOfBirth, @Nationality, @CitizenID, @CustomerAddress, 
                                @Phone, @Email, @RegistrationDate, @CustomerTypeID)";

                            using (var command = new SqlCommand(insertQuery, connection))
                            {
                                command.Parameters.AddWithValue("@FullName", customer.FullName);
                                command.Parameters.AddWithValue("@Gender", customer.Gender);
                                command.Parameters.AddWithValue("@DateOfBirth", customer.DateOfBirth);
                                command.Parameters.AddWithValue("@Nationality", customer.Nationality);
                                command.Parameters.AddWithValue("@CitizenID", customer.CitizenID);
                                command.Parameters.AddWithValue("@CustomerAddress", customer.CustomerAddress);
                                command.Parameters.AddWithValue("@Phone", customer.Phone);
                                command.Parameters.AddWithValue("@Email", customer.Email);
                                command.Parameters.AddWithValue("@RegistrationDate", customer.RegistrationDate);
                                command.Parameters.AddWithValue("@CustomerTypeID", customer.CustomerTypeID);
                                command.ExecuteNonQuery();
                            }
                        }
                        view.ShowMessage("Đã thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCustomers(view.GetFromDate(), view.GetToDate(), view.GetCustomerTypeFilter());
                        InitializeControlState();
                    }
                    else
                    {
                        // Nếu xác nhận OTP thất bại, hiển thị thông báo và không lưu khách hàng
                        view.ShowMessage("Xác nhận OTP thất bại. Khách hàng chưa được thêm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi thêm khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateCustomer(CustomerModel customer)
        {
            try
            {
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();

                    // Cập nhật thông tin khách hàng
                    string updateCustomerQuery = @"
                        UPDATE CUSTOMER
                        SET FullName = @FullName, Gender = @Gender, DateOfBirth = @DateOfBirth, Nationality = @Nationality,
                            CitizenID = @CitizenID, CustomerAddress = @CustomerAddress, Phone = @Phone, Email = @Email
                        WHERE CustomerID = @CustomerID";

                    using (var command = new SqlCommand(updateCustomerQuery, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                        command.Parameters.AddWithValue("@FullName", customer.FullName);
                        command.Parameters.AddWithValue("@Gender", customer.Gender);
                        command.Parameters.AddWithValue("@DateOfBirth", customer.DateOfBirth);
                        command.Parameters.AddWithValue("@Nationality", customer.Nationality);
                        command.Parameters.AddWithValue("@CitizenID", customer.CitizenID);
                        command.Parameters.AddWithValue("@CustomerAddress", customer.CustomerAddress);
                        command.Parameters.AddWithValue("@Phone", customer.Phone);
                        command.Parameters.AddWithValue("@Email", customer.Email);
                        command.ExecuteNonQuery();
                    }

                    // Kiểm tra xem khách hàng có tài khoản không
                    string checkAccountQuery = "SELECT COUNT(*) FROM ACCOUNT WHERE CustomerID = @CustomerID";
                    using (var command = new SqlCommand(checkAccountQuery, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                        int accountCount = (int)command.ExecuteScalar();
                        if (accountCount > 0)
                        {
                            // Cập nhật AccountName và Username trong bảng ACCOUNT
                            string updateAccountQuery = @"
                                UPDATE ACCOUNT
                                SET AccountName = @AccountName, Username = @Username
                                WHERE CustomerID = @CustomerID";
                            using (var updateCommand = new SqlCommand(updateAccountQuery, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                                string accountName = RemoveVietnameseDiacritics(customer.FullName).ToUpper();
                                updateCommand.Parameters.AddWithValue("@AccountName", accountName);
                                updateCommand.Parameters.AddWithValue("@Username", customer.Phone);
                                updateCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }
                view.ShowMessage("Đã cập nhật thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCustomers(view.GetFromDate(), view.GetToDate(), view.GetCustomerTypeFilter());
                InitializeControlState();
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi cập nhật khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Phương thức chuyển đổi tên tiếng Việt có dấu thành không dấu
        private string RemoveVietnameseDiacritics(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            string[] vietnameseChars = new string[]
            {
                "áàảãạăắằẳẵặâấầẩẫậ",
                "éèẻẽẹêếềểễệ",
                "íìỉĩị",
                "óòỏõọôốồổỗộơớờởỡợ",
                "úùủũụưứừửữự",
                "ýỳỷỹỵ",
                "đ"
            };

            string[] replacementChars = new string[] { "a", "e", "i", "o", "u", "y", "d" };

            for (int i = 0; i < vietnameseChars.Length; i++)
            {
                foreach (char c in vietnameseChars[i])
                {
                    text = text.Replace(c, replacementChars[i][0]);
                }
            }

            // Chuyển các ký tự hoa tương ứng (Á, À, Đ, v.v.)
            vietnameseChars = new string[]
            {
                "ÁÀẢÃẠĂẮẰẲẴẶÂẤẦẨẪẬ",
                "ÉÈẺẼẸÊẾỀỂỄỆ",
                "ÍÌỈĨỊ",
                "ÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢ",
                "ÚÙỦŨỤƯỨỪỬỮỰ",
                "ÝỲỶỸỴ",
                "Đ"
            };

            replacementChars = new string[] { "A", "E", "I", "O", "U", "Y", "D" };

            for (int i = 0; i < vietnameseChars.Length; i++)
            {
                foreach (char c in vietnameseChars[i])
                {
                    text = text.Replace(c, replacementChars[i][0]);
                }
            }

            return text;
        }

        public void SearchCustomers(string searchText, DateTime fromDate, DateTime toDate, string customerTypeFilter)
        {
            try
            {
                customers.Clear();
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    string query = @"
                        SELECT c.CustomerID, c.CustomerCode, c.FullName, c.Gender, c.DateOfBirth, c.Nationality, 
                               c.CitizenID, c.CustomerAddress, c.Phone, c.Email, c.RegistrationDate, ct.CustomerTypeName
                        FROM CUSTOMER c
                        JOIN CUSTOMER_TYPE ct ON c.CustomerTypeID = ct.CustomerTypeID
                        WHERE c.RegistrationDate BETWEEN @FromDate AND @ToDate
                        AND (c.CustomerCode LIKE @SearchText OR c.FullName LIKE @SearchText OR c.Phone LIKE @SearchText OR c.Email LIKE @SearchText)";

                    if (customerTypeFilter != "Không áp dụng")
                    {
                        query += " AND ct.CustomerTypeName = @CustomerTypeName";
                    }

                    query += " ORDER BY c.RegistrationDate DESC";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FromDate", fromDate);
                        command.Parameters.AddWithValue("@ToDate", toDate);
                        command.Parameters.AddWithValue("@SearchText", $"%{searchText}%");
                        if (customerTypeFilter != "Không áp dụng")
                        {
                            command.Parameters.AddWithValue("@CustomerTypeName", customerTypeFilter);
                        }

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customers.Add(new CustomerModel
                                {
                                    CustomerID = reader.GetInt32(0),
                                    CustomerCode = reader.GetString(1),
                                    FullName = reader.GetString(2),
                                    Gender = reader.GetString(3),
                                    DateOfBirth = reader.GetDateTime(4),
                                    Nationality = reader.GetString(5),
                                    CitizenID = reader.GetString(6),
                                    CustomerAddress = reader.GetString(7),
                                    Phone = reader.GetString(8),
                                    Email = reader.GetString(9),
                                    RegistrationDate = reader.GetDateTime(10),
                                    CustomerTypeID = GetCustomerTypeIdByName(reader.GetString(11))
                                });
                            }
                        }
                    }
                }
                UpdateDataGridView();
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Lỗi khi tìm kiếm khách hàng: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExportToPDF(DataGridView dgv)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF files (*.pdf)|*.pdf",
                    FileName = "CustomerList.pdf"
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

                    document.Add(new Paragraph("DANH SÁCH KHÁCH HÀNG", subHeaderFont)
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
                    PdfPTable pdfTable = new PdfPTable(11); // 11 cột
                    pdfTable.WidthPercentage = 100;
                    pdfTable.SetWidths(new float[] { 1f, 1.5f, 1f, 1f, 1f, 1f, 1f, 1.5f, 1f, 1f, 1f });

                    // Thêm tiêu đề cột với màu nền
                    string[] headers = { "Mã khách hàng", "Loại khách hàng", "Họ tên", "Giới tính", "Ngày sinh", "Quốc tịch", "CCCD/Passport", "Địa chỉ", "SĐT", "Email", "Ngày đăng kí" };
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

                    // Thêm dữ liệu từ danh sách currentCustomers
                    foreach (var customer in currentCustomers)
                    {
                        pdfTable.AddCell(new Phrase(customer.CustomerCode, vietnameseFont));
                        pdfTable.AddCell(new Phrase(customer.CustomerTypeName, vietnameseFont));
                        pdfTable.AddCell(new Phrase(customer.FullName, vietnameseFont));
                        pdfTable.AddCell(new Phrase(customer.Gender, vietnameseFont));
                        pdfTable.AddCell(new Phrase(customer.DateOfBirth, vietnameseFont));
                        pdfTable.AddCell(new Phrase(customer.Nationality, vietnameseFont));
                        pdfTable.AddCell(new Phrase(customer.CitizenID, vietnameseFont));
                        pdfTable.AddCell(new Phrase(customer.CustomerAddress, vietnameseFont));
                        pdfTable.AddCell(new Phrase(customer.Phone, vietnameseFont));
                        pdfTable.AddCell(new Phrase(customer.Email, vietnameseFont));
                        pdfTable.AddCell(new Phrase(customer.RegistrationDate, vietnameseFont));
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

        public void ExportToExcel(DataGridView dgv)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    FileName = "CustomerList.xlsx"
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
                    worksheet.Name = "CustomerList";

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

                    // Tiêu đề "DANH SÁCH KHÁCH HÀNG" (hàng 3)
                    Excel.Range subHeaderRange = worksheet.Range[worksheet.Cells[3, 1], worksheet.Cells[3, 2]];
                    subHeaderRange.Merge();
                    subHeaderRange.Value = "DANH SÁCH KHÁCH HÀNG";
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
                    string[] headers = { "Mã khách hàng", "Loại khách hàng", "Họ tên", "Giới tính", "Ngày sinh", "Quốc tịch", "CCCD/Passport", "Địa chỉ", "SĐT", "Email", "Ngày đăng kí" };
                    for (int i = 0; i < headers.Length; i++)
                    {
                        Excel.Range headerCell = worksheet.Cells[6, i + 1];
                        headerCell.Value = headers[i];
                        headerCell.Font.Bold = true; // In đậm chữ
                        headerCell.Interior.Color = System.Drawing.Color.FromArgb(252, 186, 3).ToArgb(); // Tô màu nền
                        headerCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous; // Thêm border
                        headerCell.Borders.Weight = Excel.XlBorderWeight.xlThin;
                    }

                    // Thêm dữ liệu từ danh sách currentCustomers (bắt đầu từ hàng 7)
                    for (int i = 0; i < currentCustomers.Count; i++)
                    {
                        var customer = currentCustomers[i];
                        Excel.Range rowRange = worksheet.Range[worksheet.Cells[i + 7, 1], worksheet.Cells[i + 7, 11]];
                        worksheet.Cells[i + 7, 1] = customer.CustomerCode;
                        worksheet.Cells[i + 7, 2] = customer.CustomerTypeName;
                        worksheet.Cells[i + 7, 3] = customer.FullName;
                        worksheet.Cells[i + 7, 4] = customer.Gender;
                        worksheet.Cells[i + 7, 5] = customer.DateOfBirth;
                        worksheet.Cells[i + 7, 6] = customer.Nationality;
                        worksheet.Cells[i + 7, 7] = customer.CitizenID;
                        worksheet.Cells[i + 7, 8] = customer.CustomerAddress;
                        worksheet.Cells[i + 7, 9] = customer.Phone;
                        worksheet.Cells[i + 7, 10] = customer.Email;
                        worksheet.Cells[i + 7, 11] = customer.RegistrationDate;

                        // Thêm border cho các ô dữ liệu
                        rowRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        rowRange.Borders.Weight = Excel.XlBorderWeight.xlThin;
                    }

                    // Footer (thêm vào sau dữ liệu)
                    int lastRow = currentCustomers.Count + 8; // +8 để cách 1 dòng sau dữ liệu
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
                    for (int i = 1; i <= 11; i++)
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

        public void ExportToCSV(DataGridView dgv)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv",
                    FileName = "CustomerList.csv"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder csvContent = new StringBuilder();

                    // Tiêu đề cột
                    string[] headers = { "Mã khách hàng", "Loại khách hàng", "Họ tên", "Giới tính", "Ngày sinh", "Quốc tịch", "CCCD/Passport", "Địa chỉ", "SĐT", "Email", "Ngày đăng kí" };
                    csvContent.AppendLine(string.Join(",", headers.Select(h => $"\"{h}\"")));

                    // Thêm dữ liệu từ danh sách currentCustomers
                    foreach (var customer in currentCustomers)
                    {
                        string[] rowData = new string[]
                        {
                            customer.CustomerCode?.Replace("\"", "\"\"") ?? "",
                            customer.CustomerTypeName?.Replace("\"", "\"\"") ?? "",
                            customer.FullName?.Replace("\"", "\"\"") ?? "",
                            customer.Gender?.Replace("\"", "\"\"") ?? "",
                            customer.DateOfBirth?.Replace("\"", "\"\"") ?? "",
                            customer.Nationality?.Replace("\"", "\"\"") ?? "",
                            customer.CitizenID?.Replace("\"", "\"\"") ?? "",
                            customer.CustomerAddress?.Replace("\"", "\"\"") ?? "",
                            customer.Phone?.Replace("\"", "\"\"") ?? "",
                            customer.Email?.Replace("\"", "\"\"") ?? "",
                            customer.RegistrationDate?.Replace("\"", "\"\"") ?? ""
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
    }
}