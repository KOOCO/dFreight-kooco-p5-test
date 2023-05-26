using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Dolphin.Freight.TradePartners
{
    public interface IAccountGroupAppService : 
        ICrudAppService<
            AccountGroupDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateAccountGroupDto
        >
    {
        Task<ListResultDto<AccountGroupDto>> GetAccountGroupNameLookupAsync();
    }
}
