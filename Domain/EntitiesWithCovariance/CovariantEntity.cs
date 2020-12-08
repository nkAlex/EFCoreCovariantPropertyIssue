using Domain.Identifiers;

namespace Domain.EntitiesWithCovariance
{
    public class CovariantEntity : CovariantEntityBase
    {
        public override EntityId Id { get; }

        public CovariantEntity(EntityId id) : base(id)
        {
            Id = id;
        }
    }
}
