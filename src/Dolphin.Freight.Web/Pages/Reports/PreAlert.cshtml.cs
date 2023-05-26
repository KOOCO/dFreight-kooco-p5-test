using Dolphin.Freight.ImportExport.OceanExports;
using Dolphin.Freight.Web.ViewModels.PreAlert;
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
    public class PreAlertModel : PageModel
    {
        public PreAlertIndexViewModel InfoModel { get; set; }
        private readonly IGeneratePdf _generatePdf;
        public PreAlertModel(IGeneratePdf generatePdf)
        {
            _generatePdf = generatePdf;
        }
        public void OnGet()
        {
            if (TempData["PrintDataPA"] != null)
            {
                InfoModel = JsonConvert.DeserializeObject<PreAlertIndexViewModel>(TempData["PrintDataPA"].ToString());
            }
            else 
            {
                InfoModel = new PreAlertIndexViewModel();
            }

            TempData["PrintData"] = JsonConvert.SerializeObject(InfoModel);
        }

        public async Task<IActionResult> OnPostAsync(PreAlertIndexViewModel InfoModel)
        {
            InfoModel.BaseUrl = string.Format("{0}://{1}/", HttpContext.Request.Scheme, HttpContext.Request.Host);

            return await _generatePdf.GetPdf("Views/PreAlert/Default.cshtml", InfoModel);
        }
    }
}
