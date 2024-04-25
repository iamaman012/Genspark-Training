using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusBookingModelLibrary;

namespace BusBooking_DAL_Library
{
    public class BusRepository : IRepository<int,Bus>
    {
        readonly Dictionary<int, Bus> _buses;

        public BusRepository()
        {
            _buses = new Dictionary<int, Bus>();
        }
        public Bus Add(Bus entity)
        {
            if (!_buses.ContainsValue(entity))
            {
                entity.BusId = GenerateId();
                _buses.Add(entity.BusId, entity);
                return entity;
            }
            return null;
        }

        public Bus Delete(int id)
        {
            if (_buses.ContainsKey(id))
            {
                Bus bus = _buses[id];
                _buses.Remove(id);
                return bus;
            }
            return null;
        }

        public List<Bus> GetAll()
        {
            if (_buses.Count == 0) return null;
            return _buses.Values.ToList();

        }

        public Bus GetById(int id)
        {
            if (_buses.ContainsKey(id))
                return _buses[id];
            else
                return null;
        }

        public Bus Update(Bus entity)
        {
            if (_buses.ContainsKey(entity.BusId))
            {
                _buses[entity.BusId] = entity;
                return entity;  

            }
            return null;
        }
        public int GenerateId()
        {
            if (_buses.Count == 0)
                return 201;
            int id = _buses.Keys.Max();
            return ++id;
        }
    }
}
