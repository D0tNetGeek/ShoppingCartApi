using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Core.Models
{
    [Table("Product")]
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string ProductCode { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }
    }
}