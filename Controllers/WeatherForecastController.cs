using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAPI.Data;
using TestAPI.Models;

namespace TestAPI.Controllers;

[ApiController]
[Route("[controller]/")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    IConfiguration _configuration;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    [HttpGet]
    public async Task<List<Student>> Get()
    {
       using(var context = new StudentDBContext(_configuration))
        {
            var result = await context.Student.ToListAsync();
            return result; 
        }
    }

    [HttpPost]
    [Route("save")]

    public async Task Save([FromBody]Student s1)
    {
        using(var context = new StudentDBContext(_configuration))
        {
            var result = await context.Student.AddAsync(s1);
            await context.SaveChangesAsync();
        }
    }

}

