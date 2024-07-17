using EmployeeRequestTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequestTrackerAPI.Contexts
{
    public class RequestTrackerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=71RBBX3\\SQLEXPRESS;Integrated Security=true;Initial Catalog=dbRequestTracker14May24;");
            // change for azure sql server
            optionsBuilder.UseSqlServer("Server=tcp:msdocs-azuresql-server-149631330.database.windows.net,1433;Initial Catalog=mySqlDbAman;Persist Security Info=False;User ID=azureuser;Password=Amanannn1@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
        public  DbSet<Employee> Employees { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { Id = 101, Name = "Ramu", DateOfBirth = new DateTime(2000, 2, 12), Phone = "9876543321", Image = "" },
                new Employee() { Id = 102, Name = "Somu", DateOfBirth = new DateTime(2002, 3, 24), Phone = "9988776655", Image = "" }
                );
       }
    }
}
