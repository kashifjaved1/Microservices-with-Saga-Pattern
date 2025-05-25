using OrderService.Data.Entities;
using OrderService.Infrastructure.Persistence;
using OrderService.ViewModel;

namespace OrderService.Infrastructure
{
    public class OrderDataAccess : IOrderDataAccess
    {
        private readonly OrderDbContext _context;

        public OrderDataAccess(OrderDbContext context)
        {
            _context = context;
        }

        public List<OrderViewModel> GetAllOrder()
        {
            var orders = _context.Orders?.ToList();
            var orderModel = new List<OrderViewModel>();
            orders?.ForEach(order => orderModel.Add(order.ToModel()));
            return orderModel;
        }
        public void SaveOrder(OrderViewModel order)
        {
            _context.Add(order.ToEntity());
            _context.SaveChanges();
        }

        public OrderViewModel GetOrder(Guid orderId)
        {
            return _context.Orders.Where(x => x.OrderId == orderId)?.FirstOrDefault()?.ToModel();
        }

        public bool DeleteOrder(Guid orderId)
        {
            var order = _context.Orders.Where(x => x.OrderId == orderId).FirstOrDefault();

            if (order == null)
            {
                return false;
               
            }

            _context.Remove(order);
            return _context.SaveChanges() > 0;
        }
    }
}
