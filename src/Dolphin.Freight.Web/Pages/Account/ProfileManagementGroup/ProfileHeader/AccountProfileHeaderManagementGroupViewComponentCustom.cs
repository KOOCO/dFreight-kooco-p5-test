using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;
using Volo.Abp.Auditing;
using Volo.Abp.Identity;
using Volo.Abp.Validation;

namespace Volo.Abp.Account.Web.Pages.Account.Components.ProfileManagementGroup.Settings;

public class AccountProfileHeaderManagementGroupViewComponentCustom : AbpViewComponent
{
    protected IProfileAppService ProfileAppService { get; }

    public AccountProfileHeaderManagementGroupViewComponentCustom(
        IProfileAppService profileAppService)
    {
        ProfileAppService = profileAppService;
    }

    public virtual async Task<IViewComponentResult> InvokeAsync()
    {
        return View("~/Pages/Account/ProfileManagementGroup/ProfileHeader/Default.cshtml");
    }

}
