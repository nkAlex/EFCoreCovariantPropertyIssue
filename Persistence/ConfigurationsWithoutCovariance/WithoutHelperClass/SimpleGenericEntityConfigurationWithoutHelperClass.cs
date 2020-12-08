using Domain.EntitiesWithoutCovariance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ConfigurationsWithoutCovariance
{
    public class SimpleGenericEntityConfigurationWithoutHelperClass : IEntityTypeConfiguration<SimpleGenericEntity>
    {
        public void Configure(EntityTypeBuilder<SimpleGenericEntity> builder)
        {
            builder.ToTable("SimpleGenericEntities");

            builder.Property(p => p.Id);

            builder.HasMany(p => p.Collection)
                   .WithOne()
                   .HasForeignKey(k => k.Id);

            builder.HasKey(k => k.Id);
        }
    }
}
