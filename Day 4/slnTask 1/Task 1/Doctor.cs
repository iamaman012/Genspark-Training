using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    internal class Doctor
    {
        public int Id {  get; private set; }
        public string Name { get;  set; }
        public int Age { get; set; }
        public int Exp {  get; set; }
        public string Qualification { get; set; }

        public string Speciality {  get; set; } 

        public Doctor(int id)
        {
            Id = id;
        }
      
      
       public void PrintDoctorDetails()
        {
            Console.WriteLine("**********************************************************");
            Console.WriteLine($"ID : {Id}");
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"Age : {Age}");
            Console.WriteLine($"Experience : {Exp}");
            Console.WriteLine($"Qualification : {Qualification}");
            Console.WriteLine($"Speciality : {Speciality}");
        }

    }
}
