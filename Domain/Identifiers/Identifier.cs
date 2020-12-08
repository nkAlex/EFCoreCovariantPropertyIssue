using System;

namespace Domain.Identifiers
{
    public abstract class Identifier
    {
        private readonly Guid _value;

        protected Identifier(Guid value)
        {
            _value = value;
        }

        public static implicit operator Guid(Identifier identifier)
        {
            return identifier._value;
        }
    }
}
