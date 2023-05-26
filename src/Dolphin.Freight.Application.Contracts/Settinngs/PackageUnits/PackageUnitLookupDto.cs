using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.Settinngs.PackageUnits
{
    public class PackageUnitLookupDto : EntityDto<Guid>
    {
        public string PackageName { get; set; }
    }
}
