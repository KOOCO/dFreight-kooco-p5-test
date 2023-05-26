using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Dolphin.Freight.iFreightDB.BaseTables.BsfrtcentertPortMappings
{
    public interface IBsfrtcentertPortMappingRepository : IRepository<BsfrtcentertPortMapping>
    {
        Task<List<BsfrtcentertPortMapping>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting = null,
            string filter = null
        );
    }
}
