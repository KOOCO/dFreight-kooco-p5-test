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

namespace Dolphin.Freight.iFreightDB.BaseTables.Bscitys
{
    public class EfCoreBscityRepository : EfCoreRepository<IfreightDbContext, Bscity>, IBscityRepository
    {

        private readonly IDbContextProvider<IfreightDbContext> _dbContextProvider;

        public EfCoreBscityRepository(IDbContextProvider<IfreightDbContext> dbContextProvider) : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public async Task<List<Bscity>> FindCityCdCntyCdNotInAsync(List<Bscity> Bscitys)
        {
            var context = await _dbContextProvider.GetDbContextAsync();
            var tableName = context.Model.FindEntityType(typeof(Bscity)).GetTableName();

            string tempTable = "(" + String.Join(" UNION ALL ", Bscitys.Select(x => $"SELECT '{x.CityCd.Replace("'", "''")}' AS CityCd, '{x.CntyCd.Replace("'", "''")}' AS CntyCd")) + ") AS a";
            var sqlCommand = $"SELECT CityCd, CntyCd FROM {tempTable} WHERE CONCAT(CityCd, CntyCd) NOT IN (SELECT DISTINCT CONCAT(CITY_CD, CNTY_CD) FROM {tableName})";
            var results = context.ExecuteSqlQueryToDataTable(sqlCommand).ToModelList<Bscity>();

            return results;
        }

        public async Task<List<Bscity>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(!filter.IsNullOrWhiteSpace(), x => x.CityNm.Contains(filter))
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }

    }
}
