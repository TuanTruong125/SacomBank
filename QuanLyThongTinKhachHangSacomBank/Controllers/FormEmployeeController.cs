using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyThongTinKhachHangSacomBank.Views.Employee;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class FormEmployeeController
    {
        private IFormEmployeeView view;

        public FormEmployeeController(IFormEmployeeView view)
        {
            this.view = view;
        }

        public void LoadHome()
        {
            view.LoadUserControl(new UC_Home());
        }

        public void LoadCustomerManagement()
        {
            view.LoadUserControl(new UC_CustomerManagement());
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
            view.LoadUserControl(new UC_TransactionManagement());
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
