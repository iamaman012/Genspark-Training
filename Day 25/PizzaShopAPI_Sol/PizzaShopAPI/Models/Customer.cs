﻿namespace PizzaShopAPI.Models
{
    public class Customer
    {
        public int CId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
