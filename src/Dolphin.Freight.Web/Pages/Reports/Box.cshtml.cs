using Dolphin.Freight.Web.ViewModels.PreAlert;
using Dolphin.Freight.Web.ViewModels.Reports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace Dolphin.Freight.Web.Pages.Reports
{
    public class BoxModel : PageModel
    {
        public BoxViewModel InfoModel { get; set; }
        private readonly IGeneratePdf _generatePdf;
        public BoxModel(IGeneratePdf generatePdf)
        {
            _generatePdf = generatePdf;
        }
        public void OnGet()
        {
            if (TempData["PrintDataBOX"] != null)
            {
                InfoModel = JsonConvert.DeserializeObject<BoxViewModel>(TempData["PrintDataBOX"].ToString());
            }
            else
            {
                InfoModel = new BoxViewModel();
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
