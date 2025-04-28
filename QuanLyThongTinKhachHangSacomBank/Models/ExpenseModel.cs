using System;

namespace QuanLyThongTinKhachHangSacomBank.Models
{
    public class ExpenseModel
    {
        public int ExpenseID { get; set; }
        public string ExpenseCode { get; set; }
        public decimal? InterestPaid { get; set; }
        public decimal? EmployeeSalary { get; set; }
        public decimal? SystemMaintenanceFee { get; set; }
        public DateTime ExpenseDate { get; set; }
        public int? PaySavingsID { get; set; }
        public int? ProfitID { get; set; }
    }
}