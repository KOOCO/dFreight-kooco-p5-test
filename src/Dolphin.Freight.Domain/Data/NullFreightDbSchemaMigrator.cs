using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Dolphin.Freight.Data;

/* This is used if database provider does't define
 * IFreightDbSchemaMigrator implementation.
 */
public class NullFreightDbSchemaMigrator : IFreightDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
