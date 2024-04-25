using BusBookingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking_BL_Library
{
    public interface IBusManager
    {
        List<Bus> GetAllBuses();
        Bus GetBusById(int busId);
        Bus AddBus(Bus bus);
        Bus UpdateBus(Bus bus);
        Bus DeleteBus(int busId);
        
    }
}
