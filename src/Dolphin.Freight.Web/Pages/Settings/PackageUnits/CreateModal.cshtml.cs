using Dolphin.Freight.Settings.AwbNoRanges;
using Dolphin.Freight.Settings.PackageUnits;
using Dolphin.Freight.Settinngs.PackageUnits;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Dolphin.Freight.Web.Pages.Settings.PackageUnits
{
    public class CreateModalModel : FreightPageModel
    {
        [BindProperty]
        public CreateUpdatePackageUnitDto PackageUnit { get; set; }
        private readonly IPackageUnitAppService _packageUnitAppService;

        public CreateModalModel(IPackageUnitAppService packageUnitAppService)
        {
            _packageUnitAppService = packageUnitAppService;

        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await _packageUnitAppService.CreateAsync(PackageUnit);
            return NoContent();
        }
    }
}
