using Dolphin.Freight.Accounting;
using System;

namespace Dolphin.Freight.Common.Memos
{
    public class QueryListDto
    {
        public Guid SourceId { get; set; }
        public FreightPageType FType { get; set; }
    }
}
