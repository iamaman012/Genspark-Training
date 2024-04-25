namespace BusBookingModelLibrary
{
    public class Bus
    {
        public int BusId { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public int Price { get; set; }  
        public DateTime DepartureDate { get; set; }
        public int AvailableSeats { get; set; }

       

        public Bus()
        {

        }
        public Bus(int busId, string origin, string destination,int price ,DateTime departureTime, int availableSeats)
        {
            BusId = busId;
            Origin = origin;
            Destination = destination;
            Price = price;
            DepartureDate = departureTime;
            AvailableSeats = availableSeats;
        }
        public override string ToString()
        {
            return "Bus ID: " + BusId + ", Origin: " + Origin + ", Destination: " + Destination+" Price "+Price+", Departure Date: "+DepartureDate;
        }
        public void UpdateSeats(int seats)
        {
            AvailableSeats = AvailableSeats-seats;
        }
        public void InputFromConsole()
        {
            Console.WriteLine("Enter the Bus Origin");
            Origin = Console.ReadLine();
            Console.WriteLine("Enter the Bus Destination");
            Destination = Console.ReadLine();
            Console.WriteLine("Enter the Bus Departure Date");
            DepartureDate=DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Ticket Amount");
            Price = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Available Seats");
            AvailableSeats = int.Parse(Console.ReadLine());
        }
    }
}
