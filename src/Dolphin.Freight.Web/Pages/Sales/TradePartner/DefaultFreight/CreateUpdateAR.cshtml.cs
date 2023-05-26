using Castle.Core.Logging;
using Dolphin.Freight.Accounting;
using Dolphin.Freight.AccountingSettings.BillingCodes;
using Dolphin.Freight.TradePartners;
using Dolphin.Freight.TradePartners.DefaultFreight;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using static Volo.Abp.Http.MimeTypes;

namespace Dolphin.Freight.Web.Pages.Sales.TradePartner.DefaultFreight
{
    public class CreateUpdateARModel : AbpPageModel
    {
        [BindProperty(SupportsGet = true)]
        public Guid? Id { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public Guid TradePartnerId { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public DefaultFreightCategory Category { get; set; }

        public Guid FreightCode { get; set; }

        public string FreightDescription { get; set; }

        public PCType PCType { get; set; }

        public DefaultFreightARType Type { get; set; }

        public UnitType Unit { get; set; }

        public double Vol { get; set; }

        public double Rate { get; set; }

        public double AgentAmount { get; set; }

        public bool? ShipModeFCL { get; set; } = true;

        public bool? ShipModeLCL { get; set; } = true;

        public bool? ShipModeFAK { get; set; } = true;

        public bool? ShipModeBULK { get; set; } = true;

        public List<BillingCodeDto> FreightCodeList { get; set; }

        [BindProperty]
        public CreateUpdateDefaultFreightARDto ARDto { get; set; }

        private readonly ITradePartnerDefaultFreightAppService _tradePartnerDefaultFreightAppService; 
        private readonly IBillingCodeAppService _billingCodeAppService;
        public ILogger<CreateUpdateARModel> Logger { get; set; }

        public CreateUpdateARModel(ITradePartnerDefaultFreightAppService tradePartnerDefaultFreightAppService, IBillingCodeAppService billingCodeAppService)
        {
            _tradePartnerDefaultFreightAppService = tradePartnerDefaultFreightAppService;
            _billingCodeAppService = billingCodeAppService;
            Logger = NullLogger<CreateUpdateARModel>.Instance;
        }

        public async Task OnGetAsync()
        {
            switch (Category) {
                case DefaultFreightCategory.OI:
                    FreightCodeList = await _billingCodeAppService.GetOIHListAsync();
                    break;
                    
                case DefaultFreightCategory.OE:
                    FreightCodeList = await _billingCodeAppService.GetOEHListAsync();
                    break;
                    
                case DefaultFreightCategory.AI:
                    FreightCodeList = await _billingCodeAppService.GetAIHListAsync();
                    break;
                    
                case DefaultFreightCategory.AE:
                    FreightCodeList = await _billingCodeAppService.GetAEHListAsync();
                    break;
                    
                case DefaultFreightCategory.TKM:
                    FreightCodeList = await _billingCodeAppService.GetTKMListAsync();
                    break;
                    
                case DefaultFreightCategory.MSM:
                    FreightCodeList = await _billingCodeAppService.GetMSMListAsync();
                    break;
                    
                case DefaultFreightCategory.WHS:
                    FreightCodeList = await _billingCodeAppService.GetWHSListAsync();
                    break;

            }

            if (Id != null)
            {
                DefaultFreightARDto dto = await _tradePartnerDefaultFreightAppService.GetARAsync(Id.Value);
                TradePartnerId = dto.TradePartnerId;
                Category = dto.Category;
                FreightCode = dto.FreightCode;
                FreightDescription = dto.FreightDescription;
                PCType = dto.PCType;
                Type = dto.Type;
                Unit = dto.Unit;
                Vol = dto.Vol;
                Rate = dto.Rate;
                AgentAmount = dto.AgentAmount;
                ShipModeFCL = dto.ShipModeFCL;
                ShipModeLCL = dto.ShipModeLCL;
                ShipModeFAK = dto.ShipModeFAK;
                ShipModeBULK = dto.ShipModeBULK;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ARDto.PCType = PCType.Collect;
            await _tradePartnerDefaultFreightAppService.SaveARAsync(ARDto);
            return NoContent();
        }
    }
}
