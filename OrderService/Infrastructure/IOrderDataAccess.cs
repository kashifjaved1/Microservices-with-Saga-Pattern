using OrderService.Data.Entities;
using OrderService.ViewModel;

namespace OrderService.Infrastructure
{
    public interface IOrderDataAccess
    {
        List<OrderViewModel> GetAllOrder();

        void SaveOrder(OrderViewModel order);

        OrderViewModel GetOrder(Guid orderId);

        bool DeleteOrder(Guid orderId);
    }
}
