using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace QuantumStock.Shared.Models
{
    public class TransferProduct
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Products")]
        public int ProductsId { get; set; }

        public Product? Products { get; set; }

        [StringLength(200)]
        [DisplayName("Product Name")]
        public string? Name { get; set; } = string.Empty;

        [Required]
        public int Qty { get; set; }

        [DisplayName("Selling Price")]
        public decimal SellingPrice { get; set; }

        [DisplayName("Branch Name")]
        public int BranchId { get; set; }

        public Branch? Branch { get; set; }

        [StringLength(200)]
        [DisplayName("Branch Name")]
        public string? BranchName { get; set; } = string.Empty;

        public DateTime Date { get; set; } = DateTime.Now;
    }
}