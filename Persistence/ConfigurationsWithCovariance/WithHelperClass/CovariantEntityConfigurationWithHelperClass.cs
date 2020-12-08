using Domain.EntitiesWithCovariance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ConfigurationsWithCovariance
{
    public class CovariantEntityConfigurationWithHelperClass : IEntityTypeConfiguration<CovariantEntity>
    {
        public void Configure(EntityTypeBuilder<CovariantEntity> builder)
        {
            builder.ToTable("CovariantEntities");

            builder.ConfigureCovariantEntity();
        }
    }
}
