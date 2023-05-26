using Dolphin.Freight.Settings.PackageUnits;
using Dolphin.Freight.Settinngs.ContainerSizes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Dolphin.Freight.Web.Pages.Settings.ContainerSizes
{
    public class EditModalModel : FreightPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        [BindProperty]
        public CreateUpdateContainerSizeDto ContainerSize { get; set; }
        private readonly IContainerSizeAppService _containerSizeAppService;

        public EditModalModel(IContainerSizeAppService containerSizeAppService)
        {
            _containerSizeAppService = containerSizeAppService;

        }
        public async Task OnGetAsync()
        {
            var containerSize = await _containerSizeAppService.GetAsync(Id);
            ContainerSize = ObjectMapper.Map<ContainerSizeDto, CreateUpdateContainerSizeDto>(containerSize);
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await _containerSizeAppService.UpdateAsync(Id, ContainerSize);
            return NoContent();
        }
    }
}
