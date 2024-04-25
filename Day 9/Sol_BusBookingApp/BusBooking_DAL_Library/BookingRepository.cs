using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusBookingModelLibrary;
namespace BusBooking_DAL_Library
{
    public class BookingRepository : IRepository<int,Booking>
    {
        readonly Dictionary<int, Booking> _bookings;

        public BookingRepository()
        {
            _bookings = new Dictionary<int, Booking>();
        }
        public Booking Add(Booking entity)
        {
            if (!_bookings.ContainsKey(entity.BookingId))
            {
                entity.BookingId = GenerateId();
                _bookings.Add(entity.BookingId, entity);
                return entity;
            }

            return null;
        }

        public Booking Delete(int id)
        {
            if (_bookings.ContainsKey(id))
            {
                Booking booking = _bookings[id];
                _bookings.Remove(id);   
                return booking;
            }

            return null;
        }

        public List<Booking> GetAll()
        {
            if (_bookings.Count == 0) return null;
            return _bookings.Values.ToList();   
        }

        public Booking GetById(int id)
        {
            if (_bookings.ContainsKey(id))
                return _bookings[id];
            else
                return null;
        }

        public Booking Update(Booking entity)
        {

            if (_bookings.ContainsKey(entity.BookingId))
            {
                _bookings[entity.BookingId] = entity;
                return entity;
            }
            return null;
        }
        public int GenerateId()
        {
            if (_bookings.Count == 0)
                return 101;
            int id = _bookings.Keys.Max();
            return ++id;
        }

       
    }
}
