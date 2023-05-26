using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Dolphin.Freight.Web.Pages.FreightCenter.ShippingCostManagement
{
    public class IndexModel : FreightPageModel
    {
        public void OnGet()
        {
            SortingMethod = "Total";
        }

        /// <summary>
        /// 業務員員工編號
        /// </summary>
        // [Display(Name = "SalesOwnerOnly")]
        public string SalesID { get; set; }

        public string From_Loading_Port { get; set; } // 收貨港/裝貨場(機場)
        public string To_Discharging_Port { get; set; } // 卸貨港 (機場)

        public List<SelectListItem> SortingMethods { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Total", Text = "總費用最低(Total)"},
            new SelectListItem { Value = "OF_AF", Text = "運費最低 (OF / AF)"},
            new SelectListItem { Value = "Local_Foreign", Text = "其他費用最低 (Local + Foreign charges)"}
        };

        [SelectItems(nameof(SortingMethods))]
        public string SortingMethod { get; set; } // 預設排序方式
        public string SeaAirCompany { get; set; } // 船公司 / 航空公司
        public string TradeTerms { get; set; } // 貿易條件
        public string[] CompareCurrencies { get; set; } // 比較幣別
        public int Load1 { get; set; } // 貨量20'
        public int Load2 { get; set; } // 貨量40'
        public int Load3 { get; set; } // 貨量40'HC
        public int Load4 { get; set; } // 貨量CBM
        public int Load5 { get; set; } // 貨量KG
        public int Load6 { get; set; } // 貨量Cartons

    }
}
