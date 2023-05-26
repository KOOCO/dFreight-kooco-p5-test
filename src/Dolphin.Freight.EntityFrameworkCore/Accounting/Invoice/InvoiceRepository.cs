using Dolphin.Freight.Accounting.Inv;
using Dolphin.Freight.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Uow;

namespace Dolphin.Freight.Accounting.Invoices
{
    [UnitOfWork]
    public class InvoiceRepository : EfCoreRepository<FreightDbContext, Invoice, Guid>, IInvoiceRepository
    {
        IDbContextProvider<FreightDbContext> _dbContextProvider;
        public InvoiceRepository(IDbContextProvider<FreightDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public void DeleteRange(List<Guid> invoiceList)
        {
            var _dbContext = _dbContextProvider.GetDbContext();
            var invoices = _dbContext.Invoices.Where(x => invoiceList.Contains(x.Id));
            _dbContext.Invoices.RemoveRange(invoices);
        }

        public void InsertInstance(Invoice invoice)
        {
            var _dbContext = _dbContextProvider.GetDbContext();
            _dbContext.Invoices.Add(invoice);
            _dbContext.SaveChanges();
        }

        public void UpdateInstance(Guid updateInstanceId, Invoice updateInstance)
        {
            var _dbContext = _dbContextProvider.GetDbContext();
            var invoice = _dbContext.Invoices.FirstOrDefault(x => x.Id == updateInstanceId);
            if(invoice != null)
            {
                invoice.InvoiceNo = updateInstance.InvoiceNo;
                invoice.Currency = updateInstance.Currency;
                invoice.InvoiceDescription = updateInstance.InvoiceDescription;
                invoice.InvoiceDate = updateInstance.InvoiceDate;
                invoice.DueDate = updateInstance.DueDate;
                invoice.PostDate = updateInstance.PostDate;
                invoice.OfficeId = updateInstance.OfficeId;
                invoice.CustomerId = updateInstance.CustomerId;
                invoice.GlCodeId = updateInstance.GlCodeId;
                invoice.InvoiceAmount = updateInstance.InvoiceAmount;
                invoice.BalanceAmount = updateInstance.BalanceAmount;
                invoice.PaymentAmount = updateInstance.PaymentAmount;
                invoice.PaymentAmountTwd = updateInstance.PaymentAmountTwd;
                _dbContext.Invoices.Update(invoice);
                _dbContext.SaveChanges();
            }
        }
    }
}
