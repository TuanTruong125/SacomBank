using QuanLyThongTinKhachHangSacomBank.Views.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class SavingsDetailController
    {
        public void OpenSavingsDetail()
        {
            try
            {
                FormSavingsDetail formSavingsDetail = new FormSavingsDetail();
                formSavingsDetail.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở FormSavingsDetail: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
