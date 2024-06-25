using System.ComponentModel.DataAnnotations;

namespace QuantumStock.Shared.Models
{
    public class TaxDiscount
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string? Name { get; set; }

        public double Percentage { get; set; }
        public bool Status { get; set; }
    }
}