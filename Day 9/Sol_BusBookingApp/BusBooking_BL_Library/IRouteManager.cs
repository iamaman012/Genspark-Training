using BusBookingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking_BL_Library
{
    public interface IRouteManager
    {
        List<Route> GetAllRoutes();
        Route GetRouteById(int routeId);
        void AddRoute(Route route);
        void UpdateRoute(Route route);
        void DeleteRoute(int routeId);
    }
}
