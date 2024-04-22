using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingModelLibrary
{
    public class Passenger
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; }

        public Passenger()
        {
        }

        public Passenger(string id,string name, string contactInfo)
        {
            Id = Id;
            Name = name;
            ContactInfo = contactInfo;
        }
    }
}
