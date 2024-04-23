﻿using ModelClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPatientDALLibrary
{
    public class AppointmentRepository : IRepository<int , Appointment>
    {
        readonly Dictionary<int, Appointment> _appointments;
        public AppointmentRepository()
        {
            _appointments= new Dictionary<int, Appointment>();
        }

        int GenerateId()
        {
            if (_appointments.Count == 0)
                return 1;
            int id = _appointments.Keys.Max();
            return ++id;
        }

        public Appointment Add(Appointment item)
        {
            if (_appointments.ContainsValue(item))
            {
                return null;
            }
            item.AppointmentID = GenerateId();  
            _appointments.Add(GenerateId(), item);
            return item;
        }

        public Appointment Get(int key)
        {
            return _appointments[key] ?? null;
        }

        public List<Appointment> GetAll()
        {
            if (_appointments.Count == 0)
                return null;
            return _appointments.Values.ToList();
        }

        public Appointment Update(Appointment item)
        {
            if (_appointments.ContainsKey(item.DoctorID))
            {
                _appointments[item.DoctorID] = item;
                return item;
            }
            return null;
        }

        public Appointment Delete(int key)
        {
            if (_appointments.ContainsKey(key))
            {
                var appointment = _appointments[key];
                _appointments.Remove(key);
                return appointment;
            }
            return null;
        }
    }
}
