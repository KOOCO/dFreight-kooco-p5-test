using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Dolphin.Freight.TradePartners.Credits
{
    public interface ICreditLimitGroupAppService : 
        ICrudAppService<
            CreditLimitGroupDto, // show
            Guid, // primary key of the CreditLimitGroup entity
            PagedAndSortedResultRequestDto, // for paging & sorting
            CreateUpdateCreditLimitGroupDto // create & update a CreditLimitGroup
        >, IApplicationService
    {
        Task<CreditLimitGroupDto> CreateCLGAsync(CreateUpdateCreditLimitGroupDto input);
        Task UpdateCLGAsync(Guid id, CreateUpdateCreditLimitGroupDto input);
        Task<ListResultDto<CreditLimitGroupNameLookupDto>> GetCreditLimitGroupNameLookupAsync();

    }
}
