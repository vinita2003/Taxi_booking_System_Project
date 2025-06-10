using Microsoft.EntityFrameworkCore;
using Taxi_Booking_System.Configuration;
using Taxi_Booking_System.Models;

namespace Taxi_Booking_System
{
    public class TaxiBookingDbContext : DbContext
    {
       
        public TaxiBookingDbContext(DbContextOptions<TaxiBookingDbContext> dbContextOptions) : base(dbContextOptions) { 
        }

        public DbSet<User> Users { get; set; }
       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
               .HasDiscriminator<string>("UserType") 
               .HasValue<Rider>("Rider")          
               .HasValue<Driver>("Driver");
           DriverConfiguration.Configure(modelBuilder);
            UserConfigurations.Configure(modelBuilder);
            RiderConfiguration.Configure(modelBuilder);
        }
    }
}
