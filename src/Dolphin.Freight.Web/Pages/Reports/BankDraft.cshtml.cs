using Dolphin.Freight.Accounting.Payment;
using Dolphin.Freight.Common;
using Dolphin.Freight.ImportExport.OceanExports;
using Dolphin.Freight.Web.ViewModels.BankDraft;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Wkhtmltopdf.NetCore;

namespace Dolphin.Freight.Web.Pages.Reports
{
    public class BankDraftModel : PageModel
    {
        public class InfoViewModel
        {
            public string Amount { get; set; }
            public string Date { get; set; }
            public string AtSight { get; set; }
            //實際託運人
            public string ShipperName { get; set; }
            public string DrawnDocCredit { get; set; }
            //信用狀開立日期
            public string IssueDate { get; set; }
            //信用狀開立銀行
            public string LCIssueBank { get; set; }
            public string ToLCIssueBank { get; set; }
            //選擇Consignee或NotifyParty
            public string ToTradePartnerLoadFrom { get; set; }
            //收貨人
            public string Consignee { get; set; }
            //通知方
            public string NotifyParty { get; set; }
            public string ToTradePartnerName { get; set; }
            public string DraftNo { get; set; }
            public string BankPreference { get; set; }
            //實際託運人
            public string ShipperName2 { get; set; }
            public string Gentlemen { get; set; }
            public string GentlemenNameAddress { get; set; }
            public string EncloseDate { get; set; }
            public string EncloseDraftNo { get; set; }
            public string EncloseForCollection { get; set; }
            public string EncloseForOther { get; set; }
            public string EncloseForOtherInput { get; set; }
            public string EncloseForPayment { get; set; }
            public string ExtraBl { get; set; }
            public string ExtraBlCopy { get; set; }
            public string ExtraCommInv { get; set; }
            public string ExtraInsCtf { get; set; }
            public string ExtraCtfOrig { get; set; }
            public string ExtraConsInv { get; set; }
            public string ExtraPkngList { get; set; }
            public string ExtraWgtCtf { get; set; }
            public string DeliverInOneMailing { get; set; }
            public string DeliverInTwoMailing { get; set; }
            public string DeliverIfDraft { get; set; }
            public string AllChargesForAccount { get; set; }
            public string DoNotWaiveCharges { get; set; }
            public string ProtestForNonPayment { get; set; }
            public string DoNotProtest { get; set; }
            public string PresentOnArrival { get; set; }
            public string AdviseNonPaymentBy { get; set; }
            public string AdvisePaymentBy { get; set; }
            //操作者所屬分站名稱
            public string ReferToName { get; set; }
            public string ReferToAddress { get; set; }
            public string ToActFullyOnOurBehalf { get; set; }
            public string ToAssistNotToAlter { get; set; }
            public string OtherInstructions { get; set; }
            public string ReferQuestionTo { get; set; }
            public string ReferQuestionName { get; set; }
            public string ReferQuestionPhone { get; set; }
            //Shipper
            public string ReferQuestionShipperName { get; set; }
            public string ReferQuestionShipperPhone { get; set; }
            //Freight Forwarder
            public string ReferQuestionFreightForwarderName { get; set; }
            public string ReferQuestionFreightForwarderPhone { get; set; }
            //實際託運人
            public string ShipperName3 { get; set; }
            public string AuthorizedSignatureInput { get; set; }
            //操作者名稱+/+所屬分站名稱
            public string UserCompany { get; set; }
        }
        public InfoViewModel InfoModel { get; set; }
        public List<SelectListItem> GentlemenList { get; set; }
        private readonly IAjaxDropdownAppService _ajaxDropdownAppService;
        private readonly IGeneratePdf _generatePdf;
        public BankDraftModel(IGeneratePdf generatePdf, IAjaxDropdownAppService ajaxDropdownAppService)
        {
            _generatePdf = generatePdf;
            _ajaxDropdownAppService = ajaxDropdownAppService;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            if (TempData["PrintDataBD"] != null)
            {
                InfoModel = JsonConvert.DeserializeObject<InfoViewModel>(TempData["PrintDataBD"].ToString());
            }
            else
            {
                InfoModel = new InfoViewModel();
            }

            TempData["PrintData"] = JsonConvert.SerializeObject(InfoModel);

            #region 取貿易夥伴
            QueryDto queryDto = new QueryDto();
            queryDto.QueryType = "";
            var gentlemen = await _ajaxDropdownAppService.GetAllTradePartners(queryDto);
            if (gentlemen != null)
            {
                GentlemenList = new List<SelectListItem>();
                GentlemenList.Add(new SelectListItem() { Text = "", Value = "", Selected = true });
                foreach (var receivablessource in gentlemen)
                {
                    GentlemenList.Add(new SelectListItem() { Text = receivablessource.TPName + "\r\n" + (receivablessource.TPAliasName == null ? "null" : receivablessource.TPAliasName) + "\r\n" + receivablessource.TPCode, Value = receivablessource.Id.ToString() });
                }

            }
            #endregion

            //Test Data
            #region
            //InfoModel.Amount = ".00";
            //InfoModel.Date = DateTime.Now.ToString("yyyy-MM-dd");
            //InfoModel.AtSight = "AT SIGHT";
            //InfoModel.ShipperName = "LONG BEACH CONTAINER PIER F";
            //InfoModel.DrawnDocCredit = "\"DRAWN UNDER DOCUMENTARY CREDIT NO. : OOO";
            //InfoModel.IssueDate = "04-18-2023";
            //InfoModel.LCIssueBank = "PPP";
            //InfoModel.ToLCIssueBank = "PPP";
            //InfoModel.ToTradePartnerLoadFrom = "CONSIGNEE"; //NOTIFY
            //InfoModel.Consignee = "GALLAGHER-CANNON";
            //InfoModel.NotifyParty = "RAMIREZ-LEWIS";
            //InfoModel.ToTradePartnerName = "GALLAGHER-CANNON";
            //InfoModel.DraftNo = "";
            //InfoModel.BankPreference = "";
            //InfoModel.ShipperName2 = "LONG BEACH CONTAINER PIER F";
            //InfoModel.Gentlemen = "";
            //InfoModel.GentlemenNameAddress = "";
            //InfoModel.EncloseDate = DateTime.Now.ToString("yyyy-MM-dd");
            //InfoModel.EncloseDraftNo = "";
            //InfoModel.EncloseForCollection = "";
            //InfoModel.EncloseForOther = "";
            //InfoModel.EncloseForPayment = "";
            //InfoModel.ExtraBl = "";
            //InfoModel.ExtraBlCopy = "";
            //InfoModel.ExtraCommInv = "";
            //InfoModel.ExtraInsCtf = "";
            //InfoModel.ExtraCtfOrig = "";
            //InfoModel.ExtraConsInv = "";
            //InfoModel.ExtraPkngList = "";
            //InfoModel.ExtraWgtCtf = "";
            //InfoModel.DeliverInOneMailing = "";
            //InfoModel.DeliverInTwoMailing = "";
            //InfoModel.DeliverIfDraft = "";
            //InfoModel.AllChargesForAccount = "";
            //InfoModel.DoNotWaiveCharges = "";
            //InfoModel.ProtestForNonPayment = "";
            //InfoModel.DoNotProtest = "";
            //InfoModel.PresentOnArrival = "";
            //InfoModel.AdviseNonPaymentBy = "";
            //InfoModel.AdvisePaymentBy = "";
            //InfoModel.ReferToName = "HARD CORE TECHNOLOGY(GST/VAT)";
            //InfoModel.ReferToAddress = "";
            //InfoModel.ToActFullyOnOurBehalf = "";
            //InfoModel.ToAssistNotToAlter = "";
            //InfoModel.OtherInstructions = "";
            //InfoModel.ReferQuestionTo = "";
            //InfoModel.ReferQuestionName = "HARD CORE TECHNOLOGY(GST/VAT)";
            //InfoModel.ReferQuestionPhone = "TEL: " + "08417606080";
            //InfoModel.ReferQuestionShipperName = "LONG BEACH CONTAINER PIER F";
            //InfoModel.ReferQuestionShipperPhone = "TEL: " + "(358)459-8430";
            //InfoModel.ReferQuestionFreightForwarderName = "HARD CORE TECHNOLOGY(GST/VAT)";
            //InfoModel.ReferQuestionFreightForwarderPhone = "TEL: " + "08417606080";
            //InfoModel.ShipperName3 = "LONG BEACH CONTAINER PIER F";
            //InfoModel.AuthorizedSignatureInput = "";
            //InfoModel.UserCompany = "HANJUN LIN" + " / " + "HARD CORE TECHNOLOGY(GST/VAT)";
            #endregion

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(InfoViewModel InfoModel)
        {
            string Input = JsonConvert.SerializeObject(InfoModel);
            var OutModel = new BankDraftIndexViewModel();
            OutModel = JsonConvert.DeserializeObject<BankDraftIndexViewModel>(Input);

            return await _generatePdf.GetPdf("Views/BankDraft/BankDraft.cshtml", OutModel);
        }

    }
}
