
using Dolphin.Freight.Settings.AwbNoRanges;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dolphin.Freight.Web.Pages.AwbNoRanges
{
    public class CreateModalModel : FreightPageModel
    {
        [BindProperty]
        public CreateUpdateAwbNoRangeDto AwbNoRange { get; set; }

        private readonly IAwbNoRangeAppService _AwbNoRangeAppService;

        public CreateModalModel(IAwbNoRangeAppService awbNoRangeAppService)
        {
            _AwbNoRangeAppService = awbNoRangeAppService;
            
        }

        public async void OnGet()
        {
            AwbNoRange = new CreateUpdateAwbNoRangeDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _AwbNoRangeAppService.CreateAsync(AwbNoRange);
            return NoContent();
        }
    }
}
