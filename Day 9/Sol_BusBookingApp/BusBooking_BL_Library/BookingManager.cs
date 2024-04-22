using BusBooking_DAL_Library;
using BusBookingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking_BL_Library
{
    public class BookingManager : IBookingManger
    {
        readonly IRepository<Booking> _bookingRepository;
        public BookingManager(IRepository<Booking> bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public void AddBooking(Booking booking)
        {
            _bookingRepository.Add(booking);
        }

        public void DeleteBooking(string bookingId)
        {
            _bookingRepository.Delete(bookingId);
        }

        public List<Booking> GetAllBookings()
        {
            return _bookingRepository.GetAll();
        }

        public Booking GetBookingById(string bookingId)
        {
            return _bookingRepository.GetById(bookingId);
        }

        public void UpdateBooking(Booking booking)
        {
            _bookingRepository.Update(booking);
        }
    }
}
