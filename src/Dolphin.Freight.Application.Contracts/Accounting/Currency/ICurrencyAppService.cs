using Dolphin.Freight.Common;
using Dolphin.Freight.Accounting.Currency;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Dolphin.Freight.AccountingSettings.CurrencyTables;

namespace Dolphin.Freight.Accounting.Currency
{
    public interface ICurrencyAppService :
        ICrudAppService<
        CurrencyDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateCurrencyDto>
    {
        Task<string> QueryRateInternalAsync(QueryCurrencyDto query);
    }
}
