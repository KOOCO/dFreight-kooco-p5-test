using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Dolphin.Freight.iFreightDB.BaseTables.BsfrtcentertExcelTemps
{
    public interface IBsfrtcentertExcelTempRepository : IRepository<BsfrtcentertExcelTemp>
    {
        Task<List<BsfrtcentertExcelTemp>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting = null,
            string filter = null
        );

        Task<int> DeleteByUploaderIdAsync(string userId);

    }
}
