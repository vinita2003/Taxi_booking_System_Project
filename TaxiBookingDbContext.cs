using Microsoft.EntityFrameworkCore;
using Taxi_Booking_System.Configuration;
using Taxi_Booking_System.Models;

namespace Taxi_Booking_System
{
    public class TaxiBookingDbContext : DbContext
    {
       
        public TaxiBookingDbContext(DbContextOptions<TaxiBookingDbContext> dbContextOptions) : base(dbContextOptions) { 
        }

        public DbSet<Users> Users { get; set; }
       
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
               .HasDiscriminator<string>("UserType") // Adds a discriminator column named 'PaymentType'
               .HasValue<Riders>("Rider")          // Sets discriminator value 'Card' for CardPayment entities
               .HasValue<Drivers>("Driver");
           DriverConfiguration.Configure(modelBuilder);
            UserConfigurations.Configure(modelBuilder);
            RiderConfiguration.Configure(modelBuilder);
        }
    }
}
