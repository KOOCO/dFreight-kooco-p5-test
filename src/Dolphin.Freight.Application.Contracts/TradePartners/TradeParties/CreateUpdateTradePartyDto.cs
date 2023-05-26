using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.TradePartners.TradeParties
{
    public class CreateUpdateTradePartyDto : AuditedEntityDto<Guid>
    {
        public new Guid? Id { get; set; }
        public Guid TradePartnerId { get; set; }
        public Guid TargetTradePartnerId { get; set; }
        public TradePartyType TradePartyType { get; set; }
        public string TradePartyDescription { get; set; }
        public bool IsDefault { get; set; }
    }
}
