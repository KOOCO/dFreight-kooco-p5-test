using Dolphin.Freight.AccountingSettings.BillingCodes;
using Dolphin.Freight.AccountingSettings.GlCodes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Dolphin.Freight.Web.Pages.AccountingSettings.BillingCodes
{
    public class CreateModalModel : FreightPageModel
    {
        [BindProperty]
        public CreateUpdateBillingCodeDto BillingCode { get; set; }
        private readonly IBillingCodeAppService _billingCodeAppService;

        public CreateModalModel(IBillingCodeAppService billingCodeAppService)
        {
            _billingCodeAppService = billingCodeAppService;

        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await _billingCodeAppService.CreateAsync(BillingCode);
            return NoContent();
        }
    }
}
