using Domain.Identifiers;
using Microsoft.EntityFrameworkCore.Storage;

namespace Persistence.Infrastructure
{
    public class IdentifierRelationalTypeMappingSourcePlugin : IRelationalTypeMappingSourcePlugin
    {
        public RelationalTypeMapping? FindMapping(in RelationalTypeMappingInfo mappingInfo)
        {

            return mappingInfo.ClrType.IsSubclassOf(typeof(Identifier)) ? new IdentifierRelationalTypeMapping(mappingInfo.ClrType) : null;
        }
    }
}
