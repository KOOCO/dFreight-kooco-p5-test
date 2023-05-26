using Dolphin.Freight.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dolphin.Freight.TradePartners
{
    public class EFCoreTradePartnerRepository :
        EfCoreRepository<FreightDbContext, TradePartner, Guid>,
        ITradePartnerRepository
    {
        public EFCoreTradePartnerRepository(
            IDbContextProvider<FreightDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        
        }

        public async Task<TradePartner> FindByTpNameAsync(string tpName)
        {
            var dbSet = await GetDbSetAsync();
 
            return await dbSet.FirstOrDefaultAsync(tradePartner => tradePartner.TPName == tpName);
        }

        public async Task<TradePartner> FindByTpIdAsync(Guid id)
        {
            var dbSet = await GetDbSetAsync();

            return await dbSet.FirstOrDefaultAsync(tradePartner => tradePartner.Id == id);
        }
    }
}
