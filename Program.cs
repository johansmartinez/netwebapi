using webapi;
using webapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<TareasContext>("Data Source=DESKTOP-AGLEMT3\\Johan");
builder.Services.AddScoped<IHelloWorldService, HelloWorldService>();
builder.Services.AddScoped<ICategoriaService,CategoriaService>();
builder.Services.AddScoped<ITareaService,TareaService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseWelcomePage(); // mostrar una página de inicio
//app.UseTimeMiddleware();

app.MapControllers();

app.Run();
