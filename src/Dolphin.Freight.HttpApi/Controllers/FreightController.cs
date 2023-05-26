using Dolphin.Freight.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Dolphin.Freight.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class FreightController : AbpControllerBase
{
    protected FreightController()
    {
        LocalizationResource = typeof(FreightResource);
    }
}
