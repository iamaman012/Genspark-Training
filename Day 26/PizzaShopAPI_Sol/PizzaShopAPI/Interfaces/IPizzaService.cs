using PizzaShopAPI.Models;
using PizzaShopAPI.Models.DTOs;

namespace PizzaShopAPI.Interfaces
{
    public interface IPizzaService
    {
        public Task<IEnumerable<Pizza>> GetAllPizzas();

        public Task<IEnumerable<Pizza>> GetAllPizzasInStock();

        public Task<Pizza> GetPizzaById(int id);

        public Task<Pizza> AddPizza(AddPizzaDTO pizza);

        public Task<Pizza> UpdatePizza(Pizza pizza);

        public Task<Pizza> DeletePizzaById(int id);
    }
}
