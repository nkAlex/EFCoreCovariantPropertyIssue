using Domain.EntitiesWithoutCovariance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ConfigurationsWithoutCovariance
{
    public class SimpleGenericEntityConfigurationWithHelperClass : IEntityTypeConfiguration<SimpleGenericEntity>
    {
        public void Configure(EntityTypeBuilder<SimpleGenericEntity> builder)
        {
            builder.ToTable("SimpleGenericEntities");

            builder.ConfigureSimpleGenericEntity<SimpleGenericEntity, SimpleEntity>();
        }
    }
}
