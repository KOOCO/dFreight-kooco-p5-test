using Dolphin.Freight.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Dolphin.Freight.AccountingSettings.GlCodes
{
    public interface IGlCodeAppService :
        ICrudAppService< 
        GlCodeDto, 
        Guid, 
        PagedAndSortedResultRequestDto, 
        CreateUpdateGlCodeDto> 
    {
        Task<PagedResultDto<GlCodeDto>> QueryListAsync(QueryGlCodeDto query);
        Task<List<GlCodeDto>> GetGlCodesAsync(QueryDto query);
    }
}
