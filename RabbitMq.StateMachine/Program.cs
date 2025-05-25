using MassTransit;
using MassTransit.EntityFrameworkCoreIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using RabbitMq.Configuration;
using RabbitMq.Saga.DbConfiguration;
using RabbitMq.Saga.StateMachine;
using System.Reflection;

namespace RabbitMq.StateMachine
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OrderStateDb;Integrated Security=true";

            var builder = new HostBuilder()
               .ConfigureServices((hostContext, services) =>
               {
                   services.AddMassTransit(cfg =>
                   {
                       cfg.AddSagaStateMachine<OrderStateMachine, OrderStateData>()
                        .EntityFrameworkRepository(r =>
                        {
                            r.ConcurrencyMode = ConcurrencyMode.Pessimistic; // or use Optimistic, which works with RowVersion

                            r.AddDbContext<DbContext, OrderStateDbContext>((provider, builder) =>
                            {
                                builder.UseSqlServer(connectionString, m =>
                                {
                                    m.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
                                    m.MigrationsHistoryTable($"__{nameof(OrderStateDbContext)}");
                                });
                            });
                        });

                       cfg.AddBus(provider => RabbitMqBus.ConfigureBus(provider));
                   });

                   services.AddMassTransitHostedService();
               });

            await builder.RunConsoleAsync();
        }
    }
}
