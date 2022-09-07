using webapi.Models;
namespace webapi.Services;

public class TareaService : ITareaService
{
    TareasContext context;

    public TareaService(TareasContext dbcontex)
    {
        context=dbcontex;
    }

    public IEnumerable<Tarea> Get()
    {
        return context.Tareas;
    }

    public async Task Save(Tarea tarea)
    {
        context.Add(tarea);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id,Tarea tarea)
    {
        var tareaActual =context.Tareas.Find(id);
        if (tareaActual!=null)
        {
            tareaActual.Titulo=tarea.Titulo;
            tareaActual.Descripcion=tarea.Descripcion;
            tareaActual.PrioridadTarea=tarea.PrioridadTarea;
            await context.SaveChangesAsync();
        }
        context.SaveChanges();
    }

    public async Task Delete(Guid id)
    {
        var tareaActual =context.Tareas.Find(id);
        if (tareaActual!=null)
        {
            context.Remove(tareaActual);
            await context.SaveChangesAsync();
        }
    }
}

public interface ITareaService
{
    IEnumerable<Tarea> Get();
    Task Save(Tarea tarea);
    Task Update(Guid id,Tarea tarea);
    Task Delete(Guid id);

}