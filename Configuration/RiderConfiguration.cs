using Microsoft.EntityFrameworkCore;
using Taxi_Booking_System.Models;

namespace Taxi_Booking_System.Configuration
{
    public class RiderConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rider>(entity =>
            {
                entity.Property(x => x.EmergencyContactNumber).IsRequired().HasMaxLength(15);
            });

            
                }
            
    }
}
