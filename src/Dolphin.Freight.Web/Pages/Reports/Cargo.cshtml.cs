using Dolphin.Freight.Web.ViewModels.PreAlert;
using Dolphin.Freight.Web.ViewModels.Reports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace Dolphin.Freight.Web.Pages.Reports
{
    public class CargoModel : PageModel
    {
        public CargoViewModel InfoModel { get; set; }
        private readonly IGeneratePdf _generatePdf;
        public CargoModel(IGeneratePdf generatePdf)
        {
            _generatePdf = generatePdf;
        }
        public void OnGet()
        {
            if (TempData["PrintDataCARGO"] != null)
            {
                InfoModel = JsonConvert.DeserializeObject<CargoViewModel>(TempData["PrintDataCARGO"].ToString());
            }
            else
            {
                InfoModel = new CargoViewModel();
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
