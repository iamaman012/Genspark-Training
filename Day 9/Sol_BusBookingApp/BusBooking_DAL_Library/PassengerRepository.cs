using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusBookingModelLibrary;
namespace BusBooking_DAL_Library
{
    public class PassengerRepository : IRepository<Passenger>
    {
        readonly Dictionary<string, Passenger> _passengers;

        public PassengerRepository()
        {
            _passengers = new Dictionary<string, Passenger>();
        }
        public void Add(Passenger entity)
        {
            if (!_passengers.ContainsKey(entity.Id))
                _passengers.Add(entity.Id, entity);
            else
                Console.WriteLine("Passenger with the same ID already exists.");
        }

        public void Delete(string id)
        {
            if (_passengers.ContainsKey(id))
                _passengers.Remove(id);
            else
                Console.WriteLine("Passenger not found.");
        }

        public List<Passenger> GetAll()
        {
            return new List<Passenger>(_passengers.Values);
        }

        public Passenger GetById(string id)
        {
            if (_passengers.ContainsKey(id))
                return _passengers[id];
            else
                return null;
        }

        public void Update(Passenger entity)
        {
            if (_passengers.ContainsKey(entity.Id))
                _passengers[entity.Id] = entity;
            else
                Console.WriteLine("Passenger not found.");
        }
    }
}
