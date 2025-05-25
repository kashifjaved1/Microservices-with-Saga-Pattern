namespace RabbitMq.Message.Events
{
    public interface IOrderStartedEvent
    {
        public Guid OrderId { get;  }
        public string PaymentCardNumber { get;  }
        public string ProductName { get;  }
    }
}
