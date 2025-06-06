using Microsoft.AspNetCore.Mvc;
using Taxi_Booking_System.DTO;
using Taxi_Booking_System.Interface;
using Taxi_Booking_System.Models;

namespace Taxi_Booking_System.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController : ControllerBase

    {
        private readonly IAuthServices _authServices;
        public AuthController(IAuthServices authServices)
        {
            _authServices = authServices;
        }

        [HttpPost]
        public async Task<ActionResult<Riders?>> RiderRegister(Riders request)
        {
            var user = await _authServices.RiderRegisterAsync(request);
            if (user == null) {
                return BadRequest("Username already exists!");
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<Riders?>> DriverRegister(Drivers request)
        {
            var user = await _authServices.DriverRegisterAsync(request);
            if (user == null)
            {
                return BadRequest("Username already exists!");
            }
            return Ok(user);
        }

        [HttpPost]

        public async Task<ActionResult<string?>> Login([FromBody]Riders request)
        {
            var token = await _authServices.LoginAsync(request);
            if (token == null)
            {
                return BadRequest("Username/password is wrong");
            }
            return Ok(new { token });
        }


    }
}
