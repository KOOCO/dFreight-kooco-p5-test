using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Dolphin.Freight.ImportExport.AirExports
{
    public class AirportAppService :
        CrudAppService<
            Airport, // Airport entity
            AirportDto, // show
            Guid, //Primary key 
            PagedAndSortedResultRequestDto, //Used for paging & sorting
            CreateUpdateAirportDto>, // Create & Update
        IAirportAppService // implement airport service
    {
        private IRepository<Airport, Guid> _repository;
        public AirportAppService(IRepository<Airport, Guid> repository) : base(repository)
        {
            _repository = repository;
        }
        public async Task<ListResultDto<AirportDto>> GetAirportLookupAsync()
        {
            IQueryable<Airport> airportsQueryable = await _repository.GetQueryableAsync();
            var query = from airport in airportsQueryable
                        orderby airport.AirportIataCode
                        select airport;
            var airports = query.ToList();
            return new ListResultDto<AirportDto>(
                ObjectMapper.Map<List<Airport>, List<AirportDto>>(airports)
            );
        }
    }
}
