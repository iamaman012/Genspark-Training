using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking_BL_Library
{
    public class BusNotExistException : Exception
    {
        string msg;
        public BusNotExistException()
        {
            msg = "Bus does not Exist";
        }
        public override string Message => msg;
    }
}
