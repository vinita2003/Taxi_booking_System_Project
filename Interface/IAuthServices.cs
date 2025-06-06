using Taxi_Booking_System.DTO;
using Taxi_Booking_System.Models;

namespace Taxi_Booking_System.Interface
{
    public interface IAuthServices 
    {
        public Task<Users?> RiderRegisterAsync(Riders request);
        public Task<Users?> DriverRegisterAsync(Drivers request);
        public  Task<string?> LoginAsync(Users request);
       

    }
}
