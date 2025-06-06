using Microsoft.EntityFrameworkCore;
using Taxi_Booking_System.Models;

namespace Taxi_Booking_System.Configuration
{
    public class DriverConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drivers>(entity =>
            {
                entity.Property(x => x.CarNumber).IsRequired();
                entity.Property(x => x.CarType).IsRequired();
                entity.Property(x => x.Availabilty).IsRequired();
                entity.Property(x => x.LicenseCardNumber).IsRequired();
                entity.Property(x => x.AadharCardNumber).IsRequired();
            });
        }
    }
}
