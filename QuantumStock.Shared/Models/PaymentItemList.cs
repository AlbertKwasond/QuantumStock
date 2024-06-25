using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuantumStock.Shared.Models
{
    public class PaymentItemList
    {
        [Key]
        public int Id { get; set; }

        public int SalesListId { get; set; }
        public int CustomerId { get; set; }
        public int StaffId { get; set; }

        [ForeignKey("Products")]
        public int ProductsId { get; set; }

        public int OrderNum { get; set; }
        public string? ItemName { get; set; }

        [Required]
        public int Qty { get; set; }

        [Required]
        public decimal Cost { get; set; }

        public decimal Price { get; set; }

        public Customer? Customer { get; set; }
        public Staff? Staff { get; set; }
        public Product? Products { get; set; }
        public SalesList? SalesLists { get; set; }

        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}