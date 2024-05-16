namespace PizzaShopAPI.Models.DTOs
{
    public class AddPizzaDTO
    {   
       
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

    }
}
