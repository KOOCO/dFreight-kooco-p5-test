using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dolphin.Freight.ImportExport.AirExports;
using Dolphin.Freight.Settings.Countries;
using Dolphin.Freight.Settinngs.Offices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dolphin.Freight.Web.Pages.CountryDisplayName
{
	public class CountryDisplayNameIndexModel : PageModel
    {
        private readonly ICountryDisplayNameAppService _countryDisplayNameAppService;
        private readonly IOfficeAppService _officeAppService;
        private readonly IAirportAppService _airportAppService;

        public List<OfficeDto> Offices { get; set; }

        public List<AirportDto> Airports { get; set; }

        public CountryDisplayNameIndexModel(ICountryDisplayNameAppService countryDisplayNameAppService, IOfficeAppService officeAppService, IAirportAppService airportAppService)
        {
            _countryDisplayNameAppService = countryDisplayNameAppService;
            _officeAppService = officeAppService;
            _airportAppService = airportAppService;
        }

        public async Task OnGetAsync()
        {
            Offices = await _officeAppService.GetListAsync();
            Airports = (await _airportAppService.GetAirportLookupAsync()).Items.ToList();
        }
    }
}
