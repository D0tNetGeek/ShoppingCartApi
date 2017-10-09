using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core.ExternalModules.Contracts;
using Domain.Core.Models;
using Domain.Core.Repository;
using Domain.Core.Services.Contracts;
using NLog;

namespace Domain.Core.Services.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IBusinessLogicRepository _repository;
        private readonly ILogger _logger;
        private readonly ISmtpSender _smtpSender;
        private readonly ICourierSender _courierSender;

        public OrderService(IBusinessLogicRepository repository, ISmtpSender smtpSender, ICourierSender courierSender)
        {
            _repository = repository;
            _smtpSender = smtpSender;
            _courierSender = courierSender;
            _logger = LogManager.GetCurrentClassLogger();
        }
        
        public async Task<IEnumerable<Order>> GetList(string email)
        {
            return await _repository.Query<Order>()
                .Include(x => x.ShoppingCart)
                .Where(x => x.ShoppingCart.Customer.Email == email)
                .ToListAsync();
        }

        public CreateOrderData GetOrderData(string email)
        {
            var shoppingCart = _repository.Query<ShoppingCart>()
                .Include(x => x.Customer)
                .Single(x => x.Customer.Email == email);

            var shoppingCartProducts = _repository.Query<ShoppingCartsProduct>()
                .Include(x => x.Product)
                .Include(x => x.ShoppingCart)
                .Where(x => x.ShoppingCartId == shoppingCart.Id)
                .ToArray();

            return new CreateOrderData
            {
                ShoppingCartId = shoppingCart.Id,
                ShoppingListItemsCount = shoppingCartProducts.Length,
                TotalAmount = shoppingCartProducts.Select(x => x.Product.UnitPrice).Aggregate((a, b) => a + b)
            };
        }

        public async Task ProceedOrder(Order order, string email)
        {
            _repository.Add(order);
            await _repository.SaveChanges();

            var shoppingCartId = order.ShoppingCartId;

            var shoppingCartProducts = _repository.Query<ShoppingCartsProduct>()
                .Where(x => x.ShoppingCartId == shoppingCartId)
                .ToArray();

            foreach (var shoppingCartProduct in shoppingCartProducts)
            {
                _repository.Remove(shoppingCartProduct);
            }

            await _repository.SaveChanges();

            var customer = _repository.Query<Customer>().Single(x => x.Email == email);

            customer.MoneySpent += order.Amount;

            if (customer.MoneySpent >= 500 && customer.MoneySpent < 800)
                customer.CustomerType = (short)CustomerType.Silver;
            if (customer.MoneySpent >= 800)
                customer.CustomerType = (short)CustomerType.Gold;

            await _repository.SaveChanges();

            _logger.Info("Order has been proceed successfully");
            _smtpSender.Send(email, "Thank you very much, your order has been successfully created");
            _courierSender.Send("courier@gmail.com", $"Order {order.Id} has been successfully created by user {email}. Take it to work!");
        }
    }
}