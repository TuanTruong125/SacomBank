﻿using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Views.Common;
using QuanLyThongTinKhachHangSacomBank.Controllers;
using QuanLyThongTinKhachHangSacomBank.Views.Manager;
using System;
using System.Windows.Forms;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    public class ManagerSettingController
    {
        private readonly IManagerSettingView view;
        private readonly EmployeeModel currentEmployee;
        private readonly DatabaseContext dbContext;
        private readonly IConfiguration configuration;
        private string originalPassword;

        public ManagerSettingController(IManagerSettingView view, EmployeeModel employee, DatabaseContext dbContext, IConfiguration configuration)
        {
            this.view = view;
            this.currentEmployee = employee;
            this.dbContext = dbContext;
            this.configuration = configuration;

            // Load dữ liệu quản lý khi controller được khởi tạo
            LoadManagerData();
        }

        private void LoadManagerData()
        {
            originalPassword = currentEmployee.EmployeePassword;
            view.LoadManagerData(currentEmployee);
            view.SetInitialState();
        }

        public void OnEditButtonClicked()
        {
            view.EnablePasswordEditing(true, true); // Cho phép chỉnh sửa và hiển thị mật khẩu dạng chữ rõ
            view.FocusPasswordTextBox();
        }

        public void OnCancelButtonClicked()
        {
            LoadManagerData(); // Load lại dữ liệu ban đầu
        }

        public void OnConfirmButtonClicked(string newPassword)
        {
            try
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

                if (HasVietnameseCharacters(newPassword))
                {
                    MessageBox.Show("Mật khẩu không được chứa ký tự tiếng Việt có dấu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hỏi xác nhận cập nhật
                DialogResult result = MessageBox.Show("Bạn có muốn cập nhật thông tin?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Mở form OTP để xác thực
                    using (var formOTP = new FormOTP())
                    {
                        var otpController = new OTPController(formOTP, formOTP, new ManagerSettingOTPController(currentEmployee.EmployeePhone, currentEmployee.EmployeeEmail), configuration);
                        var dialogResult = formOTP.ShowDialog();

                        if (dialogResult == DialogResult.OK)
                        {
                            // Cập nhật mật khẩu vào CSDL
                            UpdatePasswordInDatabase(newPassword);

                            // Cập nhật mật khẩu trong currentEmployee
                            currentEmployee.EmployeePassword = newPassword;

                            // Thông báo thành công
                            MessageBox.Show("Đã cập nhật mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Đưa về trạng thái ban đầu
                            LoadManagerData();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu mật khẩu: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool HasVietnameseCharacters(string input)
        {
            // Ký tự tiếng Việt thường có dấu nằm trong khoảng Unicode từ 0x1EA0 đến 0x1EF9
            foreach (char c in input)
            {
                if (c >= 0x1EA0 && c <= 0x1EF9)
                {
                    return true;
                }
            }
            return false;
        }

        private void UpdatePasswordInDatabase(string newPassword)
        {
            using (var connection = dbContext.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("UPDATE EMPLOYEE SET EmployeePassword = @NewPassword WHERE EmployeeID = @EmployeeID", connection))
                {
                    command.Parameters.AddWithValue("@NewPassword", newPassword);
                    command.Parameters.AddWithValue("@EmployeeID", currentEmployee.EmployeeID);
                    command.ExecuteNonQuery();
                }
            }
        }
    }

    public class ManagerSettingOTPController : IOTPController
    {
        public string Phone { get; }
        public string Email { get; }

        public ManagerSettingOTPController(string phone, string email)
        {
            Phone = phone;
            Email = email;
        }
    }
}