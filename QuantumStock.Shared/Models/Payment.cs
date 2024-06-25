using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuantumStock.Shared.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        public int OrderId { get; set; }
        public int ReceiptsNum { get; set; }

        [ForeignKey("SalesLists")]
        public int SalesListId { get; set; }

        [DataType(DataType.Currency)]
        public Nullable<decimal> Amount { get; set; }

        [DataType(DataType.Currency)]
        public Nullable<decimal> AmountLeft { get; set; }

        [DataType(DataType.Currency)]
        public decimal Total { get; set; }

        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }

        [StringLength(50)]
        public string? PaidBy { get; set; }

        [Phone]
        public string? MobileNumber { get; set; }

        [StringLength(50)]
        public string? Status { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
        public SalesList SalesLists { get; set; }
    }
}