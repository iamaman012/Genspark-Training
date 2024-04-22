using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusBookingModelLibrary;

namespace BusBooking_DAL_Library
{
    public class RouteRepository : IRepository<Route>
    {
        readonly Dictionary<string, Route> _routes;
        public RouteRepository()
        {
            _routes = new Dictionary<string, Route>();
        }
        public void Add(Route entity)
        {
            if (!_routes.ContainsKey(entity.RouteId))
                _routes.Add(entity.RouteId, entity);
            else
                Console.WriteLine("Route with the same ID already exists."); 
        }

        public void Delete(string id)
        {
            if (_routes.ContainsKey(id))
                _routes.Remove(id);
            else
                Console.WriteLine("Route not found."); 
        }

        public List<Route> GetAll()
        {
            return new List<Route>(_routes.Values);
        }

        public Route GetById(string id)
        {
            if (_routes.ContainsKey(id))
                return _routes[id];
            else
                return null;
        }

        public void Update(Route entity)
        {
            if (_routes.ContainsKey(entity.RouteId))
                _routes[entity.RouteId] = entity;
            else
                Console.WriteLine("Route not found."); 
        }
    }
}
