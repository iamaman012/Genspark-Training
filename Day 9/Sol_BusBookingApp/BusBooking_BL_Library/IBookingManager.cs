using BusBookingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking_BL_Library
{
    public interface IBookingManager
    {
        List<Booking> GetAllBookings();
        Booking GetBookingById(int bookingId);
        Booking AddBooking(Booking booking);
        Booking UpdateBooking(Booking booking);
        Booking DeleteBooking(int bookingId);
    }
}
