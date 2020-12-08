using Domain.Identifiers;

namespace Domain.EntitiesWithoutCovariance
{
    public class SimpleEntity : SimpleEntityBase
    {
        public SimpleEntity(EntityId id) : base(id)
        {
        }
    }
}
