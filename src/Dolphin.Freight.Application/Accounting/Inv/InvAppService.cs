using Dolphin.Freight.Accounting.Invoices;
using Dolphin.Freight.AccountingSettings.CurrencyTables;
using Dolphin.Freight.Settings.Currencies;
using Dolphin.Freight.Settings.Substations;
using Dolphin.Freight.Settings.SysCodes;
using IdentityServer4.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace Dolphin.Freight.Accounting.Inv
{
    //[UnitOfWork]
    public class InvAppService : ApplicationService, IInvAppService
    { 
        private readonly IInvRepository _invRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        //private readonly IRepository<Invoice, Guid> _invoiceRepository;
        private readonly IRepository<CurrencyTable, Guid> _currencyTableRepository;
        private readonly IRepository<SysCode, Guid> _sysCodeRepository;
        private readonly IRepository<Substation, Guid> _substationRepository;

        public InvAppService(IInvRepository invRepository, IRepository<CurrencyTable, Guid> currencyTableRepository, IRepository<SysCode, Guid> sysCodeRepository, IInvoiceRepository invoiceRepository, IRepository<Substation, Guid> substationRepository)
        {
            _invRepository = invRepository;
            _currencyTableRepository = currencyTableRepository;
            _sysCodeRepository = sysCodeRepository;
            _invoiceRepository = invoiceRepository;
            _substationRepository = substationRepository;
        }

        public async Task<List<InvoiceDto>> GetList(Guid? filter)
        {
            IQueryable<Invoice> queryable = await _invoiceRepository.GetQueryableAsync();
            //var substations = await _substationRepository.GetListAsync();

            var query = from inv in queryable
                        //join sub in substations on inv.OfficeId equals sub.Id
                        //into joingroup
                        where inv.PaymentId == filter
                        select inv;
            var invoice = query.ToList();

            return ObjectMapper.Map<List<Invoice>, List<InvoiceDto>>(invoice);
        }

        [UnitOfWork]
        public async Task UpdateList(Guid paymentId, List<CreateUpdateInvDto> list)
        {
            #region Remove
            IQueryable<Invoice> queryable = await _invoiceRepository.GetQueryableAsync();

            var query = from inv in queryable
                        where inv.PaymentId == paymentId
                        select inv;

            var idList = list.Where(y => !string.IsNullOrEmpty(y.Id)).Select(y => Guid.Parse(y.Id)).ToList();
            var deleteRange = query.Where(x => !idList.Contains(x.Id)).Select(x => x.Id).ToList();
            if (deleteRange.Any())
            {
                _invoiceRepository.DeleteRange(deleteRange);
            }
            #endregion

            #region Update
            var updateRange = list.Where(x => !string.IsNullOrEmpty(x.Id)).ToList();
            foreach (var updateInstance in updateRange)
            {
                Guid updateInstanceId;
                if (Guid.TryParse(updateInstance.Id, out updateInstanceId))
                {
                    var invoice = new Invoice();
                    invoice.InvoiceNo = updateInstance.InvoiceNo;
                    invoice.Currency = updateInstance.Currency;
                    invoice.InvoiceDescription = updateInstance.InvoiceDescription;
                    invoice.InvoiceDate = !string.IsNullOrEmpty(updateInstance.InvoiceDate) ? DateTime.Parse(updateInstance.InvoiceDate) : default(DateTime);
                    invoice.DueDate = !string.IsNullOrEmpty(updateInstance.DueDate) ? DateTime.Parse(updateInstance.DueDate) : default(DateTime);
                    invoice.PostDate = !string.IsNullOrEmpty(updateInstance.PostDate) ? DateTime.Parse(updateInstance.PostDate) : default(DateTime);
                    invoice.OfficeId = !string.IsNullOrEmpty(updateInstance.OfficeId) ? Guid.Parse(updateInstance.OfficeId) : (Guid?)null;
                    invoice.CustomerId = !string.IsNullOrEmpty(updateInstance.CustomerId) ? Guid.Parse(updateInstance.CustomerId) : (Guid?)null;
                    invoice.GlCodeId = !string.IsNullOrEmpty(updateInstance.GlCodeId) ? Guid.Parse(updateInstance.GlCodeId) : (Guid?)null;
                    invoice.InvoiceAmount = !string.IsNullOrEmpty(updateInstance.InvoiceAmount) ? Decimal.Parse(updateInstance.InvoiceAmount) : (Decimal?)null;
                    invoice.BalanceAmount = !string.IsNullOrEmpty(updateInstance.BalanceAmount) ? Decimal.Parse(updateInstance.BalanceAmount) : (Decimal?)null;
                    invoice.PaymentAmount = !string.IsNullOrEmpty(updateInstance.PaymentAmount) ? Decimal.Parse(updateInstance.PaymentAmount) : (Decimal?)null;
                    invoice.PaymentAmountTwd = !string.IsNullOrEmpty(updateInstance.PaymentAmountTwd) ? Decimal.Parse(updateInstance.PaymentAmountTwd) : (Decimal?)null;
                    _invoiceRepository.UpdateInstance(updateInstanceId, invoice);
                }
            }
            #endregion

            #region Insert
            var insertRange = list.Where(x => string.IsNullOrEmpty(x.Id)).ToList();
            foreach (var insertInstance in insertRange)
            {
                var invoice = new Invoice();
                invoice.PaymentId = paymentId;
                invoice.InvoiceNo = insertInstance.InvoiceNo;
                invoice.Currency = insertInstance.Currency;
                invoice.InvoiceDescription = insertInstance.InvoiceDescription;
                invoice.InvoiceDate = !string.IsNullOrEmpty(insertInstance.InvoiceDate) ? DateTime.Parse(insertInstance.InvoiceDate) : default(DateTime);
                invoice.DueDate = !string.IsNullOrEmpty(insertInstance.DueDate) ? DateTime.Parse(insertInstance.DueDate) : default(DateTime);
                invoice.PostDate = !string.IsNullOrEmpty(insertInstance.PostDate) ? DateTime.Parse(insertInstance.PostDate) : default(DateTime);
                invoice.OfficeId = !string.IsNullOrEmpty(insertInstance.OfficeId) ? Guid.Parse(insertInstance.OfficeId) : (Guid?)null;
                invoice.CustomerId = !string.IsNullOrEmpty(insertInstance.CustomerId) ? Guid.Parse(insertInstance.CustomerId) : (Guid?)null;
                invoice.GlCodeId = !string.IsNullOrEmpty(insertInstance.GlCodeId) ? Guid.Parse(insertInstance.GlCodeId) : (Guid?)null;
                invoice.InvoiceAmount = !string.IsNullOrEmpty(insertInstance.InvoiceAmount) ? Decimal.Parse(insertInstance.InvoiceAmount) : (Decimal?)null;
                invoice.BalanceAmount = !string.IsNullOrEmpty(insertInstance.BalanceAmount) ? Decimal.Parse(insertInstance.BalanceAmount) : (Decimal?)null;
                invoice.PaymentAmount = !string.IsNullOrEmpty(insertInstance.PaymentAmount) ? Decimal.Parse(insertInstance.PaymentAmount) : (Decimal?)null;
                invoice.PaymentAmountTwd = !string.IsNullOrEmpty(insertInstance.PaymentAmountTwd) ? Decimal.Parse(insertInstance.PaymentAmountTwd) : (Decimal?)null;
                _invoiceRepository.InsertInstance(invoice);
            }
            #endregion

        }
        
        public async Task<string> GetExchangeRate(string exchangeDate, string ccy1, string ccy2)
        {
            IQueryable<SysCode> sysCodes = await _sysCodeRepository.GetQueryableAsync();
            
            var c1 = sysCodes.FirstOrDefault(x=> x.CodeType == "Currency" && x.CodeValue == ccy1);
            var c2 = sysCodes.FirstOrDefault(x=> x.CodeType == "Currency" && x.CodeValue == ccy2);
            DateTime date;

            if (DateTime.TryParse(exchangeDate, out date) &&
                c1 != null &&
                c2 != null)
            {
                IQueryable<CurrencyTable> currencyTable = await _currencyTableRepository.GetQueryableAsync();
                var query = currencyTable.Where(x => x.Ccy1Id == c1.Id && x.Ccy2Id == c2.Id && x.StartDate <= date).OrderBy(x => x.StartDate).FirstOrDefault();

                if (query != null)
                    return query.RateInternal.ToString();
            }

            return "";
        }
    }
}