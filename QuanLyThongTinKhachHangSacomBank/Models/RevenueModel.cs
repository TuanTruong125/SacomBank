namespace QuanLyThongTinKhachHangSacomBank.Models
{
    public class RevenueModel
    {
        public int RevenueID { get; set; }
        public string RevenueCode { get; set; }        
        public decimal PrincipalAmount { get; set; }
        public decimal InterestAmount { get; set; }
        public decimal LateFee { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime RevenueDate { get; set; }
        public int PayLoanID { get; set; }
        public int ProfitID { get; set; }
    }
}