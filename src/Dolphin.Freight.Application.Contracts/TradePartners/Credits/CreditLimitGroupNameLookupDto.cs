using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AuditLogging;

namespace Dolphin.Freight.TradePartners.Credits
{
    public class CreditLimitGroupNameLookupDto : EntityDto<Guid>
    {
        public string CreditLimitGroupName { get; set; }
    }

}
