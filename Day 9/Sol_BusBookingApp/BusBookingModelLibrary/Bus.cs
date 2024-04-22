namespace BusBookingModelLibrary
{
    public class Bus
    {
        public int BusId { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public int AvailableSeats { get; set; }

        public Bus()
        {

        }
        public Bus(int busId, string origin, string destination, DateTime departureTime, int availableSeats)
        {
            BusId = busId;
            Origin = origin;
            Destination = destination;
            DepartureTime = departureTime;
            AvailableSeats = availableSeats;
        }
        public override string ToString()
        {
            return "Bus ID: " + BusId + ", Origin: " + Origin + ", Destination: " + Destination+", Departure Date: "+DepartureTime;
        }
        public void UpdateSeats(int seats)
        {
            AvailableSeats = AvailableSeats-seats;
        }
    }
}
