using Dolphin.Freight.TradePartners.Credits;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Dolphin.Freight.TradePartners
{
    public interface ITradePartnerMemoAppService : IApplicationService
    {
        Task<TradePartnerMemoDto> GetAsync(Guid id);
        Task<List<TradePartnerMemoDto>> GetListByTradePartnerIdAsync(Guid id);
        Task<bool> HasHighlightAsync(Guid id);
        Task SaveAsync(CreateUpdateTradePartnerMemoDto dto);
        Task SwitchHighlightAsync(SwitchHighlightTradePartnerMemoDto dto);
        Task DeleteAsync(Guid id);
    }
}
