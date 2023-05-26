using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Dolphin.Freight.iFreightDB.BaseTables.Bsfrtcentertms
{
    public interface IBsfrtcentertmRepository : IRepository<Bsfrtcentertm>
    {
        Task<List<Bsfrtcentertm>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );

        Task<string> GetNextJobNo(String baseCode);

    }
}
