using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyThongTinKhachHangSacomBank.Models
{
    [Table("CUSTOMER_TYPE")]
    public class CustomerTypeModel
    {
        [Key]
        public int CustomerTypeID { get; set; }

        [Required]
        public string CustomerTypeCode { get; set; }

        [Required]
        public string CustomerTypeName { get; set; }

        [Required]
        public string CustomerTypeDescription { get; set; }
    }
}