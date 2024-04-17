using Doctor_Appointment_model_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctor_Appointment_BL_Library
{
    public interface IAppointmentService
    {
        bool ScheduleAppointment(Doctor doctor, Patient patient);
        Appointment DeleteAppointment(Appointment appointment);
        Appointment RescheduleAppointment(Appointment appointment, DateTime dateTime);
        Appointment GetAppointmentByID(int id);
        List<Appointment> GetAppointmentByDoctor(int id);
        List<Appointment> GetAppointmentByPatient(int id);
        List<Appointment> GetAllAppointment();
        List<Appointment> GetAppointmentByStatus(string status);

    }
}
