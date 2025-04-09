using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Views.Customer;
using System;
using Microsoft.Data.SqlClient;
using QuanLyThongTinKhachHangSacomBank.Data;
using System.Drawing;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class ShowCustomerAccountInfoController
    {
        private readonly DatabaseContext dbContext;
        private readonly IFormShowCustomerAccountInfoView view;

        public ShowCustomerAccountInfoController(IFormShowCustomerAccountInfoView view, DatabaseContext dbContext = null)
        {
            this.view = view;
            this.dbContext = dbContext;
        }

        public void OpenShowCustomerAccountInfo(AccountModel account)
        {
            try
            {
                if (account == null)
                {
                    MessageBox.Show("Không có thông tin tài khoản để hiển thị!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dbContext == null)
                {
                    MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu! Vui lòng kiểm tra cấu hình DatabaseContext.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Truy vấn thông tin khách hàng từ CustomerID
                CustomerModel customer = null;
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand("SELECT * FROM CUSTOMER WHERE CustomerID = @CustomerID", connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", account.CustomerID);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                customer = new CustomerModel
                                {
                                    CustomerID = reader.GetInt32(reader.GetOrdinal("CustomerID")),
                                    CustomerCode = reader.GetString(reader.GetOrdinal("CustomerCode")),
                                    FullName = reader.GetString(reader.GetOrdinal("FullName")),
                                    Gender = reader.GetString(reader.GetOrdinal("Gender")),
                                    DateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                                    Nationality = reader.GetString(reader.GetOrdinal("Nationality")),
                                    CitizenID = reader.GetString(reader.GetOrdinal("CitizenID")),
                                    CustomerAddress = reader.GetString(reader.GetOrdinal("CustomerAddress")),
                                    Phone = reader.GetString(reader.GetOrdinal("Phone")),
                                    Email = reader.GetString(reader.GetOrdinal("Email")),
                                    RegistrationDate = reader.GetDateTime(reader.GetOrdinal("RegistrationDate")),
                                    CustomerTypeID = reader.GetInt32(reader.GetOrdinal("CustomerTypeID"))
                                };
                            }
                        }
                    }

                    // Truy vấn loại tài khoản từ AccountTypeID
                    string accountTypeName = "Không xác định";
                    using (var command = new SqlCommand("SELECT AccountTypeName FROM ACCOUNT_TYPE WHERE AccountTypeID = @AccountTypeID", connection))
                    {
                        command.Parameters.AddWithValue("@AccountTypeID", account.AccountTypeID);
                        var result = command.ExecuteScalar();
                        if (result != null)
                        {
                            accountTypeName = result.ToString();
                        }
                    }

                    // Truy vấn loại khách hàng từ CustomerTypeID
                    string customerTypeName = "Không xác định";
                    using (var command = new SqlCommand("SELECT CustomerTypeName FROM CUSTOMER_TYPE WHERE CustomerTypeID = @CustomerTypeID", connection))
                    {
                        command.Parameters.AddWithValue("@CustomerTypeID", customer.CustomerTypeID);
                        var result = command.ExecuteScalar();
                        if (result != null)
                        {
                            customerTypeName = result.ToString();
                        }
                    }

                    // Truyền dữ liệu vào View
                    view.SetAccountID(account.AccountCode);
                    view.SetAccountName(account.AccountName);
                    view.SetBalance(string.Format("{0:N0}", account.Balance));
                    view.SetAccountOpenDate(account.AccountOpenDate.ToString("dd/MM/yyyy"));
                    view.SetAccountTypeName(accountTypeName);

                    // Xử lý hiển thị loại khách hàng
                    if (customerTypeName.Contains("VIP"))
                    {
                        view.SetCustomerTypeName("VIP", Color.Gold);
                    }
                    else
                    {
                        view.SetCustomerTypeName("Thường", Color.Gray);
                    }
                }

                if (customer == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Hiển thị form
                view.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở FormShowCustomerAccountInfo: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}