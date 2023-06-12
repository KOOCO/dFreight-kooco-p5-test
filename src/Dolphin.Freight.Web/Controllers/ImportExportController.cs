﻿using Dolphin.Freight.ImportExport.AirExports;
using Dolphin.Freight.ImportExport.AirImports;
<<<<<<< HEAD
using Dolphin.Freight.ImportExport.OceanExports;
using Dolphin.Freight.ImportExport.OceanImports;
=======
using Dolphin.Freight.ImportExport.Attachments;
>>>>>>> DFreight-130
using Dolphin.Freight.Settinngs.PackageUnits;
using Dolphin.Freight.Settinngs.Substations;
using Dolphin.Freight.TradePartners;
using Dolphin.Freight.Web.Pages.AirImports;
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
<<<<<<< HEAD
        private readonly IAirExportHawbAppService _airExportHawbAppService;
        private readonly IOceanExportHblAppService _oceanExportHblAppService;
        private readonly IOceanImportHblAppService _oceanImportHblAppService;
        private readonly IOceanExportMblAppService _oceanExportMblAppService;
=======
        private readonly IAttachmentAppService _attachmentAppService;
>>>>>>> DFreight-130

        public List<SelectListItem> TradePartnerLookupList { get; set; }
        public List<SelectListItem> SubstationLookupList { get; set; }
        public List<SelectListItem> AirportLookupList { get; set; }
        public List<SelectListItem> PackageUnitLookupList { get; set; }
<<<<<<< HEAD
        public List<SelectListItem> WtValOtherList { get; set; }
=======

        private readonly int fileType = 10;
>>>>>>> DFreight-130
        public ImportExportController(ITradePartnerAppService tradePartnerAppService,
            ISubstationAppService substationAppService,
            IAirportAppService airportAppService,
            IPackageUnitAppService packageUnitAppService,
            IAirImportMawbAppService airImportMawbAppService,
            IAirImportHawbAppService airImportHawbAppService,
<<<<<<< HEAD
            IAirExportHawbAppService airExportHawbAppService,
            IOceanExportHblAppService oceanExportHblAppService,
            IOceanImportHblAppService oceanImportHblAppService,
            IOceanExportMblAppService oceanExportMblAppService
=======
            IAttachmentAppService attachmentAppService
>>>>>>> DFreight-130
            )
        {
            _tradePartnerAppService = tradePartnerAppService;
            _substationAppService = substationAppService;
            _airportAppService = airportAppService;
            _packageUnitAppService = packageUnitAppService;
            _airImportMawbAppService = airImportMawbAppService;
            _airImportHawbAppService = airImportHawbAppService;
<<<<<<< HEAD
            _airExportHawbAppService = airExportHawbAppService;
            _oceanExportHblAppService = oceanExportHblAppService;
            _oceanImportHblAppService = oceanImportHblAppService;
            _oceanExportMblAppService = oceanExportMblAppService;
            
=======
            _attachmentAppService = attachmentAppService;

>>>>>>> DFreight-130
            FillTradePartnerAsync().Wait();
            FillSubstationAsync().Wait();
            FillAirportAsync().Wait();
            FillPackageUnitAsync().Wait();
        }

<<<<<<< HEAD
        [HttpGet]
        [Route("hawbhblpartial")]
        public async Task<PartialViewResult> GetHawbHBL(Guid Id)
        {
            return PartialView("~/Pages/AirImports/_AirImportHawbHBL.cshtml", new HawbHblViewModel());
        }
        [Route("OceanHBL")]
        public async Task<PartialViewResult> GetOceanExportHBL(Guid Id)
=======
        

        [HttpGet]
        [Route("AirHBL")]
        public async Task<PartialViewResult> GetAirImportHBL(Guid Id)
>>>>>>> DFreight-130
        {
            HawbHblViewModel model = new();

            model.SubstationLookupList = SubstationLookupList;
            model.AirportLookupList = AirportLookupList;
            model.TradePartnerLookupList = TradePartnerLookupList;
            model.PackageUnitLookupList = PackageUnitLookupList;
<<<<<<< HEAD

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

            model.OceanExportHbl = await _oceanExportHblAppService.GetHblCardById(Id);

            return PartialView("~/Pages/OceanExports/_OceanExportAccountingHawb.cshtml", model);
=======
            model.AirImportHawbDto = new AirImportHawbDto();
            model.AirImportHawbDto = await _airImportHawbAppService.GetDocCenterCardById(Id);

            return PartialView("~/Pages/AirImports/_AirImportHBL.cshtml", model);
>>>>>>> DFreight-130
        }

        [HttpGet]
        [Route("AirDocCenterHBL")]
<<<<<<< HEAD
        public async Task<PartialViewResult> GetDocCenterHBL(Guid Id)
=======
        public async Task<PartialViewResult> GetAirDocCenterHBL(Guid Id)
>>>>>>> DFreight-130
        {
            HawbHblViewModel model = new();

            model.SubstationLookupList = SubstationLookupList;
            model.AirportLookupList = AirportLookupList;
            model.TradePartnerLookupList = TradePartnerLookupList;
            model.PackageUnitLookupList = PackageUnitLookupList;
<<<<<<< HEAD

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

            model.OceanExportHbl = await _oceanExportHblAppService.GetHblCardById(Id);
            return PartialView("~/Pages/OceanExports/_OceanExportHawb.cshtml", model);
        }

        [HttpGet]
        [Route("OceanImportHawb")]
        public async Task<PartialViewResult> GetOceanImportHawbHBL(Guid Id)
        {
            HawbHblViewModel model = new();

            model.SubstationLookupList = SubstationLookupList;
            model.AirportLookupList = AirportLookupList;
            model.TradePartnerLookupList = TradePartnerLookupList;
            model.PackageUnitLookupList = PackageUnitLookupList;

            model.OceanImportHbl = await _oceanImportHblAppService.GetHawbCardById(Id);

            return PartialView("~/Pages/OceanImports/_OceanImportHawb.cshtml", model);
=======
            model.AirImportHawbDto = await _airImportHawbAppService.GetDocCenterCardById(Id);

            QueryAttachmentDto dto = new()
            {
                QueryId = Id,
                QueryType = fileType,
            };

            model.FileList = await _attachmentAppService.QueryListAsync(dto);

            return PartialView("~/Pages/AirImports/DocCenter/_AirIndexHawb.cshtml", model);
>>>>>>> DFreight-130
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

<<<<<<< HEAD
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

=======
>>>>>>> DFreight-130
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
<<<<<<< HEAD
}
=======
}
>>>>>>> DFreight-130
