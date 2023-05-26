using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.TradePartners.Credits
{
    public class GetCreditLimitGroupListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
