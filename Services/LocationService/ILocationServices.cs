using Taxi_Booking_System.DTO;
using Taxi_Booking_System.MappingProfile;
using Taxi_Booking_System.Models;

namespace Taxi_Booking_System.Interface
{
    public interface ILocationServices
    {
          public Task<RideBookingPickUpAndDropLocationDTO?> StoreRiderPickupAndDropLocation(RideBookingPickUpAndDropLocationDTO request);
      
       
        
    }
}
