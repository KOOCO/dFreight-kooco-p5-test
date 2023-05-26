using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Dolphin.Freight.TradePartners
{
    public interface IContactPersonRepository : IRepository<ContactPerson, Guid>
    {
        Task<ContactPerson> FindByContactNameAsync(String contactName, Guid tradePartnerId);
        Task<List<ContactPerson>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            ContactPersonFilter filter = null
        );
        Task<int> GetTotalCountAsync(ContactPersonFilter filter);

    }
}
