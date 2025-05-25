using RabbitMq.Message.Events;

namespace RabbitMq.Saga.StateMachine
{
    public class CardValidateEvent: ICardValidatorEvent
    {
        private readonly OrderStateData orderSagaState;
        public CardValidateEvent(OrderStateData orderStateData)
        {
            orderSagaState = orderStateData;
        }

        public Guid OrderId => orderSagaState.OrderId;
        public string PaymentCardNumber => orderSagaState.PaymentCardNumber;
        public string ProductName => orderSagaState.ProductName;
    }
}