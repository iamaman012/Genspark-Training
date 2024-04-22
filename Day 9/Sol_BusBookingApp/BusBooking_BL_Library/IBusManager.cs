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
        void AddBus(Bus bus);
        void UpdateBus(Bus bus);
        void DeleteBus(int busId);
        List<Bus> SearchForAvailableBuses(string origin, string destination, DateTime departureDate);
    }
}
