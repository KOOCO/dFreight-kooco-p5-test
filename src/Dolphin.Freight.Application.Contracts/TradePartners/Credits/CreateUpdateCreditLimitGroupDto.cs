using Dolphin.Freight.TradePartner;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using System.Text;

namespace Dolphin.Freight.TradePartners.Credits
{
    public class CreateUpdateCreditLimitGroupDto : AuditedEntityDto<Guid>
    {
        [Required]
        [StringLength(CreditLimitGroupConsts.MaxCreditLimitGroupNameLength)]
        public string CreditLimitGroupName { get; set; }
        
        public PaymentType PaymentType { get; set; }
        public CreditTermType CreditTermType { get; set; }
        public int CreditTermDays { get; set; }
        public int CreditLimit { get; set; }
    }
}
