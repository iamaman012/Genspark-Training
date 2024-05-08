using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPatientBLLibrary
{
    public class DoctorNotFoundException: Exception
    {
        public string msg;
        public DoctorNotFoundException()
        {
            msg = "Doctor not Found in the System!!";
        }
        public override string Message => msg;
    }
}
