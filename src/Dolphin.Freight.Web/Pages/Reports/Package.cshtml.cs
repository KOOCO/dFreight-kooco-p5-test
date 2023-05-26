using Dolphin.Freight.ImportExport.OceanExports;
using Dolphin.Freight.Web.ViewModels.Package;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Wkhtmltopdf.NetCore;

namespace Dolphin.Freight.Web.Pages.Reports
{
    public class PackageModel : PageModel
    {
        public class InfoViewModel
        {
            public string Office { get; set; }
            public string To { get; set; }
            public string MblNo { get; set; }
            public string HblNo { get; set; }
            public string Pieces { get; set; }
            public string Destination { get; set; }
            public string TotalPieces { get; set; }
        }
        public InfoViewModel InfoModel { get; set; }
        public List<InfoViewModel> HblList { get; set; }
        public List<SelectListItem> HblNoList { get; set; }
        private readonly IGeneratePdf _generatePdf;
        public PackageModel(IGeneratePdf generatePdf)
        {
            _generatePdf = generatePdf;
        }
        public void OnGet(string target)
        {
            InfoModel = new InfoViewModel();
            if (TempData["PrintDataPKG"] != null)
            {
                HblList = JsonConvert.DeserializeObject<List<InfoViewModel>>(TempData["PrintDataPKG"].ToString());

                HblNoList = new List<SelectListItem>();
                foreach (var hbl in HblList)
                {
                    HblNoList.Add(new SelectListItem() { Text = hbl.HblNo, Value = hbl.HblNo });
                }

                if (target == null)
                {
                    InfoModel.Office = HblList[0].Office;
                    InfoModel.To = HblList[0].To;
                    InfoModel.MblNo = HblList[0].MblNo;
                    InfoModel.HblNo = HblList[0].HblNo;
                    InfoModel.Pieces = HblList[0].Pieces;
                    InfoModel.Destination = HblList[0].Destination;
                    InfoModel.TotalPieces = InfoModel.Pieces;
                }
                else
                {
                    if (HblList.Count > 1)
                    {
                        //¶]°j°é¨úMblNo = target
                        for (int i = 0; i < HblList.Count; i++)
                        {
                            if (HblList[i].HblNo.ToString() == target.ToString())
                            {
                                InfoModel.Office = HblList[i].Office;
                                InfoModel.To = HblList[i].To;
                                InfoModel.MblNo = HblList[i].MblNo;
                                InfoModel.HblNo = HblList[i].HblNo;
                                InfoModel.Pieces = HblList[i].Pieces;
                                InfoModel.Destination = HblList[i].Destination;
                                InfoModel.TotalPieces = InfoModel.Pieces;

                                break;
                            }
                        }
                    }
                    else 
                    {
                        InfoModel.Office = HblList[0].Office;
                        InfoModel.To = HblList[0].To;
                        InfoModel.MblNo = HblList[0].MblNo;
                        InfoModel.HblNo = HblList[0].HblNo;
                        InfoModel.Pieces = HblList[0].Pieces;
                        InfoModel.Destination = HblList[0].Destination;
                        InfoModel.TotalPieces = InfoModel.Pieces;
                    }                    
                }

                TempData["PackagePrintData"] = TempData["PrintDataPKG"];
            }
            else
            {
                if (TempData["PackagePrintData"] != null)
                {
                    HblList = JsonConvert.DeserializeObject<List<InfoViewModel>>(TempData["PackagePrintData"].ToString());

                    HblNoList = new List<SelectListItem>();
                    foreach (var hbl in HblList)
                    {
                        if (target == hbl.HblNo)
                        {
                            HblNoList.Add(new SelectListItem() { Text = hbl.HblNo, Value = hbl.HblNo, Selected = true });
                        }
                        else
                        {
                            HblNoList.Add(new SelectListItem() { Text = hbl.HblNo, Value = hbl.HblNo });
                        }                        
                    }

                    if (target == null)
                    {
                        InfoModel.Office = HblList[0].Office;
                        InfoModel.To = HblList[0].To;
                        InfoModel.MblNo = HblList[0].MblNo;
                        InfoModel.HblNo = HblList[0].HblNo;
                        InfoModel.Pieces = HblList[0].Pieces;
                        InfoModel.Destination = HblList[0].Destination;
                        InfoModel.TotalPieces = InfoModel.Pieces;
                    }
                    else
                    {
                        if (HblList.Count > 1)
                        {
                            //¶]°j°é¨úMblNo = target
                            for (int i = 0; i < HblList.Count; i++)
                            {
                                if (HblList[i].HblNo.ToString() == target.ToString())
                                {
                                    InfoModel.Office = HblList[i].Office;
                                    InfoModel.To = HblList[i].To;
                                    InfoModel.MblNo = HblList[i].MblNo;
                                    InfoModel.HblNo = HblList[i].HblNo;
                                    InfoModel.Pieces = HblList[i].Pieces;
                                    InfoModel.Destination = HblList[i].Destination;
                                    InfoModel.TotalPieces = InfoModel.Pieces;

                                    break;
                                }
                            }
                        }
                        else
                        {
                            InfoModel.Office = HblList[0].Office;
                            InfoModel.To = HblList[0].To;
                            InfoModel.MblNo = HblList[0].MblNo;
                            InfoModel.HblNo = HblList[0].HblNo;
                            InfoModel.Pieces = HblList[0].Pieces;
                            InfoModel.Destination = HblList[0].Destination;
                            InfoModel.TotalPieces = InfoModel.Pieces;
                        }
                    }
                    TempData["PackagePrintData"] = TempData["PackagePrintData"];
                }
            }

            TempData["PrintData"] = JsonConvert.SerializeObject(InfoModel);

            //Test Data
            #region
            //InfoModel.Office = "Dolphin Logistics Taipei Office";
            //InfoModel.To = "AER LINGUS\r\n6555 W. IMPERIAL HWY\r\nLOS ANGELES, CA 90045, UNITED STATES";
            //InfoModel.MblNo = "123AAABBBA";
            //InfoModel.HblNo = "OH-23010006";
            //InfoModel.Pieces = "1";
            //InfoModel.Destination = "SOUTH OGDEN, UT (UNITED STATES)";
            //InfoModel.TotalPieces = "1";
            #endregion
        }

        public async Task<IActionResult> OnPostAsync(InfoViewModel InfoModel)
        {
            string Input = JsonConvert.SerializeObject(InfoModel);
            var OutModel = new PackageIndexViewModel();
            OutModel = JsonConvert.DeserializeObject<PackageIndexViewModel>(Input);
            OutModel.TotalPieces = OutModel.Pieces;

            return await _generatePdf.GetPdf("Views/Package/Package.cshtml", OutModel);
        }

    }
}
