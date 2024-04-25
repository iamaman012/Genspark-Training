using BusBooking_DAL_Library;
using BusBookingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking_BL_Library
{
    public class PassengerManager : IPassengerManager
    {
        readonly IRepository<int,Passenger> _passengerRepository;
        public PassengerManager()
        {
            _passengerRepository = new PassengerRepository();
        }
        public Passenger AddPassenger(Passenger passenger)
        {
            Passenger result = _passengerRepository.Add(passenger);
            if (result != null) return result;
            throw new DuplicatePassengerException();
        }

        public Passenger DeletePassenger(int passengerId)
        {
            Passenger passenger = _passengerRepository.Delete(passengerId);
            if(passenger != null) return passenger;
            throw new PassengerNotExistException();
        }

        public List<Passenger> GetAllPassengers()
        {
            List<Passenger> result = _passengerRepository.GetAll();
            if(result != null) return result;
            throw new PassengerNotExistException();
        }

        public Passenger GetPassengerById(int passengerId)
        {
            Passenger result = _passengerRepository.GetById(passengerId);
            if(result!=null) return result;
            throw new PassengerNotExistException();
        }

        public Passenger UpdatePassenger(Passenger passenger)
        {
            Passenger result = _passengerRepository.Update(passenger);
            if(result != null) return result;
            throw new PassengerNotExistException();
        }

       
    }
}
