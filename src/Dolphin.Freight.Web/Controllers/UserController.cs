using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Account.Web.Pages.Account.Components.ProfileManagementGroup.Password;

namespace Dolphin.Freight.Web.Controllers
{
    public class UserController : Controller
    {
        public PartialViewResult ResetPassword()
        {
            AccountProfilePasswordManagementGroupViewComponentCustom.ChangePasswordInfoModel model = new();
            model.HideOldPasswordInput = true;

            return PartialView("Pages/Account/_ResetPassword.cshtml", model);
        }
    }
}
