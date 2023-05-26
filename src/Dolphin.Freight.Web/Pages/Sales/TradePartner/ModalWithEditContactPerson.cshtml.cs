using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Microsoft.Extensions.Logging;
using Dolphin.Freight.TradePartners;
using Microsoft.Extensions.Logging.Abstractions;
using System.Threading.Tasks;
using Dolphin.Freight.TradePartner;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Dolphin.Freight.Settings.Countries;
using System.Linq;
using Dolphin.Freight.Localization;
using Microsoft.Extensions.Localization;

namespace Dolphin.Freight.Web.Pages.Sales.TradePartner
{
    public class ModalWithEditContactPersonModel : AbpPageModel
    {
        public new ILogger<ModalWithEditContactPersonModel> Logger { get; set; }
        [BindProperty]
        public EditContactPersonViewModel ContactPersonModel { get; set; }

        public List<SelectListItem> ConstellationList { get; set; }
        public List<SelectListItem> CountryList { get; set; }

        private readonly IContactPersonAppService _contactPersonAppService;
        private readonly ICountryAppService _countryAppService;
        private readonly IStringLocalizer<FreightResource> _L;

        public ModalWithEditContactPersonModel(IContactPersonAppService contactPersonAppService, ICountryAppService countryAppService, IStringLocalizer<FreightResource> L)
        {
            _contactPersonAppService = contactPersonAppService;
            _countryAppService = countryAppService;
            _L = L;
            Logger = NullLogger<ModalWithEditContactPersonModel>.Instance;
        }

        public async Task OnGetAsync(Guid id)
        {
            Logger.LogDebug("ModalWithEditContactPerson Id:{Id}", id);
            var contactPersonDto = await _contactPersonAppService.GetAsync(id);
            ContactPersonModel = ObjectMapper.Map<ContactPersonDto, EditContactPersonViewModel>(contactPersonDto);

            ConstellationList = Enum.GetValues<ConstellationType>().Select(row => new SelectListItem() { Text = _L["DisplayName:" + row.ToString()], Value = ((int)row).ToString() }).ToList();
            ConstellationList.AddFirst(new SelectListItem() { Text = "", Value = "" });

            CountryList = (await _countryAppService.GetListAsync()).Select(row => new SelectListItem() { Text = row.CountryName, Value = row.Id.ToString() }).ToList();
            CountryList.AddFirst(new SelectListItem() { Text = "", Value = "" });
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _contactPersonAppService.UpdateContactPersonAsync(
                ContactPersonModel.Id,
                ObjectMapper.Map<EditContactPersonViewModel, CreateUpdateContactPersonDto>(ContactPersonModel)
            ) ;
            return NoContent();
        }

        public class EditContactPersonViewModel
        {
            [HiddenInput]
            public Guid Id { get; set; }
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
