using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.AutoTasks;
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
        private static LoanPaymentAutoTask loanPaymentAutoTask;
        private static ProfitAutoTask profitAutoTask;
        private static SavingsPaymentAutoTask savingsPaymentAutoTask;
        private static GeneralExpenseAutoTask generalExpenseAutoTask;

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

                // Khởi tạo các AutoTask
                loanPaymentAutoTask = new LoanPaymentAutoTask(dbContext);
                profitAutoTask = new ProfitAutoTask(dbContext);
                savingsPaymentAutoTask = new SavingsPaymentAutoTask(dbContext);
                generalExpenseAutoTask = new GeneralExpenseAutoTask(dbContext);

                ApplicationConfiguration.Initialize();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                bool exitApp = false;

                // Chạy Form Customer

                //while (!exitApp)
                //{
                //    using (FormCustomerLogin loginForm = new FormCustomerLogin(configuration, dbContext))
                //    {
                //        CustomerLoginController loginController = new CustomerLoginController(loginForm, new UC_CustomerLogin(configuration, dbContext), configuration, dbContext);
                //        Application.Run(loginForm);

                //        if (loginForm.DialogResult == DialogResult.OK)
                //        {
                //            AccountModel account = loginForm.Tag as AccountModel;
                //            if (account != null)
                //            {
                //                using (FormCustomer formCustomer = new FormCustomer(account, dbContext, configuration))
                //                {
                //                    Application.Run(formCustomer);
                //                    // Nếu FormCustomer đóng bằng nút X hoặc logout, quay lại FormCustomerLogin
                //                    if (formCustomer.DialogResult != DialogResult.Cancel && formCustomer.IsDisposed)
                //                    {
                //                        continue; // Quay lại vòng lặp để mở lại FormCustomerLogin
                //                    }
                //                    else if (formCustomer.DialogResult == DialogResult.Cancel)
                //                    {
                //                        continue; // Logout, quay lại FormCustomerLogin
                //                    }
                //                    else
                //                    {
                //                        exitApp = true; // Thoát ứng dụng nếu không phải trường hợp trên
                //                    }
                //                }
                //            }
                //        }
                //        else if (loginForm.DialogResult == DialogResult.Cancel)
                //        {
                //            continue; // Đăng ký hoặc quên mật khẩu, tiếp tục vòng lặp
                //        }
                //        else
                //        {
                //            exitApp = true; // Đóng FormCustomerLogin bằng X, thoát ứng dụng
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
                                    using (FormManager formManager = new FormManager(employee, dbContext, configuration))
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
                                    using (FormEmployee formEmployee = new FormEmployee(null, employee, dbContext, configuration))
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


                // Dừng các AutoTask khi ứng dụng thoát
                loanPaymentAutoTask?.Stop();
                profitAutoTask?.Stop();
                savingsPaymentAutoTask?.Stop();
                generalExpenseAutoTask?.Stop();


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi động app:\n{ex.Message}\n\nChi tiết lỗi:\n{ex.StackTrace}", "Lỗi", MessageBoxButtons.OK);
            }
        }
    }
}