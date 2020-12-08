using Domain.EntitiesWithCovariance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ConfigurationsWithCovariance
{
    public class CovariantGenericEntityConfigurationWithoutHelperClass : IEntityTypeConfiguration<CovariantGenericEntity>
    {
        public void Configure(EntityTypeBuilder<CovariantGenericEntity> builder)
        {
            builder.ToTable("CovariantGenericEntities");

            builder.Property(p => p.Id);

            builder.HasMany(p => p.Collection)
                   .WithOne()
                   .HasForeignKey(k => k.Id);

            builder.HasKey(k => k.Id);
        }
    }
}
