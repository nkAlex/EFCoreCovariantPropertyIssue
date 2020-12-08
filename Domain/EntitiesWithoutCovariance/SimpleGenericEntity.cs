using Domain.Identifiers;

namespace Domain.EntitiesWithoutCovariance
{
    public class SimpleGenericEntity : SimpleGenericEntityBase<SimpleEntity>
    {
        protected SimpleGenericEntity(EntityId id) : base(id)
        {
        }
    }
}
