using Dolphin.Freight.ImportExport.AirExports;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Dolphin.Freight.ImportExport.AirImports
{
    public interface IAirImportHawbAppService : 
        ICrudAppService<
            AirImportHawbDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateAirImportHawbDto
        >
    {
        Task<List<AirImportHawbDto>> GetHblById(Guid Id);
        Task<AirImportHawbDto> GetAirHawbCardById(Guid Id);
        Task<AirImportHawbDto> GetDocCenterCardById(Guid Id);
    }
}
