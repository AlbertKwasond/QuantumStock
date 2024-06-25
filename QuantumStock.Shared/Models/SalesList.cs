using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuantumStock.Shared.Models
{
    public class SalesList
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [ForeignKey("Staff")]
        public int StaffId { get; set; }

        public int OrderId { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public decimal Vat { get; set; }

        [DataType(DataType.Currency)]
        public Nullable<decimal> Paid { get; set; }

        [DataType(DataType.Currency)]
        public Nullable<decimal> Due { get; set; }

        [DataType(DataType.Currency)]
        public Nullable<decimal> AmountLeft { get; set; }

        [DataType(DataType.Currency)]
        public decimal Total { get; set; }

        [StringLength(50)]
        public string? Status { get; set; }

        [Display(Name = "Payment")]
        [StringLength(50)]
        public string? PaymentStatus { get; set; }

        public DateTime DateTime { get; set; } = DateTime.Now;
        public Customer? Customer { get; set; }
        public Staff? Staff { get; set; }
        public List<PaymentItemList>? PaymentItemLists { get; set; }
        public List<Payment>? Payments { get; set; }
    }
}