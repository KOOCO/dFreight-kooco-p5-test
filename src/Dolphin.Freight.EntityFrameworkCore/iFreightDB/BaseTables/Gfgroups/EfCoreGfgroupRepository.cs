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


namespace Dolphin.Freight.iFreightDB.BaseTables.Gfgroups
{
    public class EfCoreGfgroupRepository : EfCoreRepository<IfreightDbContext, Gfgroup>, IGfgroupRepository
    {

        private readonly IDbContextProvider<IfreightDbContext> _dbContextProvider;

        public EfCoreGfgroupRepository(IDbContextProvider<IfreightDbContext> dbContextProvider) : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public async Task<bool> CheckExistAsync(string GROUP_ID)
        {
            var context = await _dbContextProvider.GetDbContextAsync();
            int mappingCount = context.Gfgroups.Count(x => x.GroupId == GROUP_ID);
            return mappingCount > 0;
        }

    }
}
