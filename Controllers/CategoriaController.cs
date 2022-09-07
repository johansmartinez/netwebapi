using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;
using webapi.Services;
using webapi.Models;

[ApiController]
[Route("[controller]")]
public class CategoriaController : ControllerBase
{
    ICategoriaService categoriaService;
    private readonly ILogger<WeatherForecastController> _logger;

    public CategoriaController(ICategoriaService catserv, ILogger<WeatherForecastController> logger)
    {
        _logger=logger;
        categoriaService=catserv;
    }

    [HttpGet]
    public IActionResult Get(){
        return Ok(categoriaService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Categoria categoria){
        categoriaService.Save(categoria);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Post(Guid id,[FromBody] Categoria categoria){
        categoriaService.Update(id, categoria);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id){
        categoriaService.Delete(id);
        return Ok();
    }
}