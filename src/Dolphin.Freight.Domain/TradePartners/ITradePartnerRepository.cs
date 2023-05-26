using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Dolphin.Freight.TradePartners
{
    public interface ITradePartnerRepository : IRepository<TradePartner, Guid>
    {
        Task<TradePartner> FindByTpNameAsync(string tpName);

        Task<TradePartner> FindByTpIdAsync(Guid id);
    }
}