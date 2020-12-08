using System.Collections.Generic;
using Domain.Identifiers;

namespace Domain.EntitiesWithCovariance
{
    public class CovariantGenericEntityBase<T> : CovariantEntityBase where T : CovariantEntityBase
    {
        public HashSet<T>? Collection { get; set; }

        protected CovariantGenericEntityBase(Identifier id) : base(id)
        {
        }
    }
}
