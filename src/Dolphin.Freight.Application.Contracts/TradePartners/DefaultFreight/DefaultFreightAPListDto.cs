using System;
using Volo.Abp;
using Dolphin.Freight.Accounting;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.TradePartners.DefaultFreight
{
    public class DefaultFreightAPListDto : AuditedEntityDto<Guid>
    {
        public string FreightCode { get; set; }

        public string FreightDescription { get; set; }

        public PCType PCType { get; set; }

        public DefaultFreightAPType Type { get; set; }

        public UnitType Unit { get; set; }

        public double Vol { get; set; }

        public double Rate { get; set; }

        public double AgentAmount { get; set; }

        public bool? ShipModeFCL { get; set; }

        public bool? ShipModeLCL { get; set; }

        public bool? ShipModeFAK { get; set; }

        public bool? ShipModeBULK { get; set; }
    }
}
