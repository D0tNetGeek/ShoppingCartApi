using Domain.Core.Models;

namespace Domain.Core.Services.Contracts
{
    public interface ICustomerService
    {
        void Create(string email);

        Customer GetInfo(string email);
    }
}