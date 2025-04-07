using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyThongTinKhachHangSacomBank.Models
{
    [Table("ACCOUNT_TYPE")]
    public class AccountTypeModel
    {
        [Key]
        public int AccountTypeID { get; set; }

        [Required]
        public string AccountTypeCode { get; set; }

        [Required]
        public string AccountTypeName { get; set; }

        [Required]
        public string AccountTypeDescription { get; set; }
    }
}