using System;
using System.Collections.Generic;
using System.Text;
using Dolphin.Freight.Localization;
using Volo.Abp.Application.Services;

namespace Dolphin.Freight;

/* Inherit your application services from this class.
 */
public abstract class FreightAppService : ApplicationService
{
    protected FreightAppService()
    {
        LocalizationResource = typeof(FreightResource);
    }
}
