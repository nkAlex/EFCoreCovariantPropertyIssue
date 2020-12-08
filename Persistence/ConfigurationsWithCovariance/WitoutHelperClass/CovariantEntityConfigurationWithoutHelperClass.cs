using Domain.EntitiesWithCovariance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ConfigurationsWithCovariance
{
    public class CovariantEntityConfigurationWithoutHelperClass : IEntityTypeConfiguration<CovariantEntity>
    {
        public void Configure(EntityTypeBuilder<CovariantEntity> builder)
        {
            builder.ToTable("CovariantEntities");

            builder.Property(p => p.Id);

            builder.HasKey(k => k.Id);
        }
    }
}
