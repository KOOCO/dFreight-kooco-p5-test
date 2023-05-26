using Dolphin.Freight.Web.ViewModels.PreAlert;
using Dolphin.Freight.Web.ViewModels.Reports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace Dolphin.Freight.Web.Pages.Reports
{
    public class ProfitDetailModel : PageModel
    {
        public ProfitDetailViewModel InfoModel { get; set; }
        private readonly IGeneratePdf _generatePdf;
        public ProfitDetailModel(IGeneratePdf generatePdf)
        {
            _generatePdf = generatePdf;
        }
        public void OnGet()
        {
            if (TempData["PrintDataPD"] != null)
            {
                InfoModel = JsonConvert.DeserializeObject<ProfitDetailViewModel>(TempData["PrintDataPD"].ToString());
            }
            else
            {
                InfoModel = new ProfitDetailViewModel();
            }

            TempData["PrintData"] = JsonConvert.SerializeObject(InfoModel);
        }

        public async Task<IActionResult> OnPostAsync(PreAlertIndexViewModel InfoModel)
        {
            InfoModel.BaseUrl = string.Format("{0}://{1}/", HttpContext.Request.Scheme, HttpContext.Request.Host);

            return await _generatePdf.GetPdf("Views/Reports/ProfitDetail.cshtml", InfoModel);
        }
    }
}