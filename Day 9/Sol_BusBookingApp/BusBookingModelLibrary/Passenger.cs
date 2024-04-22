using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingModelLibrary
{
    public class Passenger
    {
        public string Name { get; set; }
        public string ContactInfo { get; set; }

        public Passenger()
        {
        }

        public Passenger(string name, string contactInfo)
        {
            Name = name;
            ContactInfo = contactInfo;
        }
    }
}
