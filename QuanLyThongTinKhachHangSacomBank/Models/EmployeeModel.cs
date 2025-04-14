using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyThongTinKhachHangSacomBank.Models
{
    [Table("EMPLOYEE")]
    public class EmployeeModel
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        public string EmployeeCode { get; set; }

        [Required]
        public string EmployeeName { get; set; }

        [Required]
        [StringLength(10)]
        public string EmployeeGender { get; set; }

        [Required]
        public DateTime EmployeeDateOfBirth { get; set; }

        [Required]
        [StringLength(20)]
        public string EmployeeCitizenID { get; set; }

        [Required]
        public string EmployeeAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string EmployeeRole { get; set; }

        [Required]
        [StringLength(15)]
        public string EmployeePhone { get; set; }

        [Required]
        [EmailAddress]
        public string EmployeeEmail { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        [StringLength(50)]
        public string EmployeeUsername { get; set; }

        [Required]
        [StringLength(256)]
        public string EmployeePassword { get; set; }

        [Required]
        [Range(1, 2)]
        public int AccessLevel { get; set; } // 1: Nhân viên, 2: Quản lý

        public int? ManagerID { get; set; }
    }
}