using Dolphin.Freight.Accounting;
using System;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.TradePartners.DefaultFreight
{
    public class CreateUpdateDefaultFreightDCDto
    {
        public Guid? Id { get; set; }
        public Guid TradePartnerId { get; set; }

        public DefaultFreightCategory Category { get; set; }

        public Guid FreightCode { get; set; }

        public string FreightDescription { get; set; }

        public PCType PCType { get; set; }

        public DefaultFreightDCType Type { get; set; }

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
