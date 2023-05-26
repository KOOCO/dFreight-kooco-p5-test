using Dolphin.Freight.ImportExport.OceanExports;
using Dolphin.Freight.Web.ViewModels.UsdaHeatTreatment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace Dolphin.Freight.Web.Pages.Reports
{
    public class UsdaHeatTreatmentModel : PageModel
    {
        public UsdaHeatTreatmentIndexViewModel InfoModel { get; set; }
        private readonly IGeneratePdf _generatePdf;
        public UsdaHeatTreatmentModel(IGeneratePdf generatePdf)
        {
            _generatePdf = generatePdf;
        }
        public void OnGet()
        {
            if (TempData["PrintDataUHT"] != null)
            {
                InfoModel = JsonConvert.DeserializeObject<UsdaHeatTreatmentIndexViewModel>(TempData["PrintDataUHT"].ToString());
            }
            else 
            {
                InfoModel = new UsdaHeatTreatmentIndexViewModel();
            }

            TempData["PrintData"] = JsonConvert.SerializeObject(InfoModel);
        }

        public async Task<IActionResult> OnPostAsync(UsdaHeatTreatmentIndexViewModel InfoModel)
        {
            InfoModel.BaseUrl = string.Format("{0}://{1}/", HttpContext.Request.Scheme, HttpContext.Request.Host);

            return await _generatePdf.GetPdf("Views/UsdaHeatTreatment/Default.cshtml", InfoModel);
        }
    }
}
