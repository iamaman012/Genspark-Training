using PizzaShopAPI.Models;

namespace PizzaShopAPI.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(Customer customer);
    }
}
