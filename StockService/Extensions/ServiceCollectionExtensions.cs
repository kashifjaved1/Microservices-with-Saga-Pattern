using MassTransit;
using MassTransit.Definition;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RabbitMq.Configuration;
using StockService.Consumer;
using StockService.Middleware;

namespace StockService.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection Configuration(this IServiceCollection services, IConfiguration configuration)
        {
            services.TryAddSingleton(KebabCaseEndpointNameFormatter.Instance);
            services.AddMassTransit(cfg =>
            {
                cfg.AddConsumer<OrderValidateConsumer>();

                cfg.AddBus(provider => RabbitMqBus.ConfigureBus(provider, (cfg, host) =>
                {
                }));
            });

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddMassTransitHostedService();

            return services;
        }
    }
}
