
using Dolphin.Freight.Settinngs.PackageUnits;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Dolphin.Freight.Web.Pages.Settings.PackageUnits
{
    public class EditModalModel : FreightPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        [BindProperty]
        public CreateUpdatePackageUnitDto PackageUnit { get; set; }
        private readonly IPackageUnitAppService _packageUnitAppService;
        public EditModalModel(IPackageUnitAppService packageUnitAppService)
        {
            _packageUnitAppService = packageUnitAppService;
        }
        public async Task OnGetAsync()
        {
            var packageUnit = await _packageUnitAppService.GetAsync(Id);
            PackageUnit = ObjectMapper.Map<PackageUnitDto, CreateUpdatePackageUnitDto>(packageUnit);
            var a = 1;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await _packageUnitAppService.UpdateAsync(Id, PackageUnit);
            return NoContent();
        }
    }
}
