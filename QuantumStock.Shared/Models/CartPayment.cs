using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuantumStock.Shared.Models
{
    public class CartPayment
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [ForeignKey("Staff")]
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

        [ForeignKey("CustomerId")]
        [InverseProperty("CartPayments")]
        public Customer? Customers { get; set; }

        [ForeignKey("StaffId")]
        [InverseProperty("CartPayments")]
        public Staff? Staffs { get; set; }

        [ForeignKey("ProductsId")]
        [InverseProperty("CartPayments")]
        public Product? Products { get; set; }
    }
}