using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Views.Common;
using QuanLyThongTinKhachHangSacomBank.Views.Common.CustomerLogin;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    public class CustomerRegisterController : IOTPController
    {
        private readonly FormCustomerRegister form;
        private ICustomerInfoRegisterView customerInfoRegisterView;
        private IAccountInfoRegisterView accountInfoRegisterView;
        private readonly IConfiguration configuration;
        private readonly DatabaseContext dbContext;
        private CustomerModel customer;
        private string customerTypeSelection;
        private bool isPasswordVisible = false;
        private bool isConfirmPasswordVisible = false;
        private Image eyeOpenImage;
        private Image eyeClosedImage;

        public CustomerRegisterController(FormCustomerRegister form, ICustomerInfoRegisterView initialView, IConfiguration configuration, DatabaseContext dbContext)
        {
            this.form = form;
            this.customerInfoRegisterView = initialView;
            this.configuration = configuration;
            this.dbContext = dbContext;

            

            this.customerInfoRegisterView.ConfirmRequested += CustomerInfoRegisterView_ConfirmRequested;
            this.customerInfoRegisterView.ReturnRequested += CustomerInfoRegisterView_ReturnRequested;
            LoadCustomerInfoRegister();
        }

        private void LoadCustomerInfoRegister()
        {
            form.LoadUserControl((UserControl)customerInfoRegisterView);
        }

        private void LoadAccountInfoRegister()
        {
            accountInfoRegisterView = new UC_AccountInfoRegister();

            eyeOpenImage = Properties.Resources.ShowPassword;
            eyeClosedImage = Properties.Resources.HidePassword;
            accountInfoRegisterView.SetShowPasswordButtonImage(eyeClosedImage);
            accountInfoRegisterView.SetShowConfirmPasswordButtonImage(eyeClosedImage);

            accountInfoRegisterView.ConfirmRequested += AccountInfoRegisterView_ConfirmRequested;
            this.accountInfoRegisterView.ShowPasswordRegisterRequested += View_ShowPasswordRegisterRequested;
            this.accountInfoRegisterView.ShowConfirmPasswordRegisterRequested += View_ShowConfirmPasswordRegisterRequested;
            form.LoadUserControl((UserControl)accountInfoRegisterView);

            ((UC_AccountInfoRegister)accountInfoRegisterView).SetUsername(customer.Phone);

            // Gán sự kiện FormClosing để ngăn đóng form trước khi hoàn tất đăng ký
            FormClosingEventHandler formClosingHandler = (sender, e) =>
            {
                e.Cancel = true;
                MessageBox.Show("Vui lòng hoàn tất đăng ký tài khoản trước khi thoát!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            };
            form.FormClosing += formClosingHandler;

            // Lưu handler để có thể gỡ sau này
            form.Tag = formClosingHandler;
        }

        private void CustomerInfoRegisterView_ConfirmRequested(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(customerInfoRegisterView.FullName) ||
                string.IsNullOrWhiteSpace(customerInfoRegisterView.CitizenID) ||
                string.IsNullOrWhiteSpace(customerInfoRegisterView.Gender) ||
                customerInfoRegisterView.DateOfBirth == null ||
                string.IsNullOrWhiteSpace(customerInfoRegisterView.Nationality) ||
                string.IsNullOrWhiteSpace(customerInfoRegisterView.Address) ||
                string.IsNullOrWhiteSpace(customerInfoRegisterView.Phone) ||
                string.IsNullOrWhiteSpace(customerInfoRegisterView.Email) ||
                string.IsNullOrWhiteSpace(customerInfoRegisterView.CustomerType))
            {
                customerInfoRegisterView.ShowError("Yêu cầu nhập đầy đủ thông tin!");
                return;
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(customerInfoRegisterView.Email, emailPattern))
            {
                customerInfoRegisterView.ShowError("Email không đúng định dạng!");
                return;
            }

            string phonePattern = @"^0\d{9}$";
            if (!Regex.IsMatch(customerInfoRegisterView.Phone, phonePattern))
            {
                customerInfoRegisterView.ShowError("Số điện thoại không đúng định dạng (10 số, bắt đầu bằng 0)!");
                return;
            }

            using (var connection = dbContext.GetConnection())
            {
                try
                {
                    connection.Open();

                    string checkPhoneQuery = "SELECT COUNT(*) FROM CUSTOMER WHERE Phone = @Phone";
                    using (SqlCommand command = new SqlCommand(checkPhoneQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Phone", customerInfoRegisterView.Phone);
                        int phoneCount = (int)command.ExecuteScalar();
                        if (phoneCount > 0)
                        {
                            customerInfoRegisterView.ShowError("Số điện thoại đã tồn tại!");
                            return;
                        }
                    }

                    string checkEmailQuery = "SELECT COUNT(*) FROM CUSTOMER WHERE Email = @Email";
                    using (SqlCommand command = new SqlCommand(checkEmailQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Email", customerInfoRegisterView.Email);
                        int emailCount = (int)command.ExecuteScalar();
                        if (emailCount > 0)
                        {
                            customerInfoRegisterView.ShowError("Email đã tồn tại!");
                            return;
                        }
                    }

                    string customerTypeQuery = "SELECT CustomerTypeID FROM CUSTOMER_TYPE WHERE CustomerTypeName = @CustomerTypeName";
                    int customerTypeId;
                    using (SqlCommand command = new SqlCommand(customerTypeQuery, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerTypeName", customerInfoRegisterView.CustomerType);
                        object queryResult = command.ExecuteScalar();
                        if (queryResult == null)
                        {
                            customerInfoRegisterView.ShowError("Loại khách hàng không hợp lệ!");
                            return;
                        }
                        customerTypeId = (int)queryResult;
                    }

                    customerInfoRegisterView.HideError();

                    DialogResult dialogResult = MessageBox.Show(
                        "Bạn đã chắc chắn thông tin vừa nhập là đúng?",
                        "Xác nhận thông tin",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        customerTypeSelection = customerInfoRegisterView.CustomerType;

                        customer = new CustomerModel
                        {
                            FullName = customerInfoRegisterView.FullName,
                            Gender = customerInfoRegisterView.Gender,
                            DateOfBirth = customerInfoRegisterView.DateOfBirth,
                            Nationality = customerInfoRegisterView.Nationality,
                            CitizenID = customerInfoRegisterView.CitizenID,
                            CustomerAddress = customerInfoRegisterView.Address,
                            Phone = customerInfoRegisterView.Phone,
                            Email = customerInfoRegisterView.Email,
                            RegistrationDate = DateTime.Now,
                            CustomerTypeID = customerTypeId
                        };

                        FormOTP formOTP = new FormOTP();
                        var otpController = new OTPController(formOTP, formOTP, this, configuration);
                        if (formOTP.ShowDialog() == DialogResult.OK)
                        {
                            string insertCustomerQuery = @"
                                INSERT INTO CUSTOMER (FullName, Gender, DateOfBirth, Nationality, CitizenID, CustomerAddress, Phone, Email, RegistrationDate, CustomerTypeID)
                                OUTPUT INSERTED.CustomerID
                                VALUES (@FullName, @Gender, @DateOfBirth, @Nationality, @CitizenID, @CustomerAddress, @Phone, @Email, @RegistrationDate, @CustomerTypeID)";

                            using (SqlCommand command = new SqlCommand(insertCustomerQuery, connection))
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

                                customer.CustomerID = (int)command.ExecuteScalar();
                            }

                            LoadAccountInfoRegister();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xử lý dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CustomerInfoRegisterView_ReturnRequested(object sender, EventArgs e)
        {
            form.Close();
        }

        private void AccountInfoRegisterView_ConfirmRequested(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(accountInfoRegisterView.Username) ||
                string.IsNullOrWhiteSpace(accountInfoRegisterView.Password) ||
                string.IsNullOrWhiteSpace(accountInfoRegisterView.ConfirmPassword) ||
                string.IsNullOrWhiteSpace(accountInfoRegisterView.PinCode) ||
                accountInfoRegisterView.PinCode.Length != 6)
            {
                accountInfoRegisterView.ShowError("Yêu cầu nhập đầy đủ thông tin!");
                return;
            }

            if (accountInfoRegisterView.Password.Length < 6)
            {
                accountInfoRegisterView.ShowError("Mật khẩu phải có ít nhất 6 ký tự!");
                return;
            }

            if (accountInfoRegisterView.Password != accountInfoRegisterView.ConfirmPassword)
            {
                accountInfoRegisterView.ShowError("Mật khẩu và xác nhận mật khẩu không khớp!");
                return;
            }

            using (var connection = dbContext.GetConnection())
            {
                try
                {
                    connection.Open();

                    string checkUsernameQuery = "SELECT COUNT(*) FROM ACCOUNT WHERE Username = @Username";
                    using (SqlCommand command = new SqlCommand(checkUsernameQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Username", accountInfoRegisterView.Username);
                        int usernameCount = (int)command.ExecuteScalar();
                        if (usernameCount > 0)
                        {
                            accountInfoRegisterView.ShowError("Tên đăng nhập đã tồn tại!");
                            return;
                        }
                    }

                    string accountTypeQuery = "SELECT AccountTypeID FROM ACCOUNT_TYPE WHERE AccountTypeName = @AccountTypeName";
                    int accountTypeId;
                    using (SqlCommand command = new SqlCommand(accountTypeQuery, connection))
                    {
                        command.Parameters.AddWithValue("@AccountTypeName", customerTypeSelection);
                        object queryResult = command.ExecuteScalar();
                        if (queryResult == null)
                        {
                            MessageBox.Show("Loại tài khoản không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        accountTypeId = (int)queryResult;
                    }

                    string accountName = RemoveDiacritics(customer.FullName).ToUpper();

                    var account = new AccountModel
                    {
                        AccountName = accountName,
                        Balance = 0,
                        AccountOpenDate = DateTime.Now,
                        Username = accountInfoRegisterView.Username,
                        UserPassword = accountInfoRegisterView.Password,
                        PINCode = accountInfoRegisterView.PinCode,
                        AccountStatus = "Hoạt động",
                        CustomerID = customer.CustomerID,
                        AccountTypeID = accountTypeId
                    };

                    string insertAccountQuery = @"
                        INSERT INTO ACCOUNT (AccountName, Balance, AccountOpenDate, Username, UserPassword, PINCode, AccountStatus, CustomerID, AccountTypeID)
                        VALUES (@AccountName, @Balance, @AccountOpenDate, @Username, @UserPassword, @PINCode, @AccountStatus, @CustomerID, @AccountTypeID)";

                    using (SqlCommand command = new SqlCommand(insertAccountQuery, connection))
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

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Tạo tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Gỡ sự kiện FormClosing trước khi đóng form
                    if (form.Tag is FormClosingEventHandler formClosingHandler)
                    {
                        form.FormClosing -= formClosingHandler;
                    }
                    form.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lưu tài khoản: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public string Phone => customer.Phone;
        public string Email => customer.Email;

        // Định dạng AccountName
        private string RemoveDiacritics(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            // Thay thế ký tự "Đ" và "đ" trước khi chuẩn hóa
            text = text.Replace("Đ", "D").Replace("đ", "d");

            string normalizedString = text.Normalize(System.Text.NormalizationForm.FormD);
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();

            foreach (char c in normalizedString)
            {
                System.Globalization.UnicodeCategory unicodeCategory = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(System.Text.NormalizationForm.FormC);
        }

        private void View_ShowPasswordRegisterRequested(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;
            accountInfoRegisterView.ToggleNewPasswordVisibility(isPasswordVisible);
            accountInfoRegisterView.SetShowPasswordButtonImage(isPasswordVisible ? eyeOpenImage : eyeClosedImage);
        }

        private void View_ShowConfirmPasswordRegisterRequested(object sender, EventArgs e)
        {
            isConfirmPasswordVisible = !isConfirmPasswordVisible;
            accountInfoRegisterView.ToggleConfirmNewPasswordVisibility(isConfirmPasswordVisible);
            accountInfoRegisterView.SetShowConfirmPasswordButtonImage(isConfirmPasswordVisible ? eyeOpenImage : eyeClosedImage);
        }
    }
}