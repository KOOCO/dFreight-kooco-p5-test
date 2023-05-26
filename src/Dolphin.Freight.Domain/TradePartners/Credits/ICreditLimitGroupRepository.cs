using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Dolphin.Freight.TradePartners.Credits
{
    public interface ICreditLimitGroupRepository : IRepository<CreditLimitGroup, Guid>
    {
        Task<CreditLimitGroup> FindByNameAsync(string creditLimitGroupName);
        
    }
}
