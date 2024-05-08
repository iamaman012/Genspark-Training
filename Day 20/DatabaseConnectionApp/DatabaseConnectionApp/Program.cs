using DatabaseConnectionApp.Model;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DatabaseConnectionApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Area area = new Area();
            //area.Area1 = "POPO";
            //area.Zipcode = "44332";
            dbEmployeeTrackerContext context = new dbEmployeeTrackerContext();
            //context.Areas.Add(area); // save it in the local collection
            //context.SaveChanges();   // save it in the database

            var areas = context.Areas.ToList();

            // update the area with the zipcode 00000
            var area = areas.SingleOrDefault(a => a.Area1 == "DDDD");
            area.Zipcode = "00000";
            context.Areas.Update(area);
            context.SaveChanges();

            // delete the area with the name HHHH

            area = areas.SingleOrDefault(a => a.Area1 == "HHHH");
            context.Areas.Remove(area);
            context.SaveChanges();
            areas = context.Areas.ToList();
            foreach (var a in areas)
            {
                Console.WriteLine(a.Area1 + " " + a.Zipcode);
            }



        }
    }
}
