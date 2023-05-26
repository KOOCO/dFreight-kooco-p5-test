using Dolphin.Freight.TradePartners.Credits;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Dolphin.Freight.Web.Pages.Sales.TradePartner.Credit
{
    public class ModalWithCreateCreditLimitGroupModel : AbpPageModel
    {
        [BindProperty]
        public CreateEditCreditLimitGroupViewModel CreditLimitGroup { get; set; }

        private readonly ICreditLimitGroupAppService _creditLimitGroupAppService;

        public ModalWithCreateCreditLimitGroupModel(ICreditLimitGroupAppService creditLimitGroupAppService) 
        {
            _creditLimitGroupAppService = creditLimitGroupAppService;
        }
        public void OnGet()
        {
            CreditLimitGroup = new CreateEditCreditLimitGroupViewModel();
        }

        public async Task<IActionResult> OnPostAsync() 
        {
            //await _creditLimitGroupAppService.CreateAsync(
            //    ObjectMapper.Map<CreateEditCreditLimitGroupViewModel, CreateUpdateCreditLimitGroupDto>(CreditLimitGroup)
            //    );
            var dto = ObjectMapper.Map<CreateEditCreditLimitGroupViewModel, CreateUpdateCreditLimitGroupDto>(CreditLimitGroup);
            await _creditLimitGroupAppService.CreateCLGAsync(dto); 
            return NoContent();
        }
    }
}
