using Dolphin.Freight.Settings.AirOtherCharge;
using Dolphin.Freight.Settinngs.AirOtherCharge;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;


namespace Dolphin.Freight.Web.Pages.AirOtherCharge
{
    public class EditModalModel : FreightPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateAirOtherChargeDTO AirOtherCharge { get; set; }

        private readonly IAirOtherChargeAppService _airOtherChargeAppService;

        public EditModalModel(IAirOtherChargeAppService airOtherChargeAppService)
        {
            _airOtherChargeAppService = airOtherChargeAppService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _airOtherChargeAppService.UpdateAsync(Id, AirOtherCharge);
            return NoContent();
        }

        //public AirOtherChargeModel Modal { get; set; }

        public List<SelectListItem> CompanyType { get; set; }

        public List<SelectListItem> PaymentList { get; set; }

        public List<SelectListItem> ChargeItemList { get; set; }

        public List<SelectListItem> DescriptionList { get; set; }
        public List<SelectListItem> ChargeUnitList { get; set; }


        public async Task OnGetAsync()
        {
            var airOtherChargeDTO = await _airOtherChargeAppService.GetAsync(Id);
            AirOtherCharge = ObjectMapper.Map<AirOtherChargeDTO, CreateUpdateAirOtherChargeDTO>(airOtherChargeDTO);

            CompanyType = new List<SelectListItem>
            {
                new SelectListItem { Value = "Carrier", Text = @L["Carrier"].Value},
                new SelectListItem { Value = "Agent", Text = @L["Agent"].Value},

            };

            PaymentList = new List<SelectListItem>
            {
                new SelectListItem { Value = "prepaid", Text = @L["Prepaid"].Value},
                new SelectListItem { Value = "collect", Text = @L["Collect"].Value},

            };

            ChargeItemList = new List<SelectListItem>
            {
                new SelectListItem { Value = "ChargeItem1", Text = "ChargeItem1"},
                new SelectListItem { Value = "ChargeItem2", Text = "ChargeItem2"},
                new SelectListItem { Value = "ChargeItem3", Text = "ChargeItem3"},
                new SelectListItem { Value = "ChargeItem4", Text = "ChargeItem4"},

            };

            DescriptionList = new List<SelectListItem>
            {
                  new SelectListItem { Value = "Description1", Text = "Description1"},
                  new SelectListItem { Value = "Description2", Text = "Description2"},
                  new SelectListItem { Value = "Description3", Text = "Description3"},
                  new SelectListItem { Value = "Description4", Text = "Description4"},

            };

            ChargeUnitList = new List<SelectListItem>
            {
                  new SelectListItem { Value = "KG", Text = "KG"},
                  new SelectListItem { Value = "Pond", Text = "Pond"},

            };
        }
    }
}
