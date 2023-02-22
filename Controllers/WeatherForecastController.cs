using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Tricolor_BE.Entities;

namespace Tricolor_BE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly JwtAuthenticationManager _jwtAuthenticationManager;

        public WeatherForecastController(JwtAuthenticationManager jwtAuthenticationManager)
        {
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [Authorize]
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [AllowAnonymous]
        [HttpPost("Authorize")]
        public IActionResult Authorize([FromBody] Usuario usuario)
        {
            var token = _jwtAuthenticationManager.Authenticate(usuario);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}