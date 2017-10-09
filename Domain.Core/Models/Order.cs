using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Core.Models
{
    [Table("Order")]
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long ShoppingCartId { get; set; }

        [ForeignKey(nameof(ShoppingCartId))]
        public ShoppingCart ShoppingCart { get; set; }

        public DateTime Date { get; set; }

        public string Address { get; set; }

        public decimal Amount { get; set; }
    }
}