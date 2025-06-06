using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Taxi_Booking_System;
using Taxi_Booking_System.Interface;
using Taxi_Booking_System.Middleware;
using Taxi_Booking_System.Repository;
using Taxi_Booking_System.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // Angular ka local host
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});





builder.Services.AddScoped<IUserService, UserServices>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddDbContext<TaxiBookingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyTaxiBookingDb")));
builder.Services.AddScoped<IAuthServices, AuthServices>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAngularApp"); // Ye middleware me hona chaiye

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
