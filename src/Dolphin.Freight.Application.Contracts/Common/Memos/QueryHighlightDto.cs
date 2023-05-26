using Dolphin.Freight.Accounting;
using System;

namespace Dolphin.Freight.Common.Memos
{
    public class QueryHighlightDto
    {
        public Guid SourceId { get; set; }
        public FreightPageType FType { get; set; }
    }
}
