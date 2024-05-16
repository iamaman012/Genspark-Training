using PizzaShopAPI.Models;
using PizzaShopAPI.Models.DTOs;

namespace PizzaShopAPI.Interfaces
{
    public interface ICustomerDetailService
    {
        public Task<IEnumerable<CustomerDetail>> GetAllCustomerDetails();

        public Task<CustomerDetail> AddCustomerDetail(CustomerDetail customerDetail);

    }
}
