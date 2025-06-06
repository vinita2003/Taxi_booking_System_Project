using System.ComponentModel.DataAnnotations;

namespace Taxi_Booking_System.DTO
{
    public class RiderDTO : UserDTO
    {
        [MinLength(10)]
        public String EmergencyContactNumber { get; set; }
    }
}
