using QuanLyThongTinKhachHangSacomBank.Views.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class LoanDetailController
    {
        public void OpenLoanDetail()
        {
            try
            {
                FormLoanDetail formLoanDetail = new FormLoanDetail();
                formLoanDetail.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở FormLoanDetail: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
