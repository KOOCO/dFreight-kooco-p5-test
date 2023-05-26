using Dolphin.Freight.Settings.DisplaySetting;
using Dolphin.Freight.Settinngs.DisplaySetting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Dolphin.Freight.Web.Pages.DisplaySetting
{
	public class IndexModel : FreightPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateDisplaySettingDTO DisplaySetting { get; set; }
        private readonly IDisplaySettingAppService _displaySettingAppService;

        public IndexModel(IDisplaySettingAppService displaySettingAppService)
        {
            _displaySettingAppService = displaySettingAppService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _displaySettingAppService.UpdateAsync(Id, DisplaySetting);
            return NoContent();

        }
        public List<SelectListItem> CompleteDay { get; set; }

        public void OnGet()
        {
        }

        //public AirOtherChargeModel Modal { get; set; }


    }
}
