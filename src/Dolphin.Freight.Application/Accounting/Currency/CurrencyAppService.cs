using AutoMapper.Internal.Mappers;
using Dolphin.Freight.AccountingSettings.CurrencyTables;
using Dolphin.Freight.Common;
using Dolphin.Freight.ImportExport.OceanExports;
using Dolphin.Freight.Permissions;
using Dolphin.Freight.Settings.SysCodes;
using Dolphin.Freight.Settinngs.SysCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Dolphin.Freight.Accounting.Currency
{
    public class CurrencyAppService :
        CrudAppService<
            Currency,
            CurrencyDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateCurrencyDto>,
        ICurrencyAppService
    {
        private IRepository<Currency, Guid> _repository;
        private readonly IRepository<SysCode, Guid> _sysCodeRepository;
        public CurrencyAppService(IRepository<Currency, Guid> repository, IRepository<SysCode, Guid> sysCodeRepository)
            : base(repository)
        {
            _repository = repository;
            _sysCodeRepository = sysCodeRepository;
        }
        public async Task<string> QueryRateInternalAsync(QueryCurrencyDto query)
        {
            var rs = await _repository.GetListAsync();
            string rateInternal = "";

            rs.Where(x => x.Ccy1Id.Equals(query.Ccy1Id) && x.Ccy2Id.Equals(query.Ccy2Id)).OrderBy(x => x.StartDate);
            rs.Find(x => x.Ccy1Id.Equals(query.Ccy1Id) && x.Ccy2Id.Equals(query.Ccy2Id));

            if (rs != null && rs.Count > 0)
            {

                foreach (var pu in rs)
                {
                    var pud = ObjectMapper.Map<Currency, CurrencyDto>(pu).ToString();
                    rateInternal = pud;
                }
            }

            return rateInternal;
        }
    }
}