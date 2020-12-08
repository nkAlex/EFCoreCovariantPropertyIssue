using Domain.EntitiesWithoutCovariance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ConfigurationsWithoutCovariance
{
    public class SimpleEntityConfigurationWithHelperClass : IEntityTypeConfiguration<SimpleEntity>
    {
        public void Configure(EntityTypeBuilder<SimpleEntity> builder)
        {
            builder.ToTable("SimpleEntities");

            builder.ConfigureSimpleEntity();
        }
    }
}
