using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Taxi_Booking_System.Models { 
    public enum UserGender { male, female, others }

    public class Users
    {
        public int Id { get; set; }

        [RegularExpression(@"^[A-Za-z][A-Z a-z]{3,15}$", ErrorMessage = "It Contain only alphabet letter")]
        public string Name { get; set; }

        [RegularExpression(@"^[0-9]{10,15}$", ErrorMessage = "Phone number must be between 10 and 15 digits.")]
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public UserGender Gender { get; set; }
        public decimal LocationLatitude { get; set; }
        public decimal LocationLongitude { get; set; }

    }
}
