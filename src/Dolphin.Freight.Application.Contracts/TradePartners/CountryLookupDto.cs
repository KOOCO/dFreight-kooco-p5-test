using System;
using Volo.Abp.Application.Dtos;


namespace Dolphin.Freight.TradePartners
{
    public class CountryLookupDto : EntityDto<Guid>
    {
        public string CountryName { get; set; }
        public string ShowName { get; set; }
    }
}
