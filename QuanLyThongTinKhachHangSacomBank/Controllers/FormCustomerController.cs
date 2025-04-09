using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Views.Customer;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class FormCustomerController
    {
        private IFormCustomerView view;
        private AccountModel loggedInAccount; // Lưu thông tin tài khoản từ FormCustomer
        private readonly EmployeeModel currentEmployee;
        private readonly DatabaseContext dbContext;
        private readonly IConfiguration configuration;

        public FormCustomerController(IFormCustomerView view, AccountModel account, EmployeeModel employee, DatabaseContext dbContext, IConfiguration configuration)
        {
            this.view = view;
            this.loggedInAccount = account; // Nhận thông tin tài khoản từ FormCustomer
            this.currentEmployee = employee;
            this.dbContext = dbContext;
            this.configuration = configuration;
        }

        public void LoadCustomerHome()
        {
            UC_CustomerHome customerHome = new UC_CustomerHome(loggedInAccount, currentEmployee, dbContext, configuration);
            CustomerHomeController homeController = new CustomerHomeController(customerHome, loggedInAccount);
            view.LoadUserControl(customerHome);
        }

        public void LoadCustomerService()
        {
            view.LoadUserControl(new UC_CustomerService());
        }

        public void LoadCustomerPersonal()
        {
            view.LoadUserControl(new UC_CustomerPersonal());
        }
    }
}
