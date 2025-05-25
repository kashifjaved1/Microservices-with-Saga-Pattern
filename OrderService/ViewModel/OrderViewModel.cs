namespace OrderService.ViewModel
{
    public class OrderViewModel
    {
        public required Guid OrderId { get; set; }
        public required string ProductName { get; set; }
        public required string CardNumber { get; set; }
        public required string UserId { get; set; }

        public OrderViewModel()
        {
            
        }
    }
}
