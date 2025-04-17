using System;

namespace QuanLyThongTinKhachHangSacomBank.Models
{
    public class ServiceModel
    {
        public int ServiceID { get; set; }
        public string ServiceCode { get; set; }
        public decimal TotalPrincipalAmount { get; set; }
        public string Duration { get; set; }
        public decimal InterestRate { get; set; }
        public decimal? TotalInterestAmount { get; set; }
        public string ServiceDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ApplicableDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ApprovalStatus { get; set; }
        public string ServiceStatus { get; set; }
        public int? HandledBy { get; set; }
        public int CustomerID { get; set; }
        public int AccountID { get; set; }
        public int ServiceTypeID { get; set; }
    }
}