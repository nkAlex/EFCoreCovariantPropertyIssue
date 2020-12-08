using Microsoft.EntityFrameworkCore;
using Persistence.ConfigurationsWithCovariance;
using Persistence.Infrastructure;

namespace Persistence
{
    public class DbContextCovariantWithHelperClass : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInternalServiceProvider(Overrides.ServiceProvider);
            optionsBuilder.UseSqlite();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CovariantEntityConfigurationWithHelperClass());
            builder.ApplyConfiguration(new CovariantGenericEntityConfigurationWithHelperClass());
            base.OnModelCreating(builder);
        }
    }
}
