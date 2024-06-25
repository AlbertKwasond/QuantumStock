using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuantumStock.Shared.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Authors")]
        [DisplayName("Author Name")]
        public int AuthorId { get; set; }

        [ForeignKey("Categorys")]
        [Required]
        [DisplayName("Category Name")]
        public int CategorysId { get; set; }

        [Required]
        [StringLength(200)]
        [DisplayName("Product Name")]
        public string? Name { get; set; }

        [StringLength(200)]
        public string? Barcode { get; set; }

        [Required]
        [DisplayName("Total Qty")]
        public int TotalQty { get; set; }

        [Required]
        [DisplayName("Cost Price")]
        public decimal CostPrice { get; set; }

        [Required]
        [DisplayName("Selling Price")]
        public decimal SellingPrice { get; set; }

        public Category? Categorys { get; set; }

        //   public List<Invoice>? Invoices { get; set; }
        public List<PaymentItemList>? PaymentItemLists { get; set; }

        public virtual ICollection<TransferProduct>? TransferProducts { get; set; }

        public List<CartPayment>? CartPayments { get; set; }

        public Author? Authors { get; set; }
    }
}