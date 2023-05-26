using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.ImportExport.Attachments
{
    public class QueryAttachmentDto : PagedAndSortedResultRequestDto
    {
        public Guid QueryId { get; set; }
        public int QueryType { get; set; }


    }
}

