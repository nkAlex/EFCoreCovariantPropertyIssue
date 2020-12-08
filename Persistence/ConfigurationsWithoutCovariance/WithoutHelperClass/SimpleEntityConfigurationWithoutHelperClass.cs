using Domain.EntitiesWithoutCovariance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ConfigurationsWithoutCovariance
{
    public class SimpleEntityConfigurationWithoutHelperClass : IEntityTypeConfiguration<SimpleEntity>
    {
        public void Configure(EntityTypeBuilder<SimpleEntity> builder)
        {
            builder.ToTable("SimpleEntities");

            builder.Property(p => p.Id);

            builder.HasKey(k => k.Id);
        }
    }
}
