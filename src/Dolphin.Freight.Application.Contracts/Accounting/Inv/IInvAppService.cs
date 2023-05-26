using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Dolphin.Freight.Accounting.Invoices;

namespace Dolphin.Freight.Accounting.Inv
{
    public interface IInvAppService : IApplicationService
    {
        Task<List<InvoiceDto>> GetList(Guid? filter);
        Task UpdateList(Guid paymentId, List<CreateUpdateInvDto> list);
        Task<string> GetExchangeRate(string exchangeDate, string ccy1, string ccy2);
    }
}
