using System;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.Common.Memos
{
    public class CreateUpdateMemoDto : AuditedEntityDto<Guid>
    {
        public new Guid? Id { get; set; }
        public Guid SourceId { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public FreightPageType FType { get; set; }
    }
}
