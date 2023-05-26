using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Dolphin.Freight.iFreightDB.BaseTables.Bscurs
{
    public interface IBscurRepository : IRepository<Bscur>
    {

        Task<List<string>> FindCurNotInAsync(List<string> CURs);

        Task<bool> CheckExistAsync(string CUR);

        Task<List<Bscur>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );

    }
}
