using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Dolphin.Freight.TradePartners.Credits
{
    public class CreditLimitGroupNameAlreadyExistsException : BusinessException
    {
        public CreditLimitGroupNameAlreadyExistsException(string creditLimitGroupName)
            : base(FreightDomainErrorCodes.CreditLimitGroupNameAlreadyExists) 
        {
            WithData("name", creditLimitGroupName);
        }
    }
}
