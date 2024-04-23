﻿using ModelClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPatientDALLibrary
{
    public class PatientRepository : IRepository<int , Patient>
    {
        readonly Dictionary<int, Patient> _patients;
        public PatientRepository()
        {
            _patients = new Dictionary<int, Patient>();
        }

        int GenerateId()
        {
            if (_patients.Count == 0)
                return 1;
            int id = _patients.Keys.Max();
            return ++id;
        }

        public Patient Add(Patient item)
        {
            if (_patients.ContainsValue(item))
            {
                return null;
            }
            _patients.Add(GenerateId(), item);
            return item;
        }

        public Patient Get(int key)
        {
            return _patients[key] ?? null;
        }

        public List<Patient> GetAll()
        {
            if (_patients.Count == 0)
                return null;
            return _patients.Values.ToList();
        }

        public Patient Update(Patient item)
        {
            if (_patients.ContainsKey(item.PatienceID))
            {
                _patients[item.PatienceID] = item;
                return item;
            }
            return null;
        }

        public Patient Delete(int key)
        {
            if (_patients.ContainsKey(key))
            {
                var patient = _patients[key];
                _patients.Remove(key);
                return patient;
            }
            return null;
        }
    }
}
