using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Dolphin.Freight.iFreightDB.BaseTables.Bsfrtcentertds
{
    public interface IBsfrtcentertdRepository : IRepository<Bsfrtcentertd>
    {
        Task<List<Bsfrtcentertd>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );

    }
}
