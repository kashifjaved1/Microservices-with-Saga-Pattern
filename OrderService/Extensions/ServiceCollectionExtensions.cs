using MassTransit;
using MassTransit.Definition;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OrderService.Consumers;
using OrderService.Infrastructure;
using OrderService.Infrastructure.Persistence;
using RabbitMq.Configuration;
using RabbitMq.Message;

namespace OrderService.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection Configuration(this IServiceCollection services, IConfiguration configuration)
        {
            services.TryAddSingleton(KebabCaseEndpointNameFormatter.Instance);
            services.AddMassTransit(cfg =>
            {
                cfg.AddRequestClient<IStartOrder>();

                cfg.AddConsumer<StartOrderConsumer>();
                cfg.AddConsumer<OrderCancelledConsumer>();

                cfg.AddBus(provider => RabbitMqBus.ConfigureBus(provider));
            });

            services.AddDbContext<OrderDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IOrderDataAccess, OrderDataAccess>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddMassTransitHostedService();

            return services;
        }
    }
}
