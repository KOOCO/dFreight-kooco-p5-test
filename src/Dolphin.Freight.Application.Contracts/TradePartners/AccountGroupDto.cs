using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.TradePartners
{
    public class AccountGroupDto : AuditedEntityDto<Guid>
    {
        public string AccountGroupName  { get; set; }
    }
}
