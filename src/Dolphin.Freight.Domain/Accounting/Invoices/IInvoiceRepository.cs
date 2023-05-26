using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Repositories;

namespace Dolphin.Freight.Accounting.Invoices
{
    public interface IInvoiceRepository : IRepository<Invoice, Guid>
    {
        public void DeleteRange(List<Guid> invoiceList);

        public void InsertInstance(Invoice invoice);

        public void UpdateInstance(Guid updateInstanceId, Invoice invoice);
    }
}
