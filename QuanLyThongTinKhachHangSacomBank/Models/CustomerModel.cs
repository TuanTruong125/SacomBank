using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyThongTinKhachHangSacomBank.Models
{
    [Table("CUSTOMER")]
    public class CustomerModel
    {
        [Key]
        public int CustomerID { get; set; }

        [Required]
        public string CustomerCode { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Nationality { get; set; }

        [Required]
        [StringLength(20)]
        public string CitizenID { get; set; }

        [Required]
        public string CustomerAddress { get; set; }

        [Required]
        [StringLength(15)]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Required]
        public int CustomerTypeID { get; set; }
    }
}