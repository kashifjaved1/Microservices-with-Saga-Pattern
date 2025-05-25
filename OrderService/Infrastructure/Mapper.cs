using OrderService.Data.Entities;
using OrderService.ViewModel;

namespace OrderService.Infrastructure
{
    public static class Mapper
    {
        public static OrderViewModel ToModel(this Order order)
        {
            return new OrderViewModel
            {
                OrderId = order.OrderId,
                CardNumber = order.CardNumber,
                ProductName = order.ProductName,
                UserId = order.UserId
            };
        }

        public static Order ToEntity(this OrderViewModel model)
        {
            return new Order
            {
                OrderId = model.OrderId,
                CardNumber = model.CardNumber,
                ProductName = model.ProductName,
                UserId = model.UserId
            };
        }
    }
}
