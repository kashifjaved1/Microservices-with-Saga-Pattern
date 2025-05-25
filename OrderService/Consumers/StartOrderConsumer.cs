using MassTransit;
using RabbitMq.Message;
using RabbitMq.Message.Events;

namespace OrderService.Consumers
{
    public class StartOrderConsumer : IConsumer<IStartOrder>
    {
        readonly ILogger<StartOrderConsumer> _logger;
        public StartOrderConsumer()
        {
        }

        public StartOrderConsumer(ILogger<StartOrderConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<IStartOrder> context)
        {
            _logger.LogInformation("--Application Event-- Order Transation Started and event published: {OrderId}", context.Message.OrderId);

            try
            {
                await context.Publish<IOrderStartedEvent>(new
                {
                    context.Message.OrderId,
                    context.Message.PaymentCardNumber,
                    context.Message.ProductName
                });
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
