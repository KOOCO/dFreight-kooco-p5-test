using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Dolphin.Freight.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.SettingManagement;

namespace Dolphin.Freight.iFreightDB.BaseTables.Bsfrtcentertms
{
    public class EfCoreBsfrtcentertmRepository : EfCoreRepository<IfreightDbContext, Bsfrtcentertm>, IBsfrtcentertmRepository
    {
        public EfCoreBsfrtcentertmRepository(IDbContextProvider<IfreightDbContext> dbContextProvider) : base(dbContextProvider) { }

        public async Task<List<Bsfrtcentertm>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(!filter.IsNullOrWhiteSpace(), x => x.JobNo.Contains(filter))
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }

        public async Task<string> GetNextJobNo(String baseCode)
        {
            if (String.IsNullOrEmpty(baseCode)) throw new ArgumentNullException(nameof(baseCode));

            var dbSet = await GetDbSetAsync();
            List<string> jobNoList = await dbSet
                .Where(x => x.JobNo.StartsWith(baseCode))
                .Select(x => x.JobNo)
                .ToListAsync();
            if (jobNoList.Any())
                return baseCode + (int.Parse(jobNoList.Max().Substring(13)) + 1).ToString("D4");
            else
                return baseCode + "0001";

        }

    }
}
