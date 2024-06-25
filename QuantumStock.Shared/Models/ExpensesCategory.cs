using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuantumStock.Shared.Models
{
    public class ExpensesCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Category Name")]
        public string? Name { get; set; }

        public virtual ICollection<Expenses>? Expenses { get; set; }
    }
}