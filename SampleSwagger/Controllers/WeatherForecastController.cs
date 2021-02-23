using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleSwagger.Models;

namespace SampleSwagger.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }


        /// <summary>
        /// Returns the day of the week
        /// </summary>
        /// <param name="numberDay">The numeric value for the day requested.</param>
        /// <returns>The available days to book the appointment.</returns>
        [HttpGet("weekdays")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TheDayOfTheWeek>))]
        [ProducesResponseType(401)]        
        [ProducesResponseType(400)]
        public IActionResult DaysOfWeek(int numberDay)
        {
            // Auth.
            if(User.Identity.IsAuthenticated == false)
            {
                return Unauthorized();
            } 
            else
            {
                // more checks?
                //User.IsInRole("Admin")  -> one way to check if the user is in a role.
                // .... 
            }
            
            // Validation
            if(numberDay < 1)
            {
                return BadRequest("Invalid value");
            }

            // Here security + Custom validations (if any) are clear/passed OK. Biz Logic starts here.
            List<TheDayOfTheWeek> days = new List<TheDayOfTheWeek>();
            days.Add(new TheDayOfTheWeek { Name = "Monday", Number = 1 });
            days.Add(new TheDayOfTheWeek { Name = "Tuesday", Number = 2 });
            
            return Ok(days);
        }

        
    }
}
