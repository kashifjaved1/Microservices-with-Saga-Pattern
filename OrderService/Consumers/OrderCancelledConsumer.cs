using MassTransit;
using OrderService.Infrastructure;
using RabbitMq.Message.Events;

namespace OrderService.Consumers
{
    public class OrderCancelledConsumer : IConsumer<IOrderCanceledEvent>
    {
        private readonly IOrderDataAccess _orderDataAccess;

        public OrderCancelledConsumer(IOrderDataAccess orderDataAccess)
        {
            _orderDataAccess = orderDataAccess;
        }

        public async Task Consume(ConsumeContext<IOrderCanceledEvent> context)
        {
            var data = context.Message;
            _orderDataAccess.DeleteOrder(data.OrderId);
        }
    }
}
