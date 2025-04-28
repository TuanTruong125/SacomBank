using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThongTinKhachHangSacomBank.Models
{
    class NotificationModel
    {
        public int NotificationID { get; set; }
        public string NotificationCode { get; set; }
        public string Title { get; set; }
        public string NotificationMessage { get; set; }
        public DateTime NotificationDate { get; set; }
        public string NotificationStatus { get; set; }
        public int? ReferenceID { get; set; }
        public int? CustomerID { get; set; }
        public int? EmployeeID { get; set; }
        public int NotificationTypeID { get; set; }
    }
}
