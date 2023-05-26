using System;
using System.Threading.Tasks;
using Dolphin.Freight.Settings.DisplaySetting;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Dolphin.Freight.Settinngs.DisplaySetting
{

    /// <summary>
    /// 顯示設定interface
    /// </summary>
    public interface IDisplaySettingAppService :
            ICrudAppService< //Defines CRUD methods
            DisplaySettingDTO, //顯示設定
            Guid,//Primary key of the book entity
            PagedAndSortedResultRequestDto,
            CreateUpdateDisplaySettingDTO> //修改顯示設定
    {
	}
}

