namespace BusBookingModelLibrary
{
    public class Bus
    {
        public string BusId { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public int AvailableSeats { get; set; }

        public Bus()
        {

        }
        public Bus(string busId, string origin, string destination, DateTime departureTime, int availableSeats)
        {
            BusId = busId;
            Origin = origin;
            Destination = destination;
            DepartureTime = departureTime;
            AvailableSeats = availableSeats;
        }
    }
}
