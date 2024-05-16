using PizzaShopAPI.Models;
using PizzaShopAPI.Models.DTOs;

namespace PizzaShopAPI.Interfaces
{
    public interface IUserService
    {

        public Task<ReturnLoginDTO> Login(LoginCustomerDTO loginCustomerDTO);

        public Task<Customer> Register(RegisterCustomerDTO registerCustomerDTO);
    }
}
