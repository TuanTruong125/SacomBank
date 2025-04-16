namespace QuanLyThongTinKhachHangSacomBank.Models
{
    public class RequestModel
    {
        public int RequestID { get; set; }
        public string RequestCode { get; set; }
        public string Title { get; set; }
        public string RequestMessage { get; set; }
        public DateTime RequestDate { get; set; }
        public int? HandledBy { get; set; }
        public string EmployeeName { get; set; } // Để hiển thị tên nhân viên xử lý
        public string RequestStatus { get; set; }
        public int CustomerID { get; set; }
    }
}