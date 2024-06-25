using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuantumStock.Shared.Models
{
    public class Branch
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        [DisplayName("Branch Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string Location { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Required]
        public string Contact { get; set; }

        public List<Staff>? Staffs { get; set; }

        public List<TransferProduct>? TransferProducts { get; set; }
    }
}