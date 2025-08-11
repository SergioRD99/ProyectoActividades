

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policyBuilder =>
    {
        policyBuilder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});//add

var app = builder.Build();
// Configuración de middlewares

app.UseCors("AllowAll");//add

app.ConfigureMiddlewares();

app.Run();

