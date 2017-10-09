using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Core.Models;

namespace Domain.Core.Services.Contracts
{
    public interface IProductService
    {
        Task<List<Product>> GetList();

        string AddToShoppingCart(long productId, string userEmail);
    }
}