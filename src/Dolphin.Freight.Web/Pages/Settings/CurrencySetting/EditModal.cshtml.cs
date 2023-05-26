using Dolphin.Freight.Settings.CurrencySetting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Dolphin.Freight.Web.Pages.CurrencySetting
{
    public class EditModalModel : FreightPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateCurrencySettingDTO CurrencySetting { get; set; }

        private readonly ICurrencySettingAppService _currencySettingAppService;

        public EditModalModel(ICurrencySettingAppService currencySettingAppService)
        {
            _currencySettingAppService = currencySettingAppService;
        }

        public async Task OnGetAsync()
        {
            var currencySettingDTO = await _currencySettingAppService.GetAsync(Id);
            CurrencySetting = ObjectMapper.Map<CurrencySettingDTO, CreateUpdateCurrencySettingDTO>(currencySettingDTO);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _currencySettingAppService.UpdateAsync(Id, CurrencySetting);
            return NoContent();
        }
    }
}
