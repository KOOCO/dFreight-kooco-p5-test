using Dolphin.Freight.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Dolphin.Freight.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class FreightPageModel : AbpPageModel
{
    protected FreightPageModel()
    {
        LocalizationResourceType = typeof(FreightResource);
    }
}
