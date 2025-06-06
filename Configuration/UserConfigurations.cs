using Microsoft.EntityFrameworkCore;
using Taxi_Booking_System.Models;

namespace Taxi_Booking_System.Configuration
{
    public class UserConfigurations
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasKey(x => x.Id);
            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(user => user.Name).IsRequired();
                entity.Property(user => user.PhoneNumber).IsRequired();
                entity.Property(user => user.Gender).IsRequired();
                entity.Property(user => user.Password).IsRequired();
                }
            );
           

        }
    }
}
