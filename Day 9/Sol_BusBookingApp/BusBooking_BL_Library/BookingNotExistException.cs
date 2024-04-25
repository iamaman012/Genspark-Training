using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking_BL_Library
{
    public class BookingNotExistException:Exception
    {
        string msg;
        public BookingNotExistException()
        {
            msg = "Booking does not  Exist";
        }
        public override string Message => msg;
    }
}
