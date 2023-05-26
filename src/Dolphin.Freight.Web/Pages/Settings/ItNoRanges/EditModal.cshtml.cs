using Dolphin.Freight.Settings.ItNoRanges;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Dolphin.Freight.Web.Pages.ItNoRanges
{
    public class EditModalModel : FreightPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateItNoRangeDto ItNoRange { get; set; }

        private readonly IItNoRangeAppService _itNoRangeAppService;

        public EditModalModel(IItNoRangeAppService itNoRangeAppService)
        {
            _itNoRangeAppService = itNoRangeAppService;
        }

        public async Task OnGetAsync()
        {
            var itNoRangeDto = await _itNoRangeAppService.GetAsync(Id);
            ItNoRange = ObjectMapper.Map<ItNoRangeDto, CreateUpdateItNoRangeDto>(itNoRangeDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _itNoRangeAppService.UpdateAsync(Id, ItNoRange);
            return NoContent();
        }
    }
}
