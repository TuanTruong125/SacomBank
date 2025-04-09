using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyThongTinKhachHangSacomBank.Models
{
    [Table("TRANSACTION_TYPE")]
    public class TransactionTypeModel
    {
        [Key]
        public int TransactionTypeID { get; set; }

        public string TransactionTypeCode { get; set; }

        [Required]
        public string TransactionTypeName { get; set; }

        [Required]
        public string TransactionTypeDescription { get; set; }
    }
}