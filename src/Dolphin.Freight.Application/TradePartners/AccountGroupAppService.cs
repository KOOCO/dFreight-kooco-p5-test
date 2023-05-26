using Dolphin.Freight.Settings.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Dolphin.Freight.TradePartners
{
    public class AccountGroupAppService : 
        CrudAppService<
            AccountGroup,
            AccountGroupDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateAccountGroupDto>,
        IAccountGroupAppService
    {
        private readonly IRepository<AccountGroup, Guid> _repository;

        public AccountGroupAppService(
            IRepository<AccountGroup, Guid> repository
            )
            : base(repository)
        {
            _repository = repository;
        }

        public async Task<ListResultDto<AccountGroupDto>> GetAccountGroupNameLookupAsync()
        {
            var accountGroupNames = await _repository.GetListAsync();
            return new ListResultDto<AccountGroupDto>(
                ObjectMapper.Map<List<AccountGroup>, List<AccountGroupDto>>(accountGroupNames)
            );
        }

    }
}
