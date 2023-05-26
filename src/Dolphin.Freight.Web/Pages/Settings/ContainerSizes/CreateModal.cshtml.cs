using Dolphin.Freight.Settings.ContainerSizes;
using Dolphin.Freight.Settings.PackageUnits;
using Dolphin.Freight.Settinngs.ContainerSizes;
using Dolphin.Freight.Settinngs.PackageUnits;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Dolphin.Freight.Web.Pages.Settings.ContainerSizes
{
    public class CreateModalModel : FreightPageModel
    {
        [BindProperty]
        public CreateUpdateContainerSizeDto ContainerSize { get; set; }
        private readonly IContainerSizeAppService _containerSizeAppService;

        public CreateModalModel(IContainerSizeAppService containerSizeAppService)
        {
            _containerSizeAppService = containerSizeAppService;

        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await _containerSizeAppService.CreateAsync(ContainerSize);
            return NoContent();
        }
    }
}
