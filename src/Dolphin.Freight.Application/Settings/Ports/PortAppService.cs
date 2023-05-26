using AutoMapper.Internal.Mappers;
using Dolphin.Freight.Common;
using Dolphin.Freight.Permissions;
using Dolphin.Freight.Settings.Ports;
using Dolphin.Freight.Settings.SysCodes;
using Dolphin.Freight.Settinngs.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Dolphin.Freight.Settings.Ports
{
    public class PortAppService :
        CrudAppService<
            Port, //IT號碼管理entity
            PortDto, //顯示IT號碼管理用
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdatePortDto>, //新增修改IT號碼管理用
        IPortAppService //實作IPortAppService
    {
        private IRepository<Port, Guid> _repository;
        private IRepository<SysCode, Guid> _sysCodeRepository;
        public PortAppService(IRepository<Port, Guid> repository, IRepository<SysCode, Guid> sysCodeRepository)
            : base(repository)
        {
            _repository = repository;
            _sysCodeRepository = sysCodeRepository;
        }
        public async Task<PagedResultDto<PortDto>> QueryListAsync(QueryDto query)
        {
            var SysCodes = await _sysCodeRepository.GetListAsync();
            Dictionary<Guid, string> dictionary = new Dictionary<Guid, string>();
            if (SysCodes != null)
            {
                foreach (var syscode in SysCodes)
                {
                    dictionary.Add(syscode.Id, syscode.CodeValue);
                }
            }
            var Ports = await _repository.GetListAsync();
            List<Port> rs;
            List<PortDto> list = new List<PortDto>();
            rs = Ports;
            if (rs != null && rs.Count > 0)
            {

                foreach (var pu in rs)
                {
                    var pud = ObjectMapper.Map<Port, PortDto>(pu);
                    list.Add(pud);
                }
            }
            PagedResultDto<PortDto> listDto = new PagedResultDto<PortDto>();
            listDto.Items = list;
            listDto.TotalCount = list.Count;
            return listDto;
        }
        public async Task<List<PortDto>> QueryListAllAsync(QueryDto query) 
        {
            var Ports = await _repository.GetListAsync();
            var list = new List<PortDto>();
            return list;
        }

    }
}
