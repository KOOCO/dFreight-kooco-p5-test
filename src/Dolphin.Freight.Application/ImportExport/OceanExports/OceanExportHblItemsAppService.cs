using Dolphin.Freight.ImportExport.Containers;
using Dolphin.Freight.Settings.SysCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Dolphin.Freight.ImportExport.OceanExports
{
    public class OceanExportHblItemsAppService :
        CrudAppService<
            OceanExportHblItems,
            OceanExportHblItemsDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateOceanExportHblItemsDto>,
        IOceanExportHblItemsAppService
    {
        private IRepository<OceanExportHblItems, Guid> _repository;
        public OceanExportHblItemsAppService(IRepository<OceanExportHblItems, Guid> repository)
           : base(repository)
        {
            _repository = repository;
        }
    }
}
