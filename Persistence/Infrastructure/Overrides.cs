using System;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence.Infrastructure
{
    public static class Overrides
    {
        public static readonly IServiceProvider ServiceProvider =
            new ServiceCollection()
                .AddSingleton<IRelationalTypeMappingSourcePlugin, IdentifierRelationalTypeMappingSourcePlugin>()
                .AddEntityFrameworkSqlite()
                .BuildServiceProvider();
    }
}
