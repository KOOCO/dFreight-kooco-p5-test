using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace Dolphin.Freight;

[DependsOn(
    typeof(FreightDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(FreightApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class FreightApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<FreightApplicationModule>();
        });

        // 錯誤訊息傳送到客戶端(但是這個太詳細了，第幾行出錯都直接講出來)，但是可以拿來偵錯用
        // Configure<Volo.Abp.AspNetCore.ExceptionHandling.AbpExceptionHandlingOptions>(options =>
        // {
        //     options.SendExceptionsDetailsToClients = true;
        // });
    }
}
