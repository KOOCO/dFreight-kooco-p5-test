using Dolphin.Freight.ImportExport.AirExports;
using Dolphin.Freight.ImportExport.AirImports;
using Dolphin.Freight.ImportExport.OceanExports;
using Dolphin.Freight.Settinngs.PackageUnits;
using Dolphin.Freight.Settinngs.Substations;
using Dolphin.Freight.TradePartners;
using Dolphin.Freight.Web.Pages.Sales.TradePartner;
using Dolphin.Freight.Web.ViewModels.ImportExport;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Dolphin.Freight.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportExportController : AbpController
    {
        private readonly ITradePartnerAppService _tradePartnerAppService;
        private readonly ISubstationAppService _substationAppService;
        private readonly IAirportAppService _airportAppService;
        private readonly IPackageUnitAppService _packageUnitAppService;
        private readonly IAirImportMawbAppService _airImportMawbAppService;
        private readonly IAirImportHawbAppService _airImportHawbAppService;
        private readonly IAirExportHawbAppService _airExportHawbAppService;
        private readonly IOceanExportHblAppService _oceanExportHblAppService;

        public List<SelectListItem> TradePartnerLookupList { get; set; }
        public List<SelectListItem> SubstationLookupList { get; set; }
        public List<SelectListItem> AirportLookupList { get; set; }
        public List<SelectListItem> PackageUnitLookupList { get; set; }
        public List<SelectListItem> WtValOtherList { get; set; }
        public ImportExportController(ITradePartnerAppService tradePartnerAppService,
            ISubstationAppService substationAppService,
            IAirportAppService airportAppService,
            IPackageUnitAppService packageUnitAppService,
            IAirImportMawbAppService airImportMawbAppService,
            IAirImportHawbAppService airImportHawbAppService,
            IAirExportHawbAppService airExportHawbAppService,
            IOceanExportHblAppService oceanExportHblAppService
            )
        {
            _tradePartnerAppService = tradePartnerAppService;
            _substationAppService = substationAppService;
            _airportAppService = airportAppService;
            _packageUnitAppService = packageUnitAppService;
            _airImportMawbAppService = airImportMawbAppService;
            _airImportHawbAppService = airImportHawbAppService;
            _airExportHawbAppService = airExportHawbAppService;
            _oceanExportHblAppService = oceanExportHblAppService;

            FillTradePartnerAsync().Wait();
            FillSubstationAsync().Wait();
            FillAirportAsync().Wait();
            FillPackageUnitAsync().Wait();
        }

        [HttpGet]
        [Route("hawbhblpartial")]
        public async Task<PartialViewResult> GetHawbHBL(Guid Id)
        {
            HawbHblViewModel model = new();

            model.SubstationLookupList = SubstationLookupList;
            model.AirportLookupList = AirportLookupList;
            model.TradePartnerLookupList = TradePartnerLookupList;
            model.PackageUnitLookupList = PackageUnitLookupList;

            model.HawbModel = await _airImportHawbAppService.GetHawbCardById(Id);

            return PartialView("~/Pages/AirImports/_AirImportHawbHBL.cshtml", model);
        }

        [HttpGet]
        [Route("ExportHawbhblPartial")]
        public async Task<PartialViewResult> GetAirExportHawbHBL(Guid Id)
        {
            HawbHblViewModel model = new();

            model.SubstationLookupList = SubstationLookupList;
            model.AirportLookupList = AirportLookupList;
            model.TradePartnerLookupList = TradePartnerLookupList;
            model.PackageUnitLookupList = PackageUnitLookupList;

            FillWtValOther();

            model.WtValOtherList = WtValOtherList;

            model.AirExportHawbDto = await _airExportHawbAppService.GetHawbCardById(Id);

            return PartialView("~/Pages/AirExports/_AirExportHawbHBL.cshtml", model);
        }

        [HttpGet]
        [Route("OceanExportHawb")]
        public async Task<PartialViewResult> GetOceanExportHawbHBL(Guid Id)
        {
            HawbHblViewModel model = new();

            model.SubstationLookupList = SubstationLookupList;
            model.AirportLookupList = AirportLookupList;
            model.TradePartnerLookupList = TradePartnerLookupList;
            model.PackageUnitLookupList = PackageUnitLookupList;

            model.OceanExportHbl = await _oceanExportHblAppService.GetHawbCardById(Id);
            return PartialView("~/Pages/OceanExports/_OceanExportHawb.cshtml", model);
        }


        #region FillTradePartnerAsync()
        private async Task FillTradePartnerAsync()
        {
            var tradePartnerLookup = await _tradePartnerAppService.GetTradePartnersLookupAsync();
            TradePartnerLookupList = tradePartnerLookup.Items
                                                .Select(x => new SelectListItem(x.TPName + " / " + x.TPCode, x.Id.ToString(), false))
                                                .ToList();
        }
        #endregion

        #region FillSubstationAsync()
        private async Task FillSubstationAsync()
        {
            var substationLookup = await _substationAppService.GetSubstationsLookupAsync();
            SubstationLookupList = substationLookup.Items
                                                .Select(x => new SelectListItem(x.SubstationName + "  (" + x.AbbreviationName + ")", x.Id.ToString(), false))
                                                .ToList();
        }
        #endregion

        #region FillAirportAsync()
        private async Task FillAirportAsync()
        {
            var airportLookup = await _airportAppService.GetAirportLookupAsync();
            AirportLookupList = airportLookup.Items
                                                .Select(x => new SelectListItem(x.AirportIataCode + " " + x.AirportName, x.Id.ToString(), false))
                                                .ToList();
        }
        #endregion

        #region FillPackageUnitAsync()
        private async Task FillPackageUnitAsync()
        {
            var packageUnitLookup = await _packageUnitAppService.GetPackageUnitsLookupAsync();
            PackageUnitLookupList = packageUnitLookup.Items
                                                .Select(x => new SelectListItem(x.PackageName, x.Id.ToString(), false))
                                                .ToList();
        }
        #endregion

        #region FillWtVal()
        private void FillWtValOther()
        {
            WtValOtherList = new List<SelectListItem>
            {
                new SelectListItem { Value = "PPD", Text = "PPD"},
                new SelectListItem { Value = "COLL", Text = "COLL"}
            };
        }
        #endregion

        #region SetAirImportFileNo() 
        /// <summary>
        /// ³]©wAir ImportªºFile No
        /// </summary>
        private string SetAirImportFileNo()
        {
            string today = DateTime.Now.ToString("yyyyMMddhhmmss");
            string AIFileNo = "AIM-" + today;
            return AIFileNo;
        }
        #endregion
    }
}
