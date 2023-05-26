using Dolphin.Freight.TradePartner;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Dolphin.Freight.TradePartners.Credits
{
    public class CreditLimitGroupManager : DomainService
    {
        private readonly ICreditLimitGroupRepository _creditLimitGroupRepository;

        public CreditLimitGroupManager(ICreditLimitGroupRepository creditLimitGroupRepository)
        { 
            _creditLimitGroupRepository = creditLimitGroupRepository;
        }

        public async Task<CreditLimitGroup> CreateAsync(
            [NotNull] string creditLimitGroupName,
            PaymentType paymentType,
            CreditTermType creditTermType,
            int creditTermDays,
            int creditLimit) 
        {
            Check.NotNullOrWhiteSpace(creditLimitGroupName, nameof(creditLimitGroupName));
            var existingCreditLimitGroupName = await _creditLimitGroupRepository.FindByNameAsync(creditLimitGroupName);
            if (null != existingCreditLimitGroupName)
            {
                //throw new CreditLimitGroupNameAlreadyExistsException(creditLimitGroupName);
                throw new BusinessException(FreightDomainErrorCodes.CreditLimitGroupNameAlreadyExists)
                        .WithData("CreditLimitGroupName", creditLimitGroupName);
            }
            return new CreditLimitGroup(
                GuidGenerator.Create(),
                creditLimitGroupName,
                paymentType,
                creditTermType,
                creditTermDays,
                creditLimit
            ); 
        }

        public async Task ChangeNameAsync(
            [NotNull] CreditLimitGroup creditLimitGroup,
            [NotNull] string newCreditLimitGroupName)
        {
            Check.NotNull(creditLimitGroup, nameof(creditLimitGroup));
            Check.NotNullOrWhiteSpace(newCreditLimitGroupName, nameof(newCreditLimitGroupName));
            var existingCreditLimitGroup = await _creditLimitGroupRepository.FindByNameAsync(newCreditLimitGroupName);
            if (null != existingCreditLimitGroup && existingCreditLimitGroup.Id != creditLimitGroup.Id)
            {
                throw new BusinessException(FreightDomainErrorCodes.CreditLimitGroupNameAlreadyExists)
                        .WithData("CreditLimitGroupName", newCreditLimitGroupName);
            }
            creditLimitGroup.ChangeCreditGroupName(newCreditLimitGroupName);
        }
    }

}
