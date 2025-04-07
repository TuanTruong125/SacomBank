
using QuanLyThongTinKhachHangSacomBank.Views.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThongTinKhachHangSacomBank.Controllers
{
    class TransactionHistoryController
    {
        public void OpenTransactionHistory()
        {
            try
            {
                FormTransactionHistory formTransactionHistory = new FormTransactionHistory();
                formTransactionHistory.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở FormTransactionHistory: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
