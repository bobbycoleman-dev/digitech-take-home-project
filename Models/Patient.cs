#pragma warning disable
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace DigitechTakeHomeProject.Models
{
    public class Patient
    {
        [Key]
        public int PatientKey { get; set; }

        public int AccountNumber { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [MaxLength(1)]
        [DisplayName("Middle Initial")]
        public string? MiddleInitial { get; set; }

        [Required]
        [MaxLength(100)]
        [DisplayName("Address 1")]
        public string Address1 { get; set; }

        [MaxLength(100)]
        [DisplayName("Address 2")]
        public string? Address2 { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [MaxLength(2)]
        public string State { get; set; }

        [Required]
        [MaxLength(10)]
        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }

        [MaxLength(20)]
        [Phone]
        [DisplayName("Home Phone")]
        public string? HomePhone { get; set; }

        [MaxLength(20)]
        [Phone]
        [DisplayName("Business Phone")]
        public string? BusinessPhone { get; set; }

        [MaxLength(20)]
        [Phone]
        [DisplayName("Cell Phone")]
        public string? CellPhone { get; set; }

        [Required]
        [MaxLength(250)]
        [EmailAddress]
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }

}



