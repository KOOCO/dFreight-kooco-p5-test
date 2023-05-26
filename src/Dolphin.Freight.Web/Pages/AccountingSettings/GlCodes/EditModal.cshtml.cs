using Dolphin.Freight.AccountingSettings.GlCodes;
using Dolphin.Freight.Settings.ContainerSizes;
using Dolphin.Freight.Settinngs.ContainerSizes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using Volo.Abp.ObjectMapping;

namespace Dolphin.Freight.Web.Pages.AccountingSettings.GlCodes
{
    public class EditModalModel : FreightPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        [BindProperty]
        public CreateUpdateGlCodeDto GlCode { get; set; }
        private readonly IGlCodeAppService _glCodesAppService;

        public EditModalModel(IGlCodeAppService glCodesAppService)
        {
            _glCodesAppService = glCodesAppService;

        }
        public async Task OnGetAsync()
        {
            var glCode = await _glCodesAppService.GetAsync(Id);
            GlCode = ObjectMapper.Map<GlCodeDto, CreateUpdateGlCodeDto>(glCode);
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await _glCodesAppService.UpdateAsync(Id, GlCode);
            return NoContent();
        }
    }
}
