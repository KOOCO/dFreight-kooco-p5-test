using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.ImportExport.Containers
{
    public class QueryContainerDto : PagedAndSortedResultRequestDto
    {
        public Guid QueryId { get; set; }
        public int QueryType { get; set; }


    }
}