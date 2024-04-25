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
            Console.WriteLine("1. List Buses");
            Console.WriteLine("2. Add Bus");
            //Console.WriteLine("2. Add Rout");
            Console.WriteLine("3. Update bus");
            Console.WriteLine("4. Delete Bus");
            Console.WriteLine("5. Display All Bookings");
            Console.WriteLine("6. Back to Main Menu");
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
                        AddBus();
                        break;
                    case 3:
                        UpdateBus();    
                        break;

                    case 4:
                        DeleteBus();
                        break;
                    case 5:
                        DisplayAllBooking();
                        break;
                    case 6:
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
                        BookTicket();
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
            Bus bus = new Bus();
            bus.InputFromConsole();
            Bus result= busManager.AddBus(bus);
            Console.WriteLine(result);
           
        }
        static void ListBuses()
        {
            // Call BL method to get all buses
            try
            {
                var buses = busManager.GetAllBuses();
                Console.WriteLine("Available Buses:");
                foreach (var bus in buses)
                {
                    Console.WriteLine(bus);
                }

            }
            catch(BusNotExistException ex)
            {
                Console.WriteLine(ex.Message);
            }

          
            
        }
        static void UpdateBus()
        {
            Console.WriteLine("Enter the Bus Id");
            int Id = int.Parse(Console.ReadLine());
            Bus bus = new Bus()
            {
                BusId = Id
            };

            bus.InputFromConsole();
            try { 
              Bus result = busManager.UpdateBus(bus);
                Console.WriteLine(result);
            }
            catch(BusNotExistException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            DisplayAdminMenu(); 
        }

       static void DeleteBus()
        {
            Console.WriteLine("Enter the Bus Id");
            int id = int.Parse(Console.ReadLine());
            try
            {
                Bus result = busManager.DeleteBus(id);
                Console.WriteLine(result);
            }
            catch(BusNotExistException ex)
            {
                Console.WriteLine(ex.Message);
            }
           
            DisplayAdminMenu();
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
       
        public static void BookTicket()
        {
            Console.WriteLine("Booking Ticket:");

            Console.WriteLine("Enter the Origin");
            string origin = Console.ReadLine();
            Console.WriteLine("Enter the Destination");
            string destination= Console.ReadLine();
            Console.WriteLine("Enter the Departure Date");
            DateTime departureDate = DateTime.Parse(Console.ReadLine());
            try
            {
                List<Bus> buses = busManager.GetAllBuses();
                List<Bus> UserBuses = new List<Bus>();
                foreach (Bus bu in buses)
                {
                    if (bu.Origin == origin && bu.Destination == destination && bu.DepartureDate == departureDate) UserBuses.Add(bu);
                }
                foreach(Bus bu in UserBuses)
                {
                    Console.WriteLine(bu);
                }
                Console.WriteLine("Enter the bus Id for booking");
                int busId = int.Parse(Console.ReadLine());
                Bus BookingBus = busManager.GetBusById(busId);
                Passenger passenger = new Passenger();
                passenger.GetInputFromConsole();
                Passenger BookingPass = passengerManager.AddPassenger(passenger);
                Booking booking = new Booking();
                booking.GetInputFromConsole(BookingBus, BookingPass);
                Booking NBooking = bookingManager.AddBooking(booking);
                Console.WriteLine(NBooking);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
           // Console.WriteLine("Enter the bus Id for booking");
           // int busId = int.Parse(Console.ReadLine());
           // Bus BookingBus = busManager.GetBusById(busId);
           // Passenger passenger = new Passenger();
           // passenger.GetInputFromConsole();
           //Passenger BookingPass= passengerManager.AddPassenger(passenger);
           // Booking booking = new Booking();
           // booking.GetInputFromConsole(BookingBus,BookingPass );
           // Booking NBooking=bookingManager.AddBooking(booking);
           // Console.WriteLine(NBooking);









            DisplayUserMenu();
        }

       static void DisplayAllBooking()
        {
            try
            {
                List<Booking> bookings = bookingManager.GetAllBookings();
                foreach (Booking booking in bookings)
                {
                    Console.WriteLine(booking);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
               Booking booking= bookingManager.DeleteBooking(BookId);
                Console.WriteLine(booking);
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
