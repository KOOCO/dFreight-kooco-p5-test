using Dolphin.Freight.ImportExport.AirExports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Dolphin.Freight.ImportExport.AirImports
{
    public class AirImportMawbAppService :
        CrudAppService<
            AirImportMawb,
            AirImportMawbDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateAirImportMawbDto>,
        IAirImportMawbAppService
    {
        private IRepository<AirImportMawb, Guid> _repository;
        private IRepository<Airport, Guid> _airportRepository;
        private readonly IRepository<Dolphin.Freight.TradePartners.TradePartner, Guid> _tradePartnerRepository;

        public AirImportMawbAppService(
            IRepository<AirImportMawb, Guid> repository,
            IRepository<Airport, Guid> airportRepository,
            IRepository<Dolphin.Freight.TradePartners.TradePartner, Guid> tradePartnerRepository
            ) : base(repository)
        {
            _repository = repository;
            _airportRepository = airportRepository;
            _tradePartnerRepository = tradePartnerRepository;
        }

        public override async Task<PagedResultDto<AirImportMawbDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            // airport
            Dictionary<Guid, string> airportDictionary = new Dictionary<Guid, string>();
            var airportList = await _airportRepository.GetListAsync();
            if (null != airportList) 
            {
                foreach (var airport in airportList)
                {
                    airportDictionary.Add(airport.Id, airport.AirportName);
                }
            }

            // tradepartner
            Dictionary<Guid, string> tradePartnerDictionary = new Dictionary<Guid, string>();
            var tradePartnerList = await _tradePartnerRepository.GetListAsync();
            if (null != tradePartnerList && tradePartnerList.Count > 0) 
            {
                foreach (var tradePartner in tradePartnerList)
                {
                    tradePartnerDictionary.Add(tradePartner.Id, tradePartner.TPName);
                }
            }

            var queryable = await Repository.GetQueryableAsync();
            var query = queryable
                .OrderBy(x=>x.CreationTime)
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);
            var airImportMawbList = await AsyncExecuter.ToListAsync(query);
            List<AirImportMawbDto> airImportMawbDtoList = new List<AirImportMawbDto>();
            if (null != airImportMawbList && airImportMawbList.Count > 0)
            {
                foreach (var airImportMawb in airImportMawbList)
                {
                    var airImportMawbDto = ObjectMapper.Map<AirImportMawb, AirImportMawbDto>(airImportMawb);
                    if (airImportMawb.DepatureId != null)
                    {
                        airImportMawbDto.DepatureAirportName = airportDictionary[airImportMawb.DepatureId.Value];
                    }
                    else
                    {
                        airImportMawbDto.DepatureAirportName = null;
                    }
                    if (airImportMawb.DestinationId != null)
                    {
                        airImportMawbDto.DestinationAirportName = airportDictionary[airImportMawb.DestinationId.Value];
                    }
                    else
                    {
                        airImportMawbDto.DestinationAirportName = null;
                    }
                    if (airImportMawb.OverseaAgentId != null)
                    {
                        airImportMawbDto.OverseaAgentTPName = tradePartnerDictionary[airImportMawb.OverseaAgentId.Value];
                    }
                    else
                    {
                        airImportMawbDto.OverseaAgentTPName = null;
                    }
                    if (airImportMawb.CarrierId != null)
                    {
                        airImportMawbDto.CarrierTPName = tradePartnerDictionary[airImportMawb.CarrierId.Value];
                    }
                    else
                    {
                        airImportMawbDto.CarrierTPName = null;
                    }

                    airImportMawbDtoList.Add(airImportMawbDto);
                }
            }

            //Get the total count with another query
            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<AirImportMawbDto>(
                totalCount,
                airImportMawbDtoList
            );
        }

    }
}
