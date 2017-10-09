using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Core.Models;

namespace Domain.Core.Services.Contracts
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetList(string email);

        CreateOrderData GetOrderData(string email);

        Task ProceedOrder(Order order, string email);
    }
}