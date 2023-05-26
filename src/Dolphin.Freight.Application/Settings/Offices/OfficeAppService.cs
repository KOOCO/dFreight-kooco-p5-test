using Dolphin.Freight.Settinngs.Offices;
using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Dolphin.Freight.Settings.Offices
{
    public class OfficeAppService : ApplicationService, IOfficeAppService
    {
        private IRepository<Office, Guid> _repository;

        public OfficeAppService(IRepository<Office, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<List<OfficeDto>> GetListAsync()
        {
            List<OfficeDto> result = new();
            foreach (var row in await _repository.GetListAsync())
            {
                result.Add(new OfficeDto { 
                    Id = row.Id, 
                    OfficeName = row.OfficeName,
                    OfficeCode = row.OfficeCode,
                });
            }

            return result;
        }
    }
}
