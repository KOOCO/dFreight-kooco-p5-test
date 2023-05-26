using Dolphin.Freight.Permissions;
using Dolphin.Freight.Settings.SysCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Dolphin.Freight.Accounting.Payment
{
    public class PaymentAppService :
        CrudAppService<
            Payment,
            PaymentDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdatePaymentDto>,
        IPaymentAppService
    {
        private readonly IPaymentRepository _PaymentRepository;
        private IRepository<SysCode, Guid> _syscodeRepository;

        public PaymentAppService(IRepository<Payment, Guid> repository, IPaymentRepository PaymentRepository, IRepository<SysCode, Guid> syscodeRepository)
        : base(repository)
        {
            _PaymentRepository = PaymentRepository;
            _syscodeRepository = syscodeRepository;
            GetPolicyName = AccountingPermissions.Payment.Default;
            GetListPolicyName = AccountingPermissions.Payment.Default;
            CreatePolicyName = AccountingPermissions.Payment.Create;
            UpdatePolicyName = AccountingPermissions.Payment.Edit;
            DeletePolicyName = AccountingPermissions.Payment.Delete;
        }

        public async Task<PaymentDto> GetDataAsync(Guid id)
        {
            var cp = await _PaymentRepository.FindByIdAsync(id);
            return ObjectMapper.Map<Payment, PaymentDto>(cp);
        }

        public async Task<PagedResultDto<PaymentDto>> GetDataList()
        {
            IQueryable<Payment> queryable = await _PaymentRepository.GetQueryableAsync();

            IQueryable<SysCode> sysCodes = await _syscodeRepository.GetQueryableAsync();

            var list = (from cp in queryable
                        join sc in sysCodes on cp.Category equals sc.CodeValue
                        where sc.CodeType.Equals("Category")
                        select new PaymentDto
                        {
                            Id = cp.Id,
                            ReleaseDate = cp.ReleaseDate,
                            PaidTo = cp.PaidTo,
                            PaidToName = cp.PaidToName != null ? cp.PaidToName.TPName : "",
                            Category = sc.ShowName,
                            CheckNo = cp.CheckNo,
                            Bank = cp.Bank,
                            BankCurrency = cp.BankCurrency,
                            Clear = cp.Clear,
                            Invalid = cp.Invalid,
                            OfficeId = cp.OfficeId,
                            OfficeName = cp.Office != null ? cp.Office.SubstationName : "",
                            CreatorId = cp.CreatorId,
                            Memo = cp.Memo,
                            //Creator = cp.CreatorId
                        }).ToList();

            PagedResultDto<PaymentDto> listDto = new PagedResultDto<PaymentDto>();
            listDto.Items = list;
            listDto.TotalCount = list.Count;

            return listDto;
        }

        public async Task<PaymentDto> CheckByPaymentIdAsync(Guid PaymentId)
        {
            var cp = await _PaymentRepository.CheckByPaymentIdAsync(PaymentId);
            return ObjectMapper.Map<Payment, PaymentDto>(cp);
        }
    }
}