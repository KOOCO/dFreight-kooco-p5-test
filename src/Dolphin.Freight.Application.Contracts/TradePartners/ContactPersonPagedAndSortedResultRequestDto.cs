using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.TradePartners
{
    public class ContactPersonPagedAndSortedResultRequestDto : PagedAndSortedResultRequestDto
    {
        public string TradePartnerId { get; set; }
    }
}
