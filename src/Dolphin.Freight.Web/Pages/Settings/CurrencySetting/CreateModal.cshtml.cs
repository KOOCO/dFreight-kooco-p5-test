using Dolphin.Freight.Settings.CurrencySetting;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dolphin.Freight.Web.Pages.CurrencySetting
{
    public class CreateModalModel : FreightPageModel
    {
        [BindProperty]
        public CreateUpdateCurrencySettingDTO CurrencySetting { get; set; }

        private readonly ICurrencySettingAppService _currencySettingAppService;

        public CreateModalModel(ICurrencySettingAppService currencySettingAppService)
        {
            _currencySettingAppService = currencySettingAppService;
        }

        public void OnGet()
        {
            CurrencySetting = new CreateUpdateCurrencySettingDTO();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _currencySettingAppService.CreateAsync(CurrencySetting);
            return NoContent();
        }
    }
}
