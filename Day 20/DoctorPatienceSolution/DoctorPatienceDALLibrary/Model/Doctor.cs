using System;
using System.Collections.Generic;

namespace DoctorPatientDALLibrary.Model
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Specialization { get; set; }
        public bool? Available { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
