using InterfaceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementInterfaceapp
{
    public class EmployeeBenefit
    {
        public void PrintBenefitDetails(IGovtRules govtRules, double Salary,float Exp) {
            double pf = govtRules.EmployeePF(Salary);
            Console.WriteLine($"Employee PF {pf}");
            string leaves = govtRules.LeaveDetails();
            Console.WriteLine(leaves);
            double Gamount = govtRules.gratuityAmount(Exp,Salary);
            Console.WriteLine($"Gratuity Amount : {Gamount}");
        }
    }
}
