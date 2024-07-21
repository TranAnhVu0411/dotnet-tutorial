using Microsoft.AspNetCore.Mvc;

namespace LoggingDemo.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    // Inject Logger to Constructor
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        // // Print Log message to console (Those 2 commands are the same)
        // _logger.Log(LogLevel.Information, "This is an information logging message");
        _logger.LogInformation("This is an information logging message");
        // Other Logging types
        _logger.LogTrace("This is a trace logging message"); // Not display since the priority of trace logging is less than information one (Need to fix appsettings.json)

        // Use Event Id to identify log messages
        _logger.LogInformation(EventIds.LoginEvent, "This is a logging message with event id");

        // Use string/formatted string with args param for logging
        _logger.LogInformation("This is a logging message with args: Today is {Week}. It is {Time}.", DateTime.Now.DayOfWeek, DateTime.Now.ToLongTimeString());
        
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet]
    [Route("Exception")]
    public ActionResult ExceptionSample()
    {
        try
        {
            var random = new Random();
            var randomNumber = random.Next(1, 6);
            if (randomNumber != 3)
            {
                throw new Exception("This is a generic exception");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "This is an exception logging message. Datetime: {exceptionDateTime}. Exception message: {exceptionMessage}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), ex.Message);
            // throw;
        }
        return Ok("This is to test an exception.");
    }

    [HttpGet]
    [Route("structured-logging")]
    public ActionResult StructuredLoggingSample()
    {
        _logger.LogInformation("This is a logging messae with args: Today is {Week}. It is {Time}.", DateTime.Now.DayOfWeek, DateTime.Now.ToLongTimeString());
        _logger.LogInformation($"This is a logging messae with string concatenation: Today is {DateTime.Now.DayOfWeek}. It is {DateTime.Now.ToLongTimeString()}.");
        return Ok("This is to test the difference between structured logging and string concatenation");
    }
}
