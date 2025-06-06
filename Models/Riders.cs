using System.ComponentModel.DataAnnotations;

namespace Taxi_Booking_System.Models
{
    public class Riders : Users
    {
        [RegularExpression(@"^[0-9]{10,15}$", ErrorMessage = "Phone number must be between 10 and 15 digits.")]
        public String? EmergencyContactNumber { get; set; }

    }
}
