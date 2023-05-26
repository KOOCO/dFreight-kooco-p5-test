using Dolphin.Freight.Common;
using Dolphin.Freight.Settinngs.Countries;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Dolphin.Freight.Settings.Countries
{
    public interface ICountryDisplayNameAppService: IApplicationService
    {
        Task<PagedResultDto<CountryDisplayNameListDto>> GetListAsync(CountryDisplayNameQueryDto queryDto);
        Task<CountryDisplayNameDto> GetAsync(Guid id);
        Task SaveAsync(CreateUpdateCountryDisplayNameDto dto);
    }
}
