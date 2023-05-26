using Dolphin.Freight.Web.ViewModels.PreAlert;
using Dolphin.Freight.Web.ViewModels.Reports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace Dolphin.Freight.Web.Pages.Reports
{
    public class ProfitSummaryModel : PageModel
    {
        public ProfitSummaryViewModel InfoModel { get; set; }
        private readonly IGeneratePdf _generatePdf;
        public ProfitSummaryModel(IGeneratePdf generatePdf)
        {
            _generatePdf = generatePdf;
        }
        public void OnGet()
        {
            if (TempData["PrintDataPS"] != null)
            {
                InfoModel = JsonConvert.DeserializeObject<ProfitSummaryViewModel>(TempData["PrintDataPS"].ToString());
            }
            else
            {
                InfoModel = new ProfitSummaryViewModel();
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