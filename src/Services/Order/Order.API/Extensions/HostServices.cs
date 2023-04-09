using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Order.API.Extensions
{
    public static class HostServices
    {
        public static WebApplicationBuilder MigrateDatabase<T>(this WebApplicationBuilder builder, Action<T, IServiceProvider> seeder,
            int? retry = 0) where T : DbContext
        {
            using (var scope = builder.Services.BuildServiceProvider().CreateScope())
            {
                var retryForAvailability = retry.Value;
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<T>>();
                var context = services.GetService<T>();

                try
                {
                    logger.LogInformation("Migrating database associated with context {DbContextName}", typeof(T).Name);

                    InvokeSeeder(seeder, context, services);
                
                    //if (retryForAvailability < 50)
                    //{
                    //    retryForAvailability++;
                    //    Thread.Sleep(2000);
                    //    MigrateDatabase<T>(builder, seeder, retryForAvailability);
                    //}

                    logger.LogInformation("Migrated database associated with context {DbContextName}", typeof(T).Name);
                }
                catch (SqlException ex)
                {
                    logger.LogError(ex, "An error occurred while migrating the database used on context {DbContextName}", typeof(T).Name);
                }
            }
            return builder;
        }

        private static void InvokeSeeder<TContext>(Action<TContext, IServiceProvider> seeder, TContext context, IServiceProvider services)
            where TContext : DbContext
        {
            context.Database.Migrate();
            seeder(context, services);
        }
    }
}
