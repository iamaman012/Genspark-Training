using System.Runtime.ConstrainedExecution;

namespace InterfaceLibrary
{
    public class Accenture : Employee, IGovtRules
    {
        
        public Accenture(int id, string name, string department, string designation, double salary,float exp) : base(id, name, department, designation, salary,exp)
        {
            
            Console.WriteLine("Parameterized constructor of Accenture class called");
        }
        public Accenture() { }

       public double EmployeePF(double basicSalary)
        {
            double TotalPf = (12 * basicSalary) / 100;
            double employerPf = (0 * basicSalary) / 100;
            double employeepf = (12 * basicSalary) / 100;
            return employeepf;
        }

       public double gratuityAmount(float serviceCompleted, double basicSalary)
        {
            /*Console.WriteLine("Gratuity Amount Not Applicable");*/
            return 0;
        }

      public  string LeaveDetails()
        {
            string Leaves = "2 day of Casual Leave per month" +
                            "\n5 days of Sick Leave per year" +
                            "\n5 days of Previlage Leave per year";
            return Leaves;
        }
        public void PrintEmployeeDetails()
        {
            base.PrintEmployeeDetails();
            Console.WriteLine("Comapny name : Accenture");
        }
    }
}
