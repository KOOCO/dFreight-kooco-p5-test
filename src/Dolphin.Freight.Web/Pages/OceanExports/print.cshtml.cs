using Dolphin.Freight.Web.ViewModels.Telexrelease;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace Dolphin.Freight.Web.Pages.OceanExports
{
    public class printModel : PageModel
    {
        private readonly IGeneratePdf _generatePdf;
        public printModel(IGeneratePdf generatePdf)
        {
            _generatePdf = generatePdf;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnGetDownload(string input)
        {
            var InfoModel = new TelexreleaseIndexViewModel();
            InfoModel = JsonConvert.DeserializeObject<TelexreleaseIndexViewModel>(input);
            //Test Data
            #region
            //InfoModel.Office = "Dolphin Logistics Taipei Office";
            //InfoModel.Address = "";
            //InfoModel.Tel = "+886-2-2545-9900#8671";
            //InfoModel.Fax = "";
            //InfoModel.Email = "it@dolphin-gp.com";
            //InfoModel.FirstName = "萬泰";
            //InfoModel.LastName = "資訊部";
            //InfoModel.DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //InfoModel.Date = DateTime.Now.ToString("yyyy-MM-dd");
            //InfoModel.Date_M = DateTime.Now.ToString("MMMM dd, yyyy", new CultureInfo("en-US"));
            //InfoModel.To = "";
            //InfoModel.Attn = "EXPORT FREIGHT CASHER";
            //InfoModel.From = "DOLPHIN LOGISTICS TAIPEI OFFICE";
            //InfoModel.Vessel = "";
            //InfoModel.Voyage = "444";
            //InfoModel.Mbl = "TEST00000002";
            //InfoModel.Pod = "";
            //InfoModel.Pol = "BALLSTON LAKE, NY (UNITED STATES)";
            //InfoModel.Cnee = "";
            //InfoModel.Consignee = "AER LINGUS";
            //InfoModel.Find_Check = "";

            //InfoModel.TextArea = InfoModel.LastName;
            #endregion

            return await _generatePdf.GetPdf("Views/Telexrelease/Index.cshtml", InfoModel);
        }
    }
}
