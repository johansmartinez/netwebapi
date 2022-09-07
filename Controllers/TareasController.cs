using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;
using webapi.Services;
using webapi.Models;

[ApiController]
[Route("[controller]")]
public class TareasController : ControllerBase
{
    ITareaService tareaService;
    private readonly ILogger<WeatherForecastController> _logger;

    public TareasController(ITareaService tareaServ, ILogger<WeatherForecastController> logger)
    {
        _logger=logger;
        tareaService=tareaServ;
    }

    [HttpGet]
    public IActionResult Get(){
        return Ok(tareaService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Tarea tarea){
        tareaService.Save(tarea);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Post(Guid id,[FromBody] Tarea tarea){
        tareaService.Update(id, tarea);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id){
        tareaService.Delete(id);
        return Ok();
    }
}