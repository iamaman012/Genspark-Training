using BusBookingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking_BL_Library
{
    public interface IPassengerManager
    {
        List<Passenger> GetAllPassengers();
        Passenger GetPassengerById(int passengerId);
        Passenger AddPassenger(Passenger passenger);
        Passenger UpdatePassenger(Passenger passenger);
        Passenger DeletePassenger(int passengerId);
    }
}
