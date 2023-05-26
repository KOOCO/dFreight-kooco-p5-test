using System;
using System.Collections.Generic;
using System.Text;

namespace Dolphin.Freight.TradePartners.TradeParties
{
    public enum TradePartyType
    {
        BillTo = 1,
        CustomsBroker,
        Trucker,
        PickupDeliveryLocation,
        Consignee,
        Shipper,
        Notify,
        Vendor
    }
}
