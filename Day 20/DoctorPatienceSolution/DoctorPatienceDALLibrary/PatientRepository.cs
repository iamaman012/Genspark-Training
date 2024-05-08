//using ModelClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorPatientDALLibrary.Model;

namespace DoctorPatientDALLibrary
{
    public class PatientRepository : IRepository<int, Patient>
    {
        //readonly Dictionary<int, Patient> _patients;
        db_ClinicShopContext context;
        public PatientRepository()
        {
            context = new db_ClinicShopContext();
        }

        //int GenerateId()
        //{
        //    if (_patients.Count == 0)
        //        return 1;
        //    int id = _patients.Keys.Max();
        //    return ++id;
        //}

        public Patient Add(Patient item)
        {
            var patients = context.Patients.ToList();

            Patient result = patients.Find(d => d.Id == item.Id);
            if (result != null)
            {
                return null;
            }

            context.Patients.Add(item);
            context.SaveChanges();
            return item;
        }

        public Patient Get(int key)
        {
            var patients = context.Patients.ToList();

            Patient result = patients.Find(d => d.Id == key);
            return result;
        }

        public List<Patient> GetAll()
        {

            var patients = context.Patients.ToList();
            return patients;
        }

        public Patient Update(Patient item)
        {
            var patients = context.Patients.ToList();
            Patient result = patients.Find(d => d.Id == item.Id);
            if (result != null)
            {
                context.Patients.Update(item);
                context.SaveChanges();
                return item;
            }

            return null;
        }

        public Patient Delete(int key)
        {
            var patients = context.Patients.ToList();
            Patient result = patients.Find(d => d.Id == key);
            if (result != null)
            {
                context.Patients.Remove(result);
                context.SaveChanges();
                return result;
            }
            return null;
        }
    }
}
