using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Controllers;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Views.Common.CustomerLogin;
using QuanLyThongTinKhachHangSacomBank.Views.Common.EmployeeLogin;
using QuanLyThongTinKhachHangSacomBank.Views.Customer;
using QuanLyThongTinKhachHangSacomBank.Views.Employee;
using QuanLyThongTinKhachHangSacomBank.Views.Manager;

namespace QuanLyThongTinKhachHangSacomBank
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                DatabaseContext dbContext = new DatabaseContext(configuration);

                ApplicationConfiguration.Initialize();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                bool exitApp = false;

                // Chạy Form Customer

                //while (!exitApp)
                //{
                //    using (FormCustomerLogin loginForm = new FormCustomerLogin(configuration, dbContext))
                //    {
                //        Application.Run(loginForm); // Chạy FormCustomerLogin

                //        // Kiểm tra kết quả trả về từ FormCustomerLogin
                //        if (loginForm.DialogResult == DialogResult.OK)
                //        {
                //            // Đăng nhập thành công, mở FormCustomer
                //            using (FormCustomer formCustomer = new FormCustomer())
                //            {
                //                Application.Run(formCustomer); // Chạy FormCustomer

                //                // Nếu logout (DialogResult.Cancel), tiếp tục vòng lặp để mở lại FormCustomerLogin
                //                if (formCustomer.DialogResult != DialogResult.Cancel)
                //                {
                //                    exitApp = true; // Thoát ứng dụng nếu không logout
                //                }
                //            }
                //        }
                //        else if (loginForm.DialogResult == DialogResult.Cancel)
                //        {
                //            // Đăng ký hoặc quên mật khẩu, tiếp tục vòng lặp
                //            continue;
                //        }
                //        else
                //        {
                //            // Người dùng đóng form bằng nút X, thoát ứng dụng
                //            exitApp = true;
                //        }
                //    }
                //}




                // Chạy Form Employee
                while (!exitApp)
                {
                    using (FormEmployeeLogin loginForm = new FormEmployeeLogin(configuration, dbContext))
                    {
                        Application.Run(loginForm);

                        if (loginForm.DialogResult == DialogResult.OK)
                        {
                            EmployeeModel employee = loginForm.Tag as EmployeeModel;
                            if (employee != null)
                            {
                                if (employee.AccessLevel == 2) // Quản lý
                                {
                                    using (FormManager formManager = new FormManager())
                                    {
                                        Application.Run(formManager);
                                        if (formManager.DialogResult != DialogResult.Cancel)
                                        {
                                            exitApp = true;
                                        }
                                    }
                                }
                                else // Nhân viên (AccessLevel = 1)
                                {
                                    using (FormEmployee formEmployee = new FormEmployee())
                                    {
                                        Application.Run(formEmployee);
                                        if (formEmployee.DialogResult != DialogResult.Cancel)
                                        {
                                            exitApp = true;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            exitApp = true;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi động app:\n{ex.Message}\n\nChi tiết lỗi:\n{ex.StackTrace}", "Lỗi", MessageBoxButtons.OK);
            }
        }
    }
}