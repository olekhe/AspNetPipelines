using AspNetPipelines.Controllers;

namespace AspNetPipelines
{

    public enum TemperatureUnits
    {
        Celsius,
        Fahrenheit
    }

    public class WeatherForecast
    {
        public string? City { get; set; }

        public DateOnly Date { get; set; }

        public Dictionary<string, int> Temp { get; set; }

        //public int? TemperatureC { get; set; }

       // public int? TemperatureF { get; set; }
                
        public int TempC_Midlle { get; set; }

        public string? Summary { get; set; }
    }

}