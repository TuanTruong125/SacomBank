using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyThongTinKhachHangSacomBank.Models
{
    [Table("ACCOUNT")]
    public class AccountModel
    {
        [Key]
        public int AccountID { get; set; }

        [Required]
        public string AccountCode { get; set; }

        [Required]
        public string AccountName { get; set; }

        [Required]
        public decimal Balance { get; set; }

        [Required]
        public DateTime AccountOpenDate { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string UserPassword { get; set; }

        [Required]
        [StringLength(6)]
        public string PINCode { get; set; }

        [Required]
        public string AccountStatus { get; set; }

        [Required]
        public int CustomerID { get; set; }

        [Required]
        public int AccountTypeID { get; set; }
    }
}