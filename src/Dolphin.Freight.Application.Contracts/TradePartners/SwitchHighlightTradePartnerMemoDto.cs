using System;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.TradePartners
{
    public class SwitchHighlightTradePartnerMemoDto : AuditedEntityDto<Guid>
    {
        public bool Highlight { get; set; }
    }
}
