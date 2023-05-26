using Dolphin.Freight.ImportExport.OceanExports;
using Dolphin.Freight.Web.ViewModels.DockRecepit;
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
    public class DockRecepitModel : PageModel
    {
        public DockRecepitIndexViewModel InfoModel { get; set; }
        private readonly IGeneratePdf _generatePdf;
        public DockRecepitModel(IGeneratePdf generatePdf)
        {
            _generatePdf = generatePdf;
        }
        public void OnGet()
        {
            if (TempData["PrintDataDR"] != null)
            {
                InfoModel = JsonConvert.DeserializeObject<DockRecepitIndexViewModel>(TempData["PrintDataDR"].ToString());
            }
            else 
            {
                InfoModel = new DockRecepitIndexViewModel();
            }

            TempData["PrintData"] = JsonConvert.SerializeObject(InfoModel);
        }

        public async Task<IActionResult> OnPostAsync(DockRecepitIndexViewModel InfoModel)
        {
            InfoModel.BaseUrl = string.Format("{0}://{1}/", HttpContext.Request.Scheme, HttpContext.Request.Host);

            return await _generatePdf.GetPdf("Views/DockRecepit/Default.cshtml", InfoModel);
        }
    }
}
