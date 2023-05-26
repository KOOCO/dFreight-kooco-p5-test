using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Dolphin.Freight.Accounting.Payment
{
    public interface IPaymentMadeListAppService :
        ICrudAppService<
        PaymentMadeListDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdatePaymentMadeListDto>
    {
    }
}
