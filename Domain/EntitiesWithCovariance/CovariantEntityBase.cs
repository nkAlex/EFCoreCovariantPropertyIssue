using Domain.Identifiers;

namespace Domain.EntitiesWithCovariance
{
    public class CovariantEntityBase
    {
        public virtual Identifier Id { get; }

        public CovariantEntityBase(Identifier id)
        {
            Id = id;
        }
    }
}
