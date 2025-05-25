using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMq.Message.Events
{
    public interface IOrderCanceledEvent
    {
        public Guid OrderId { get; }
        public string PaymentCardNumber { get; }
        public string ProductName { get; }
    }
}
