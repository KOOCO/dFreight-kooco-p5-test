using Dolphin.Freight.ImportExport.OceanExports;
using Dolphin.Freight.Web.ViewModels.ForwarderCargoReceipt;
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
    public class ForwarderCargoReceiptModel : PageModel
    {
        public ForwarderCargoReceiptIndexViewModel InfoModel { get; set; }
        private readonly IGeneratePdf _generatePdf;
        public ForwarderCargoReceiptModel(IGeneratePdf generatePdf)
        {
            _generatePdf = generatePdf;
        }
        public void OnGet()
        {
            if (TempData["PrintDataFCR"] != null)
            {
                InfoModel = JsonConvert.DeserializeObject<ForwarderCargoReceiptIndexViewModel>(TempData["PrintDataFCR"].ToString());
            }
            else 
            {
                InfoModel = new ForwarderCargoReceiptIndexViewModel();
            }

            TempData["PrintData"] = JsonConvert.SerializeObject(InfoModel);
        }

        public async Task<IActionResult> OnPostAsync(ForwarderCargoReceiptIndexViewModel InfoModel)
        {
            InfoModel.BaseUrl = string.Format("{0}://{1}/", HttpContext.Request.Scheme, HttpContext.Request.Host);

            return await _generatePdf.GetPdf("Views/ForwarderCargoReceipt/Default.cshtml", InfoModel);
        }
    }
}
