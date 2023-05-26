using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.Common.Memos
{
    public class SwitchHighlightDto : AuditedEntityDto<Guid>
    {
        public bool Highlight { get; set; }
    }
}
