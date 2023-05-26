using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Dolphin.Freight.iFreightDB.BaseTables.Bscitys
{
    public interface IBscityRepository : IRepository<Bscity>
    {

        Task<List<Bscity>> FindCityCdCntyCdNotInAsync(List<Bscity> Bscitys);

        Task<List<Bscity>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );

    }
}
