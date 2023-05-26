using Dolphin.Freight.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dolphin.Freight.TradePartners.Credits
{
    public class EfCoreCreditLimitGroupRepository
        : EfCoreRepository<FreightDbContext, CreditLimitGroup, Guid>,
        ICreditLimitGroupRepository
    {
        public EfCoreCreditLimitGroupRepository(
            IDbContextProvider<FreightDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<CreditLimitGroup> FindByNameAsync(string creditLimitGroupName)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(creditLimitGroup => creditLimitGroup.CreditLimitGroupName == creditLimitGroupName);
        }
    }
}
