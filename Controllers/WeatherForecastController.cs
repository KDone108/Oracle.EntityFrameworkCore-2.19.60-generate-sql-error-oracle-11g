using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace WebEFCoreDemo.Controllers
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
        private readonly MyDbContext _myDbContext;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, MyDbContext myDbContext)
        {
            _logger = logger;
            _myDbContext = myDbContext;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            try
            {
                var result = _myDbContext.BusinessRules.Include("Values.Rule").FirstOrDefault(c => c.BRANCHID == "FDG");
            }
            catch (Exception ex)
            {
                if (!ex.Message.Contains("Connection request timed out"))
                {
                    //Debug.WriteLine($"ORACLE 904:{ex.Message}{ex.InnerException?.Message
                    throw new Exception($"ORACLE 904:{ex.Message}{ex.InnerException?.Message}");
                }
            }
            
            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
            return null;
        }
    }
}
