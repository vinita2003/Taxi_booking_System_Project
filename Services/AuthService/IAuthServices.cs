using Taxi_Booking_System.Models;

namespace Taxi_Booking_System.Interface
{
    public interface IAuthServices 
    {
        public Task<User?> RiderRegisterAsync(Rider request);
        public Task<User?> DriverRegisterAsync(Driver request);
        public  Task<string?> LoginAsync(User request);
       

    }
}
