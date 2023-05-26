using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Dolphin.Freight.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;


namespace Dolphin.Freight.iFreightDB.BaseTables.BsfrtcentertExcelTemps
{
    public class EfCoreBsfrtcentertExcelTempRepository : EfCoreRepository<IfreightDbContext, BsfrtcentertExcelTemp>, IBsfrtcentertExcelTempRepository
    {

        private readonly IDbContextProvider<IfreightDbContext> _dbContextProvider;

        public EfCoreBsfrtcentertExcelTempRepository(IDbContextProvider<IfreightDbContext> dbContextProvider) : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public async Task<int> DeleteByUploaderIdAsync(string userId)
        {
            var context = await _dbContextProvider.GetDbContextAsync();

            var tableName = context.Model.FindEntityType(typeof(BsfrtcentertExcelTemp)).GetTableName();
            var sqlCommand = $"DELETE FROM {tableName} WHERE UPLOADER_ID = @_userid";

            // 如果是查詢類的 可以參考下列語法
            // var sqlCommand = "SELECT * FROM SomeTable WHERE SomeColumn = @someParam";
            // var result = await context.BsfrtcentertExcelTemps.FromSqlRaw(sqlCommand, new SqlParameter("@someParam", "aaaaaa")).ToListAsync();
            
            return await context.Database.ExecuteSqlRawAsync(sqlCommand, new SqlParameter("@_userid", userId));
        }

        public async Task<List<BsfrtcentertExcelTemp>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting = null,
            string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(!filter.IsNullOrWhiteSpace(), x => x.UploaderId.Contains(filter))
                .OrderBy(sorting ?? "1")
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }

    }
}
