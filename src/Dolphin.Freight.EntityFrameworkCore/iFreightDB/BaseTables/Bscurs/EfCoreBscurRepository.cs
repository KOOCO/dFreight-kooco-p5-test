using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Dolphin.Freight.ExtensionTools;
using Dolphin.Freight.EntityFrameworkCore;
using Dolphin.Freight.iFreightDB.BaseTables.BsfrtcentertExcelTemps;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NPOI.SS.Formula.Functions;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using static Volo.Abp.Identity.Settings.IdentitySettingNames;
using System.Runtime.ConstrainedExecution;

namespace Dolphin.Freight.iFreightDB.BaseTables.Bscurs
{

    public class EfCoreBscurRepository : EfCoreRepository<IfreightDbContext, Bscur>, IBscurRepository
    {
        private readonly IDbContextProvider<IfreightDbContext> _dbContextProvider;
        public virtual DbSet<string> Cur { get; set; }

        public EfCoreBscurRepository(IDbContextProvider<IfreightDbContext> dbContextProvider) : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public async Task<List<string>> FindCurNotInAsync(List<string> CURs)
        {
            var context = await _dbContextProvider.GetDbContextAsync();
            var tableName = context.Model.FindEntityType(typeof(Bscur)).GetTableName();

            string tempTable = "(" + String.Join(" UNION ALL ", CURs.Select(x => $"SELECT '{x.Replace("'", "''")}' AS CUR")) + ") AS a";
            var sqlCommand = $"SELECT CUR FROM {tempTable} WHERE CUR NOT IN (SELECT DISTINCT CUR FROM {tableName})";
            var results = context.ExecuteSqlQueryToDataTable(sqlCommand).ToStringList();

            return results;
        }

        private class ResultData
        {
            public string Cur { get; set; }
            public string GroupId { get; set; }
            public string Cmp { get; set; }
            public string Stn { get; set; }
        }

        public async Task<bool> CheckExistAsync(string CUR)
        {
            var context = await _dbContextProvider.GetDbContextAsync();
            int mappingCount = context.Bscurs.Count(x => x.Cur == CUR);
            return mappingCount > 0;
        }

        public async Task<List<Bscur>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(!filter.IsNullOrWhiteSpace(), x => x.Cur.Contains(filter))
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }

    }
}
