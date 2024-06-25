using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuantumStock.Shared.Models
{
    public class CompanyDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        [DisplayName("Company Name")]
        public string? Name { get; set; }

        [Required]
        [StringLength(50)]
        public string? Address { get; set; }

        [Required]
        [StringLength(50)]
        public string? Location { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        [Required]
        public string? Contact { get; set; }

        [StringLength(150)]
        public string? Website { get; set; }

        [StringLength(150)]
        public string? Logo { get; set; }

        [StringLength(150)]
        public string? BankName { get; set; }

        public int BankAccountNumber { get; set; }

        [StringLength(150)]
        public string? Provider { get; set; }

        [Phone]
        [StringLength(25)]
        public string? PhoneNumber { get; set; }

        [StringLength(55)]
        public string? NameonAccount { get; set; }

        public bool Status { get; set; }
    }
}