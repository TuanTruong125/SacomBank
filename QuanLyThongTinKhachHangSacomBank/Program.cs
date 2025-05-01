using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.AutoTasks;
using QuanLyThongTinKhachHangSacomBank.Controllers;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Views.Common.CustomerLogin;
using QuanLyThongTinKhachHangSacomBank.Views.Common.EmployeeLogin;
using QuanLyThongTinKhachHangSacomBank.Views.Common.LoginTypeSelection;
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
        private static CustomerTypeUpdateAutoTask customerTypeUpdateAutoTask;

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

                // TH1: Không cần chạy lại Form
                // Hiển thị form chọn loại đăng nhập

                //while (!exitApp)
                //{
                //    ILoginTypeSelectionView loginTypeView = new FormLoginTypeSelection();
                //    Application.Run((Form)loginTypeView);

                //    if (loginTypeView.DialogResult == DialogResult.OK)
                //    {
                //        string selectedRole = loginTypeView.SelectedRole;

                //        // Dừng các AutoTask hiện tại (nếu có) trước khi khởi động mới
                //        loanPaymentAutoTask?.Stop();
                //        profitAutoTask?.Stop();
                //        savingsPaymentAutoTask?.Stop();
                //        generalExpenseAutoTask?.Stop();
                //        customerTypeUpdateAutoTask?.Stop();

                //        // Khởi động lại các AutoTask cho cả Khách hàng và Nhân viên
                //        loanPaymentAutoTask = new LoanPaymentAutoTask(dbContext);
                //        profitAutoTask = new ProfitAutoTask(dbContext);
                //        savingsPaymentAutoTask = new SavingsPaymentAutoTask(dbContext);
                //        generalExpenseAutoTask = new GeneralExpenseAutoTask(dbContext);
                //        customerTypeUpdateAutoTask = new CustomerTypeUpdateAutoTask(dbContext);

                //        if (selectedRole == "Khách hàng")
                //        {
                //            // Chạy Form Customer Login
                //            using (FormCustomerLogin loginForm = new FormCustomerLogin(configuration, dbContext))
                //            {
                //                CustomerLoginController loginController = new CustomerLoginController(loginForm, new UC_CustomerLogin(configuration, dbContext), configuration, dbContext);
                //                Application.Run(loginForm);

                //                if (loginForm.DialogResult == DialogResult.OK)
                //                {
                //                    AccountModel account = loginForm.Tag as AccountModel;
                //                    if (account != null)
                //                    {
                //                        using (FormCustomer formCustomer = new FormCustomer(account, dbContext, configuration))
                //                        {
                //                            Application.Run(formCustomer);
                //                            // Quay lại FormLoginTypeSelection khi đóng FormCustomer
                //                            continue;
                //                        }
                //                    }
                //                }
                //                else
                //                {
                //                    // Nếu đóng FormCustomerLogin bằng "X", quay lại FormLoginTypeSelection
                //                    continue;
                //                }
                //            }
                //        }
                //        else if (selectedRole == "Nhân viên")
                //        {
                //            // Chạy Form Employee Login
                //            using (FormEmployeeLogin loginForm = new FormEmployeeLogin(configuration, dbContext))
                //            {
                //                Application.Run(loginForm);

                //                if (loginForm.DialogResult == DialogResult.OK)
                //                {
                //                    EmployeeModel employee = loginForm.Tag as EmployeeModel;
                //                    if (employee != null)
                //                    {
                //                        if (employee.AccessLevel == 2) // Quản lý
                //                        {
                //                            using (FormManager formManager = new FormManager(employee, dbContext, configuration))
                //                            {
                //                                Application.Run(formManager);
                //                                // Quay lại FormLoginTypeSelection khi đóng FormManager
                //                                continue;
                //                            }
                //                        }
                //                        else // Nhân viên (AccessLevel = 1)
                //                        {
                //                            using (FormEmployee formEmployee = new FormEmployee(null, employee, dbContext, configuration))
                //                            {
                //                                Application.Run(formEmployee);
                //                                // Quay lại FormLoginTypeSelection khi đóng FormEmployee
                //                                continue;
                //                            }
                //                        }
                //                    }
                //                }
                //                else
                //                {
                //                    // Nếu đóng FormEmployeeLogin bằng "X", quay lại FormLoginTypeSelection
                //                    continue;
                //                }
                //            }
                //        }
                //    }
                //    else
                //    {
                //        // Đóng FormLoginTypeSelection bằng "X", thoát ứng dụng
                //        exitApp = true;
                //    }
                //}



                // TH2: Hiệu suất cao hơn nhưng phải chạy lại Form
                // Hiển thị form chọn loại đăng nhập

                loanPaymentAutoTask = new LoanPaymentAutoTask(dbContext);
                profitAutoTask = new ProfitAutoTask(dbContext);
                savingsPaymentAutoTask = new SavingsPaymentAutoTask(dbContext);
                generalExpenseAutoTask = new GeneralExpenseAutoTask(dbContext);
                customerTypeUpdateAutoTask = new CustomerTypeUpdateAutoTask(dbContext);

                while (!exitApp)
                {
                    ILoginTypeSelectionView loginTypeView = new FormLoginTypeSelection();
                    Application.Run((Form)loginTypeView);

                    if (loginTypeView.DialogResult == DialogResult.OK)
                    {
                        string selectedRole = loginTypeView.SelectedRole;

                        if (selectedRole == "Khách hàng")
                        {
                            // Chạy Form Customer Login
                            using (FormCustomerLogin loginForm = new FormCustomerLogin(configuration, dbContext))
                            {
                                CustomerLoginController loginController = new CustomerLoginController(loginForm, new UC_CustomerLogin(configuration, dbContext), configuration, dbContext);
                                Application.Run(loginForm);

                                if (loginForm.DialogResult == DialogResult.OK)
                                {
                                    AccountModel account = loginForm.Tag as AccountModel;
                                    if (account != null)
                                    {
                                        using (FormCustomer formCustomer = new FormCustomer(account, dbContext, configuration))
                                        {
                                            Application.Run(formCustomer);
                                            // Thoát ứng dụng khi đóng FormCustomer (bằng "X" hoặc "Đăng xuất")
                                            exitApp = true;
                                        }
                                    }
                                }
                                else
                                {
                                    // Nếu đóng FormCustomerLogin bằng "X", quay lại FormLoginTypeSelection
                                    continue;
                                }
                            }
                        }
                        else if (selectedRole == "Nhân viên")
                        {
                            // Chạy Form Employee Login
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
                                                // Thoát ứng dụng khi đóng FormManager (bằng "X" hoặc "Đăng xuất")
                                                exitApp = true;
                                            }
                                        }
                                        else // Nhân viên (AccessLevel = 1)
                                        {
                                            using (FormEmployee formEmployee = new FormEmployee(null, employee, dbContext, configuration))
                                            {
                                                Application.Run(formEmployee);
                                                // Thoát ứng dụng khi đóng FormEmployee (bằng "X" hoặc "Đăng xuất")
                                                exitApp = true;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    // Nếu đóng FormEmployeeLogin bằng "X", quay lại FormLoginTypeSelection
                                    continue;
                                }
                            }
                        }
                    }
                    else
                    {
                        // Đóng FormLoginTypeSelection bằng "X", thoát ứng dụng
                        exitApp = true;
                    }
                }



                // Dừng các AutoTask khi ứng dụng thoát
                loanPaymentAutoTask?.Stop();
                profitAutoTask?.Stop();
                savingsPaymentAutoTask?.Stop();
                generalExpenseAutoTask?.Stop();
                customerTypeUpdateAutoTask?.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi động app:\n{ex.Message}\n\nChi tiết lỗi:\n{ex.StackTrace}", "Lỗi", MessageBoxButtons.OK);
            }
        }
    }
}