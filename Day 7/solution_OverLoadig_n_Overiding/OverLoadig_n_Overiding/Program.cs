﻿using Bl_Library;
using Overriding_Overloading_model_library;
using System.Collections;

namespace OverLoadig_n_Overiding
{
    public class Program
    {
        // void UnderstaingList()
        // {
        //     ArrayList list = new ArrayList();
        //     list.Add(100);
        //     list.Add("Hello");
        //     list.Add(23.4);
        //     list.Add(90.3f);
        //     list.Add(new Employee(101, "Ramu", new DateTime(), "Admin"));
        //     for (int i = 0; i < list.Count; i++)
        //     {
        //         Console.WriteLine(list[i]);
        //     }
        // }
        //public void UnderstandingGenericList()
        // {
        //     List<int> numbers = new List<int>();
        //     numbers.Add(100);
        //     numbers.Add(79);
        //     numbers.Add(55);
        //     double total = 0;
        //     //for (int i = 0; i < numbers.Count; i++)
        //     //{
        //     //    Console.WriteLine(numbers[i]);
        //     //    total += numbers[i];
        //     //}
        //     foreach (int i in numbers)
        //     {
        //         Console.WriteLine(i);
        //         total += i;
        //     }
        //     Console.WriteLine($"Total is {total}");
        // }
        // void UnderstandingSet()
        // {
        //     HashSet<string> names = new HashSet<string>()
        //         {
        //              "Ramu","Bimu"
        //         };
        //     names.Add("Somu");
        //     names.Add("Komu");
        //     names.Add("Timu");
        //     names.Add("Ramu");
        //     foreach (string name in names)
        //     {
        //         Console.WriteLine(name);
        //     }
        // }
        // void UnderstandingDictionary()
        // {
        //     Dictionary<int, string> employees = new Dictionary<int, string>();
        //     employees.Add(101, "Ramu");
        //     employees.Add(102, "Komu");
        //     employees.Add(103, "Bimu");
        //     employees.Add(104, "Ramu");
        //     foreach (var key in employees.Keys)
        //     {
        //         Console.WriteLine(key + " " + employees[key]);
        //     }
        //     if (employees.ContainsKey(101))
        //         Console.WriteLine("employee 101 present and name is " + employees[101]);
        //     if (employees.ContainsValue("Somu"))
        //         Console.WriteLine("there is an emploeye with name Somu in teh collection");
        // }

        // static void Main(string[] args)
        // {
        //     //Employee employee1, employee2;

        //     //employee1 = new Employee(101, "Ramu", new DateTime(2000, 12, 2), "Admin");
        //     //employee2 = new Employee(101, "Ramu", new DateTime(2000, 12, 2), "Admin");
        //     //if (employee1 == employee2)
        //     //{
        //     //    Console.WriteLine("Both Same");
        //     //}
        //     //else
        //     //{
        //     //    Console.WriteLine($"{employee1} and {employee2} are Not same employee");
        //     //}


        //     //new Program().UnderstandingDictionary();
        //     int num1, num2, result;
        //     try
        //     {
        //         num1 = Convert.ToInt32(Console.ReadLine());
        //         num2 = Convert.ToInt32(Console.ReadLine());
        //         result = num1 / num2;
        //         Console.WriteLine(result);
        //     }
        //     catch (FormatException fe)
        //     {
        //         Console.WriteLine(fe.Message);
        //         Console.WriteLine("The given data could not be converted to number.");
        //     }
        //     catch (DivideByZeroException dbze)
        //     {
        //         Console.WriteLine("You are trying to divide by zero. Its not worth");
        //     }
        //     Console.WriteLine("Bye bye");



        // }
        void AddDepartment()
        {

            DepartmentBL departmentBL = new DepartmentBL();
            try
            {
                Console.WriteLine("Pleae enter the department name");
                string name = Console.ReadLine();
                Department department = new Department() { Name = name };
                int id = departmentBL.AddDepartment(department);
                Console.WriteLine("Congrats. We ahve created the department for you and the Id is " + id);
                Console.WriteLine("Pleae enter the department name");
                name = Console.ReadLine();
                department = new Department() { Name = name };
                id = departmentBL.AddDepartment(department);
                Console.WriteLine("Congrats. We ahve created the department for you and the Id is " + id);
            }
            catch (DuplicateDepartmentNameException ddne)
            {
                Console.WriteLine(ddne.Message);
            }
        }
        static void Main(string[] args)
        {
            new Program().AddDepartment();
        }
    }
}
