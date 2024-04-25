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
      
        public int NumberOfSeats { get; set; }
        public Passenger PassengerInfo { get; set; }

        public Booking()
        {
        }

     
        public Booking(int bookingId, Bus bookedBus, int numberOfSeats, Passenger passengerInfo)
        {
            BookingId = bookingId;
            BookedBus = bookedBus;
            
            NumberOfSeats = numberOfSeats;
            PassengerInfo = passengerInfo;
        }
        public override string ToString()
        {
            return "Booking ID: " + BookingId;
        }
        public void GetInputFromConsole(Bus bus,Passenger passenger)
        {
            BookedBus = bus;
            PassengerInfo = passenger;
            Console.WriteLine("Enter the Number of Seats");
            NumberOfSeats=int.Parse(Console.ReadLine());
        }
    }
}
