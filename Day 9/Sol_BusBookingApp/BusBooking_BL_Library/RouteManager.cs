using BusBooking_DAL_Library;
using BusBookingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking_BL_Library
{
    public class RouteManager : IRouteManager
    {
        readonly IRepository<Route> _routeRepository;

        public RouteManager()
        {
            _routeRepository = new RouteRepository();
        }
        public void AddRoute(Route route)
        {
            _routeRepository.Add(route);
        }

        public void DeleteRoute(int routeId)
        {
            _routeRepository.Delete(routeId);
        }

        public List<Route> GetAllRoutes()
        {
            return _routeRepository.GetAll();
        }

        public Route GetRouteById(int routeId)
        {
            return _routeRepository.GetById(routeId);
        }

        public void UpdateRoute(Route route)
        {
            _routeRepository.Update(route);
        }
    }
}
