using System;
using System.Collections.Generic;

namespace DoctorPatientDALLibrary.Model
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public int? Did { get; set; }
        public int? Pid { get; set; }
        public DateTime? Date { get; set; }
        public string? Status { get; set; }

        public virtual Doctor? DidNavigation { get; set; }
        public virtual Patient? PidNavigation { get; set; }
    }
}
