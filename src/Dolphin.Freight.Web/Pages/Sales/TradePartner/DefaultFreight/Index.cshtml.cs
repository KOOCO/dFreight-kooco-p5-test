using Castle.Core.Logging;
using Dolphin.Freight.TradePartners.DefaultFreight;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Dolphin.Freight.Web.Pages.Sales.TradePartner.DefaultFreight
{
    public class IndexModel : AbpPageModel
    {
        public Guid Id { get; set; }

        private readonly ILogger<IndexModel> logger;

        public IndexModel()
        {
            logger = NullLogger<IndexModel>.Instance;
        }

        public IActionResult OnGet(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            Id = id;

            return Page();
        }
    }
}
