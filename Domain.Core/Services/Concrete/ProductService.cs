using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core.Models;
using Domain.Core.Repository;
using Domain.Core.Services.Contracts;
using NLog;

namespace Domain.Core.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IBusinessLogicRepository _repository;
        private readonly ILogger _logger;

        public ProductService(IBusinessLogicRepository repository)
        {
            _repository = repository;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public async Task<List<Product>> GetList()
        {
            return await _repository.Query<Product>().ToListAsync();
        }

        public string AddToShoppingCart(long productId, string userEmail)
        {
            var customer = _repository.Query<Customer>().Single(x => x.Email == userEmail);

            var shoppingCart = _repository.Query<ShoppingCart>().Single(x => x.CustomerId == customer.Id);

            if (_repository.Query<ShoppingCartsProduct>().Any(x => x.ProductId == productId && x.ShoppingCartId == shoppingCart.Id))
            {
                _logger.Info($"Item {productId} has been added already to the shopping cart");
                return "Item has been added already to the shopping cart";
            }

            shoppingCart.Quantity += 1;

            _repository.Add(new ShoppingCartsProduct
            {
                ProductId = productId,
                ShoppingCartId = shoppingCart.Id
            });
            _repository.SaveChanges();

            _logger.Info($"Item {productId} has been added successfully to the shopping cart");
            return "Item has been added successfully to the shopping cart";
        }
    }
}