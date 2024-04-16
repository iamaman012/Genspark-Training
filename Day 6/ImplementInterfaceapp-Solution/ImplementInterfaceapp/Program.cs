using InterfaceLibrary;

namespace ImplementInterfaceapp
{
    public class Program
    {
        Employee[] employees;
        public Program()
        {
            employees = new Employee[1];
        }

        void PrintMenu()
        {
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Print Employees");
            Console.WriteLine("0. Exit");
        }

        void EmployeeInteraction()
        {
            int choice = 0;
            do
            {
                PrintMenu();
                Console.WriteLine("Please select an option");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye.....");
                        break;
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        PrintAllEmployees();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            } while (choice != 0);
        }
        void AddEmployee()
        {
            if (employees[employees.Length - 1] != null)
            {
                Console.WriteLine("Sorry we have reached the maximum number of employees");
                return;
            }
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] == null)
                {
                    employees[i] = CreateEmployee(i);
                }
            }

        }
        void PrintAllEmployees()
        {
            if (employees[0] == null)
            {
                Console.WriteLine("No Employees available");
                return;
            }
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null)
                {
                    
                    PrintEmployee(employees[i]);

                }

            }
        }
        Employee CreateEmployee(int id)
        {
            Employee Employee = new Employee();
            Console.WriteLine("Enter The Company Name :");
            string name = Console.ReadLine();
            if (name == "TCS")
            {
                Employee = new TCS();
            }
            else if (name == "Accenture")
            {
                Employee = new Accenture();
            }
            Employee.Id= 101 + id;
            Employee.BuildFromConsole();
            return Employee;

        }
        void PrintEmployee(Employee Employee)
        {
            Console.WriteLine("---------------------------");
            Employee.PrintEmployeeDetails();
            EmployeeBenefit extraBenefits = new EmployeeBenefit();
            extraBenefits.PrintBenefitDetails(Employee, Employee.Salary, Employee.Experience);
            Console.WriteLine("---------------------------");
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.EmployeeInteraction();
        }
    }
}
