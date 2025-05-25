using MassTransit;
using RabbitMq.Message.Events;
namespace StockService.Consumer
{
    public class OrderValidateConsumer : IConsumer<IOrderValidateEvent>
    {
        public async Task Consume(ConsumeContext<IOrderValidateEvent> context)
        {
            var data = context.Message;

            if (data.PaymentCardNumber.Contains("test"))
            {
                await context.Publish<IOrderCanceledEvent>(
          new { OrderId = context.Message.OrderId, PaymentCardNumber = context.Message.PaymentCardNumber });
            }
            else
            {
                // send to next microservice
            }
        }
    }
}
