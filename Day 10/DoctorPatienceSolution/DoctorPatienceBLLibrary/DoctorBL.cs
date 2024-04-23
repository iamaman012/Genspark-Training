using DoctorPatientDALLibrary;
using ModelClassLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPatientBLLibrary
{
    public class DoctorBL : IDoctorSerivce
    {   
        readonly IRepository<int,Doctor> _doctorRepository;
        [ExcludeFromCodeCoverage]


        public DoctorBL()
        {
            _doctorRepository = new DoctorRepository();    
        }
        [ExcludeFromCodeCoverage]

        public DoctorBL(IRepository<int, Doctor> doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        [ExcludeFromCodeCoverage]
        public int CreateDoctor(Doctor doctor)
        {
            Doctor Result= _doctorRepository.Add(doctor);
            if(Result!=null)
            {
                return Result.DoctorID;
            }
            throw new DuplicateDoctorNameException();
        }

        public Doctor DeleteDoctor(int id)
        {
            Doctor result = _doctorRepository.Delete(id);
            if(result!=null)
            {
                return result;
            }
            throw new DoctorNotFoundException();
        }

        public List<Doctor> GetAllDoctors()
        {
            List<Doctor> result = _doctorRepository.GetAll();
            if(result!=null)
            {
                return result;
            }
            throw new DoctorNotFoundException();
        }

        public List<Doctor> GetDoctorByAvailability(bool available)
        {
            List<Doctor> doctors = _doctorRepository.GetAll();
            if(doctors!=null)
            {
                List<Doctor> results = new List<Doctor>();
                foreach(Doctor doctor in doctors)
                {
                    if (doctor.Available == available)
                    {
                        results.Add(doctor);
                    }
                }
                return results;
            }
            throw new DoctorNotFoundException();
        }

        public Doctor GetDoctorByID(int id)
        {
            Doctor result = _doctorRepository.Get(id);
            if( result!=null ) return result;
            throw new DoctorNotFoundException();    
        }

        public List<Doctor> GetDoctorBySpecialization(string specialization)
        {
            List<Doctor> doctors = _doctorRepository.GetAll();
            if( doctors!=null )
            {
                List<Doctor> result = new List<Doctor>();
                foreach(Doctor doctor in doctors)
                {
                    if(doctor.Specialization== specialization)
                    {
                        result.Add(doctor);
                    }
                }
                if(result.Count==0) throw new DoctorNotFoundException();
                return result;
            }
            throw new DoctorNotFoundException();
        }

        public Doctor UpdateDoctor(Doctor doctor)
        {
            Doctor result = _doctorRepository.Update(doctor);
            if( result!=null ) return result;
            throw new DoctorNotFoundException();
        }
    }
}
