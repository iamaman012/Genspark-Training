using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary
{
    public class Employee :IGovtRules
    { 

        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Department {  get; set; } 
        public double Salary {  get; set; }
        public float Experience {  get; set; }
           
        public Employee()
        {
            Id = 0;
            Name= string.Empty;
            Designation= string.Empty;
            Department= string.Empty;
            Salary= 0;
            Experience= 0;

        }

        public Employee(int id,string name,string department,string designation, double salary,float exp)
        {
            Id = id;
            Name = name;
            Designation =  designation;
            Department = department;
            Salary = salary;
            Experience = exp;
            
        }
       public void PrintEmployeeDetails()
        {
            Console.WriteLine($"Employee ID : {this.Id}");
            Console.WriteLine($"Employee Name : {this.Name}");
            Console.WriteLine($"Employee Department : {this.Department}");
            Console.WriteLine($"Employee Designation : {this.Designation}");
            Console.WriteLine($"Employee Salary : {this.Salary}");
          

        }
        public void BuildFromConsole()
        {
            Console.WriteLine("Please Enter the Name");
            Name = Console.ReadLine(); 
            Console.WriteLine("Please Enter the Department");
            Department = Console.ReadLine();
            Console.WriteLine("Please Enter the Designation");
            Designation = Console.ReadLine();
            Console.WriteLine("Please Enter the Salary");
            Salary = double.Parse(Console.ReadLine());
            Console.WriteLine("please enter the experience");
            Experience=float.Parse(Console.ReadLine());

        }

        public double EmployeePF(double basicSalary)
        {
            throw new NotImplementedException();
        }

        public string LeaveDetails()
        {
            throw new NotImplementedException();
        }

        public double gratuityAmount(float serviceCompleted, double basicSalary)
        {
            throw new NotImplementedException();
        }
    }
}
