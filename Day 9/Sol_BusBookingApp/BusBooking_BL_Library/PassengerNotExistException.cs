using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking_BL_Library
{
    public class PassengerNotExistException : Exception
    {
        string msg;
        public PassengerNotExistException()
        {
            msg = "Passenger does not Exist";
        }
        public override string Message => msg;
    }
}
