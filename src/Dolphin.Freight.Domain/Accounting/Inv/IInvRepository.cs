using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Repositories;

namespace Dolphin.Freight.Accounting.Inv
{
    public interface IInvRepository : IRepository<Inv, Guid>
    {
        public void DeleteRange(List<Guid> invoiceList);

        public void InsertInstance(Inv invoice);

        public void UpdateInstance(Guid updateInstanceId, Inv invoice);
    }
}
