using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Dolphin.Freight.Data;
using Volo.Abp.DependencyInjection;

namespace Dolphin.Freight.EntityFrameworkCore;

public class EntityFrameworkCoreFreightDbSchemaMigrator
    : IFreightDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreFreightDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the FreightDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<FreightDbContext>()
            .Database
            .MigrateAsync();

        // 伺服器提供者 添加既有 iFfreight 資料庫的 Context
        await _serviceProvider
            .GetRequiredService<IfreightDbContext>()
            .Database
            .MigrateAsync();

    }
}
