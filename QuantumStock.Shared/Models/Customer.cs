using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuantumStock.Shared.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [DisplayName("First name")]
        public string? FirstName { get; set; }

        [StringLength(200)]
        [DisplayName("Middle Name")]
        public string? MiddleName { get; set; }

        [Required]
        [StringLength(255)]
        [DisplayName("Last name")]
        public string? LastName { get; set; }

        [StringLength(255)]
        public string FullName
        { get { return String.Format("{0} {1} {2}", this.FirstName, this.MiddleName, this.LastName); } }

        [Required]
        [StringLength(25)]
        public string? Gender { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [Phone]
        public string? Contact { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }

        [ForeignKey("Staff")]
        public int StaffId { get; set; }

        public Staff? Staff { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public List<SalesList>? SalesLists { get; set; }

        public List<CartPayment>? CartPayments { get; set; }
    }
}