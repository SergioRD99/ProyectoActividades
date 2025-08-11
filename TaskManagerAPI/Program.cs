using UseCases.Abstracciones;
using UseCases.interfaces;

var builder = WebApplication.CreateBuilder(args);

// Registrar controladores
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// Registrar tu servicio
builder.Services.AddScoped<ITask, TaskRepository>();

var app = builder.Build();

// Middleware y configuraci�n pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        options.RoutePrefix = string.Empty; // Swagger UI en la ra�z /
    });

    app.MapOpenApi(); // Solo si quieres tambi�n JSON OpenAPI
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();