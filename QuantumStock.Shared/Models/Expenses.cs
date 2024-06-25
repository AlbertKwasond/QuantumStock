using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuantumStock.Shared.Models
{
    public class Expenses
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Category Name")]
        [ForeignKey("ExpensesCategory")]
        public int ExpensesCategoryId { get; set; }

        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public int StaffId { get; set; }
        public Staff? Staff { get; set; }
        public DateTime DateTime { get; set; } = new DateTime();
        public ExpensesCategory? ExpensesCategory { get; set; }
    }
}