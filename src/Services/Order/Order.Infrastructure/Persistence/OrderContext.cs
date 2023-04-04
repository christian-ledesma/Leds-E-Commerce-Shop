using Microsoft.EntityFrameworkCore;
using Order.Domain.Common;

namespace Order.Infrastructure.Persistence
{
    using Order.Domain.Entities;

    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
            
        }

        public virtual DbSet<Order> Orders { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries<EntityBase>())
            {
                switch (item.State)
                {
                    case EntityState.Added:
                        item.Entity.CreatedDate = DateTime.UtcNow;
                        item.Entity.CreatedBy = "christianleds";
                        break;
                    case EntityState.Modified:
                        item.Entity.LastModifiedDate = DateTime.UtcNow;
                        item.Entity.LastModifiedBy = "christianleds";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
