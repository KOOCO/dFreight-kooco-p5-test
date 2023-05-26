using Dolphin.Freight.Data;
using Dolphin.Freight.TradePartners.Credits;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.ObjectMapping;

namespace Dolphin.Freight.Web.Pages.Sales.TradePartner.Credit
{
    public class ModalWithEditCreditLimitGroupModel : FreightPageModel
    {
        public ILogger<ModalWithEditCreditLimitGroupModel> Logger { get; set; }

        [BindProperty]
        public CreateEditCreditLimitGroupViewModel CreditLimitGroup { get; set; }

        private readonly ICreditLimitGroupAppService _creditLimitGroupAppService;

        public ModalWithEditCreditLimitGroupModel(ICreditLimitGroupAppService creditLimitGroupAppService)
        {
            _creditLimitGroupAppService = creditLimitGroupAppService;
            Logger = NullLogger<ModalWithEditCreditLimitGroupModel>.Instance;
        }

        public async Task OnGetAsync(Guid id)
        {
            Logger.LogDebug("1_CreditLimitGroup Id:{Id}", id);
            var creditLimtGroupDto = await _creditLimitGroupAppService.GetAsync(id);
            CreditLimitGroup = ObjectMapper.Map<CreditLimitGroupDto, CreateEditCreditLimitGroupViewModel>(creditLimtGroupDto);
            Logger.LogDebug("3_CreditLimitGroup Id:{Id}", CreditLimitGroup.Id);
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Logger.LogDebug("2_CreditLimitGroup Id:{Id}", CreditLimitGroup.Id);
            await _creditLimitGroupAppService.UpdateCLGAsync(
                CreditLimitGroup.Id,
                ObjectMapper.Map<CreateEditCreditLimitGroupViewModel, CreateUpdateCreditLimitGroupDto>(CreditLimitGroup)
            );

            return NoContent();
        }
    }
}
