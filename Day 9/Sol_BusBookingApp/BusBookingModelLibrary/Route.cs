using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingModelLibrary
{
    public class Route
    {
        public int RouteId { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public Route()
        {
        }
        public Route(int routeId, string origin, string destination)
        {
            RouteId = routeId;
            Origin = origin;
            Destination = destination;
        }
    }
}
