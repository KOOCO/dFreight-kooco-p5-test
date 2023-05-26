using Dolphin.Freight.Accounting.Inv;
using Dolphin.Freight.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Uow;

namespace Dolphin.Freight.Accounting.Payment
{
    //[UnitOfWork]
    public class PaymentRepository : EfCoreRepository<FreightDbContext, Payment, Guid>, IPaymentRepository
    {
        IDbContextProvider<FreightDbContext> _dbContextProvider;
        public PaymentRepository(IDbContextProvider<FreightDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public async Task<Payment> FindByIdAsync(Guid id)
        {
            var dbSet = await GetDbSetAsync();

            return await dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Payment> CheckByPaymentIdAsync(Guid PaymentId)
        {
            var dbSet = await GetDbSetAsync();

            return await dbSet.FirstOrDefaultAsync(x => x.PaymentId == PaymentId);
        }
    }
}
