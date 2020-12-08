using System;

namespace Domain.Identifiers
{
    public class EntityId : Identifier
    {
        public EntityId(Guid value) : base(value)
        {
        }
    }
}
