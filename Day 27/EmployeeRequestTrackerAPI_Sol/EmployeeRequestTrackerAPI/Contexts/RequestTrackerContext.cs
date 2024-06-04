using EmployeeRequestTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequestTrackerAPI.Contexts
{
    public class RequestTrackerContext : DbContext
    {
        public RequestTrackerContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=71RBBX3\\SQLEXPRESS;Integrated Security=true;Initial Catalog=dbRequestTracker14May24;");
        }
        public  DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { Id = 101, Name = "Ramu", DateOfBirth = new DateTime(2000, 2, 12), Phone = "9876543321", Image = "" },
                new Employee() { Id = 102, Name = "Somu", DateOfBirth = new DateTime(2002, 3, 24), Phone = "9988776655", Image = "" }
                );
            modelBuilder.Entity<Request>().HasKey(r => r.RequestNumber);
            modelBuilder.Entity<Employee>().HasMany(e=>e.RequestsRaised).WithOne(r => r.RaisedByEmployee).HasForeignKey(r => r.RequestRaisedBy).OnDelete(DeleteBehavior.Restrict).IsRequired();
            modelBuilder.Entity<Employee>().HasMany(e => e.RequestsClosed).WithOne(r => r.RequestClosedByEmployee).HasForeignKey(r => r.RequestClosedBy).OnDelete(DeleteBehavior.Restrict);
       }
    }
}
