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
        public IActionResult DaysOfWeek(int numberDay)
        {
            List<TheDayOfTheWeek> days = new List<TheDayOfTheWeek>();
            days.Add(new TheDayOfTheWeek { Name = "Monday", Number = 1 });
            days.Add(new TheDayOfTheWeek { Name = "Tuesday", Number = 2 });
            if(numberDay < 1)
            {
                return BadRequest("Invalid value");
            }
            return Ok(days);
        }

        
    }
}
