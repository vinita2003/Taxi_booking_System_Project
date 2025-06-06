using System.Linq.Expressions;
using System.Net;
using System.Text.Json;

namespace Taxi_Booking_System.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
            Console.WriteLine("Global error middleware hit huaa");
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex) {
                _logger.LogError(ex, "An unhandled exception has occured");

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = new
                {
                    Title = "An unexcepted error occured.",
                    Status = context.Response.StatusCode,
                    Detail = context.RequestServices.GetService(typeof(IWebHostEnvironment)) is IWebHostEnvironment env && env.IsDevelopment() ? $" {ex} Something went wrong " : "Please contact support"
                };

                var jsonResponse = JsonSerializer.Serialize(response);

                await context.Response.WriteAsync(jsonResponse);
                }
            }
        }
    }

