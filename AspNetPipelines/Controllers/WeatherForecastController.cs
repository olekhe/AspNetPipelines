using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AspNetPipelines.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public enum Temper
        {
            Celsius,
            Fahrenheit
        }

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> GetWeatherForecast(int days = 3, string city = "Chernivtsi", Temper temper = Temper.Celsius)
        {
            return Enumerable.Range(0, days).Select(index => new WeatherForecast
            {
                City = city,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                //TemperatureC = Random.Shared.Next(-20, 55),
                Temperature = new Dictionary<string, int> { { temper.ToString(), temper == Temper.Celsius ? 
                                                            Random.Shared.Next(-20, 55) : 
                                                            (Random.Shared.Next(-20, 55) * 9 / 5 + 32) } },
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}