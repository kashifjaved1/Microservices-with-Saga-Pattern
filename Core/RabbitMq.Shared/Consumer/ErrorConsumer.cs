using MassTransit;

namespace RabbitMq.Common.Consumer
{
    public class ErrorConsumer : IConsumer<string>
    {
        public async Task Consume(ConsumeContext<string> context)
        {
            var data = context.Message;
            if(data is null)
            {
                return;
            }

            throw new Exception(data);
        }
    }
}
