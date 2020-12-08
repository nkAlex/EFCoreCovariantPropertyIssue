using System;
using System.Linq.Expressions;
using Domain.Identifiers;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Persistence.Infrastructure
{
    public class IdentifierToGuidValueConverter<T> : ValueConverter<T, Guid> where T : Identifier
    {
        private static readonly Func<Guid, T> _acrivator = CreateActivator();
        private static readonly Expression<Func<T, Guid>> _toProviderExpression = x => (Guid)x;
        private static readonly Expression<Func<Guid, T>> _fromProviderExpression = x => _acrivator(x);

        public static IdentifierToGuidValueConverter<T> Default { get; } = new();

        public IdentifierToGuidValueConverter(ConverterMappingHints? mappingHints = null)
            : base(_toProviderExpression, _fromProviderExpression, mappingHints)
        {
        }

        private static Func<Guid, T> CreateActivator()
        {
            var constructor = typeof(T).GetConstructor(new[] {typeof(Guid)})!;
            var parameter = Expression.Parameter(typeof(Guid), "value");
            var creatorExpression = Expression.Lambda<Func<Guid, T>>(Expression.New(constructor, parameter), parameter);
            return creatorExpression.Compile();
        }
    }
}
