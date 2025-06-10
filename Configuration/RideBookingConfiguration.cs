using Microsoft.EntityFrameworkCore;
using Taxi_Booking_System.Models;

namespace Taxi_Booking_System.Configuration
{
    public class RideBookingConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RideBooking>().HasKey(x => x.Id);
            modelBuilder.Entity<RideBooking>(entity =>
            {
                entity.Property(rideBooking => rideBooking.PickUpLocationLatitude).IsRequired();
                entity.Property(rideBooking => rideBooking.PickUpLocationLongitude).IsRequired();
                entity.Property(rideBooking => rideBooking.DropLocationLatitude).IsRequired();
                entity.Property(rideBooking => rideBooking.DropLocationLongitude).IsRequired();
                entity.Property(rideBooking => rideBooking.Status).IsRequired();
                entity.Property(riderBooking => riderBooking.CarType).IsRequired();

            });

            modelBuilder.Entity<RideBooking>().HasOne(rb => rb.Rider).WithMany(r => r.RideBookings).HasForeignKey(rb => rb.Id).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
