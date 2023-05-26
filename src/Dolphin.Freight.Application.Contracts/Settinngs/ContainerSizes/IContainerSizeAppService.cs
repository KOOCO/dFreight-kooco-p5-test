using Dolphin.Freight.Common;
using Dolphin.Freight.Settinngs.ContainerSizes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Dolphin.Freight.Settinngs.ContainerSizes
{
    public interface IContainerSizeAppService :
        ICrudAppService< //Defines CRUD methods
        ContainerSizeDto, //顯示Awb號碼管理用
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateContainerSizeDto> //新增修改Awb號碼管理用
    {
        Task<PagedResultDto<ContainerSizeDto>> QueryListAsync(QueryDto query);
        Task<List<ContainerSizeDto>> QueryAllListAsync(QueryDto query);
    }
}