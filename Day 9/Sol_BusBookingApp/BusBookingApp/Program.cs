using BusBookingModelLibrary;
using BusBooking_BL_Library;
using BusBooking_DAL_Library;

using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
namespace BusBookingApp
{
    internal class Program
    {
        static IBusManager busManager;
        
        static IPassengerManager passengerManager;
        static IBookingManager bookingManager;

        static void DisplayMainMenu()
        {
            Console.WriteLine("Welcome to Bus Booking System!");
            Console.WriteLine("1. Admin Functionality");
            Console.WriteLine("2. User Functionality");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        DisplayAdminMenu();
                        break;
                    case 2:
                        DisplayUserMenu();
                        break;
                    case 3:
                        Console.WriteLine("Thank you for using Bus Booking System. Goodbye!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

            // Display menu again
            DisplayMainMenu();
        }
        static void DisplayAdminMenu()
        {
            Console.WriteLine("Admin Functionality:");
            Console.WriteLine("1. Add Bus");
            //Console.WriteLine("2. Add Rout");
            Console.WriteLine("2. Display All Bookings");
            Console.WriteLine("3. Back to Main Menu");
            Console.Write("Enter your choice: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        AddBus();
                        break;
                    
                    case 2:
                        DisplayAllBooking();
                        break;
                    case 3:
                        DisplayMainMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

            // Display menu again
            DisplayAdminMenu();
        }
        static void DisplayUserMenu()
        {
            Console.WriteLine("User Functionality:");
            Console.WriteLine("1. List Buses");
            Console.WriteLine("2. Book Ticket");
            Console.WriteLine("3. Cancel Booking");
            Console.WriteLine("4. Back to Main Menu");
            Console.Write("Enter your choice: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        ListBuses();
                        break;
                    case 2:
                        SearchForBuses();
                        break;
                    case 3:
                        CancelTicket();
                        break;
                    case 4:
                        DisplayMainMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

            // Display menu again
            DisplayUserMenu();
        }
        static void AddBus()
        {
            Console.WriteLine("Adding a New Bus:");

            //Console.Write("Enter Bus ID: ");
            //int busId = int.Parse(Console.ReadLine());
            IRepository<Bus> busRepository = new BusRepository();
            int busId = busRepository.GenerateId();

            Console.Write("Enter Origin: ");
            string origin = Console.ReadLine();

            Console.Write("Enter Destination: ");
            string destination = Console.ReadLine();

            Console.Write("Enter Departure Time (YYYY-MM-DD HH:MM): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime departureTime))
            {
                Console.Write("Enter Available Seats: ");
                if (int.TryParse(Console.ReadLine(), out int availableSeats))
                {
                    Bus bus = new Bus
                    {
                        BusId = busId,
                        Origin = origin,
                        Destination = destination,
                        DepartureTime = departureTime,
                        AvailableSeats = availableSeats
                    };

                    // Call BL method to add the bus
                    busManager.AddBus(bus);

                    Console.WriteLine("Bus added successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid input for available seats. Please enter a number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for departure time. Please enter a valid date and time (YYYY-MM-DD HH:MM).");
            }
        }
        static void ListBuses()
        {
            // Call BL method to get all buses
            var buses = busManager.GetAllBuses();

            if (buses.Count == 0)
            {
                Console.WriteLine("No buses are currently available.");
            }
            else
            {
                Console.WriteLine("Available Buses:");
                foreach (var bus in buses)
                {
                    Console.WriteLine($"Bus ID: {bus.BusId}, Origin: {bus.Origin}, Destination: {bus.Destination}, Departure Time: {bus.DepartureTime}, Available Seats: {bus.AvailableSeats}");
                }
            }
        }
        //static void AddRoute()
        //{
        //    Console.WriteLine("Adding a New Route:");

        //    Console.Write("Enter Route ID: ");
        //    int routeId = int.Parse(Console.ReadLine());

        //    Console.Write("Enter Origin: ");
        //    string origin = Console.ReadLine();

        //    Console.Write("Enter Destination: ");
        //    string destination = Console.ReadLine();

        //    // Create a new route
        //    Route route = new Route
        //    {
        //        RouteId = routeId,
        //        Origin = origin,
        //        Destination = destination
        //    };

        //    // Call BL method to add the route
        //    routeManager.AddRoute(route);

        //    Console.WriteLine("Route added successfully!");
        //}
        static void SearchForBuses()
        {
            Console.WriteLine("Search for Available Buses:");

            Console.Write("Enter Origin: ");
            string origin = Console.ReadLine();

            Console.Write("Enter Destination: ");
            string destination = Console.ReadLine();

            Console.Write("Enter Departure Date (YYYY-MM-DD): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime departureDate))
            {
                // Call BL method to search for available buses
                var availableBuses = busManager.SearchForAvailableBuses(origin, destination, departureDate);

                if (availableBuses.Count == 0)
                {
                    Console.WriteLine("No available buses found for the given criteria.");
                }
                else
                {
                    Console.WriteLine("Available Buses:");
                    foreach (var bus in availableBuses)
                    {
                        Console.WriteLine($"Bus ID: {bus.BusId}, Origin: {bus.Origin}, Destination: {bus.Destination}, Departure Time: {bus.DepartureTime}, Available Seats: {bus.AvailableSeats}");
                    }
                    BookTicket();
                }
            }
            else
            {
                Console.WriteLine("Invalid input for departure date. Please enter a valid date (YYYY-MM-DD).");
            }
        }
        public static void BookTicket()
        {
            Console.WriteLine("Booking Ticket:");

            // Prompt user for necessary information
            Console.Write("Enter Bus ID: ");
            int busId = int.Parse(Console.ReadLine());
            Console.Write("Enter Number of Seats: ");
            if (int.TryParse(Console.ReadLine(), out int numberOfSeats))
            {
                //Console.WriteLine("Enter the Passenger Id");
                //int Pid = int.Parse(Console.ReadLine());
                IRepository<Passenger> PassRepository = new PassengerRepository();
                int Pid=PassRepository.GenerateId();
                Console.Write("Enter Passenger Name: ");
                string passengerName = Console.ReadLine();
                Console.WriteLine("Enter the Passenger Contact Number");
                string ContactNumber = Console.ReadLine();

                Bus bus = busManager.GetBusById(busId);
                bus.UpdateSeats(numberOfSeats);
                Passenger passenger = new Passenger(Pid, passengerName, ContactNumber);
                Booking booking = new Booking(Pid,bus,bus.DepartureTime,numberOfSeats,passenger);
                bookingManager.AddBooking(booking);
                Console.WriteLine("Ticket Booked Successfully");


            }
           
          else  {
                Console.WriteLine("Invalid input for number of seats. Please enter a number.");
            }
            DisplayUserMenu();
        }

       static void DisplayAllBooking()
        {
            List<Booking> booking= bookingManager.GetAllBookings();
            if (booking.Count == 0)
            {
                Console.WriteLine("No Bookings");
            }
            else
            {
                foreach (Booking book in booking)
                {

                    Console.WriteLine("Booking Id: " + book.BookingId +", "+ book.BookedBus  + ", Number of Seats " + book.NumberOfSeats + ", "+ book.PassengerInfo);
                }
            }
            DisplayAdminMenu();

        }
       static void CancelTicket()
        {
            Console.WriteLine("Enter the Booking Id for Cancellation");
            int BookId = int.Parse(Console.ReadLine());
            if (bookingManager.GetBookingById(BookId) == null)
            {
                Console.WriteLine("No Booking with this id");
                
            }
            else
            {
                bookingManager.DeleteBooking(BookId);
                Console.WriteLine("Ticket Cancelled Successfully");
            }
            DisplayUserMenu();
           
        }


        static void Main(string[] args)
        {
            busManager = new BusManager();
            
            passengerManager = new PassengerManager();
            bookingManager = new BookingManager();
            DisplayMainMenu();



        }
    }
}
