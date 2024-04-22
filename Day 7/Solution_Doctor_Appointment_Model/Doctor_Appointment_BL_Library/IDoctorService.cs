using Doctor_Appointment_model_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctor_Appointment_BL_Library
{
    public interface IDoctorService
    {
        int CreateDoctor(Doctor doctor);
        Doctor UpdateDoctor(Doctor doctor);
        Doctor GetDoctorByID(int id);
        List<Doctor> GetDoctorBySpecialization(string specialization);
        List<Doctor> GetDoctorByAvailability(bool available);
        List<Doctor> GetAllDoctors();
        Doctor DeleteDoctor(int id);
    }
}
