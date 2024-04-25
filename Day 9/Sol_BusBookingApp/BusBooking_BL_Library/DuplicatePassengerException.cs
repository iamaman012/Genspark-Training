using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking_BL_Library
{
    public class DuplicatePassengerException:Exception
    {
        string msg;
        public DuplicatePassengerException()
        {
            msg = "Passenger Already Exist";
        }
        public override string Message => msg;
    }
}
