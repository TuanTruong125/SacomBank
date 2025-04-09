using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyThongTinKhachHangSacomBank.Models
{
    [Table("TRANSACTION")]
    public class TransactionModel
    {
        [Key]
        public int TransactionID { get; set; }

        public string TransactionCode { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public int ReceiverAccountID { get; set; }

        [Required]
        public string TransactionStatus { get; set; }

        public int? HandledBy { get; set; }

        public string TransactionDescription { get; set; }

        [Required]
        public string TransactionMethod { get; set; }

        [Required]
        public string ReceiverAccountName { get; set; }

        [Required]
        public int AccountID { get; set; }

        [Required]
        public int TransactionTypeID { get; set; }

        [ForeignKey("AccountID")]
        public virtual AccountModel Account { get; set; }

        [ForeignKey("ReceiverAccountID")]
        public virtual AccountModel ReceiverAccount { get; set; }

        [ForeignKey("TransactionTypeID")]
        public virtual TransactionTypeModel TransactionType { get; set; }

        [ForeignKey("HandledBy")]
        public virtual EmployeeModel Employee { get; set; }
    }
}