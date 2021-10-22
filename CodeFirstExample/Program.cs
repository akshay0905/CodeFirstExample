using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstExample
{
    public class Passenger
    {
        [Key]
        public int PID { get; set; }
        public string PName { get; set; }
        public DateTime? DOB { get; set; }
        public DateTime? TravelDate { get; set; }
    }
    public class TourbusContext : DbContext
    {
        public TourbusContext()
        {
        }
        public DbSet<Passenger> Passengers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            object p = optionsBuilder.UseSqlServer(@"Server=localhost;Database=TourDB;Trusted_Connection=True;");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            using (TourbusContext dbCtx = new TourbusContext())
            {
                var passenger = new Passenger()
                {
                    PName = "Priya Singh",
                    DOB = new DateTime(),
                    TravelDate = new DateTime()
                };
                dbCtx.Passengers.Add(passenger);
                dbCtx.SaveChanges();
            }
        }
    }

}
