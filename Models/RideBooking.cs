namespace Taxi_Booking_System.Models
{
    public class RideBooking
    {
        public int Id { get; set; }
        public double PickUpLocationLatitude { get; set; }
        public double PickUpLocationLongitude { get; set; }
        public double DropLocationLatitude { get; set; }
         public double DropLocationLongitude { get; set; }
        public string CarType { get; set; }
        public TimeOnly DesiredArrivalTime { get; set; }
        public string? Status { get; set; }
        public string? CancellationReason { get; set; }
        public decimal CancellationFees { get; set; }

        public int UserId { get; set; }

        public Rider Rider { get; set; }
    }
}
