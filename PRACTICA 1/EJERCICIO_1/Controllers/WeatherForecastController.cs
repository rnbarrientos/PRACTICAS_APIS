using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EJERCICIO_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Daniel", "Patricia"

    };

        private static readonly string[] Summaries1 = new[]
        {
        "G�mez", "Salgado"
    };
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }



        //M�todo Post

        [HttpPost("PostWeatherForecast")]
        public String Post([FromBody] WeatherForecast parametro)
        {
            List<WeatherForecast> forecast = new List<WeatherForecast>();
            forecast.Add(new WeatherForecast

            {
                Nombre = "Daniel ",
                Apellido = "G�mez",
                
            });

            return JsonConvert.SerializeObject(forecast);

        }


        //M�todo Get

        [HttpGet("GetWeatherForecast")]
        public List<WeatherForecast> Get(int Nombres)
        {
            List<WeatherForecast> nuevomodelo = new List<WeatherForecast>();


            if (Nombres == 1)
            {

                nuevomodelo.Add(new WeatherForecast
                {
                    Nombre = "Daniel",
                    Apellido = "G�mez"
                    
                });
            }
            else if (Nombres == 2)
            {

                nuevomodelo.Add(new WeatherForecast

                {
                    Nombre = "Patricia",
                    Apellido = "Salgado"
                    
                });
            }

            return nuevomodelo;
        }

        //M�todo Put

        [HttpPut("PutWeatherForecast")]
        public String Put([FromBody] WeatherForecast parametro)
        {
            

            List<WeatherForecast> forecast = new List<WeatherForecast>();
            forecast.Add(new WeatherForecast

            {
                Nombre = "Daniel",
                Apellido = "G�mez"
               
            });

            return JsonConvert.SerializeObject(forecast);


        }


        //M�todo Delete

        [HttpDelete("DeleteWeatherForecast")]

        public String Delete([FromBody] WeatherForecast parametro)
        {
            List<WeatherForecast> forecast = new List<WeatherForecast>();
            forecast.Add(new WeatherForecast

            {
                Nombre = "Daniel",
                Apellido = "G�mez"
                
            });

            return JsonConvert.SerializeObject(forecast);
        }


    }
}