using StockService.Middleware;

namespace StockService.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static WebApplication BuildAndConfigureRequestPipeline(this WebApplicationBuilder builder)
        {
            var app = builder.Build();

            //app.UseMiddleware<ExceptionMiddleware>();
            //app.UseExceptionHandler();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}
