namespace QuanLyThongTinKhachHangSacomBank.Models
{
    public class ProfitModel
    {
        public int ProfitID { get; set; }
        public string ProfitCode { get; set; }        
        public decimal TotalRevenue { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal NetProfit { get; set; }
        public DateTime ProfitDate { get; set; }
    }
}