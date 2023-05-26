using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dolphin.Freight.Common
{
    public interface IAjaxRepository
    {
        IList<TradePartners.TradePartner> GetAllTradePartners();
    }
}
