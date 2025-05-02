using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Controllers;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Views.Common;
using QuanLyThongTinKhachHangSacomBank.Views.Employee;
using System.Net.Mail;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

public class EmployeeCustomerAccountManagementController : IOTPController
{
    private readonly IAccountManagementView view;
    private readonly IConfiguration configuration;
    private readonly DatabaseContext dbContext;
    private AccountModel selectedAccount;
    private CustomerModel selectedCustomer;
    private List<AccountModel> accounts;
    private List<AccountTypeModel> accountTypes;
    private List<AccountDisplayModel> currentAccounts;
    private bool isAdding;
    private bool isEditing;

    // Triển khai IOTPController
    public string Phone => selectedCustomer?.Phone;
    public string Email => selectedCustomer?.Email;

    public EmployeeCustomerAccountManagementController(IAccountManagementView view, IConfiguration configuration, DatabaseContext dbContext)
    {
        this.view = view;
        this.configuration = configuration;
        this.dbContext = dbContext;

        // Khởi tạo các danh sách
        accounts = new List<AccountModel>();
        accountTypes = new List<AccountTypeModel>();
        currentAccounts = new List<AccountDisplayModel>();
        selectedAccount = null;
        isAdding = false;
        isEditing = false;

        InitializeControlState();
    }

    public void InitializeControlState()
    {
        view.EnableControls(false);
        view.EnableResetButtons(false);
        view.ClearInputs();
        view.SetControlState(true, false, false, false);
    }

    public void LoadInitialData()
    {
        LoadAccountTypes();
        DateTime fromDate = DateTime.Now;
        DateTime toDate = DateTime.Now;
        view.SetDateFilter(fromDate, toDate);
        LoadAccounts(fromDate, toDate, "Không áp dụng", "Không áp dụng");
    }

    private void LoadAccountTypes()
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
                string query = "SELECT * FROM ACCOUNT_TYPE";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        accountTypes.Clear();
                        while (reader.Read())
                        {
                            accountTypes.Add(new AccountTypeModel
                            {
                                AccountTypeID = reader.GetInt32(0),
                                AccountTypeCode = reader.GetString(1),
                                AccountTypeName = reader.GetString(2),
                                AccountTypeDescription = reader.GetString(3)
                            });
                        }
                        view.LoadAccountTypes(accountTypes);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            view.ShowMessage($"Lỗi khi tải danh sách loại tài khoản: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public void LoadAccounts(DateTime fromDate, DateTime toDate, string accountTypeFilter, string statusFilter)
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
                SELECT a.*, at.AccountTypeName, c.CustomerCode
                FROM ACCOUNT a
                JOIN ACCOUNT_TYPE at ON a.AccountTypeID = at.AccountTypeID
                JOIN CUSTOMER c ON a.CustomerID = c.CustomerID
                WHERE a.AccountOpenDate BETWEEN @FromDate AND @ToDate";

                if (!string.IsNullOrEmpty(accountTypeFilter) && accountTypeFilter != "Không áp dụng")
                {
                    query += " AND at.AccountTypeName = @AccountType";
                }

                if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "Không áp dụng")
                {
                    query += " AND a.AccountStatus = @Status";
                }

