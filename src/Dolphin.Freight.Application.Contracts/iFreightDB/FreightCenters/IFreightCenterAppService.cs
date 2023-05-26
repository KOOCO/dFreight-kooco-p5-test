using Dolphin.Freight.iFreightDB.BaseTables.Stemps;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;


namespace Dolphin.Freight.iFreightDB.FreightCenters
{
    public interface IFreightCenterAppService : IApplicationService
    {
        Task<Models.NotificationMessage> OceanShippingCostUploadAsync(OceanShippingExcelFileUploadDto input);
        Task<Models.NotificationMessage> OceanShippingCostConvertToDatabaseAsync(OceanShippingExcelFileUploadDto input);

    }
}
