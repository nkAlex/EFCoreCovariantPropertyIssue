using Domain.Identifiers;

namespace Domain.EntitiesWithoutCovariance
{
    public class SimpleEntityBase
    {
        public EntityId Id { get; }

        public SimpleEntityBase(EntityId id)
        {
            Id = id;
        }
    }
}
