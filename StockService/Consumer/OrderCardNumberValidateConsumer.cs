using MassTransit;
using RabbitMq.Message;

namespace StockService.Consumer
{
    public class OrderCardNumberValidateConsumer : IConsumer<IOrderMessage>
    {
        public async Task Consume(ConsumeContext<IOrderMessage> context)
        {
            var data = context.Message;
        }
    }
}
