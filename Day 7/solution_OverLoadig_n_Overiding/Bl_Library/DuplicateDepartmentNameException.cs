using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl_Library
{
    public class DuplicateDepartmentNameException : Exception
    {
        string msg;
        public DuplicateDepartmentNameException()
        {
            msg = "Department name already exists";
        }
        public override string Message => msg;
    }
}
