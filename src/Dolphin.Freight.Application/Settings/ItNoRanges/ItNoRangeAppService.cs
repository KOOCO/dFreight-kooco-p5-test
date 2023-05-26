using Dolphin.Freight.Permissions;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Dolphin.Freight.Settings.ItNoRanges
{
    public class ItNoRangeAppService :
        CrudAppService<
            ItNoRange, //IT號碼管理entity
            ItNoRangeDto, //顯示IT號碼管理用
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateItNoRangeDto>, //新增修改IT號碼管理用
        IItNoRangeAppService //實作IItNoRangeAppService
    {
        public ItNoRangeAppService(IRepository<ItNoRange, Guid> repository)
            : base(repository)
        {
            GetPolicyName = SettingsPermissions.ItNoRanges.Default;
            GetListPolicyName = SettingsPermissions.ItNoRanges.Default;
            CreatePolicyName = SettingsPermissions.ItNoRanges.Create;
            UpdatePolicyName = SettingsPermissions.ItNoRanges.Edit;
            DeletePolicyName = SettingsPermissions.ItNoRanges.Delete;
        }
    }
}
