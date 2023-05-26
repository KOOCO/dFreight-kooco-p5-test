using Dolphin.Freight.Accounting.Invoices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Dolphin.Freight.Accounting.InvoiceBills
{
    public interface IInvoiceBillAppService :
        ICrudAppService<
        InvoiceBillDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateInvoiceBillDto>
    {
        Task<PagedResultDto<InvoiceBillDto>> QueryListAsync(QueryInvoiceBillDto query);
        Task<IList<InvoiceBillDto>> QueryInvoiceBillsAsync(QueryInvoiceBillDto query);
        void CopyByInvoiceIds(List<CopyIdDto> list);
    }
}
