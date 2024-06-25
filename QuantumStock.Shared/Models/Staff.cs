using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuantumStock.Shared.Models
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First Name")]
        [StringLength(150)]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your Last name")]
        [Display(Name = "Last Name")]
        [StringLength(150)]
        public string? LastName { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime? DOB { get; set; }

        [Display(Name = "Full Name")]
        public string? FullName => $"{FirstName} {LastName}";

        [StringLength(10)]
        public string? Gender { get; set; }

        [Required(ErrorMessage = "Please enter a mobile number")]
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        [DisplayName("Mobile Number")]
        public string? MobileNumber { get; set; }

        [Required(ErrorMessage = "Please enter an email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please enter an address")]
        [StringLength(255, ErrorMessage = "Address should be less than 255 characters")]
        public string? Address { get; set; }

        [StringLength(50)]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Please select a role")]
        [StringLength(50)]
        public string? Roles { get; set; }

        [ForeignKey("Branch")]
        public int BranchId { get; set; }

        public Branch? Branch { get; set; }
        public List<Expenses>? ExpensesList { get; set; }
        public List<CartPayment>? CartPayments { get; set; }
    }
}