using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Core.Models
{
    [Table("ShoppingCartsProducts")]
    public class ShoppingCartsProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey(nameof(ShoppingCartId))]
        public ShoppingCart ShoppingCart { get; set; }

        public long ShoppingCartId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        public long ProductId { get; set; }
    }
}