using System;
using System.Collections.Generic;
using System.Text;

namespace Dolphin.Freight.TradePartner
{
    public enum CreditTermType 
    { 
        DaysAfterETA = 1,
        DaysAfterETD,
        Days,
        DueOnReceipt,
        EndOfNextMonth,
        EndOfThisMonth,
        OfNextMonth
    }
}
