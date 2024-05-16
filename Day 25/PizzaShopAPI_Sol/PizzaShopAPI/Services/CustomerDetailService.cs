using PizzaShopAPI.Interfaces;
using PizzaShopAPI.Models;
using PizzaShopAPI.Repositories;

namespace PizzaShopAPI.Services
{
    public class CustomerDetailService : ICustomerDetailService
    {
        private readonly IRepository<int,CustomerDetail> _repository;

        public CustomerDetailService(IRepository<int,CustomerDetail> repository) {
          _repository = repository;
        }
        public  async Task<CustomerDetail> AddCustomerDetail(CustomerDetail customerDetail)
        {
            var result = await _repository.Add(customerDetail);
            if(result != null )
            {
                return result;
            }
            throw new Exception("Customer Detail not added");
        }

        public Task<IEnumerable<CustomerDetail>> GetAllCustomerDetails()
        {
            var results = _repository.GetAll();
            if(results != null)
            {
                return results;
            }
            throw new Exception("No customer details found");
        }
    }
}
