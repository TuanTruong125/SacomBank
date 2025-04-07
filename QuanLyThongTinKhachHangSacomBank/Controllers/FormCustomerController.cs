using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyThongTinKhachHangSacomBank.Views.Customer;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class FormCustomerController
    {
        private IFormCustomerView view;

        public FormCustomerController(IFormCustomerView view)
        {
            this.view = view;
        }

        public void LoadCustomerHome()
        {
            view.LoadUserControl(new UC_CustomerHome());
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
