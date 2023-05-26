using Dolphin.Freight.TradePartner;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dolphin.Freight.TradePartners.Credits
{
    public class CreditLimitGroup : AuditedAggregateRoot<Guid>, ISoftDelete
    {
	    public string CreditLimitGroupName { get; private set; }
        public PaymentType PaymentType { get; set; }
        public CreditTermType CreditTermType { get; set; }
        public int CreditTermDays { get; set; }
        public int CreditLimit { get; set; }
        public bool IsDeleted { get; set; }

        private CreditLimitGroup() 
        { 
        
        }

        internal CreditLimitGroup(
            Guid id,
            [NotNull] string creditLimitGroupName,
            PaymentType paymentType,
            CreditTermType creditTermType,
            int creditTermDays,
            int creditLimit,
            bool IsDeleted = false
            ) : base(id)
        {
            SetCreditLimitGroupName(creditLimitGroupName);
            PaymentType = paymentType;
            CreditTermType = creditTermType;
            CreditTermDays = creditTermDays;
            CreditLimit = creditLimit;
        }

        internal CreditLimitGroup ChangeCreditGroupName([NotNull] string creditLimitGroupName)
        {
            SetCreditLimitGroupName(creditLimitGroupName);
            return this;
        }

        private void SetCreditLimitGroupName([NotNull] string creditLimitGroupName)
        {
            CreditLimitGroupName = Check.NotNullOrWhiteSpace(
                    creditLimitGroupName,
                    nameof(creditLimitGroupName),
                    maxLength: CreditLimitGroupConsts.MaxCreditLimitGroupNameLength
                );
        }

    }
}
