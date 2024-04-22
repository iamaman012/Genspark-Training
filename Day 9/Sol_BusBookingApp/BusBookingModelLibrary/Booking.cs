using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingModelLibrary
{
    public class Booking
    {
        public int BookingId { get; set; }
        public Bus BookedBus { get; set; }
        public DateTime DepartureDate { get; set; }
        public int NumberOfSeats { get; set; }
        public Passenger PassengerInfo { get; set; }

        public Booking()
        {
        }

     
        public Booking(int bookingId, Bus bookedBus, DateTime departureDate, int numberOfSeats, Passenger passengerInfo)
        {
            BookingId = bookingId;
            BookedBus = bookedBus;
            DepartureDate = departureDate;
            NumberOfSeats = numberOfSeats;
            PassengerInfo = passengerInfo;
        }
    }
}
