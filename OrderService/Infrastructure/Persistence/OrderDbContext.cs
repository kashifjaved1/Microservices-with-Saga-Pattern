using Microsoft.EntityFrameworkCore;
using OrderService.Data.Entities;

namespace OrderService.Infrastructure.Persistence
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        // required by ef core.
        private OrderDbContext()
        {
        }

        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }
    }
}
