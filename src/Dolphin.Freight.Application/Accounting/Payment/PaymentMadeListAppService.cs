using Dolphin.Freight.Accounting.Inv;
using Dolphin.Freight.AccountingSettings.CurrencyTables;
using Dolphin.Freight.ImportExport.OceanExports;
using Dolphin.Freight.Permissions;
using Dolphin.Freight.Settings.Currencies;
using Dolphin.Freight.Settings.SysCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace Dolphin.Freight.Accounting.Payment
{
    public class PaymentMadeListAppService :
        CrudAppService<
            PaymentMadeList,
            PaymentMadeListDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdatePaymentMadeListDto>,
        IPaymentMadeListAppService
    {
        private IRepository<PaymentMadeList, Guid> _repository;
        private IRepository<SysCode, Guid> _sysCodeRepository;
        public PaymentMadeListAppService(IRepository<PaymentMadeList, Guid> repository, IRepository<SysCode, Guid> sysCodeRepository)
            : base(repository)
        {
            _repository = repository;
            _sysCodeRepository = sysCodeRepository;

            GetPolicyName = AccountingPermissions.PaymentMadeList.Default;
            GetListPolicyName = AccountingPermissions.PaymentMadeList.Default;
            CreatePolicyName = AccountingPermissions.PaymentMadeList.Create;
            UpdatePolicyName = AccountingPermissions.PaymentMadeList.Edit;
            DeletePolicyName = AccountingPermissions.PaymentMadeList.Delete;
        }
    }
}