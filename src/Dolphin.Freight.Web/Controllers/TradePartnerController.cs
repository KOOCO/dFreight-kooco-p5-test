using Dolphin.Freight.TradePartners;
using Dolphin.Freight.Web.Pages.Sales.TradePartner;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Dolphin.Freight.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradePartnerController : AbpController
    {
        private readonly ITradePartnerAppService _tradePartnerAppService;
        public new ILogger<TradePartnerController> Logger { get; set; }

        private readonly List<UserInfo> _data = new List<UserInfo>
    {
        new UserInfo{ Id = 1, Name = "Poy Chang"},
        new UserInfo{ Id = 2, Name = "foo2"},
        new UserInfo{ Id = 3, Name = "bar2"}
    };

        public TradePartnerController(ITradePartnerAppService tradePartnerAppService)
        {
            _tradePartnerAppService = tradePartnerAppService;
            Logger = NullLogger<TradePartnerController>.Instance;
        }

        [HttpGet]
        [Route("search")]
        public IActionResult Search(string term)
        {
            return new JsonResult(_data.Where(p => p.Name == term));
        }

        [HttpGet]
        public IActionResult GetData()
        {
            return new JsonResult(_data);
        }

        [HttpPost]
        public IActionResult PostData()
        {
            return new JsonResult(_data);
        }

    }
}
