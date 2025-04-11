using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using QuanLyThongTinKhachHangSacomBank.Data;
using QuanLyThongTinKhachHangSacomBank.Models;
using QuanLyThongTinKhachHangSacomBank.Views.Manager;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class FormManagerController
    {
        private IFormManagerView view;
        private readonly EmployeeModel employee;
        private readonly DatabaseContext dbContext;
        private readonly IConfiguration configuration;

        public FormManagerController(IFormManagerView view, EmployeeModel employee, DatabaseContext dbContext, IConfiguration configuration)
        {
            this.view = view;
            this.employee = employee;
            this.dbContext = dbContext;
            this.configuration = configuration;
        }

        public void LoadManagerHome()
        {
            try
            {
                var ucManagerHome = new UC_ManagerHome(employee);
                view.LoadUserControl(ucManagerHome);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load UC_ManagerHome: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadEmployeeManagement()
        {
            view.LoadUserControl(new UC_EmployeeManagement());
        }

        public void LoadRequestManagement()
        {
            view.LoadUserControl(new UC_RequestManagement());
        }

        public void LoadReportStatistic()
        {
            view.LoadUserControl(new UC_ReportStatistic());
        }

        public void LoadManagerSetting()
        {
            view.LoadUserControl(new UC_ManagerSetting());
        }
    }
    
}
