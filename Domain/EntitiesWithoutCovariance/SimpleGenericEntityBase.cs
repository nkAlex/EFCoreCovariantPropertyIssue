using System.Collections.Generic;
using Domain.Identifiers;

namespace Domain.EntitiesWithoutCovariance
{
    public class SimpleGenericEntityBase<T> : SimpleEntityBase where T : SimpleEntityBase
    {
        public HashSet<T>? Collection { get; set; }

        protected SimpleGenericEntityBase(EntityId id) : base(id)
        {
        }
    }
}
