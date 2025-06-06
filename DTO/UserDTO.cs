using System.ComponentModel.DataAnnotations;
using Taxi_Booking_System.Models;

namespace Taxi_Booking_System.DTO
{
    public class UserDTO
    {

        [RegularExpression(@"^[A-Za-z][A-Z a-z]{3,15}$", ErrorMessage = "It Contain only alphabet letter")]
        public string Name { get; set; } =  string.Empty;

        [RegularExpression(@"^[0-9]{10,15}$", ErrorMessage = "Phone number must be between 10 and 15 digits.")]
        public string PhoneNumber { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public UserGender Gender { get; set; }
    }
}
