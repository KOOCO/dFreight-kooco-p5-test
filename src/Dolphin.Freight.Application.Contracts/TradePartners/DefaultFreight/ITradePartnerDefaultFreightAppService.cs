using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Dolphin.Freight.TradePartners.DefaultFreight
{
    public interface ITradePartnerDefaultFreightAppService : IApplicationService
    {
        Task<DefaultFreightARDto> GetARAsync(Guid id);
        Task<DefaultFreightAPDto> GetAPAsync(Guid id);
        Task<DefaultFreightDCDto> GetDCAsync(Guid id);

        Task<List<DefaultFreightARListDto>> GetARListByQueryAsync(QueryListDto dto);
        Task<List<DefaultFreightAPListDto>> GetAPListByQueryAsync(QueryListDto dto);
        Task<List<DefaultFreightDCListDto>> GetDCListByQueryAsync(QueryListDto dto);

        Task SaveARAsync(CreateUpdateDefaultFreightARDto dto);
        Task SaveAPAsync(CreateUpdateDefaultFreightAPDto dto);
        Task SaveDCAsync(CreateUpdateDefaultFreightDCDto dto);

        Task DeleteARAsync(Guid id);
        Task DeleteAPAsync(Guid id);
        Task DeleteDCAsync(Guid id);
    }
}
