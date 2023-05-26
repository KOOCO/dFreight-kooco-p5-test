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


namespace Dolphin.Freight.iFreightDB.BaseTables.Gfcompanys
{
    public class EfCoreGfcompanyRepository : EfCoreRepository<IfreightDbContext, Gfcompany>, IGfcompanyRepository
    {

        private readonly IDbContextProvider<IfreightDbContext> _dbContextProvider;

        public EfCoreGfcompanyRepository(IDbContextProvider<IfreightDbContext> dbContextProvider) : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public async Task<bool> CheckExistAsync(string GROUP_ID, string CMP, string STN)
        {
            var context = await _dbContextProvider.GetDbContextAsync();
            int mappingCount = context.Gfcompanies.Count(x => x.GroupId == GROUP_ID && x.Cmp == CMP && x.Stn == STN);
            return mappingCount > 0;
        }

    }
}
