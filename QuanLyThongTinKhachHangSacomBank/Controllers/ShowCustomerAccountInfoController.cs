using QuanLyThongTinKhachHangSacomBank.Views.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class ShowCustomerAccountInfoController
    {
        public void OpenShowCustomerAccountInfo()
        {
            try
            {
                FormShowCustomerAccountInfo formShowCustomerAccountInfo = new FormShowCustomerAccountInfo();
                formShowCustomerAccountInfo.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở FormShowCustomerAccountInfo: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
