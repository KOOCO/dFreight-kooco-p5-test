using Dolphin.Freight.Accounting;
using Dolphin.Freight.AccountingSettings.BillingCodes;
using Dolphin.Freight.TradePartners.DefaultFreight;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Dolphin.Freight.Web.Pages.Sales.TradePartner.DefaultFreight
{
    public class CreateUpdateDCModal : AbpPageModel
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

        public DefaultFreightDCType Type { get; set; }

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
        public CreateUpdateDefaultFreightDCDto DCDto { get; set; }

        private readonly ITradePartnerDefaultFreightAppService _tradePartnerDefaultFreightAppService;
        private readonly IBillingCodeAppService _billingCodeAppService;

        public CreateUpdateDCModal(ITradePartnerDefaultFreightAppService tradePartnerDefaultFreightAppService, IBillingCodeAppService billingCodeAppService)
        {
            _tradePartnerDefaultFreightAppService = tradePartnerDefaultFreightAppService;
            _billingCodeAppService = billingCodeAppService;
        }

        public async Task OnGetAsync()
        {
            switch (Category)
            {
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
                DefaultFreightDCDto dto = await _tradePartnerDefaultFreightAppService.GetDCAsync(Id.Value);
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
            await _tradePartnerDefaultFreightAppService.SaveDCAsync(DCDto);
            return NoContent();
        }
    }
}
