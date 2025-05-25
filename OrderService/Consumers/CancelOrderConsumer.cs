using MassTransit;
using OrderService.Infrastructure;
using RabbitMq.Message.Events;

namespace OrderService.Consumers
{

    public class CancelOrderConsumer :
    IConsumer<IOrderCanceledEvent>
    {
        private readonly IOrderDataAccess _orderDataAccess;

        public CancelOrderConsumer(IOrderDataAccess orderDataAccess)
        {
            _orderDataAccess = orderDataAccess;
        }

        public async Task Consume(ConsumeContext<IOrderCanceledEvent> context)
        {
            var data = context.Message;

            // delete from order database
            _orderDataAccess.DeleteOrder(data.OrderId);
        }
    }
}
