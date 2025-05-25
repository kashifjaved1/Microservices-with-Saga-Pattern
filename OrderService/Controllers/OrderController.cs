using MassTransit;
using Microsoft.AspNetCore.Mvc;
using OrderService.Infrastructure;
using OrderService.ViewModel;
using RabbitMq.Configuration;
using RabbitMq.Message;
using RabbitMq.Message.Events;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;
        private readonly string errorsEndpoint;
        private readonly IOrderDataAccess _orderDataAccess;

        public OrderController(ISendEndpointProvider sendEndpointProvider, IOrderDataAccess orderDataAccess)
        {
            _sendEndpointProvider = sendEndpointProvider;
            _orderDataAccess = orderDataAccess;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateOrderUsingStateMachine([FromBody] OrderViewModel model)
        {
            model.OrderId = Guid.NewGuid();
            var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:" + BusConstants.StartOrderTranastionQueue)); 

            _orderDataAccess.SaveOrder(model);

            await endpoint.Send<IStartOrder>(new
            {
                OrderId = model.OrderId,
                PaymentCardNumber = model.CardNumber,
                ProductName = model.ProductName
            });

            return Ok("Success");
        }

        [HttpGet]
        [Route("Orders")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_orderDataAccess.GetAllOrder());
        }

        [HttpGet]
        [Route("Order")]
        public async Task<IActionResult> GetOrder(Guid orderId)
        {
            try
            {
                return Ok(_orderDataAccess.GetOrder(orderId));
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteOrder(Guid orderId)
        {
            try
            {
                return Ok(_orderDataAccess.DeleteOrder(orderId));
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}