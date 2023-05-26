using Dolphin.Freight.AccountingSettings.BillingCodes;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Dolphin.Freight.TradePartners.DefaultFreight
{
    public class TradePartnerDefaultFreightAppService : ApplicationService, ITradePartnerDefaultFreightAppService
    {
        private readonly IRepository<DefaultFreightAP, Guid> _apRepository;
        private readonly IRepository<DefaultFreightAR, Guid> _arRepository;
        private readonly IRepository<DefaultFreightDC, Guid> _dcRepository;
        private readonly IRepository<BillingCode, Guid> _billingCodeRepository;
        
        public new ILogger<TradePartnerDefaultFreightAppService> Logger { get; set; } 

        public TradePartnerDefaultFreightAppService(
            IRepository<DefaultFreightAP, Guid> apRepository, 
            IRepository<DefaultFreightAR, Guid> arRepository, 
            IRepository<DefaultFreightDC, Guid> dcRepository, 
            IRepository<BillingCode, Guid> billingCodeRepository
        )
        {
            _apRepository = apRepository;
            _arRepository = arRepository;
            _dcRepository = dcRepository;
            _billingCodeRepository = billingCodeRepository;

            Logger = NullLogger<TradePartnerDefaultFreightAppService>.Instance;
        }

        public async Task DeleteAPAsync(Guid id)
        {
            await _apRepository.DeleteAsync(id);
        }

        public async Task DeleteARAsync(Guid id)
        {
            await _arRepository.DeleteAsync(id);
        }

        public async Task DeleteDCAsync(Guid id)
        {
            await _dcRepository.DeleteAsync(id);
        }

        public async Task<DefaultFreightAPDto> GetAPAsync(Guid id)
        {
            return ObjectMapper.Map<DefaultFreightAP, DefaultFreightAPDto>(await _apRepository.GetAsync(id));
        }

        public async Task<List<DefaultFreightAPListDto>> GetAPListByQueryAsync(QueryListDto dto)
        {
            IQueryable<BillingCode> codeQuery = await _billingCodeRepository.GetQueryableAsync();
            IQueryable<DefaultFreightAP> query = await _apRepository.GetQueryableAsync();

            var rows = from ap in query
                       where ap.TradePartnerId == dto.TradePartnerId && ap.Category == dto.Category
                       join code in codeQuery on ap.FreightCode equals code.Id
                       select new { AP = ap, CodeName = code.BillingName };

            return rows.ToList().Select(r => {
                DefaultFreightAPListDto defaultFreightAPListDto = ObjectMapper.Map<DefaultFreightAP, DefaultFreightAPListDto>(r.AP);
                defaultFreightAPListDto.FreightCode = r.CodeName;

                return defaultFreightAPListDto;
            }).ToList();
        }

        public async Task<DefaultFreightARDto> GetARAsync(Guid id)
        {
            return ObjectMapper.Map<DefaultFreightAR, DefaultFreightARDto>(await _arRepository.GetAsync(id));
        }

        public async Task<List<DefaultFreightARListDto>> GetARListByQueryAsync(QueryListDto dto)
        {
            IQueryable<BillingCode> codeQuery = await _billingCodeRepository.GetQueryableAsync();
            IQueryable<DefaultFreightAR> query = await _arRepository.GetQueryableAsync();

            var rows = from ar in query
                       where ar.TradePartnerId == dto.TradePartnerId && ar.Category == dto.Category
                       join code in codeQuery on ar.FreightCode equals code.Id
                       select new { AR = ar, CodeName = code.BillingName };

            return rows.ToList().Select(r => {
                DefaultFreightARListDto defaultFreightARListDto = ObjectMapper.Map<DefaultFreightAR, DefaultFreightARListDto>(r.AR);
                defaultFreightARListDto.FreightCode = r.CodeName;

                return defaultFreightARListDto;
            }).ToList();
        }

        public async Task<DefaultFreightDCDto> GetDCAsync(Guid id)
        {
            return ObjectMapper.Map<DefaultFreightDC, DefaultFreightDCDto>(await _dcRepository.GetAsync(id));
        }

        public async Task<List<DefaultFreightDCListDto>> GetDCListByQueryAsync(QueryListDto dto)
        {
            IQueryable<BillingCode> codeQuery = await _billingCodeRepository.GetQueryableAsync();
            IQueryable<DefaultFreightDC> query = await _dcRepository.GetQueryableAsync();

            var rows = from dc in query
                       where dc.TradePartnerId == dto.TradePartnerId && dc.Category == dto.Category
                       join code in codeQuery on dc.FreightCode equals code.Id
                       select new { DC = dc, CodeName = code.BillingName };

            return rows.ToList().Select(r => {
                DefaultFreightDCListDto defaultFreightDCListDto = ObjectMapper.Map<DefaultFreightDC, DefaultFreightDCListDto>(r.DC);
                defaultFreightDCListDto.FreightCode = r.CodeName;

                return defaultFreightDCListDto;
            }).ToList();
        }

        public async Task SaveAPAsync(CreateUpdateDefaultFreightAPDto dto)
        {
            if (dto.Id == null)
            {
                DefaultFreightAP entity = ObjectMapper.Map<CreateUpdateDefaultFreightAPDto, DefaultFreightAP>(dto);
                await _apRepository.InsertAsync(entity);
            }
            else
            {
                DefaultFreightAP entity = await _apRepository.GetAsync(dto.Id.Value);
                await _apRepository.UpdateAsync(ObjectMapper.Map(dto, entity));
            }
        }

        public async Task SaveARAsync(CreateUpdateDefaultFreightARDto dto)
        {
            if (dto.Id == null)
            {
                DefaultFreightAR entity = ObjectMapper.Map<CreateUpdateDefaultFreightARDto, DefaultFreightAR>(dto);
                await _arRepository.InsertAsync(entity);
            }
            else
            {
                DefaultFreightAR entity = await _arRepository.GetAsync(dto.Id.Value);
                await _arRepository.UpdateAsync(ObjectMapper.Map(dto, entity));
            }
        }

        public async Task SaveDCAsync(CreateUpdateDefaultFreightDCDto dto)
        {
            if (dto.Id == null)
            {
                DefaultFreightDC entity = ObjectMapper.Map<CreateUpdateDefaultFreightDCDto, DefaultFreightDC>(dto);
                await _dcRepository.InsertAsync(entity);
            }
            else
            {
                DefaultFreightDC entity = await _dcRepository.GetAsync(dto.Id.Value);
                await _dcRepository.UpdateAsync(ObjectMapper.Map(dto, entity));
            }
        }
    }
}
