using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking_BL_Library
{
    public class DuplicateBookingException : Exception
    {
        string msg;
        public DuplicateBookingException()
        {
            msg = "Booking Already Exist";
        }
        public override string Message => msg;
    }
}
