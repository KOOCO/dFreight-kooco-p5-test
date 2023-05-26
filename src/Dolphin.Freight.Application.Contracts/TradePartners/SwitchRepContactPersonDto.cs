using System;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.TradePartners
{
    public class SwitchRepContactPersonDto : AuditedEntityDto<Guid>
    {
        public bool IsRep { get; set; }
    }
}
