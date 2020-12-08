using Microsoft.EntityFrameworkCore;
using Persistence.ConfigurationsWithCovariance;
using Persistence.Infrastructure;

namespace Persistence
{
    public class DbContextCovariantWithoutHelperClass : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInternalServiceProvider(Overrides.ServiceProvider);
            optionsBuilder.UseSqlite();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CovariantEntityConfigurationWithoutHelperClass());
            builder.ApplyConfiguration(new CovariantGenericEntityConfigurationWithoutHelperClass());
            base.OnModelCreating(builder);
        }
    }
}
