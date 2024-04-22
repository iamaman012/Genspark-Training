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
        readonly IRepository<Passenger> _passengerRepository;
        public PassengerManager(IRepository<Passenger> passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }
        public void AddPassenger(Passenger passenger)
        {
            _passengerRepository.Add(passenger);
        }

        public void DeletePassenger(string passengerId)
        {
            _passengerRepository.Delete(passengerId);
        }

        public List<Passenger> GetAllPassengers()
        {
            return _passengerRepository.GetAll();
        }

        public Passenger GetPassengerById(string passengerId)
        {
            return _passengerRepository.GetById(passengerId);
        }

        public void UpdatePassenger(Passenger passenger)
        {
            _passengerRepository.Update(passenger);
        }
    }
}
