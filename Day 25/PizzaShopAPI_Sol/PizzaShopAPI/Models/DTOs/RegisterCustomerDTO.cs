namespace PizzaShopAPI.Models.DTOs
{
    public class RegisterCustomerDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public string Password { get; set; }    
    }
}
