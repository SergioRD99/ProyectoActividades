namespace ActivitiesAPI.Configuration
{
    public static class MiddlewareConfiguration
    {
        public static WebApplication ConfigureMiddlewares(this WebApplication app)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API v1");
            });

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Configuración de CORS
            app.UseCors("AllowAll");

            return app;
        }
    }
}
