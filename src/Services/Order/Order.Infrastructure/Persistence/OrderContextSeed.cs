using Microsoft.Extensions.Logging;

namespace Order.Infrastructure.Persistence
{
    using Order.Domain.Entities;

    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(OrderContext).Name);
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order()
                {
                    UserName = "christianleds",
                    FirstName = "Christian",
                    LastName = "Ledesma",
                    EmailAddress = "christian_ledesma_a@hotmail.com",
                    AddressLine = "Madrid",
                    Country = "España",
                    TotalPrice = 350
                }
            };
        }
    }
}
