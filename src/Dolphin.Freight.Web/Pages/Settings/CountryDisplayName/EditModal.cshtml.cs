using Dolphin.Freight.ImportExport.AirExports;
using Dolphin.Freight.Settings.AirOtherCharge;
using Dolphin.Freight.Settings.Countries;
using Dolphin.Freight.Settings.ItNoRanges;
using Dolphin.Freight.Settings.Offices;
using Dolphin.Freight.Settinngs.AirOtherCharge;
using Dolphin.Freight.Settinngs.Offices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;


namespace Dolphin.Freight.Web.Pages.CountryDisplayName
{
    public class EditModalModel : FreightPageModel
    {
        [BindProperty(SupportsGet = true)]
        public Guid? Id { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guid OfficeId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string OfficeName { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guid CountryId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string CountryName { get; set; }


        public string DisplayName { get; set; }
        public Guid? AirportId { get; set; }
        public string AirportName { get; set; }

        [BindProperty]
        public CreateUpdateCountryDisplayNameDto CreateUpdateCountryDisplayNameDto { get; set; }

        public List<AirportDto> Airports { get; set; }

        private readonly ICountryDisplayNameAppService _countryDisplayNameAppService;
        private readonly IAirportAppService _airportAppService;

        public EditModalModel(ICountryDisplayNameAppService countryDisplayNameAppService, IAirportAppService airportAppService)
        {
            _countryDisplayNameAppService = countryDisplayNameAppService;
            _airportAppService = airportAppService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _countryDisplayNameAppService.SaveAsync(CreateUpdateCountryDisplayNameDto);
            return NoContent();
        }

        public async Task OnGetAsync()
        {
            if (Id != null)
            {
                CountryDisplayNameDto dto = await _countryDisplayNameAppService.GetAsync(Id.Value);

                DisplayName = dto.DisplayName;
                CountryId = dto.CountryId;
                CountryName = dto.CountryName;
                OfficeName = dto.OfficeName;
                AirportId = dto.AirportId;
                AirportName = dto.AirportName;
            }

            Airports = (await _airportAppService.GetAirportLookupAsync()).Items.ToList();
        }
    }
}
