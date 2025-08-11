using Activities.Entities;
using System.Text.Json.Serialization;

namespace ActivitiesAPI.Configuration
{
    internal static class ServicesConfiguration
    {
        public static WebApplicationBuilder ConfigurationWebApi(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.Configure<ConnectionStringOptions>(
                builder.Configuration.GetSection(ConnectionStringOptions.SectionKey));


            // Configurar CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policyBuilder =>
                {
                    policyBuilder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            var connectionStringOptions = builder.Configuration
                .GetSection(ConnectionStringOptions.SectionKey)
                .Get<ConnectionStringOptions>();

            // Pasar las opciones de conexión a BackendServices
            builder.Services.BackendServices(connectionStringOptions);

            // Configurar controladores
            builder.Services.AddControllers().AddJsonOptions(options =>
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull);

            return builder;
        }
    }
}
