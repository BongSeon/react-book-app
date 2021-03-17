using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.React.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherSeoulController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherSeoulController> _logger;

        public WeatherSeoulController(ILogger<WeatherSeoulController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherSeoul> Get()
        {
            //var rng = new Random();
            //return Enumerable.Range(1, 4).Select(index => new WeatherSeoul
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureMin = -20,
            //    TemperatureMax = 20,
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
            var rng = new Random();
            return Enumerable.Range(1, 4).Select(index => new WeatherSeoul
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureMin = -20,
                TemperatureMax = 20,
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

    }
}
