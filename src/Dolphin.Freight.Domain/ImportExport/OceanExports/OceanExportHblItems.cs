using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;

namespace Dolphin.Freight.ImportExport.OceanExports
{
    public class OceanExportHblItems: AuditedAggregateRoot<Guid>, ISoftDelete
    {
        public string ProductDesc { get; set; }
        public string PackingType { get; set; }
        public string HTSCode { get; set; }
        public int NumberOfPeices { get; set; }
        public float NetWeight { get; set; }
        public float GrossWeight { get; set; }
        public float UnitPrice { get; set; }
        public float AmountOfMoney { get; set; }
        public string ProductDetails { get; set; }
        public string Container { get; set; }
        public bool IsDeleted { get; set; }
    }
}
