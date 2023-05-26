using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.Accounting.Invoices
{
    public class QueryInvoiceDto : PagedAndSortedResultRequestDto
    {
        /// <summary>
        /// ParentId的類別，0：Mbl，1：Hbl
        /// </summary>
        public int QueryType { get; set; }
        /// <summary>
        /// 查詢類別：
        /// 1 InvoiceType < 3 (0：AR，1：D/C，2：AP)
        /// 2 InvoiceType > 2 (3：G&A 收入，4：G&A 支出)
        /// </summary>
        public int QueryInvoiceType { get; set; }
        /// <summary>
        /// Mbl或Hbl的Id，或ExportBookingId
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// 新對應的ExportBookingId
        /// </summary>
        public Guid? NewParentId { get; set; }

    }
}
