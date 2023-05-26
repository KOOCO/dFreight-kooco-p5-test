using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.Settinngs.Substations
{
    public class SubstationLookupDto : EntityDto<Guid>
    {
        public string SubstationName { get; set; }
        public string AbbreviationName { get; set; }
    }
}
