using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using Microsoft.Extensions.Localization;
using Dolphin.Freight.Localization;
using Volo.Abp.Users;
using Dolphin.Freight.iFreightDB.FreightCenters;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;

namespace Dolphin.Freight.Web.Pages.FreightCenter.ShippingCostList
{
    public class IndexModel : FreightPageModel
    {

        public Models.NotificationMessage NotificationMessage { get; set; }

        public IndexModel() { }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            await Task.Delay(1);
            return Page();
        }

    }

}
