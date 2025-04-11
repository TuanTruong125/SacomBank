using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Views.Customer;
using QuanLyThongTinKhachHangSacomBank.Views.Employee;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class FormEmployeeController
    {
        private IFormEmployeeView view;
        private readonly AccountModel currentAccount;
        private readonly EmployeeModel currentEmployee;
        private readonly DatabaseContext dbContext;
        private readonly IConfiguration configuration;

        public FormEmployeeController(IFormEmployeeView view, AccountModel account, EmployeeModel employee, DatabaseContext dbContext, IConfiguration configuration)
        {
            this.view = view;
            this.currentAccount = account;
            this.currentEmployee = employee;
            this.dbContext = dbContext;
            this.configuration = configuration;
        }

        public void LoadHome()
        {
            try
            {
                var ucHome = new UC_Home(currentEmployee);
                view.LoadUserControl(ucHome);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load UC_Home: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadCustomerManagement()
        {
            view.LoadUserControl(new UC_CustomerManagement(dbContext, configuration));
        }

        public void LoadAccountManagement()
        {
            view.LoadUserControl(new UC_AccountManagement());
        }

        public void LoadServiceManagement()
        {
            view.LoadUserControl(new UC_ServiceManagement());
        }

        public void LoadTransactionManagement()
        {
            // Khởi tạo UC_CustomerHome để truyền vào UC_TransactionManagement
            ICustomerHomeView customerHomeView = new UC_CustomerHome(currentAccount, currentEmployee, dbContext, configuration);
            view.LoadUserControl(new UC_TransactionManagement(currentAccount, currentEmployee, dbContext, configuration, customerHomeView));
        }

        public void LoadCustomerCare()
        {
            view.LoadUserControl(new UC_CustomerCare());
        }

        public void LoadSetting()
        {
            view.LoadUserControl(new UC_Setting());
        }
    }
}
