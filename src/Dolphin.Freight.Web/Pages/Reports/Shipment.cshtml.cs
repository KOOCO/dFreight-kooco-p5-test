using Dolphin.Freight.Web.ViewModels.PreAlert;
using Dolphin.Freight.Web.ViewModels.Reports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace Dolphin.Freight.Web.Pages.Reports
{
    public class ShipmentModel : PageModel
    {
        public ShipmentViewModel InfoModel { get; set; }
        private readonly IGeneratePdf _generatePdf;
        public ShipmentModel(IGeneratePdf generatePdf)
        {
            _generatePdf = generatePdf;
        }
        public void OnGet()
        {
            if (TempData["PrintDataSHIPMENT"] != null)
            {
                InfoModel = JsonConvert.DeserializeObject<ShipmentViewModel>(TempData["PrintDataSHIPMENT"].ToString());
            }
            else
            {
                InfoModel = new ShipmentViewModel();
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
