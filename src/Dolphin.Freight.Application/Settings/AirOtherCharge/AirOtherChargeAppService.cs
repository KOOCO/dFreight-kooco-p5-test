using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Dolphin.Freight.Permissions;
using Dolphin.Freight.Settinngs.AirOtherCharge;

namespace Dolphin.Freight.Settings.AirOtherCharge
{
    public class AirOtherChargeAppService : CrudAppService<
            AirOtherCharge,//空運出口其他費用entity
            AirOtherChargeDTO,//空運出口其他費用顯示用
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto,//Used for paging/sorting
            CreateUpdateAirOtherChargeDTO>, //空運出口其他費用CRUD用
       IAirOtherChargeAppService
    {
        public AirOtherChargeAppService(IRepository<AirOtherCharge, Guid> repository) : base(repository)
        {
            GetPolicyName = SettingsPermissions.AirOtherCharge.Default;
            GetListPolicyName = SettingsPermissions.AirOtherCharge.Default;
            CreatePolicyName = SettingsPermissions.AirOtherCharge.Create;
            UpdatePolicyName = SettingsPermissions.AirOtherCharge.Edit;
            DeletePolicyName = SettingsPermissions.AirOtherCharge.Delete;
        }
    }
}

