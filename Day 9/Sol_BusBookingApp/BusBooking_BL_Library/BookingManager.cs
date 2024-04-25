using BusBooking_DAL_Library;
using BusBookingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking_BL_Library
{
    public class BookingManager : IBookingManager
    {
        readonly IRepository<int,Booking> _bookingRepository;
        public BookingManager()
        {
            _bookingRepository = new BookingRepository();
        }
        public Booking AddBooking(Booking booking)
        {
            Booking result = _bookingRepository.Add(booking);
            if (result!=null) return result;
            throw new DuplicateBookingException();
        }

        public Booking DeleteBooking(int bookingId)
        {
             Booking result = _bookingRepository.Delete(bookingId);
            if(result!=null) return result;
            throw new BookingNotExistException();
        }

        public List<Booking> GetAllBookings()
        {
            List<Booking> bookings = _bookingRepository.GetAll();
            if(bookings!=null) return bookings;
            throw new BookingNotExistException();

        }

        public Booking GetBookingById(int bookingId)
        {
            Booking result = _bookingRepository.GetById(bookingId);
            if(result!=null) return result; 
            throw new BookingNotExistException();
        }

        public Booking UpdateBooking(Booking booking)
        {
           var result = _bookingRepository.Update(booking);
            if(result != null) return result;
            throw new BookingNotExistException();
        }

      
    }
}
