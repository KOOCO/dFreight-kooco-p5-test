using System;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.TradePartners
{
    public class TradePartnerMemoDto : AuditedEntityDto<Guid>
    {
        public Guid TradePartnerId { get; set; }
        public string Title { get; set; }
        public string Memo { get; set; }
        public bool Highlight { get; set; }
        public string CreatedUserName { get; set; }
        public string LastUpdatedUserName { get; set; }
    }
}
