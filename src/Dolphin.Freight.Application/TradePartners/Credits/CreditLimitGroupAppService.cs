using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Dolphin.Freight.TradePartners.Credits
{
    public class CreditLimitGroupAppService :
        CrudAppService<
            CreditLimitGroup,
            CreditLimitGroupDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateCreditLimitGroupDto>,
            ICreditLimitGroupAppService
    {
        private readonly ICreditLimitGroupRepository _creditLimitGroupRepository;
        private readonly CreditLimitGroupManager _creditLimitGroupManager;
        public CreditLimitGroupAppService(
            IRepository<CreditLimitGroup, Guid> repository, 
            ICreditLimitGroupRepository creditLimitGroupRepository, 
            CreditLimitGroupManager creditLimitGroupManager) 
            : base(repository)
        {
            _creditLimitGroupRepository = creditLimitGroupRepository;
            _creditLimitGroupManager = creditLimitGroupManager;
        }
        public async Task<CreditLimitGroupDto> CreateCLGAsync(CreateUpdateCreditLimitGroupDto input)
        {
            var creditLimitGroup = await _creditLimitGroupManager.CreateAsync(
                input.CreditLimitGroupName,
                input.PaymentType,
                input.CreditTermType,
                input.CreditTermDays,
                input.CreditLimit
            );

            await _creditLimitGroupRepository.InsertAsync(creditLimitGroup);

            return ObjectMapper.Map<CreditLimitGroup, CreditLimitGroupDto>(creditLimitGroup);
        }

        public async Task<ListResultDto<CreditLimitGroupNameLookupDto>> GetCreditLimitGroupNameLookupAsync()
        {
            var creditLimitGroupNames = await _creditLimitGroupRepository.GetListAsync();
            return new ListResultDto<CreditLimitGroupNameLookupDto>(
                ObjectMapper.Map<List<CreditLimitGroup>, List<CreditLimitGroupNameLookupDto>>(creditLimitGroupNames)
                );
        }

        public async Task UpdateCLGAsync(Guid id, CreateUpdateCreditLimitGroupDto input)
        {
            var creditLimitGroup = await _creditLimitGroupRepository.GetAsync(id);

            if (creditLimitGroup.CreditLimitGroupName != input.CreditLimitGroupName)
            {
                await _creditLimitGroupManager.ChangeNameAsync(creditLimitGroup, input.CreditLimitGroupName);
            }

            creditLimitGroup.PaymentType = input.PaymentType;
            creditLimitGroup.CreditTermType = input.CreditTermType;
            creditLimitGroup.CreditTermDays = input.CreditTermDays;
            creditLimitGroup.CreditLimit = input.CreditLimit;

            await _creditLimitGroupRepository.UpdateAsync(creditLimitGroup);
        }
    }
}
