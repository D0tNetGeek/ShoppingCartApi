using Domain.Core.Models;
using Domain.Core.Repository;
using Domain.Core.Services.Contracts;

namespace Domain.Core.Services.Concrete
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IBusinessLogicRepository _repository;

        public ShoppingCartService(IBusinessLogicRepository repository)
        {
            _repository = repository;
        }

        public void Create(long customerId)
        {
            _repository.Add(new ShoppingCart
            {
                CustomerId = customerId,
                Quantity = 0,
                UnitPrice = 0.0m
            });
            _repository.SaveChanges();
        }
    }
}