namespace RabbitMq.Message.Events
{
    public interface IOrderValidateEvent
    {
        public Guid OrderId { get; }
        public string PaymentCardNumber { get; }
        public string ProductName { get; }
    }
}
