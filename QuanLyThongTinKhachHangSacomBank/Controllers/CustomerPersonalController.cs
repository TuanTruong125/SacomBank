using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Views.Common;
using QuanLyThongTinKhachHangSacomBank.Views.Customer;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    public class CustomerPersonalController
    {
        private readonly ICustomerPersonalView view;
        private readonly CustomerModel customer;
        private readonly AccountModel account;
        private readonly DatabaseContext dbContext;
        private readonly IConfiguration configuration;
        private string originalPassword;
        private string originalPIN;
        private bool isEditingPassword = false;
        private bool isEditingPIN = false;

        public CustomerPersonalController(ICustomerPersonalView view, CustomerModel customer, AccountModel account, DatabaseContext dbContext, IConfiguration configuration)
        {
            this.view = view;
            this.customer = customer;
            this.account = account;
            this.dbContext = dbContext;
            this.configuration = configuration;

            // Load dữ liệu khách hàng khi controller được khởi tạo
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            originalPassword = account.UserPassword;
            originalPIN = account.PINCode ?? string.Empty;
            view.LoadCustomerData(customer, account);
            view.SetInitialState();
        }

        public void OnEditButtonClicked()
        {
            var result = MessageBox.Show("Bạn muốn sửa mật khẩu hay mã PIN?\n- Nhấn Yes để sửa mật khẩu\n- Nhấn No để sửa mã PIN\n- Nhấn Cancel để quay lại",
                "Chọn tùy chọn", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes) // Sửa mật khẩu
            {
                isEditingPassword = true;
                isEditingPIN = false;
                view.EnablePasswordEditing(true, true); // Cho phép chỉnh sửa và hiển thị mật khẩu dạng chữ rõ
                view.FocusPasswordTextBox();
            }
            else if (result == DialogResult.No) // Sửa mã PIN
            {
                isEditingPassword = false;
                isEditingPIN = true;
                view.EnablePINEditing(true);
                view.FocusPINTextBox();
            }
            // Nếu chọn "Cancel", không làm gì
        }

        public void OnCancelButtonClicked()
        {
            LoadCustomerData(); // Load lại dữ liệu ban đầu
        }

        public void OnConfirmButtonClicked(string newPassword, string newPIN)
        {
            try
            {
                if (isEditingPassword)
                {
                    // Kiểm tra mật khẩu mới
                    if (newPassword == originalPassword)
                    {
                        MessageBox.Show("Mật khẩu mới không được trùng với mật khẩu cũ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (newPassword.Length < 6)
                    {
                        MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (ContainsVietnameseDiacritics(newPassword))
                    {
                        MessageBox.Show("Mật khẩu không được chứa ký tự tiếng Việt có dấu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else if (isEditingPIN)
                {
                    // Kiểm tra mã PIN mới
                    if (newPIN.Length != 6 || !newPIN.All(char.IsDigit))
                    {
                        MessageBox.Show("Mã PIN phải có đúng 6 chữ số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (newPIN == originalPIN)
                    {
                        MessageBox.Show("Mã PIN mới không được trùng với mã PIN cũ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Hỏi xác nhận cập nhật
                DialogResult result = MessageBox.Show("Bạn có muốn cập nhật thông tin?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Mở form OTP để xác thực
                    using (var formOTP = new FormOTP())
                    {
                        var otpController = new OTPController(formOTP, formOTP, new CustomerPersonalOTPController(customer.Phone, customer.Email), configuration);
                        var dialogResult = formOTP.ShowDialog();

                        if (dialogResult == DialogResult.OK)
                        {
                            // Cập nhật thông tin vào CSDL
                            UpdateAccountInDatabase(newPassword, newPIN);

                            // Cập nhật lại account
                            if (isEditingPassword)
                            {
                                account.UserPassword = newPassword;
                            }
                            if (isEditingPIN)
                            {
                                account.PINCode = newPIN;
                            }

                            // Thông báo thành công
                            MessageBox.Show("Đã cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Đưa về trạng thái ban đầu
                            LoadCustomerData();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu thông tin: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ContainsVietnameseDiacritics(string text)
        {
            return Regex.IsMatch(text, @"[àáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹđ]");
        }

        private void UpdateAccountInDatabase(string newPassword, string newPIN)
        {
            // Kiểm tra dbContext không null
            if (dbContext == null)
            {
                MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var connection = dbContext.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand(
                    "UPDATE ACCOUNT SET UserPassword = @UserPassword, PINCode = @PINCode WHERE AccountID = @AccountID", connection))
                {
                    command.Parameters.AddWithValue("@UserPassword", isEditingPassword ? newPassword : account.UserPassword);
                    command.Parameters.AddWithValue("@PINCode", isEditingPIN ? newPIN : (object)account.PINCode ?? DBNull.Value);
                    command.Parameters.AddWithValue("@AccountID", account.AccountID);
                    command.ExecuteNonQuery();
                }
            }
        }
    }

    public class CustomerPersonalOTPController : IOTPController
    {
        public string Phone { get; }
        public string Email { get; }

        public CustomerPersonalOTPController(string phone, string email)
        {
            Phone = phone;
            Email = email;
        }
    }
}