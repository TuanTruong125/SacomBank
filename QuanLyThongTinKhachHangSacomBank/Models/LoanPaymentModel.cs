namespace QuanLyThongTinKhachHangSacomBank.Models
{
    public class LoanPaymentModel
    {
        public int PayLoanID { get; set; }
        public string PayLoanCode { get; set; }       
        public decimal PrincipalDue { get; set; }
        public decimal InterestDue { get; set; }
        public decimal LateFee { get; set; }
        public decimal TotalDue { get; set; }
        public decimal RemainingDebt { get; set; }        
        public bool PayNotification { get; set; }
        public DateTime DueDate { get; set; }
        public string PaymentStatus { get; set; }        
        public int ServiceID { get; set; }
    }
}