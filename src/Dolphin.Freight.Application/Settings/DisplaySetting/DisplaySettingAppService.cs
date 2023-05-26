using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Dolphin.Freight.Permissions;
using Dolphin.Freight.Settinngs.DisplaySetting;
using Dolphin.Freight.Settings.DisplaySetting;
using System.Threading.Tasks;

namespace Dolphin.Freight.Settings.DisplaySetting
{
    public class DisplaySettingAppService : CrudAppService<
            DisplaySetting,//空運出口其他費用entity
            DisplaySettingDTO,//空運出口其他費用顯示用
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto,
            CreateUpdateDisplaySettingDTO>, //空運出口其他費用CRUD用
        IDisplaySettingAppService
    {
        public DisplaySettingAppService(IRepository<DisplaySetting, Guid> repository) : base(repository)
        {
            GetPolicyName = SettingsPermissions.DisplaySetting.Default;
            GetListPolicyName = SettingsPermissions.DisplaySetting.Default;
            CreatePolicyName = SettingsPermissions.DisplaySetting.Create;
            UpdatePolicyName = SettingsPermissions.DisplaySetting.Edit;
            DeletePolicyName = SettingsPermissions.DisplaySetting.Delete;
        }
    }
}

