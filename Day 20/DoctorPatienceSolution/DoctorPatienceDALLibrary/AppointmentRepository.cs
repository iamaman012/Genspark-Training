using System.Collections.Generic;
using System.Linq;
using DoctorPatientDALLibrary.Model;

namespace DoctorPatientDALLibrary
{
    public class AppointmentRepository : IRepository<int, Appointment>
    {
        db_ClinicShopContext context;

        public AppointmentRepository()
        {
            context = new db_ClinicShopContext();
        }

        public Appointment Add(Appointment item)
        {
            var appointments = context.Appointments.ToList();
            Appointment result = appointments.FirstOrDefault(a => a.Id == item.Id);
            if (result != null)
            {
                return null;
            }
            context.Appointments.Add(item);
            context.SaveChanges();
            return item;
        }

        public Appointment Get(int key)
        {
            var appointments = context.Appointments.ToList();
            return appointments.FirstOrDefault(a => a.Id == key);
        }

        public List<Appointment> GetAll()
        {
            return context.Appointments.ToList();
        }

        public Appointment Update(Appointment item)
        {
            var appointments = context.Appointments.ToList();
            Appointment result = appointments.FirstOrDefault(a => a.Id == item.Id);
            if (result != null)
            {
                context.Appointments.Update(item);
                context.SaveChanges();
                return item;
            }
            return null;
        }

        public Appointment Delete(int key)
        {
            var appointment = Get(key);
            if (appointment != null)
            {
                context.Appointments.Remove(appointment);
                context.SaveChanges(); // Save changes to the database

            }
            return appointment;
        }
    }
}
