using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusBookingModelLibrary;

namespace BusBooking_DAL_Library
{
    public class BusRepository : IRepository<Bus>
    {
        readonly Dictionary<int, Bus> _buses;

        public BusRepository()
        {
            _buses = new Dictionary<int, Bus>();
        }
        public void Add(Bus entity)
        {
            if (!_buses.ContainsValue(entity))
                _buses.Add(entity.BusId, entity);
            else Console.WriteLine("Bus with the same ID Already Exist");
        }

        public void Delete(int id)
        {
            if (_buses.ContainsKey(id))
                _buses.Remove(id);
            else
                Console.WriteLine("Bus not found.");
        }

        public List<Bus> GetAll()
        {
            return new List<Bus>(_buses.Values);
        }

        public Bus GetById(int id)
        {
            if (_buses.ContainsKey(id))
                return _buses[id];
            else
                return null;
        }

        public void Update(Bus entity)
        {
            if (_buses.ContainsKey(entity.BusId))
                _buses[entity.BusId] = entity;
            else
                Console.WriteLine("Bus not found.");
        }
        public int GenerateId()
        {
            if (_buses.Count == 0)
                return 1;
            int id = _buses.Keys.Max();
            return ++id;
        }
    }
}
