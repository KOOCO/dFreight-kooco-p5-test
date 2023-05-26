using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Dolphin.Freight.iFreightDB.BaseTables.Gfcompanys
{
    public interface IGfcompanyRepository : IRepository<Gfcompany>
    {
        Task<bool> CheckExistAsync(string GROUP_ID, string CMP, string STN);
    }
}
