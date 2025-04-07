using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyThongTinKhachHangSacomBank.Views.Manager;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class FormManagerController
    {
        private IFormManagerView view;

        public FormManagerController(IFormManagerView view)
        {
            this.view = view;
        }

        public void LoadManagerHome()
        {
            view.LoadUserControl(new UC_ManagerHome());
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
