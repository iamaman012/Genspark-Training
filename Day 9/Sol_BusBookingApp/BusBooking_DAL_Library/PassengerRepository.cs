using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusBookingModelLibrary;
namespace BusBooking_DAL_Library
{
    public class PassengerRepository : IRepository<int,Passenger>
    {
        readonly Dictionary<int, Passenger> _passengers;

        public PassengerRepository()
        {
            _passengers = new Dictionary<int, Passenger>();
        }
        public Passenger Add(Passenger entity)
        {
            if (!_passengers.ContainsKey(entity.Id))
            {entity.Id = GenerateId();
                _passengers.Add(entity.Id, entity);
                return entity;

            }
            return null;
        }

        public Passenger Delete(int id)
        {
            if (_passengers.ContainsKey(id))
            {
                var patient = _passengers[id];  
                _passengers.Remove(id);
                return patient;
            }
            return null;
        }

        public List<Passenger> GetAll()
        {
            if (_passengers.Count == 0) return null;
            return _passengers.Values.ToList(); 
        }

        public Passenger GetById(int id)
        {
            if (_passengers.ContainsKey(id))
                return _passengers[id];
            else
                return null;
        }

        public Passenger Update(Passenger entity)
        {
            if (_passengers.ContainsKey(entity.Id))
            {

                _passengers[entity.Id] = entity;
                return entity;
            }
            return null;
        }
       public int GenerateId()
        {
            if (_passengers.Count == 0)
                return 301;
            int id = _passengers.Keys.Max();
            return ++id;
        }
    }
}
