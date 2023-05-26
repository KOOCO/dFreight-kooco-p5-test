using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.TradePartners.TradeParties
{
    public class TradePartyDto : AuditedEntityDto<Guid>
    {
        public TradePartyType TradePartyType { get; set; }
        public bool IsDefault { get; set; }
        public string TradePartyDescription { get; set; }
        public Guid TradePartnerId { get; set; }
        public Guid TargetTradePartnerId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
