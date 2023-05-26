using Dolphin.Freight.TradePartner;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.TradePartners.Credits
{
    public class CreditLimitGroupDto : AuditedEntityDto<Guid>
    {
        public string CreditLimitGroupName { get; set; }
        public PaymentType PaymentType { get; set; }
        public CreditTermType CreditTermType { get; set; }
        public int CreditTermDays { get; set; }
        public int CreditLimit { get; set; }
        public bool IsDeleted { get; set; }
    }
}
