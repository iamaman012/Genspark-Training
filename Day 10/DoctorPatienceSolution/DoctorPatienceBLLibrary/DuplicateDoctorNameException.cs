using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPatientBLLibrary
{
    public class DuplicateDoctorNameException : Exception
    {
      string message;
      public  DuplicateDoctorNameException()
        {
            message = "Department Name Already Exist !!";
        }
        public override string Message => message;

    }
}
