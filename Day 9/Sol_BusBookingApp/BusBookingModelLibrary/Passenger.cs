using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingModelLibrary
{
    public class Passenger
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; }

        public Passenger()
        {
        }

        public Passenger(int id,string name, string contactInfo)
        {
            Id = id;
            Name = name;
            ContactInfo = contactInfo;
        }
        public override string ToString()
        {
            return "Passenger ID: " + Id + ", Passenger Name: " + Name + ", Contact Info: " + ContactInfo;
        }
        public void GetInputFromConsole()
        {
            Console.WriteLine("Enter the Passenger Name");
            Name = Console.ReadLine();
            Console.WriteLine("Enter the Passenger Contact Number");
            ContactInfo = Console.ReadLine();
        }
    }
}