                query += " ORDER BY a.AccountOpenDate DESC";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FromDate", fromDate);
                    command.Parameters.AddWithValue("@ToDate", toDate);
                    if (!string.IsNullOrEmpty(accountTypeFilter) && accountTypeFilter != "Không áp dụng")
                    {
                        command.Parameters.AddWithValue("@AccountType", accountTypeFilter);
                    }
                    if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "Không áp dụng")
                    {
                        command.Parameters.AddWithValue("@Status", statusFilter);
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        accounts.Clear();
                        currentAccounts.Clear();
                        while (reader.Read())
                        {
                            var account = new AccountModel
                            {
                                AccountID = reader.GetInt32(0),
                                AccountCode = reader.GetString(1),
                                AccountName = reader.GetString(2),
                                Balance = reader.GetDecimal(3),
                                AccountOpenDate = reader.GetDateTime(4),
                                Username = reader.GetString(5),
                                UserPassword = reader.GetString(6),
                                PINCode = reader.GetString(7),
                                AccountStatus = reader.GetString(8),
                                CustomerID = reader.GetInt32(9),
                                AccountTypeID = reader.GetInt32(10)
                            };
                            accounts.Add(account);

                            currentAccounts.Add(new AccountDisplayModel
                            {
                                CustomerCode = reader.GetString(12), // Cột CustomerCode
                                AccountName = account.AccountName,
                                AccountCode = account.AccountCode,
                                AccountTypeName = reader.GetString(11), // Cột AccountTypeName
                                Balance = account.Balance.ToString("N0"),
                                AccountOpenDate = account.AccountOpenDate.ToString("dd/MM/yyyy HH:mm:ss"),
                                AccountStatus = account.AccountStatus
                            });
                        }
                        view.LoadAccounts(currentAccounts);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            view.ShowMessage($"Lỗi khi tải danh sách tài khoản: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public void OnCustomerIDChanged()
    {
        string customerIDText = view.GetCustomerID();
        customerIDText = customerIDText.Replace("KH", "");
        if (string.IsNullOrWhiteSpace(customerIDText) || !int.TryParse(customerIDText, out int customerID))
        {
            view.ShowMessage("Mã khách hàng không hợp lệ (ví dụ: KH1, KH2)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            view.SetCustomerID("");
            return;
        }

        try
        {
            using (var connection = dbContext.GetConnection())
            {
                connection.Open();

                // Kiểm tra xem khách hàng có tồn tại không
                string checkQuery = "SELECT COUNT(*) FROM CUSTOMER WHERE CustomerID = @CustomerID";
                using (var checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@CustomerID", customerID);
                    int count = (int)checkCommand.ExecuteScalar();
                    if (count == 0)
                    {
                        view.ShowMessage("Khách hàng không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        view.SetCustomerID("");
                        return;
                    }
                }

                // Lấy thông tin khách hàng
                string query = @"
                    SELECT c.*, ct.CustomerTypeName
                    FROM CUSTOMER c
                    JOIN CUSTOMER_TYPE ct ON c.CustomerTypeID = ct.CustomerTypeID
                    WHERE c.CustomerID = @CustomerID";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerID", customerID);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            selectedCustomer = new CustomerModel
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
                                CustomerTypeID = reader.GetInt32(11)
                            };

                            // Cập nhật thông tin lên giao diện
                            string accountName = selectedCustomer.FullName.ToUpper();
                            string customerTypeName = reader.GetString(12);
                            string accountType = customerTypeName.Contains("Cá nhân") ? "Cá nhân" : "Doanh nghiệp";

                            view.SetAccountName(accountName);
                            view.SetAccountTypeName(accountType);
                            view.SetBalance(0);
                            view.SetAccountOpenDate(DateTime.Now);
                            view.SetAccountStatus("Hoạt động");

                            // Kích hoạt các trường để hiển thị thông tin
                            view.EnableControls(true, false);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            view.ShowMessage($"Lỗi khi tải thông tin khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            view.SetCustomerID("");
        }
    }

    public void OnAddAccountRequested()
    {
        isAdding = true;
        isEditing = false;
        selectedAccount = null;

        view.EnableControls(true, true); // Chỉ cho phép nhập CustomerID
        view.ClearInputs();
        view.SetControlState(false, false, true, true);
    }

    public void OnEditAccountRequested()
    {
        // Kiểm tra xem có hàng nào được chọn trong DataGridView không
        if (view.GetSelectedRowCount() == 0)
        {
            view.ShowMessage("Vui lòng chọn một tài khoản để chỉnh sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Đặt trạng thái chỉnh sửa
        isAdding = false;
        isEditing = true;

        // Lấy hàng được chọn từ DataGridView
        var selectedRow = view.GetSelectedRow();
        string accountIDText = selectedRow.Cells[2].Value.ToString(); // Cột AccountCode
        accountIDText = accountIDText.Replace("TK", ""); // Loại bỏ tiền tố "TK"

        // Kiểm tra và phân tích cú pháp AccountID
        if (!int.TryParse(accountIDText, out int accountID))
        {
            view.ShowMessage("Mã tài khoản không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            // Kiểm tra DatabaseContext
            if (dbContext == null)
            {
                view.ShowMessage("DatabaseContext không được khởi tạo!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var connection = dbContext.GetConnection())
            {
                connection.Open();

                // Truy vấn thông tin tài khoản
                string accountQuery = @"
                SELECT a.*, at.AccountTypeName 
                FROM ACCOUNT a 
                JOIN ACCOUNT_TYPE at ON a.AccountTypeID = at.AccountTypeID 
                WHERE a.AccountID = @AccountID";

                using (var command = new SqlCommand(accountQuery, connection))
                {
                    command.Parameters.AddWithValue("@AccountID", accountID);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            selectedAccount = new AccountModel
                            {
                                AccountID = reader.GetInt32(0),
                                AccountCode = reader.GetString(1),
                                AccountName = reader.GetString(2),
                                Balance = reader.GetDecimal(3),
                                AccountOpenDate = reader.GetDateTime(4),
                                Username = reader.GetString(5),
                                UserPassword = reader.GetString(6),
                                PINCode = reader.GetString(7),
                                AccountStatus = reader.GetString(8),
                                CustomerID = reader.GetInt32(9),
                                AccountTypeID = reader.GetInt32(10)
                            };
                        }
                        else
                        {
                            view.ShowMessage("Không tìm thấy tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                // Truy vấn thông tin khách hàng
                string customerQuery = @"
                SELECT c.*, ct.CustomerTypeName 
                FROM CUSTOMER c 
                JOIN CUSTOMER_TYPE ct ON c.CustomerTypeID = ct.CustomerTypeID 
                WHERE c.CustomerID = @CustomerID";

                using (var customerCommand = new SqlCommand(customerQuery, connection))
                {
                    customerCommand.Parameters.AddWithValue("@CustomerID", selectedAccount.CustomerID);
                    using (var customerReader = customerCommand.ExecuteReader())
                    {
                        if (customerReader.Read())
                        {
                            selectedCustomer = new CustomerModel
                            {
                                CustomerID = customerReader.GetInt32(0),
                                CustomerCode = customerReader.GetString(1),
                                FullName = customerReader.GetString(2),
                                Gender = customerReader.GetString(3),
                                DateOfBirth = customerReader.GetDateTime(4),
                                Nationality = customerReader.GetString(5),
                                CitizenID = customerReader.GetString(6),
                                CustomerAddress = customerReader.GetString(7),
                                Phone = customerReader.GetString(8),
                                Email = customerReader.GetString(9),
                                RegistrationDate = customerReader.GetDateTime(10),
                                CustomerTypeID = customerReader.GetInt32(11)
                            };
                        }
                        else
                        {
                            view.ShowMessage("Không tìm thấy thông tin khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                // Cập nhật giao diện với dữ liệu tài khoản
                view.SetCustomerID(selectedCustomer.CustomerCode); // Hiển thị mã khách hàng (KHxxx)
                view.SetAccountID(selectedAccount.AccountCode); // Hiển thị mã tài khoản (TKxxx)
                view.SetAccountName(selectedAccount.AccountName);
                view.SetAccountTypeName(selectedAccount.AccountTypeID == 1 ? "Cá nhân" : "Doanh nghiệp");
                view.SetBalance(selectedAccount.Balance);
                view.SetAccountOpenDate(selectedAccount.AccountOpenDate);
                view.SetAccountStatus(selectedAccount.AccountStatus);

                // Bật chỉ combobox trạng thái để chỉnh sửa
                view.EnableControls(true, false, true); // editMode = true để chỉ bật comboBoxAccountStatus
                view.SetControlState(false, false, true, true); // Cập nhật trạng thái nút
            }
        }
        catch (Exception ex)
        {
            view.ShowMessage($"Lỗi khi tải thông tin tài khoản: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            isEditing = false;
            view.EnableControls(false);
            view.SetControlState(true, false, false, false);
        }
    }

    public void OnCancelAccountRequested()
    {
        isAdding = false;
        isEditing = false;
        selectedAccount = null;
        view.EnableControls(false);
        view.ClearInputs();
        view.SetControlState(true, false, false, false);
    }

    public void OnSaveAccountRequested()
    {
        if (isAdding)
        {
            // Giữ nguyên logic cho chế độ thêm
            string customerIDText = view.GetCustomerID();
            Console.WriteLine($"CustomerIDText: {customerIDText}");
            customerIDText = customerIDText.Replace("KH", "");
            if (string.IsNullOrWhiteSpace(customerIDText) || !int.TryParse(customerIDText, out int customerID))
            {
                Console.WriteLine("Invalid CustomerID format");
                view.ShowMessage("Vui lòng nhập mã khách hàng hợp lệ (ví dụ: KH1, KH2)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (dbContext == null)
                {
                    Console.WriteLine("DatabaseContext is null");
                    view.ShowMessage("DatabaseContext không được khởi tạo!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();

                    // Kiểm tra xem khách hàng có tồn tại không
                    string checkCustomerQuery = "SELECT COUNT(*) FROM CUSTOMER WHERE CustomerID = @CustomerID";
                    using (var checkCommand = new SqlCommand(checkCustomerQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@CustomerID", customerID);
                        int count = (int)checkCommand.ExecuteScalar();
                        Console.WriteLine($"CustomerID {customerID} exists: {count}");
                        if (count == 0)
                        {
                            view.ShowMessage("Khách hàng không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Kiểm tra xem khách hàng đã có tài khoản hay chưa
                    string checkAccountQuery = "SELECT COUNT(*) FROM ACCOUNT WHERE CustomerID = @CustomerID";
                    using (var checkAccountCommand = new SqlCommand(checkAccountQuery, connection))
                    {
                        checkAccountCommand.Parameters.AddWithValue("@CustomerID", customerID);
                        int accountCount = (int)checkAccountCommand.ExecuteScalar();
                        if (accountCount > 0)
                        {
                            view.ShowMessage("Khách hàng này đã có tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Lấy thông tin khách hàng
                    string query = @"
                    SELECT c.*, ct.CustomerTypeName
                    FROM CUSTOMER c
                    JOIN CUSTOMER_TYPE ct ON c.CustomerTypeID = ct.CustomerTypeID
                    WHERE c.CustomerID = @CustomerID";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", customerID);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                selectedCustomer = new CustomerModel
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
                                    CustomerTypeID = reader.GetInt32(11)
                                };

                                // Định dạng lại AccountName: in hoa và bỏ dấu tiếng Việt
                                string accountName = RemoveVietnameseDiacritics(selectedCustomer.FullName).ToUpper();
                                view.SetAccountName(accountName);

                                string customerTypeName = reader.GetString(12);
                                string accountType = customerTypeName.Contains("Cá nhân") ? "Cá nhân" : "Doanh nghiệp";
                                view.SetAccountTypeName(accountType);

                                view.SetBalance(0);
                                view.SetAccountOpenDate(DateTime.Now);
                                view.SetAccountStatus("Hoạt động");
                            }
                        }
                    }

                    var result = view.ShowConfirmation($"Bạn có chắc chắn muốn mở tài khoản cho khách hàng {view.GetAccountName()}?", "Xác nhận");
                    Console.WriteLine($"Confirmation result: {result}");
                    if (result == DialogResult.No)
                    {
                        return;
                    }

                    string password = GenerateRandomPassword();
                    string pinCode = GenerateRandomPIN();

                    var account = new AccountModel
                    {
                        AccountName = view.GetAccountName(),
                        Balance = 0,
                        AccountOpenDate = view.GetAccountOpenDate(),
                        Username = selectedCustomer.Phone,
                        UserPassword = password,
                        PINCode = pinCode,
                        AccountStatus = "Hoạt động",
                        CustomerID = customerID,
                        AccountTypeID = view.GetAccountTypeName() == "Cá nhân" ? 1 : 2
                    };

                    AddAccount(account);

                    SendCredentialsByEmail(selectedCustomer.Email, password, pinCode);

                    isAdding = false;
                    view.EnableControls(false);
                    view.ClearInputs();
                    view.SetControlState(true, false, false, false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in OnSaveAccountRequested: {ex.Message}\nStackTrace: {ex.StackTrace}");
                view.ShowMessage($"Lỗi khi mở tài khoản: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        else if (isEditing)
        {
            if (selectedAccount == null)
            {
                view.ShowMessage("Không có tài khoản nào được chọn để chỉnh sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Chỉ cập nhật trạng thái tài khoản
            selectedAccount.AccountStatus = view.GetAccountStatus();

            UpdateAccount(selectedAccount);

            isEditing = false;
            view.EnableControls(false);
            view.ClearInputs();
            view.SetControlState(true, false, false, false);
        }
    }

    private string RemoveVietnameseDiacritics(string text)
    {
        if (string.IsNullOrEmpty(text))
            return text;

        // Bảng ánh xạ các ký tự có dấu sang không dấu
        string[][] vietnameseSigns = new string[][]
        {
            new string[] {"á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ"},
            new string[] {"đ"},
            new string[] {"é", "è", "ẻ", "ẽ", "ẹ", "ê", "ế", "ề", "ể", "ễ", "ệ"},
            new string[] {"í", "ì", "ỉ", "ĩ", "ị"},
            new string[] {"ó", "ò", "ỏ", "õ", "ọ", "ô", "ố", "ồ", "ổ", "ỗ", "ộ", "ơ", "ớ", "ờ", "ở", "ỡ", "ợ"},
            new string[] {"ú", "ù", "ủ", "ũ", "ụ", "ư", "ứ", "ừ", "ử", "ữ", "ự"},
            new string[] {"ý", "ỳ", "ỷ", "ỹ", "ỵ"}
        };

        // Thay thế các ký tự có dấu bằng không dấu
        for (int i = 0; i < vietnameseSigns.Length; i++)
        {
            string replacement = i switch
            {
                0 => "a",
                1 => "d",
                2 => "e",
                3 => "i",
                4 => "o",
                5 => "u",
                6 => "y",
                _ => ""
            };

            foreach (string sign in vietnameseSigns[i])
            {
                text = text.Replace(sign, replacement);
                text = text.Replace(sign.ToUpper(), replacement.ToUpper());
            }
        }

        return text;
    }

    private void AddAccount(AccountModel account)
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
                string insertQuery = @"
                    INSERT INTO ACCOUNT (AccountName, Balance, AccountOpenDate, Username, UserPassword, PINCode, AccountStatus, CustomerID, AccountTypeID)
                    VALUES (@AccountName, @Balance, @AccountOpenDate, @Username, @UserPassword, @PINCode, @AccountStatus, @CustomerID, @AccountTypeID);
                    SELECT SCOPE_IDENTITY();"; // Lấy AccountID vừa thêm

                using (var command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@AccountName", account.AccountName);
                    command.Parameters.AddWithValue("@Balance", account.Balance);
                    command.Parameters.AddWithValue("@AccountOpenDate", account.AccountOpenDate);
                    command.Parameters.AddWithValue("@Username", account.Username);
                    command.Parameters.AddWithValue("@UserPassword", account.UserPassword);
                    command.Parameters.AddWithValue("@PINCode", account.PINCode);
                    command.Parameters.AddWithValue("@AccountStatus", account.AccountStatus);
                    command.Parameters.AddWithValue("@CustomerID", account.CustomerID);
                    command.Parameters.AddWithValue("@AccountTypeID", account.AccountTypeID);

                    // Lấy AccountID vừa thêm
                    account.AccountID = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            view.ShowMessage("Đã mở tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadAccounts(view.GetFromDate(), view.GetToDate(), view.GetAccountTypeFilter(), view.GetStatusFilter());
        }
        catch (Exception ex)
        {
            view.ShowMessage($"Lỗi khi mở tài khoản: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void UpdateAccount(AccountModel account)
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
                string updateQuery = @"
                UPDATE ACCOUNT
                SET AccountStatus = @AccountStatus
                WHERE AccountID = @AccountID";

                using (var command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@AccountStatus", account.AccountStatus);
                    command.Parameters.AddWithValue("@AccountID", account.AccountID);
                    command.ExecuteNonQuery();
                }
            }
            view.ShowMessage("Đã cập nhật trạng thái tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadAccounts(view.GetFromDate(), view.GetToDate(), view.GetAccountTypeFilter(), view.GetStatusFilter());
        }
        catch (Exception ex)
        {
            view.ShowMessage($"Lỗi khi cập nhật trạng thái tài khoản: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private string GenerateRandomPassword()
    {
        Random random = new Random();
        const string letters = "abcdefghijklmnopqrstuvwxyz";
        const string numbers = "0123456789";
        StringBuilder password = new StringBuilder();

        for (int i = 0; i < 3; i++)
        {
            password.Append(letters[random.Next(letters.Length)]);
        }

        for (int i = 0; i < 3; i++)
        {
            password.Append(numbers[random.Next(numbers.Length)]);
        }

        return password.ToString();
    }

    private string GenerateRandomPIN()
    {
        Random random = new Random();
        return random.Next(100000, 999999).ToString();
    }

    private void SendCredentialsByEmail(string email, string password, string pinCode)
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
                                                <h1 style='color: #1a73e8;'>Thông Tin Tài Khoản</h1>
                                                <h2 style='color: #1a73e8; margin: 5px 0 20px 0;'>Sacombank</h2>
                                                <p>Xin chào,</p>
                                                <p>Tài khoản của bạn đã được mở thành công. Dưới đây là thông tin đăng nhập:</p>
                                                <p><strong>Mật khẩu:</strong> " + password + @"</p>
                                                <p><strong>Mã PIN:</strong> " + pinCode + @"</p>
                                                <p>Vui lòng cập nhật lại và không chia sẻ thông tin này với bất kỳ ai.</p>
                                                <p>Nếu bạn không yêu cầu mở tài khoản này, vui lòng liên hệ với chúng tôi qua email: <a href='mailto:support@sacombank.com'>support@sacombank.com</a>.</p>
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

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(senderEmail, senderName),
                    Subject = "Thông Tin Tài Khoản - Sacombank",
                    Body = htmlBody,
                    IsBodyHtml = true
                };
                mailMessage.To.Add(email);

                smtpClient.Send(mailMessage);
                view.ShowMessage($"Thông tin tài khoản đã được gửi đến email {email}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            view.ShowMessage($"Lỗi khi gửi email: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public void OnResetPasswordRequested()
    {
        if (view.GetSelectedRowCount() == 0)
        {
            view.ShowMessage("Vui lòng chọn một tài khoản để đặt lại mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var result = view.ShowConfirmation("Bạn có chắc chắn muốn đặt lại mật khẩu cho tài khoản này?", "Xác nhận");
        if (result == DialogResult.No)
        {
            return;
        }

        ShowOTPForm(true);
    }

    public void OnResetPINCodeRequested()
    {
        if (view.GetSelectedRowCount() == 0)
        {
            view.ShowMessage("Vui lòng chọn một tài khoản để đặt lại mã PIN!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var result = view.ShowConfirmation("Bạn có chắc chắn muốn đặt lại mã PIN cho tài khoản này?", "Xác nhận");
        if (result == DialogResult.No)
        {
            return;
        }

        ShowOTPForm(false);
    }

    private void ShowOTPForm(bool isResetPassword)
    {
        using (var form = new FormOTP())
        {
            var otpController = new OTPController(form, form, this, configuration);
            if (form.ShowDialog() == DialogResult.OK)
            {
                string newCredential = isResetPassword ? GenerateRandomPassword() : GenerateRandomPIN();
                string columnToUpdate = isResetPassword ? "UserPassword" : "PINCode";
                string credentialType = isResetPassword ? "mật khẩu" : "mã PIN";

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
                        string updateQuery = $"UPDATE ACCOUNT SET {columnToUpdate} = @NewCredential WHERE AccountID = @AccountID";
                        using (var command = new SqlCommand(updateQuery, connection))
                        {
                            command.Parameters.AddWithValue("@NewCredential", newCredential);
                            command.Parameters.AddWithValue("@AccountID", selectedAccount.AccountID);
                            command.ExecuteNonQuery();
                        }
                    }

                    SendNewCredentialByEmail(selectedCustomer.Email, newCredential, credentialType);

                    view.ShowMessage($"Đã đặt lại {credentialType} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAccounts(view.GetFromDate(), view.GetToDate(), view.GetAccountTypeFilter(), view.GetStatusFilter());
                }
                catch (Exception ex)
                {
                    view.ShowMessage($"Lỗi khi đặt lại {credentialType}: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    private void SendNewCredentialByEmail(string email, string credential, string credentialType)
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
                                                <h1 style='color: #1a73e8;'>Đặt Lại " + credentialType.ToUpper() + @"</h1>
                                                <h2 style='color: #1a73e8; margin: 5px 0 20px 0;'>Sacombank</h2>
                                                <p>Xin chào,</p>
                                                <p>" + credentialType + @" của bạn đã được đặt lại. Dưới đây là " + credentialType + @" mới:</p>
                                                <p><strong>" + credentialType + @":</strong> " + credential + @"</p>
                                                <p>Vui lòng cập nhật lại và không chia sẻ thông tin này với bất kỳ ai.</p>
                                                <p>Nếu bạn không yêu cầu đặt lại " + credentialType + @", vui lòng liên hệ với chúng tôi qua email: <a href='mailto:support@sacombank.com'>support@sacombank.com</a>.</p>
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

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(senderEmail, senderName),
                    Subject = $"Đặt Lại {credentialType} - Sacombank",
                    Body = htmlBody,
                    IsBodyHtml = true
                };
                mailMessage.To.Add(email);

                smtpClient.Send(mailMessage);
                view.ShowMessage($"{credentialType} mới đã được gửi đến email {email}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            view.ShowMessage($"Lỗi khi gửi email: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public void OnAccountSelected(AccountModel account)
    {
        if (!isAdding && !isEditing)
        {
            selectedAccount = account;
            view.EnableControls(false);
            view.SetControlState(false, true, true, false);
        }
    }

    public void OnAccountDeselected()
    {
        if (!isAdding && !isEditing)
        {
            selectedAccount = null;
            view.EnableControls(false);
            view.EnableResetButtons(false);
            view.SetControlState(true, false, false, false);
        }
    }

    public void OnSearchAccountRequested()
    {
        string searchText = view.GetSearchText();
        if (string.IsNullOrWhiteSpace(searchText))
        {
            LoadAccounts(view.GetFromDate(), view.GetToDate(), view.GetAccountTypeFilter(), view.GetStatusFilter());
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
                SELECT a.*, at.AccountTypeName, c.CustomerCode
                FROM ACCOUNT a
                JOIN ACCOUNT_TYPE at ON a.AccountTypeID = at.AccountTypeID
                JOIN CUSTOMER c ON a.CustomerID = c.CustomerID
                WHERE (
                    c.CustomerCode LIKE '%' + @SearchText + '%' OR
                    a.AccountName LIKE '%' + @SearchText + '%' OR
                    a.AccountCode LIKE '%' + @SearchText + '%' OR
                    at.AccountTypeName LIKE '%' + @SearchText + '%' OR
                    CONVERT(VARCHAR, a.AccountOpenDate, 103) LIKE '%' + @SearchText + '%' OR
                    a.AccountStatus LIKE '%' + @SearchText + '%'
                )
                AND a.AccountOpenDate BETWEEN @FromDate AND @ToDate";

                string accountTypeFilter = view.GetAccountTypeFilter();
                string statusFilter = view.GetStatusFilter();

                if (accountTypeFilter != "Không áp dụng")
                {
                    query += " AND at.AccountTypeName = @AccountType";
                }

                if (statusFilter != "Không áp dụng")
                {
                    query += " AND a.AccountStatus = @Status";
                }

                query += " ORDER BY a.AccountOpenDate DESC";

                using (var command = new SqlCommand(query, connection))
                {
                    // Loại bỏ tiền tố "KH" và "TK" trước khi tìm kiếm
                    string cleanedSearchText = searchText.Replace("KH", "").Replace("TK", "");
                    command.Parameters.AddWithValue("@SearchText", cleanedSearchText);
                    command.Parameters.AddWithValue("@FromDate", view.GetFromDate());
                    command.Parameters.AddWithValue("@ToDate", view.GetToDate());
                    if (accountTypeFilter != "Không áp dụng")
                    {
                        command.Parameters.AddWithValue("@AccountType", accountTypeFilter);
                    }
                    if (statusFilter != "Không áp dụng")
                    {
                        command.Parameters.AddWithValue("@Status", statusFilter);
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        accounts.Clear();
                        currentAccounts.Clear();
                        while (reader.Read())
                        {
                            var account = new AccountModel
                            {
                                AccountID = reader.GetInt32(0),
                                AccountCode = reader.GetString(1),
                                AccountName = reader.GetString(2),
                                Balance = reader.GetDecimal(3),
                                AccountOpenDate = reader.GetDateTime(4),
                                Username = reader.GetString(5),
                                UserPassword = reader.GetString(6),
                                PINCode = reader.GetString(7),
                                AccountStatus = reader.GetString(8),
                                CustomerID = reader.GetInt32(9),
                                AccountTypeID = reader.GetInt32(10)
                            };
                            accounts.Add(account);

                            currentAccounts.Add(new AccountDisplayModel
                            {
                                CustomerCode = reader.GetString(12), // Cột CustomerCode
                                AccountName = account.AccountName,
                                AccountCode = account.AccountCode,
                                AccountTypeName = reader.GetString(11), // Cột AccountTypeName
                                Balance = account.Balance.ToString("N0"),
                                AccountOpenDate = account.AccountOpenDate.ToString("dd/MM/yyyy HH:mm:ss"),
                                AccountStatus = account.AccountStatus
                            });
                        }
                        view.LoadAccounts(currentAccounts);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            view.ShowMessage($"Lỗi khi tìm kiếm tài khoản: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public void OnExportPDFRequested()
    {
        try
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                FileName = "AccountList.pdf"
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

                document.Add(new Paragraph("DANH SÁCH TÀI KHOẢN", subHeaderFont)
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
                PdfPTable pdfTable = new PdfPTable(7); // 7 cột (dựa trên AccountDisplayModel)
                pdfTable.WidthPercentage = 100;
                pdfTable.SetWidths(new float[] { 1f, 1.5f, 1f, 1f, 1f, 1f, 1f });

                // Thêm tiêu đề cột với màu nền
                string[] headers = { "Mã khách hàng", "Tên tài khoản", "Mã tài khoản", "Loại tài khoản", "Số dư", "Ngày mở", "Trạng thái" };
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

                // Thêm dữ liệu từ danh sách currentAccounts
                foreach (var account in currentAccounts)
                {
                    pdfTable.AddCell(new Phrase(account.CustomerCode, vietnameseFont));
                    pdfTable.AddCell(new Phrase(account.AccountName, vietnameseFont));
                    pdfTable.AddCell(new Phrase(account.AccountCode, vietnameseFont));
                    pdfTable.AddCell(new Phrase(account.AccountTypeName, vietnameseFont));
                    pdfTable.AddCell(new Phrase(account.Balance, vietnameseFont));
                    pdfTable.AddCell(new Phrase(account.AccountOpenDate, vietnameseFont));
                    pdfTable.AddCell(new Phrase(account.AccountStatus, vietnameseFont));
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

    public void OnExportExcelRequested()
    {
        Excel.Application excelApp = null;
        Excel.Workbook workbook = null;
        Excel.Worksheet worksheet = null;

        try
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel files (*.xlsx)|*.xlsx",
                FileName = "AccountList.xlsx"
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
                worksheet.Name = "AccountList";

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

                // Tiêu đề "DANH SÁCH TÀI KHOẢN" (hàng 3)
                Excel.Range subHeaderRange = worksheet.Range[worksheet.Cells[3, 1], worksheet.Cells[3, 2]];
                subHeaderRange.Merge();
                subHeaderRange.Value = "DANH SÁCH TÀI KHOẢN";
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
                string[] headers = { "Mã khách hàng", "Tên tài khoản", "Mã tài khoản", "Loại tài khoản", "Số dư", "Ngày mở", "Trạng thái" };
                for (int i = 0; i < headers.Length; i++)
                {
                    Excel.Range headerCell = worksheet.Cells[6, i + 1];
                    headerCell.Value = headers[i];
                    headerCell.Font.Bold = true; // In đậm chữ
                    headerCell.Interior.Color = System.Drawing.Color.FromArgb(252, 186, 3).ToArgb(); // Tô màu nền
                    headerCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous; // Thêm border
                    headerCell.Borders.Weight = Excel.XlBorderWeight.xlThin;
                }

                // Thêm dữ liệu từ danh sách currentAccounts (bắt đầu từ hàng 7)
                for (int i = 0; i < currentAccounts.Count; i++)
                {
                    var account = currentAccounts[i];
                    Excel.Range rowRange = worksheet.Range[worksheet.Cells[i + 7, 1], worksheet.Cells[i + 7, 7]];
                    worksheet.Cells[i + 7, 1] = account.CustomerCode;
                    worksheet.Cells[i + 7, 2] = account.AccountName;
                    worksheet.Cells[i + 7, 3] = account.AccountCode;
                    worksheet.Cells[i + 7, 4] = account.AccountTypeName;
                    worksheet.Cells[i + 7, 5] = account.Balance;
                    worksheet.Cells[i + 7, 6] = account.AccountOpenDate;
                    worksheet.Cells[i + 7, 7] = account.AccountStatus;

                    // Thêm border cho các ô dữ liệu
                    rowRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    rowRange.Borders.Weight = Excel.XlBorderWeight.xlThin;
                }

                // Footer (thêm vào sau dữ liệu)
                int lastRow = currentAccounts.Count + 8; // +8 để cách 1 dòng sau dữ liệu
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
                for (int i = 1; i <= 7; i++)
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

    public void OnExportCSVRequested()
    {
        try
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                FileName = "AccountList.csv"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StringBuilder csvContent = new StringBuilder();

                // Tiêu đề cột
                string[] headers = { "Mã khách hàng", "Tên tài khoản", "Mã tài khoản", "Loại tài khoản", "Số dư", "Ngày mở", "Trạng thái" };
                csvContent.AppendLine(string.Join(",", headers.Select(h => $"\"{h}\"")));

                // Thêm dữ liệu từ danh sách currentAccounts
                foreach (var account in currentAccounts)
                {
                    string[] rowData = new string[]
                    {
                    (account.CustomerCode)?.Replace("\"", "\"\"") ?? "",
                    account.AccountName?.Replace("\"", "\"\"") ?? "",
                    (account.AccountCode)?.Replace("\"", "\"\"") ?? "",
                    account.AccountTypeName?.Replace("\"", "\"\"") ?? "",
                    account.Balance?.Replace("\"", "\"\"") ?? "",
                    account.AccountOpenDate?.Replace("\"", "\"\"") ?? "",
                    account.AccountStatus?.Replace("\"", "\"\"") ?? ""
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