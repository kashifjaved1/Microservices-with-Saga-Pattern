using Automatonymous;
using System.ComponentModel.DataAnnotations;

namespace RabbitMq.Saga.StateMachine
{
    public class OrderStateData : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public string CurrentState { get; set; }
        public DateTime? OrderCreationDateTime { get; set; }
        public DateTime? OrderCancelDateTime { get; set; }
        public Guid OrderId { get; set; }
        public string PaymentCardNumber { get; set; }
        public string ProductName { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        //// Managed manually (e.g., using Fluent API or database trigger)
        //public long RowVersion { get; set; }
        //// Uncomment above and paste following in dbcontext class.
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<OrderStateData>()
        //        .Property(p => p.RowVersion)
        //        .IsRowVersion(); // Or .IsConcurrencyToken() for non-byte[] types
        //}
    }
}