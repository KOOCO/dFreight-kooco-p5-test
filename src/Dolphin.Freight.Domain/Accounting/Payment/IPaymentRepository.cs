using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Dolphin.Freight.Accounting.Payment
{
    public interface IPaymentRepository : IRepository<Payment, Guid>
    {
        Task<Payment> FindByIdAsync(Guid id);
        Task<Payment> CheckByPaymentIdAsync(Guid PaymentId);
    }
}
