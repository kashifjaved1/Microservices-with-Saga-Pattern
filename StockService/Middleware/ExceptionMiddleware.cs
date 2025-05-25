using MassTransit;
using RabbitMq.Configuration;

namespace StockService.Middleware
{
    public class ExceptionMiddleware(RequestDelegate next,
        ISendEndpointProvider sendEndpointProvider)
    {
        private readonly RequestDelegate next = next;
        private readonly ISendEndpointProvider _sendEndpointProvider = sendEndpointProvider;

        public async Task InvokeAsync(HttpContext context)
        {
            // UseExceptionHandler will handle non-api calls (as it renders HTML).

            try
            {
                await this.next(context);
            }
            catch (Exception ex)
            {
                var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:" + BusConstants.ErrorQueue));

                await endpoint.Send(ex.Message);
            }
        }
    }
}
