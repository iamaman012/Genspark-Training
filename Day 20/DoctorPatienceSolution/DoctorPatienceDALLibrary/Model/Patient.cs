using System;
using System.Collections.Generic;

namespace DoctorPatientDALLibrary.Model
{
    public partial class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
