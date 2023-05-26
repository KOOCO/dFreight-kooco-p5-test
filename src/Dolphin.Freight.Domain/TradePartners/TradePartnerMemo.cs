using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dolphin.Freight.TradePartners
{
    public class TradePartnerMemo : AuditedAggregateRoot<Guid>
    {
        public Guid TradePartnerId { get; set; }
        [ForeignKey("TradePartnerId")]
        public TradePartner TradePartner { get; set; }
        public string Title { get; set; }
        public string Memo { get; set; }
        public bool Highlight { get; set; }
    }
}
