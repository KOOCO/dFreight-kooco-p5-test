using Dolphin.Freight.ImportExport.OceanExports;
using Dolphin.Freight.Web.ViewModels.Package;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Wkhtmltopdf.NetCore;

namespace Dolphin.Freight.Web.Pages.Reports
{
    public class HblPackageLabelModel : PageModel
    {
        public class InfoViewModel
        {
            public string Office { get; set; }
            public string To { get; set; }
            public string MblNo { get; set; }
            public string HblNo { get; set; }
            public string Pieces { get; set; }
            public string Destination { get; set; }
            public string TotalPieces { get; set; }
        }
        public InfoViewModel InfoModel { get; set; }
        private readonly IGeneratePdf _generatePdf;
        public HblPackageLabelModel(IGeneratePdf generatePdf)
        {
            _generatePdf = generatePdf;
        }
        public void OnGet()
        {
            if (TempData["PrintDataHBLPL"] != null)
            {
                InfoModel = JsonConvert.DeserializeObject<InfoViewModel>(TempData["PrintDataHBLPL"].ToString());
            }
            else
            {
                InfoModel = new InfoViewModel();
            }

            TempData["PrintData"] = JsonConvert.SerializeObject(InfoModel);

            //Test Data
            #region
            //InfoModel.Office = "Dolphin Logistics Taipei Office";
            //InfoModel.To = "AER LINGUS\r\n6555 W. IMPERIAL HWY\r\nLOS ANGELES, CA 90045, UNITED STATES";
            //InfoModel.MblNo = "123AAABBBA";
            //InfoModel.HblNo = "OH-23010006";
            //InfoModel.Pieces = "1";
            //InfoModel.Destination = "SOUTH OGDEN, UT (UNITED STATES)";
            //InfoModel.TotalPieces = "1";
            #endregion
        }

        public async Task<IActionResult> OnPostAsync(InfoViewModel InfoModel)
        {
            string Input = JsonConvert.SerializeObject(InfoModel);
            var OutModel = new PackageIndexViewModel();
            OutModel = JsonConvert.DeserializeObject<PackageIndexViewModel>(Input);
            OutModel.TotalPieces = OutModel.Pieces;

            return await _generatePdf.GetPdf("Views/Package/Package.cshtml", OutModel);
        }

    }
}
