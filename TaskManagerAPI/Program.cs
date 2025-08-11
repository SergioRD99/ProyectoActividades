using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using UseCases.Abstracciones;
using UseCases.interfaces;

var builder = WebApplication.CreateBuilder(args);

// Limpiar proveedores de logs y agregar consola para ver detalles
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Registrar controladores
builder.Services.AddControllers();

// Configuración de la base de datos con logs detallados
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar tu servicio
builder.Services.AddScoped<ITask, TaskRepository>();

var app = builder.Build();

// Middleware y configuración pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Task Manager API V1");
        options.RoutePrefix = string.Empty; // Swagger UI en la raíz /
    });

    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();