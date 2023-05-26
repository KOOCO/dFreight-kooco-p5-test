using Dolphin.Freight.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Dolphin.Freight.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(FreightEntityFrameworkCoreModule),
    typeof(FreightApplicationContractsModule)
    )]
public class FreightDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
