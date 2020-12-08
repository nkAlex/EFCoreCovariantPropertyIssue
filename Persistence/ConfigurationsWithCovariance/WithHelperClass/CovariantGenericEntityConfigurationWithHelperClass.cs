using Domain.EntitiesWithCovariance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ConfigurationsWithCovariance
{
    public class CovariantGenericEntityConfigurationWithHelperClass : IEntityTypeConfiguration<CovariantGenericEntity>
    {
        public void Configure(EntityTypeBuilder<CovariantGenericEntity> builder)
        {
            builder.ToTable("CovariantGenericEntities");

            builder.ConfigureCovariantGenericEntity<CovariantGenericEntity, CovariantEntity>();
        }
    }
}
