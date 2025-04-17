using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Views.Customer;
using System.Windows.Forms;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class FormCustomerController
    {
        private IFormCustomerView view;
        private readonly AccountModel loggedInAccount; // Lưu thông tin tài khoản từ FormCustomer
        private readonly EmployeeModel currentEmployee;
        private readonly CustomerModel currentCustomer; // Thêm để lưu thông tin khách hàng
        private readonly DatabaseContext dbContext;
        private readonly IConfiguration configuration;

        public FormCustomerController(IFormCustomerView view, AccountModel account, EmployeeModel employee, DatabaseContext dbContext, IConfiguration configuration)
        {
            this.view = view;
            this.loggedInAccount = account; // Nhận thông tin tài khoản từ FormCustomer
            this.currentEmployee = employee;
            this.dbContext = dbContext;
            this.configuration = configuration;

            // Kiểm tra loggedInAccount và dbContext trước khi gọi LoadCustomerFromAccount
            if (loggedInAccount == null)
            {
                MessageBox.Show("Tài khoản đăng nhập không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.currentCustomer = null;
            }
            else if (dbContext == null)
            {
                MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.currentCustomer = null;
            }
            else
            {
                this.currentCustomer = LoadCustomerFromAccount(loggedInAccount);
            }
        }

        private CustomerModel LoadCustomerFromAccount(AccountModel account)
        {
            // Kiểm tra account không null (đã có từ trước)
            if (account == null)
            {
                MessageBox.Show("Tài khoản không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            // Kiểm tra dbContext không null
            if (dbContext == null)
            {
                MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            try
            {
                using (var connection = dbContext.GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand(
                        "SELECT c.* FROM CUSTOMER c JOIN ACCOUNT a ON c.CustomerID = a.CustomerID WHERE a.AccountID = @AccountID", connection))
                    {
                        command.Parameters.AddWithValue("@AccountID", account.AccountID);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new CustomerModel
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load thông tin khách hàng: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        public void LoadCustomerHome()
        {
            if (loggedInAccount == null)
            {
                MessageBox.Show("Tài khoản đăng nhập không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UC_CustomerHome customerHome = new UC_CustomerHome(loggedInAccount, currentEmployee, dbContext, configuration);
            CustomerHomeController homeController = new CustomerHomeController(customerHome, loggedInAccount);
            view.LoadUserControl(customerHome);
        }

        public void LoadCustomerService()
        {
            if (loggedInAccount == null || dbContext == null || configuration == null)
            {
                MessageBox.Show("Không thể load thông tin tài khoản hoặc cơ sở dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UC_CustomerService customerService = new UC_CustomerService(loggedInAccount, dbContext, configuration);
            view.LoadUserControl(customerService);
        }

        public void LoadCustomerPersonal()
        {
            if (currentCustomer == null || loggedInAccount == null)
            {
                MessageBox.Show("Không thể load thông tin khách hàng hoặc tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            view.LoadUserControl(new UC_CustomerPersonal(currentCustomer, loggedInAccount, dbContext, configuration));
        }
    }
}