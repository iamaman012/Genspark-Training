using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusBookingModelLibrary;
namespace BusBooking_DAL_Library
{
    public class BookingRepository : IRepository<Booking>
    {
        readonly Dictionary<int, Booking> _bookings;

        public BookingRepository()
        {
            _bookings = new Dictionary<int, Booking>();
        }
        public void Add(Booking entity)
        {
            if (!_bookings.ContainsKey(entity.BookingId))
                _bookings.Add(entity.BookingId, entity);
            else
                Console.WriteLine("Booking with the same ID already exists.");
        }

        public void Delete(int id)
        {
            if (_bookings.ContainsKey(id))
                _bookings.Remove(id);
            else
                Console.WriteLine("Booking not found.");
        }

        public List<Booking> GetAll()
        {
            return new List<Booking>(_bookings.Values);
        }

        public Booking GetById(int id)
        {
            if (_bookings.ContainsKey(id))
                return _bookings[id];
            else
                return null;
        }

        public void Update(Booking entity)
        {
            if (_bookings.ContainsKey(entity.BookingId))
                _bookings[entity.BookingId] = entity;
            else
                Console.WriteLine("Booking not found.");
        }
        public int GenerateId()
        {
            if (_bookings.Count == 0)
                return 1;
            int id = _bookings.Keys.Max();
            return ++id;
        }
    }
}
