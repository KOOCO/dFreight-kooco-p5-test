using Dolphin.Freight.ImportExport.OceanExports;
using Dolphin.Freight.Web.ViewModels.CertificateOfOrigin;
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
    public class CertificateOfOriginModel : PageModel
    {
        public CertificateOfOriginIndexViewModel InfoModel { get; set; }
        private readonly IGeneratePdf _generatePdf;
        public CertificateOfOriginModel(IGeneratePdf generatePdf)
        {
            _generatePdf = generatePdf;
        }
        public void OnGet()
        {
            if (TempData["PrintDataCOO"] != null)
            {
                InfoModel = JsonConvert.DeserializeObject<CertificateOfOriginIndexViewModel>(TempData["PrintDataCOO"].ToString());
            }
            else 
            {
                InfoModel = new CertificateOfOriginIndexViewModel();
            }

            TempData["PrintData"] = JsonConvert.SerializeObject(InfoModel);
        }

        public async Task<IActionResult> OnPostAsync(CertificateOfOriginIndexViewModel InfoModel)
        {
            InfoModel.BaseUrl = string.Format("{0}://{1}/", HttpContext.Request.Scheme, HttpContext.Request.Host);

            return await _generatePdf.GetPdf("Views/CertificateOfOrigin/Default.cshtml", InfoModel);
        }
    }
}
