using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Dolphin.Freight.Settings.ItNoRanges
{
    /// <summary>
    /// IT號碼管理interface
    /// </summary>
    public interface IItNoRangeAppService :
            ICrudAppService< //Defines CRUD methods
            ItNoRangeDto, //顯示IT號碼管理用
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateItNoRangeDto> //新增修改IT號碼管理用
    {
    }
}
