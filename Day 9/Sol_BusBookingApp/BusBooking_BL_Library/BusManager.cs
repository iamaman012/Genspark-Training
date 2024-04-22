using BusBooking_DAL_Library;
using BusBookingModelLibrary;

namespace BusBooking_BL_Library
{
    public class BusManager : IBusManager
    {
        readonly IRepository<Bus> _busRepository;

        public BusManager(IRepository<Bus> busRepository)
        {
            _busRepository = busRepository;
        }

        public void AddBus(Bus bus)
        {
            _busRepository.Add(bus);
        }

        public void DeleteBus(string busId)
        {
            _busRepository.Delete(busId);
        }

        public List<Bus> GetAllBuses()
        {
            return _busRepository.GetAll();
        }

        public Bus GetBusById(string busId)
        {
            return _busRepository.GetById(busId);
        }

        public void UpdateBus(Bus bus)
        {
            _busRepository.Update(bus);
        }
    }
}
