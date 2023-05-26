using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.TradePartners
{
    public class CurrencyLookupDto : EntityDto<Guid>
    {
        public string CurrencyName { get; set; }
    }
}
