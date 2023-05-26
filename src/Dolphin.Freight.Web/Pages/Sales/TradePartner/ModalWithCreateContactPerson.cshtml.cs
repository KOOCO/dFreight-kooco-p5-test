using Dolphin.Freight.Localization;
using Dolphin.Freight.Settings.Countries;
using Dolphin.Freight.TradePartner;
using Dolphin.Freight.TradePartners;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Dolphin.Freight.Web.Pages.Sales.TradePartner
{
    public class ModalWithCreateContactPersonModel : AbpPageModel
    {
        public ILogger<ModalWithCreateContactPersonModel> Logger { get; set; }
        [BindProperty]
        public CreateContactPersonViewModel ContactPersonModel { get; set; }

        public List<SelectListItem> ConstellationList { get; set; }
        public List<SelectListItem> CountryList { get; set; }

        private readonly IContactPersonAppService _contactPersonAppService;
        private readonly ICountryAppService _countryAppService;
        private readonly IStringLocalizer<FreightResource> _L;

        public ModalWithCreateContactPersonModel(IContactPersonAppService contactPersonAppService, ICountryAppService countryAppService, IStringLocalizer<FreightResource> L)
        {
            _contactPersonAppService = contactPersonAppService;
            _countryAppService = countryAppService;
            _L = L;
            Logger = NullLogger<ModalWithCreateContactPersonModel>.Instance;
        }
        
        
        public async Task OnGet(Guid tradePartnerId)
        {
            Logger.LogDebug("1_Enter into ModalWithCreateContactPersonModel OnGet:" + tradePartnerId.ToString());
            ContactPersonModel = new CreateContactPersonViewModel();
            ContactPersonModel.TradePartnerId = tradePartnerId;
            Logger.LogDebug("2_ContactPersonModel.TradePartnerId:" + ContactPersonModel.TradePartnerId.ToString());

            ConstellationList = Enum.GetValues<ConstellationType>().Select(row => new SelectListItem() { Text = _L["DisplayName:" + row.ToString()], Value = ((int)row).ToString() }).ToList();
            ConstellationList.AddFirst(new SelectListItem() { Text = "", Value = "" });

            CountryList = (await _countryAppService.GetListAsync()).Select(row => new SelectListItem() { Text = row.CountryName, Value = row.Id.ToString() }).ToList();
            CountryList.AddFirst(new SelectListItem() { Text = "", Value = "" });
        }

        public async Task<IActionResult> OnPostAsync() 
        {
            Logger.LogDebug("3_Enter into ModalWithCreateContactPersonModel OnPost:" + ContactPersonModel.ContactName);
            var dto = ObjectMapper.Map<CreateContactPersonViewModel, CreateUpdateContactPersonDto>(ContactPersonModel);
            Logger.LogDebug("4_dto:" + dto.TradePartnerId.ToString());
            var createDto = await _contactPersonAppService.CreateContactPersonAsync(dto);
            Logger.LogDebug("5_createDto:" + createDto.ContactName);
            return NoContent();
        }

        public class CreateContactPersonViewModel
        {
            public bool IsRep { get; set; }
            public bool IsEmailNotification { get; set; }
            [Required]
            public string ContactName { get; set; }
            public string ContactTitle { get; set; }
            public string ContactDivision { get; set; }
            public string ContactCellPhone { get; set; }
            public string ContactPhone { get; set; }
            public string ContactFax { get; set; }
            public string ContactEmailAddress { get; set; }
            [TextArea]
            public string ContactRemark { get; set; }
            public GenderType? ContactGender { get; set; }
            public MarriageType? ContactMarriage { get; set; }
            public SmokesType? ContactSmokes { get; set; }
            public DrinkType? ContactDrink { get; set; }
            public int? ContactAge { get; set; }
            public string ContactGarment { get; set; }
            public string ContactHobby { get; set; }
            public string ContactInterest { get; set; }
            public ConstellationType? ContactConstellation { get; set; }
            public DateTime? ContactMemorialDay { get; set; }
            public DateTime? ContactBirthday { get; set; }
            public Guid? ContactCountryId { get; set; }
            public string ContactCityCode { get; set; }
            public string ContactStateCode { get; set; }
            public string ContactPostCode { get; set; }
            public string ContactAddress { get; set; }
            [HiddenInput]
            public Guid TradePartnerId { get; set; }
        }
    }
}
