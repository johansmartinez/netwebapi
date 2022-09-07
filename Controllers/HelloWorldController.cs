using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloWorldController : ControllerBase
{
    IHelloWorldService helloWorldService;
    private readonly ILogger<WeatherForecastController> _logger;

    public HelloWorldController(IHelloWorldService helloWorld, ILogger<WeatherForecastController> logger)
    {
        _logger=logger;
        helloWorldService=helloWorld;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("Consultando hello world");
        return Ok(helloWorldService.GetHelloWorld());
    }
}