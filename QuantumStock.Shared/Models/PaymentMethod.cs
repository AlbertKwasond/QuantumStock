using System.ComponentModel.DataAnnotations;

namespace QuantumStock.Shared.Models
{
    public class PaymentMethod
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }
    }
}