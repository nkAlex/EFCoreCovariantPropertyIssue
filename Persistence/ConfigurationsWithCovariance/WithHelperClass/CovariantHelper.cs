using Domain.EntitiesWithCovariance;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ConfigurationsWithCovariance
{
    public static class CovariantHelper
    {
        public static void ConfigureCovariantEntity<T>(this EntityTypeBuilder<T> builder)
            where T : CovariantEntityBase
        {
            builder.Property(p => p.Id);

            builder.HasKey(k => k.Id);
        }

        public static void ConfigureCovariantGenericEntity<T0, T1>(this EntityTypeBuilder<T0> builder)
            where T0 : CovariantGenericEntityBase<T1>
            where T1 : CovariantEntityBase
        {
            builder.Property(p => p.Id);

            builder.HasMany(p => p.Collection)
                   .WithOne()
                   .HasForeignKey(k => k.Id);

            builder.HasKey(k => k.Id);
        }
    }
}
