using BusBooking_DAL_Library;
using BusBookingModelLibrary;

namespace BusBooking_BL_Library
{
    public class BusManager : IBusManager
    {
        readonly IRepository<Bus> _busRepository;

        public BusManager()
        {
            _busRepository = new BusRepository();
        }

        public void AddBus(Bus bus)
        {
            _busRepository.Add(bus);
        }

        public void DeleteBus(int busId)
        {
            _busRepository.Delete(busId);
        }

        public List<Bus> GetAllBuses()
        {
            return _busRepository.GetAll();
        }

        public Bus GetBusById(int busId)
        {
            return _busRepository.GetById(busId);
        }

        public List<Bus> SearchForAvailableBuses(string origin, string destination, DateTime departureDate)
        {
            List<Bus> buses = _busRepository.GetAll();
            List<Bus> result = new List<Bus>();
            
          foreach (Bus entity in buses) {
               if(entity.Origin==origin && entity.Destination==destination && entity.DepartureTime.Date==departureDate)
                {
                    result.Add(entity);
                }
            }
            return result;
        }

        public void UpdateBus(Bus bus)
        {
            _busRepository.Update(bus);
        }
    }
}
