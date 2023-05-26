using System.Threading.Tasks;

namespace Dolphin.Freight.Data;

public interface IFreightDbSchemaMigrator
{
    Task MigrateAsync();
}
