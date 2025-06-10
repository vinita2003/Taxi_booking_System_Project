using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Taxi_Booking_System.Interface;
using Taxi_Booking_System.Models;


namespace Taxi_Booking_System.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly IConfiguration _configuration;
        private readonly TaxiBookingDbContext _context;
        public AuthServices(IConfiguration configuration, TaxiBookingDbContext context)
        {
            this._configuration = configuration;
            this._context = context;

        }

        public async Task<User?> RiderRegisterAsync(Rider request)
        {
            if (await _context.Users.AnyAsync(u => u.Name == request.Name))
            {
                return null;
            }

            var user = new Rider();
            user.Name = request.Name;
            user.PhoneNumber = request.PhoneNumber;
            user.Gender = request.Gender;
            user.Password = new PasswordHasher<User>().HashPassword(user, request.Password);

            user.EmergencyContactNumber = request.EmergencyContactNumber;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> DriverRegisterAsync(Driver request)
        {
            if (await _context.Users.AnyAsync(u => u.Name == request.Name))
            {
                return null;
            }

            var user = new Driver();
            user.Name = request.Name;
            user.PhoneNumber = request.PhoneNumber;
            user.Gender = request.Gender;
            user.Password = new PasswordHasher<User>().HashPassword(user, request.Password);

            user.CarNumber = request.CarNumber;
            user.CarType = request.CarType;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<string?> LoginAsync(User request)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(u => u.PhoneNumber == request.PhoneNumber);
            if (user == null)
            {
                return null;
            }
            if (new PasswordHasher<User>().VerifyHashedPassword(user, user.Password, request.Password) == PasswordVerificationResult.Failed)
                return null;
            string token = CreateToken(user);
            return token;
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings:Token")));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("AppSettings:Issuer"),
                audience: _configuration.GetValue<string>("AppSettings: Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

        }







    }
}