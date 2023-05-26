using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Dolphin.Freight.ExtensionTools;
using Dolphin.Freight.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dolphin.Freight.iFreightDB.BaseTables.Bscss
{
    public class EfCoreBscsRepository : EfCoreRepository<IfreightDbContext, Bscs>, IBscsRepository
    {

        private readonly IDbContextProvider<IfreightDbContext> _dbContextProvider;

        public EfCoreBscsRepository(IDbContextProvider<IfreightDbContext> dbContextProvider) : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public async Task<List<string>> FindCustCdNotInAsync(List<string> CUST_CDs)
        {
            var context = await _dbContextProvider.GetDbContextAsync();
            var tableName = context.Model.FindEntityType(typeof(Bscs)).GetTableName();

            string tempTable = "(" + String.Join(" UNION ALL ", CUST_CDs.Select(x => $"SELECT '{x.Replace("'", "''")}' AS CUST_CD")) + ") AS a";
            var sqlCommand = $"SELECT CUST_CD FROM {tempTable} WHERE CUST_CD NOT IN (SELECT DISTINCT CUST_CD FROM {tableName})";
            var results = context.ExecuteSqlQueryToDataTable(sqlCommand).ToStringList();

            return results;
        }

        public async Task<List<Bscs>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(!filter.IsNullOrWhiteSpace(), x => x.CustCd.Contains(filter))
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }

    }
}
