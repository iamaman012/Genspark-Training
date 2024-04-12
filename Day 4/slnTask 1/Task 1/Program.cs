using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;

namespace Task_1
{
    internal class Program
    {    
        static void PrintDoctorDetailsOnSpec(string str,int size,Doctor []doctor)
        {
            if(str== null || str == "") {
                Console.WriteLine("Below are the list of Doctors");
                for (int i=0;i<size;i++)
                {
                    doctor[i].PrintDoctorDetails();
                }
            }
            else
            {
                string spec = str.Replace(" ", "").ToLower();
                for(int i=0;i<size; i++)
                {
                    if (doctor[i].Speciality.Replace(" ","").ToLower() == spec)
                    {
                        doctor[i].PrintDoctorDetails();
                    }
                }
            }
        }
        static Doctor CreateObjectOfDoctorClass(int id)
        {
            Doctor dr= new Doctor(id);
            Console.WriteLine("Please Enter the Name");
            dr.Name = Console.ReadLine();
            Console.WriteLine("Please Enter the Age");
            dr.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Please Enter the Experience in Years");
            dr.Exp=int.Parse(Console.ReadLine());
            Console.WriteLine("Please Enter the Qualification");
            dr.Qualification = Console.ReadLine();
            Console.WriteLine("Please Enter the Speciality");
            dr.Speciality = Console.ReadLine();
            return dr;

        }
        static void Main(string[] args)
        {
           
            Console.WriteLine("Please Enter the Size of the Array!!");
            int ArraySize = 0;
            ArraySize = int.Parse(Console.ReadLine());
            Doctor[] doctor = new Doctor[ArraySize];
            for(int i = 0; i < ArraySize; i++)
            {
                Console.WriteLine("**********************************************************");
                Console.WriteLine($"Please Enter the details of Doctor {i+1}");
                Console.WriteLine();
                doctor[i] = CreateObjectOfDoctorClass(101 + i);
            }
            Console.WriteLine();
            Console.WriteLine("Please Enter the Speciality, for Doctor's Details");
            string spec = Console.ReadLine();
            PrintDoctorDetailsOnSpec(spec, ArraySize, doctor);



        }
    }
}
