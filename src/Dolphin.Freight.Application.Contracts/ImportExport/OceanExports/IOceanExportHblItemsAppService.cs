using Dolphin.Freight.ImportExport.Containers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Dolphin.Freight.ImportExport.OceanExports
{
    public interface IOceanExportHblItemsAppService
        :
        ICrudAppService<
        OceanExportHblItemsDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateOceanExportHblItemsDto>
    {
    }
}
