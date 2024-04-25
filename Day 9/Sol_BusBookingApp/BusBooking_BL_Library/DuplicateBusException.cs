using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking_BL_Library
{
    public class DuplicateBusException : Exception
    {
        string msg;
        public DuplicateBusException()
        {
            msg = "Bus Already Exist";
        }
        public override string Message => msg;
    }
}
