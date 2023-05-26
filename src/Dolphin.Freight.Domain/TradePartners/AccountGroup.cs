using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dolphin.Freight.TradePartners
{
    public class AccountGroup : AuditedAggregateRoot<Guid>
    {
        public string AccountGroupName { get; set; }
    }

}
