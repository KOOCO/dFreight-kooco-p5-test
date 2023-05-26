using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Dolphin.Freight.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dolphin.Freight.iFreightDB.BaseTables.BsfrtcentertPortMappings
{
    public class EfCoreBsfrtcentertPortMappingRepository : EfCoreRepository<IfreightDbContext, BsfrtcentertPortMapping>, IBsfrtcentertPortMappingRepository
    {

        public EfCoreBsfrtcentertPortMappingRepository(IDbContextProvider<IfreightDbContext> dbContextProvider) : base(dbContextProvider) { }

        public async Task<List<BsfrtcentertPortMapping>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting = null,
            string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(!filter.IsNullOrWhiteSpace(), x => x.PortName.Contains(filter))
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }

    }
}
