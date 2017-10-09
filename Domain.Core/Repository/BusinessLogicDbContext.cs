using System.Data.Entity;
using Domain.Core.Models;

namespace Domain.Core.Repository
{
    public class BusinessLogicDbContext : DbContext
    {
        public BusinessLogicDbContext() : base("DefaultConnection")
        {
            Database.SetInitializer<BusinessLogicDbContext>(null);
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ShoppingCartsProduct> ShoppingCartsProducts { get; set; }
    }
}