using Domain.EntitiesWithoutCovariance;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ConfigurationsWithoutCovariance
{
    public static class SimpleHelper
    {
        public static void ConfigureSimpleEntity<T>(this EntityTypeBuilder<T> builder)
            where T : SimpleEntityBase
        {
            builder.Property(p => p.Id);

            builder.HasKey(k => k.Id);
        }

        public static void ConfigureSimpleGenericEntity<T0, T1>(this EntityTypeBuilder<T0> builder)
            where T0 : SimpleGenericEntityBase<T1>
            where T1 : SimpleEntityBase
        {
            builder.Property(p => p.Id);

            builder.HasMany(p => p.Collection)
                   .WithOne()
                   .HasForeignKey(k => k.Id);

            builder.HasKey(k => k.Id);
        }
    }
}
