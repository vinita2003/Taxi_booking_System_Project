using System.ComponentModel.DataAnnotations;

namespace Taxi_Booking_System.Models
{
    public enum DriverAvailabilty
    {
        Online, Offline
    }

    public enum DriverCarType
    {
        Sedan, Mini, UV
    }
    public class Driver : User
    {
        public decimal? Rating { get; set; }
        public DriverAvailabilty Availabilty { get; set; } = DriverAvailabilty.Offline;
        [RegularExpression(@"^[A-Za-z0-9]{10}$", ErrorMessage = "Car number must be Alphabets and Numbers only, length 10")]
        public string CarNumber { get; set; }
        public DriverCarType CarType { get; set; }
        [RegularExpression(@"^[A-Za-z0-9]{10}$", ErrorMessage = "AadharCard number must be Alphabets and Numbers only, length 10")]
        public string AadharCardNumber { get; set; }
        [RegularExpression(@"^[A-Za-z0-9]{10}$", ErrorMessage = "LicenseCard number must be Alphabets and Numbers only, length 10")]
        public string LicenseCardNumber { get; set; }


    }
}
