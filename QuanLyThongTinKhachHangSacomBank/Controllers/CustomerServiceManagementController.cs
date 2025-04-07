using QuanLyThongTinKhachHangSacomBank.Views.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class CustomerServiceManagementController
    {
        public void OpenCustomerServiceManagement()
        {
            try
            {
                FormCustomerServiceManagement formCustomerServiceManagement = new FormCustomerServiceManagement();
                formCustomerServiceManagement.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở FormCustomerServiceManagement: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
