using Microsoft.EntityFrameworkCore;
using Persistence.ConfigurationsWithoutCovariance;
using Persistence.Infrastructure;

namespace Persistence
{
    public class DbContextSimpleWithoutHelperClass : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInternalServiceProvider(Overrides.ServiceProvider);
            optionsBuilder.UseSqlite();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new SimpleEntityConfigurationWithoutHelperClass());
            builder.ApplyConfiguration(new SimpleGenericEntityConfigurationWithoutHelperClass());
            base.OnModelCreating(builder);
        }
    }
}
