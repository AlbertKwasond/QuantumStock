using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumStock.Shared.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Fullname { get; set; }

        [Required]
        [StringLength(25)]
        public string Gender { get; set; }

        public List<Product>? Products { get; set; }
    }
}