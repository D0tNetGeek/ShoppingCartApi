using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Core.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Name { get; set; }

        public short CustomerType { get; set; }

        [MinLength(10), MaxLength(200)]
        public string Address { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public decimal MoneySpent { get; set; }
    }
}