using Domain.Identifiers;

namespace Domain.EntitiesWithCovariance
{
    public class CovariantGenericEntity : CovariantGenericEntityBase<CovariantEntity>
    {
        public override EntityId Id { get; }

        protected CovariantGenericEntity(EntityId id) : base(id)
        {
            Id = id;
        }
    }
}
