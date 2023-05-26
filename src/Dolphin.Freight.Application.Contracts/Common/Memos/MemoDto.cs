using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.Common.Memos
{
    public class MemoDto : AuditedEntityDto<Guid>
    {
        public Guid SourceId { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public bool Highlight { get; set; }
        public string CreatedUserName { get; set; }
        public string LastUpdatedUserName { get; set; }
    }
}
