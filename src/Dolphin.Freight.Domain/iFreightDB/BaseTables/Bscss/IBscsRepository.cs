using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Dolphin.Freight.iFreightDB.BaseTables.Bscss
{
    public interface IBscsRepository : IRepository<Bscs>
    {

        Task<List<string>> FindCustCdNotInAsync(List<string> CUST_CDs);

        Task<List<Bscs>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );

    }
}
