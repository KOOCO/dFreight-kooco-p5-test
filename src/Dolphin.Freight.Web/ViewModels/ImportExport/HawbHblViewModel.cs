using Dolphin.Freight.ImportExport.AirImports;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Dolphin.Freight.ImportExport.AirExports;
using Org.BouncyCastle.Asn1.Mozilla;
using Dolphin.Freight.ImportExport.OceanExports;

namespace Dolphin.Freight.Web.ViewModels.ImportExport
{
    public class HawbHblViewModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ShowMsg { get; set; }
        [BindProperty]
        public AirImportHawbDto HawbModel { get; set; }
        public OceanExportHblDto OceanExportHbl { get; set; }
        public AirExportHawbDto AirExportHawbDto { get; set; }
        public List<SelectListItem> TradePartnerLookupList { get; set; }
        public List<SelectListItem> SubstationLookupList { get; set; }
        public List<SelectListItem> AirportLookupList { get; set; }
        public List<SelectListItem> PackageUnitLookupList { get; set; }
        public List<SelectListItem> WtValOtherList { get; set; }
    }
}
