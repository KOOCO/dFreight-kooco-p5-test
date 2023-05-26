using Dolphin.Freight.Settings.ItNoRanges;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dolphin.Freight.Web.Pages.ItNoRanges
{
    public class CreateModalModel : FreightPageModel
    {
        [BindProperty]
        public CreateUpdateItNoRangeDto ItNoRange { get; set; }

        private readonly IItNoRangeAppService _itNoRangeAppService;

        public CreateModalModel(IItNoRangeAppService itNoRangeAppService)
        {
            _itNoRangeAppService = itNoRangeAppService;
        }

        public void OnGet()
        {
            ItNoRange = new CreateUpdateItNoRangeDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _itNoRangeAppService.CreateAsync(ItNoRange);
            return NoContent();
        }
    }
}
