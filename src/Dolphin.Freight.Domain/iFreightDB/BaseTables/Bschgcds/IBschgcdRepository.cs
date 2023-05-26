using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Dolphin.Freight.iFreightDB.BaseTables.Bschgcds
{
    public interface IBschgcdRepository : IRepository<Bschgcd>
    {
        Task<List<Bschgcd>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );

    }
}
