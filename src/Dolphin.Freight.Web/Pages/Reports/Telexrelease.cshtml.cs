using Dolphin.Freight.ImportExport.OceanExports;
using Dolphin.Freight.Web.ViewModels.Telexrelease;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace Dolphin.Freight.Web.Pages.Reports
{
    public class TelexreleaseModel : PageModel
    {
        public class InfoViewModel
        {
            public string Office { get; set; }
            public string Address { get; set; }
            public string Tel { get; set; }
            public string Fax { get; set; }
            public string Email { get; set; }
            public string Email_U { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Date { get; set; }
            //Cosco
            public string Date_M { get; set; }
            public string DateTime { get; set; }
            public string To { get; set; }
            //Default
            public string Attn { get; set; }
            //Default
            public string From { get; set; }
            public string Vessel { get; set; }
            //Cosco
            public string Voyage { get; set; }
            //Cosco
            public string Pol { get; set; }
            public string Pod { get; set; }
            public string Mbl { get; set; }
            //Default
            public string Cnee { get; set; }
            //Cosco
            public string Consignee { get; set; }
            public string TextArea { get; set; }
            //Default
            public string Find_Check { get; set; }
            //Cosco
            public string to_vessel_voyage { get; set; }
            //Cosco
            public string vessel_voyage { get; set; }
            //Cosco
            public string LD_ports { get; set; }

            //Cosco
            public string cargo { get; set; }

            //Cosco
            public string bills_of_lading { get; set; }
        }
        public InfoViewModel InfoModel { get; set; }
        private readonly IGeneratePdf _generatePdf;
        public TelexreleaseModel(IGeneratePdf generatePdf)
        {
            _generatePdf = generatePdf;
        }
        public void OnGet()
        {
            if (TempData["PrintDataTR"] != null)
            {
                InfoModel = JsonConvert.DeserializeObject<InfoViewModel>(TempData["PrintDataTR"].ToString());
            }
            else 
            {
                InfoModel = new InfoViewModel();
            }

            TempData["PrintData"] = JsonConvert.SerializeObject(InfoModel);
            //Test Data
            #region
            //InfoModel.Office = "Dolphin Logistics Taipei Office";
            //InfoModel.Address = "";
            //InfoModel.Tel = "+886-2-2545-9900#8671";
            //InfoModel.Fax = "";
            //InfoModel.Email = "it@dolphin-gp.com";
            //InfoModel.Email_U = InfoModel.Email.ToUpper();
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
        }

        public async Task<IActionResult> OnPostAsync(InfoViewModel InfoModel)
        {
            string Input = JsonConvert.SerializeObject(InfoModel);
            var OutModel = new TelexreleaseIndexViewModel();
            OutModel = JsonConvert.DeserializeObject<TelexreleaseIndexViewModel>(Input);

            return await _generatePdf.GetPdf("Views/Telexrelease/Default.cshtml", OutModel);
        }

        public IActionResult OnGetReportCosco()
        {
            InfoViewModel InfoViewModel = new InfoViewModel();

            if (TempData["PrintData"] != null)
            {
                InfoViewModel = JsonConvert.DeserializeObject<InfoViewModel>(TempData["PrintData"].ToString());
            }
            else
            {
                InfoViewModel = new InfoViewModel();
            }

            string Input = JsonConvert.SerializeObject(InfoViewModel);

            TempData["PrintDataTRC"] = null;
            TempData["PrintDataTRC"] = Input;

            return RedirectToPage("/Reports/TelexreleaseCosco", new {});
        }
    }
}
