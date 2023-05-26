using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.TradePartners
{
    public class TradePartnerLookupDto : EntityDto<Guid>
    {
        public string TPName { get; set; }
        public string TPCode { get; set; }
        public string TPLocalAddress { get; set; }
    }
}
