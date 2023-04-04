using Order.Application.Contracts.Persistence;
using Order.Infrastructure.Persistence;

namespace Order.Infrastructure.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Order.Domain.Entities;

    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(OrderContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
        {
            var orders = await _context.Orders
                                .Where(o => o.UserName == userName)
                                .ToListAsync();
            return orders;
        }
    }
}
