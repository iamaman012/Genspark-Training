using BusBooking_DAL_Library;
using BusBookingModelLibrary;

namespace BusBooking_BL_Library
{
    public class BusManager : IBusManager
    {
        readonly IRepository<int,Bus> _busRepository;

        public BusManager()
        {
            _busRepository = new BusRepository();
        }

        public Bus AddBus(Bus bus)
        {
            Bus result = _busRepository.Add(bus);
            if(result!=null) return result;
            throw new DuplicateBusException();

        }

        public Bus DeleteBus(int busId)
        {
          Bus result=  _busRepository.Delete(busId);
            if(result!=null) return result;
            throw new BusNotExistException();
        }

        public List<Bus> GetAllBuses()
        {
            List<Bus> buses = _busRepository.GetAll();
            if(buses!=null) return buses;
            throw new BusNotExistException();
        }

        public Bus GetBusById(int busId)
        {
            Bus bus = _busRepository.GetById(busId);
            if(bus!=null) return bus;
            throw new BusNotExistException();
        }

       

        public Bus UpdateBus(Bus bus)
        {
            Bus result = _busRepository.Update(bus);
            if(result!=null) return result;
            throw new BusNotExistException();
        }

       
        
    }
}
