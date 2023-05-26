using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Dolphin.Freight.ImportExport.AirExports
{
    public interface IAirportAppService :
        ICrudAppService<
            AirportDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateAirportDto
        >
    {
        Task<ListResultDto<AirportDto>> GetAirportLookupAsync();
    }
}
