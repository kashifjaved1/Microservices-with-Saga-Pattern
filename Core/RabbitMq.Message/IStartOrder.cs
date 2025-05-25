namespace RabbitMq.Message
{
    public interface IStartOrder
    {
        public Guid OrderId { get; }
        public string PaymentCardNumber { get; }
        public string ProductName { get; }
    }
}
