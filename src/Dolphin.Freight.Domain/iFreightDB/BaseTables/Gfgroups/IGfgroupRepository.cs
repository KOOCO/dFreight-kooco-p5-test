using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Dolphin.Freight.iFreightDB.BaseTables.Gfgroups
{
    public interface IGfgroupRepository : IRepository<Gfgroup>
    {
        Task<bool> CheckExistAsync(string GROUP_ID);
    }
}
