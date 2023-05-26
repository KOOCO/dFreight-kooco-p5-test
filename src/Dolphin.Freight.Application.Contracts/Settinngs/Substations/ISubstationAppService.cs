using Dolphin.Freight.Common;
using Dolphin.Freight.Settinngs.Substations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Dolphin.Freight.Settinngs.Substations
{
    public interface ISubstationAppService :
        ICrudAppService<
        SubstationDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateSubstationDto>
    {
        Task<List<SubstationDto>> GetSubstationsAsync(QueryDto query);
        Task<ListResultDto<SubstationLookupDto>> GetSubstationsLookupAsync();
    }
}
