// Program.cs

using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.AutoTasks;
using QuanLyThongTinKhachHangSacomBank.Controllers;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Services;
using QuanLyThongTinKhachHangSacomBank.Views.Common;
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
                // Cấu hình ứng dụng Windows Forms
                ApplicationConfiguration.Initialize();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // Tải cấu hình từ appsettings.json
                IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                // Kiểm tra cấu hình kết nối
                if (!ConnectionConfigService.ConfigExists())
                {
                    // Hiển thị form cấu hình khi chưa có thông tin kết nối
                    using (var configForm = new FormDatabaseConfig())
                    {
                        DialogResult result = configForm.ShowDialog();

                        if (result != DialogResult.OK)
                        {
                            // Người dùng đã hủy cấu hình, thoát ứng dụng
                            return;
                        }
                    }
                }

                // Khởi tạo DatabaseContext
                DatabaseContext dbContext = new DatabaseContext(configuration);

                // Kiểm tra kết nối trước khi khởi động ứng dụng
                try
                {
                    using (var connection = dbContext.GetConnection())
                    {
                        connection.Open();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Không thể kết nối đến cơ sở dữ liệu:\n{ex.Message}\n\n" +
                        "Vui lòng kiểm tra lại cấu hình kết nối.",
                        "Lỗi kết nối",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    // Hiển thị form cấu hình lại
                    using (var configForm = new FormDatabaseConfig())
                    {
                        DialogResult result = configForm.ShowDialog();

                        if (result != DialogResult.OK)
                        {
                            // Người dùng đã hủy cấu hình, thoát ứng dụng
                            return;
                        }

                        // Tạo lại DatabaseContext với cấu hình mới
                        dbContext = new DatabaseContext(configuration);
                    }
                }

                // Khởi động các AutoTask
                loanPaymentAutoTask = new LoanPaymentAutoTask(dbContext);
                profitAutoTask = new ProfitAutoTask(dbContext);
                savingsPaymentAutoTask = new SavingsPaymentAutoTask(dbContext);
                generalExpenseAutoTask = new GeneralExpenseAutoTask(dbContext);
                customerTypeUpdateAutoTask = new CustomerTypeUpdateAutoTask(dbContext);

                bool exitApp = false;

                // Luồng ứng dụng chính
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