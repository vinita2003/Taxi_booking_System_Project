using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TaxiBooking.Api.Middleware;
using TaxiBooking.Application.Interface;
using TaxiBooking.Application.Services;
using TaxiBooking.Infastructure.Data;
using TaxiBooking.Infastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TaxiBooking.RealTime.Hubs;
using TaxiBooking.Application.Interfaces;


var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
builder.Logging.ClearProviders();
        builder.Logging.AddConsole();
        builder.Logging.AddDebug();
        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            //options.JsonSerializerOptions.PropertyNamingPolicy = null;
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.WithOrigins("http://localhost:4200")
                      .AllowAnyHeader()
                      .AllowAnyMethod()
                       .AllowCredentials();

            });
        });
        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        builder.Services.AddDbContext<TaxiBookingDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("MyTaxiBookingDb")));
        builder.Services.AddScoped<IAuthServices, AuthServices>();
builder.Services.AddScoped<IRiderServices, RiderService>();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IDriverServices, DriverServices>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>

{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = config["Jwt:Issuer"],
        ValidAudience = config["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(config["Jwt:Token"]))
    };

    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var accessToken = context.Request.Query["access_token"];
            var path = context.HttpContext.Request.Path;
            Console.WriteLine($"[JWT] Incoming token: {accessToken}");
            Console.WriteLine($"[Path] Requested path: {path}");

            if (!string.IsNullOrEmpty(accessToken) &&
                path.StartsWithSegments("/driverHub"))
            {
                context.Token = accessToken;
                Console.WriteLine("[JWT] Token assigned successfully for SignalR");
            }

            return Task.CompletedTask;
        }
    };
});

builder.Services.AddSignalR();
builder.Services.AddAuthorization();
builder.Services.AddSignalR();

var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseCors();

        app.UseMiddleware<ErrorHandlerMiddleware>();

        app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();
app.MapHub<DriverHub>("/driverHub");

app.Run();
   