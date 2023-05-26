using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Dolphin.Freight.Accounting.Payment
{
    public interface ICustomerPaymentRepository : IRepository<CustomerPayment, Guid>
    {
        Task<CustomerPayment> FindByIdAsync(Guid id);
        Task<CustomerPayment> CheckByPaymentIdAsync(Guid PaymentId);
    }
}
