using Dolphin.Freight.Accounting.Inv;
using Dolphin.Freight.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Uow;

namespace Dolphin.Freight.Accounting.Inv
{
    [UnitOfWork]
    public class InvRepository : EfCoreRepository<FreightDbContext, Inv, Guid>, IInvRepository
    {
        IDbContextProvider<FreightDbContext> _dbContextProvider;
        public InvRepository(IDbContextProvider<FreightDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public void DeleteRange(List<Guid> invoiceList)
        {
            var _dbContext = _dbContextProvider.GetDbContext();
            var invoices = _dbContext.Inv.Where(x => invoiceList.Contains(x.Id));
            _dbContext.Inv.RemoveRange(invoices);
        }

        public void InsertInstance(Inv invoice)
        {
            var _dbContext = _dbContextProvider.GetDbContext();
            _dbContext.Inv.Add(invoice);
            _dbContext.SaveChanges();
        }

        public void UpdateInstance(Guid updateInstanceId, Inv updateInstance)
        {
            var _dbContext = _dbContextProvider.GetDbContext();
            var invoice = _dbContext.Inv.FirstOrDefault(x => x.Id == updateInstanceId);
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
                _dbContext.Inv.Update(invoice);
                _dbContext.SaveChanges();
            }
        }
    }
}
