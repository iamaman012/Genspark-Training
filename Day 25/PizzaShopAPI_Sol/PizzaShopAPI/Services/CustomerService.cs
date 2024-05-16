using PizzaShopAPI.Interfaces;
using PizzaShopAPI.Models;
using PizzaShopAPI.Repositories;

namespace PizzaShopAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<int,Customer> _repository;

        public CustomerService(IRepository<int,Customer> repository)
        {
            _repository = repository;
        }
        public async Task<Customer> AddCustomer(Customer customer)
        {
            var result = await _repository.Add(customer);
            if(result != null   )
            {
                return result;
            }
            throw new Exception("Customer not added");
        }

        public async Task<Customer> DeleteCustomerById(int id)
        {
            var customer = await  _repository.DeleteById(id);  
            if(customer != null )
            {
                return customer;
            }
            throw new Exception("Customer not found");
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            var customers = await _repository.GetAll();
            if(customers != null    )
            {
                return customers;
            }
            throw new Exception("No customers found");
        }

        public  async Task<Customer> GetCustomerById(int id)
        {
            var customer = await _repository.GetById(id);
            if(customer != null )
            {
                return customer;
            }
            throw new Exception("Customer not found");
        }

        public Task<Customer> UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
