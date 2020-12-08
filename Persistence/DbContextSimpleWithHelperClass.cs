using Microsoft.EntityFrameworkCore;
using Persistence.ConfigurationsWithoutCovariance;
using Persistence.Infrastructure;

namespace Persistence
{
    public class DbContextSimpleWithHelperClass : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInternalServiceProvider(Overrides.ServiceProvider);
            optionsBuilder.UseSqlite();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new SimpleEntityConfigurationWithHelperClass());
            builder.ApplyConfiguration(new SimpleGenericEntityConfigurationWithHelperClass());
            base.OnModelCreating(builder);
        }
    }
}
