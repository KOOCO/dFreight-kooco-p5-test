using Dolphin.Freight.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dolphin.Freight.TradePartners
{
    public class EfCoreContactPersonRepository
        : EfCoreRepository<FreightDbContext, ContactPerson, Guid>,
        IContactPersonRepository
    {
        public EfCoreContactPersonRepository(
            IDbContextProvider<FreightDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<ContactPerson> FindByContactNameAsync(string contactName, Guid tradePartnerId) {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(contactPerson => contactPerson.ContactName == contactName && contactPerson.TradePartnerId == tradePartnerId);
        }

        public async Task<List<ContactPerson>> GetListAsync(int skipCount, int maxResultCount, string sorting, ContactPersonFilter filter = null)
        {
           var dbSet = await GetDbSetAsync();
           var contactPersons = await dbSet
                .WhereIf(!filter.TradePartnerId.IsNullOrWhiteSpace(), x => x.TradePartnerId.ToString().Contains(filter.TradePartnerId))
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
            return contactPersons;
        }

        public async Task<int> GetTotalCountAsync(ContactPersonFilter filter)
        {
            var dbSet = await GetDbSetAsync();
            var contactPersons = await dbSet
                .WhereIf(!filter.TradePartnerId.IsNullOrWhiteSpace(), x => x.TradePartnerId.ToString().Contains(filter.TradePartnerId))
                .ToListAsync();
            return contactPersons.Count;
        }
    }
}
