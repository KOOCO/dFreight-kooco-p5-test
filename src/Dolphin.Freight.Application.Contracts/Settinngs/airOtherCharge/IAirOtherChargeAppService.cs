using System;
using System.Threading.Tasks;
using Dolphin.Freight.Settings.AirOtherCharge;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Dolphin.Freight.Settinngs.AirOtherCharge
{

    /// <summary>
    /// 空運出口其他費用interface
    /// </summary>
    public interface IAirOtherChargeAppService :
            ICrudAppService< //Defines CRUD methods
            AirOtherChargeDTO, //顯示空運出口其他費用
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto,//Used for paging/sorting
            CreateUpdateAirOtherChargeDTO> //新增修改空運出口其他費用
    {

    }
}

