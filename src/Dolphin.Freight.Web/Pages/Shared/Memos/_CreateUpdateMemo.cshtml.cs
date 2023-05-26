using Dolphin.Freight.Common;
using Dolphin.Freight.Common.Memos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Dolphin.Freight.Web.Pages.Shared.Memos
{
    public class _CreateUpdateMemoModel : AbpPageModel
    {
        [BindProperty(SupportsGet = true)]
        public Guid? Id { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guid SourceId { get; set; }

        [BindProperty(SupportsGet = true)]
        public FreightPageType FType { get; set; }

        public string MemoSubject { get; set; }

        public string MemoContent { get; set; }

        [BindProperty]
        public CreateUpdateMemoDto CreateUpdateMemoDto { get; set; }

        private readonly IMemoAppService _memoAppService;
        private ILogger<_CreateUpdateMemoModel> Logger { get; set; }

        public _CreateUpdateMemoModel(IMemoAppService memoAppService)
        {
            _memoAppService = memoAppService;
            Logger = NullLogger<_CreateUpdateMemoModel>.Instance;
        }

        public async Task OnGetAsync()
        {
            if (Id != null)
            {
                MemoDto dto = await _memoAppService.GetAsync(Id.Value);
                SourceId = dto.SourceId;
                MemoSubject = dto.Subject;
                MemoContent = dto.Content;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _memoAppService.SaveAsync(CreateUpdateMemoDto);
            return NoContent();
        }
    }
}
