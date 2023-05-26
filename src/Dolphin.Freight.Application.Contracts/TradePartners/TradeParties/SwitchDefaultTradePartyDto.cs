using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.TradePartners.TradeParties
{
    public class SwitchDefaultTradePartyDto : AuditedEntityDto<Guid>
    {
        public bool IsDefault { get; set; }
    }
}
