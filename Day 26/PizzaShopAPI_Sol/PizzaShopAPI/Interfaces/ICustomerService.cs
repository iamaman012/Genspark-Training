using PizzaShopAPI.Models;

namespace PizzaShopAPI.Interfaces
{
    public interface ICustomerService
    {
        public Task<IEnumerable<Customer>> GetAllCustomers();

        public Task<Customer> GetCustomerById(int id);

        public Task<Customer> AddCustomer(Customer customer);

        public Task<Customer> UpdateCustomer(Customer customer);

        public Task<Customer> DeleteCustomerById(int id);
    }
}
