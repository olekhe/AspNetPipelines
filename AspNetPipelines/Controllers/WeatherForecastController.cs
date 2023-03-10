using Microsoft.AspNetCore.Mvc;

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

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        public enum Units
        {
            Celsius,
            Fahrenheit
        }



        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> GetWeatherForecast(string city, int days = 3, Units unit = Units.Celsius)
        {
            return Enumerable.Range(0, days).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),

                //  TemperatureC = Random.Shared.Next(-20, 55),
                
                Temp = new Dictionary<string, int> { { unit.ToString(), unit == Units.Celsius ?
                                                            Random.Shared.Next(-20, 55) :
                                                            (Random.Shared.Next(-20, 55) * 9 / 5 + 32) } },


                Summary = Summaries[Random.Shared.Next(Summaries.Length)],

                City = city,

            })
            .ToArray();



        }

       




    }
}