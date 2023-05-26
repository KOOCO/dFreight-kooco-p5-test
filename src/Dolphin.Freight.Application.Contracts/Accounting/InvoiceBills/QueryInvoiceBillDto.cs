using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.Accounting.InvoiceBills
{
    public class QueryInvoiceBillDto : PagedAndSortedResultRequestDto
    {
        /// <summary>
        /// 發票號碼
        /// </summary>
        public string InvoiceNo { get; set; }
        public Guid InvoiceId { get; set; }
        public Guid NewInvoiceId { get; set; }
    }
}
