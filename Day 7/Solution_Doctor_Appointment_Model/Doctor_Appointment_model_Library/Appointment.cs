using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctor_Appointment_model_Library
{
    public class Appointment
    {
        public int Id { get; set; }
        public string PatientName { get; set; } 
        public string DoctorName {  get; set; }
        public DateTime Date { get; set; }
    }
}
