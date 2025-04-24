using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThongTinKhachHangSacomBank.Models
{
    class SavingsPaymentModel
    {
        public int PaySavingsID { get; set; }
        public string PaySavingsCode { get; set; }
        public decimal MonthlyInterestAmount { get; set; }
        public decimal TotalInterestPaid { get; set; }
        public DateTime LastInterestPaidDate { get; set; }
        public int ServiceID { get; set; }
    }
}
