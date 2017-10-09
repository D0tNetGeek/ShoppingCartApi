using System.Linq;
using Domain.Core.Models;
using Domain.Core.Repository;
using Domain.Core.Services.Contracts;

namespace Domain.Core.Services.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly IBusinessLogicRepository _repository;

        public CustomerService(IBusinessLogicRepository repository)
        {
            _repository = repository;
        }

        public void Create(string email)
        {
            _repository.Add(new Customer
            {
                CustomerType = (short)CustomerType.Standard,
                Name = email,
                Email = email
            });
            _repository.SaveChangesSync();
        }

        public Customer GetInfo(string email)
        {
            return _repository.Query<Customer>().SingleOrDefault(x => x.Email == email);
        }
    }
}