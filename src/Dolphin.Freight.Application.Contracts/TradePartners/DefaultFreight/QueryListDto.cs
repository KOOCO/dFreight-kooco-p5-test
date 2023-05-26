using Dolphin.Freight.Accounting;
using System;

namespace Dolphin.Freight.TradePartners.DefaultFreight
{
    public class QueryListDto
    {
        public Guid TradePartnerId { get; set; }
        public DefaultFreightCategory Category { get; set; }
    }
}
