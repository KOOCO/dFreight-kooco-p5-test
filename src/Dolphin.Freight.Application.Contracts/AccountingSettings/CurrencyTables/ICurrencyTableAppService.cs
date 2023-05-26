using Dolphin.Freight.Accounting.Currency;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Dolphin.Freight.AccountingSettings.CurrencyTables
{
    public interface ICurrencyTableAppService :
        ICrudAppService<
        CurrencyTableDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateCurrencyTableDto>
    {
        Task<PagedResultDto<CurrencyTableDto>> QueryListAsync(QueryCurrencyTableDto query);

        Task<string> QueryRateInternalAsync(QueryCurrencyTableDto query);
    }
}
