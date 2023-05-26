using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Dolphin.Freight.iFreightDB.BaseTables.Bscodes
{
    public interface IBscodeRepository : IRepository<Bscode>
    {
        Task<List<Bscode>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );

    }
}
