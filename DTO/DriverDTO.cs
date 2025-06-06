using Taxi_Booking_System.Models;

namespace Taxi_Booking_System.DTO
{
    public class DriverDTO : UserDTO
    {
        public decimal? Rating { get; set; } = decimal.MinValue;
        public DriverAvailabilty Availabilty { get; set; } = DriverAvailabilty.Offline;

        public string CarNumber { get; set; } = string.Empty;
        public DriverCarType CarType { get; set; } = DriverCarType.UV;
    }
}
