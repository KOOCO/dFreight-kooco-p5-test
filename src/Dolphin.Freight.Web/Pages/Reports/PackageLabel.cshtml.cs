using Dolphin.Freight.ImportExport.OceanExports;
using Dolphin.Freight.Web.ViewModels.PackageLabel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Wkhtmltopdf.NetCore;

namespace Dolphin.Freight.Web.Pages.Reports
{
    public class PackageLabelModel : PageModel
    {
        public class InfoViewModel
        {
            public string Office { get; set; }
            public string To { get; set; }
            public string MblNo { get; set; }
            public string CarrierBookingNo { get; set; }
            public string Pieces { get; set; }
            public string Destination { get; set; }
            public string TotalPieces { get; set; }
        }
        public InfoViewModel InfoModel { get; set; }
        private readonly IGeneratePdf _generatePdf;
        public PackageLabelModel(IGeneratePdf generatePdf)
        {
            _generatePdf = generatePdf;
        }
        public void OnGet()
        {
            if (TempData["PrintDataPL"] != null)
            {
                InfoModel = JsonConvert.DeserializeObject<InfoViewModel>(TempData["PrintDataPL"].ToString());
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
            //InfoModel.CarrierBookingNo = "A1234";
            //InfoModel.Pieces = "1";
            //InfoModel.Destination = "SOUTH OGDEN, UT (UNITED STATES)";
            //InfoModel.TotalPieces = "1";
            #endregion
        }

        public async Task<IActionResult> OnPostAsync(InfoViewModel InfoModel)
        {
            string Input = JsonConvert.SerializeObject(InfoModel);
            var OutModel = new PackageLabelIndexViewModel();
            OutModel = JsonConvert.DeserializeObject<PackageLabelIndexViewModel>(Input);
            OutModel.TotalPieces = OutModel.Pieces;
            //OutModel.To = OutModel.To.Replace("\r\n", "<br />");
            return await _generatePdf.GetPdf("Views/PackageLabel/PackageLabel.cshtml", OutModel);
        }

    }
}
