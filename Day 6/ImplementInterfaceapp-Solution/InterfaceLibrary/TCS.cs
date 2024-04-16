using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary
{
    public class TCS: Employee,IGovtRules
    {
       
        public TCS(int id, string name, string department, string designation, double salary,float exp) : base(id, name, department, designation, salary,exp)
        {
            
            Console.WriteLine("Parameterized constructor of TCS class called");
        }
        public TCS()
        {
          
        }

        public double EmployeePF(double basicSalary)
        {
            double TotalPf = (12 * basicSalary) / 100;
            double employerPf = (8.33 * basicSalary) / 100;
            double employeepf = (3.67 * basicSalary) / 100;
            return employeepf;
        }

        public double gratuityAmount(float serviceCompleted, double basicSalary)
        {
            
            if(serviceCompleted <= 5)
            {
                return 0;
            
            }
            else if(serviceCompleted > 5 && serviceCompleted <=10)
            {
                return basicSalary / 12;
            }
            else if(serviceCompleted>10 && serviceCompleted <= 20)
            {
                return 2 * basicSalary;
            }
            else return 3* basicSalary;
        }

        public string LeaveDetails()
        {
            string Leaves = "1 day of Casual Leave per month" +
                            "\n12 days of Sick Leave per year" +
                            "\n10 days of Privilege Leave per year";
            return Leaves;
        }
        public void PrintEmployeeDetails()
        {
            base.PrintEmployeeDetails();
            Console.WriteLine("Company Name :TCS");
        }
    }
}
