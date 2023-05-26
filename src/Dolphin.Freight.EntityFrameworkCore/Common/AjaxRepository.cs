using Dolphin.Freight.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;

namespace Dolphin.Freight.Common
{
    public class AjaxRepository: IAjaxRepository
    {
        private readonly FreightDbContext _dbContext;
        public AjaxRepository(FreightDbContext dbContext) {
            _dbContext = dbContext;
        }
        public IList<TradePartners.TradePartner> GetAllTradePartners() {
            var list = _dbContext.TradePartners.ToList<TradePartners.TradePartner>();
            return list;
        }
    }
}
