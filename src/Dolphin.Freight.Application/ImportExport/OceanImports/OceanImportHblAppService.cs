﻿using AutoMapper.Internal.Mappers;
using Dolphin.Freight.ImportExport.OceanExports;
using Dolphin.Freight.Permissions;
using Dolphin.Freight.Settings.Ports;
using Dolphin.Freight.Settings.Substations;
using Dolphin.Freight.Settings.SysCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Dolphin.Freight.ImportExport.OceanImports
{
    public class OceanImportHblAppService :
        CrudAppService<
            OceanImportHbl,
            OceanImportHblDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateOceanImportHblDto>,
        IOceanImportHblAppService
    {
        private readonly IRepository<OceanImportHbl, Guid> _repository;
        private readonly IRepository<OceanImportMbl, Guid> _mblRepository;
        private readonly IRepository<SysCode, Guid> _sysCodeRepository;
        private readonly IRepository<Substation, Guid> _substationRepository;
        private readonly IRepository<Port, Guid> _portRepository;
        private readonly IRepository<Dolphin.Freight.TradePartners.TradePartner, Guid> _tradePartnerRepository;
        public OceanImportHblAppService(IRepository<OceanImportHbl, Guid> repository, IRepository<SysCode, Guid> sysCodeRepository, IRepository<OceanImportMbl, Guid> mblRepository, IRepository<Substation, Guid> substationRepository, IRepository<Port, Guid> portRepository, IRepository<Dolphin.Freight.TradePartners.TradePartner, Guid> tradePartnerRepository)
            : base(repository)
        {
            _repository = repository;
            _sysCodeRepository = sysCodeRepository;
            _mblRepository = mblRepository;
            _substationRepository = substationRepository;
            _portRepository = portRepository;
            _tradePartnerRepository = tradePartnerRepository;
            /*
            GetPolicyName = OceanImportPermissions.OceanImportHbls.Default;
            GetListPolicyName = OceanImportPermissions.OceanImportHbls.Default;
            CreatePolicyName = OceanImportPermissions.OceanImportHbls.Create;
            UpdatePolicyName = OceanImportPermissions.OceanImportHbls.Edit;
            DeletePolicyName = OceanImportPermissions.OceanImportHbls.Delete;*/
        }
        public async Task<PagedResultDto<OceanImportHblDto>> QueryListAsync(QueryHblDto query)
        {
            var SysCodes = await _sysCodeRepository.GetListAsync();
            Dictionary<Guid, string> dictionary = new();
            if (SysCodes != null)
            {
                foreach (var syscode in SysCodes)
                {
                    dictionary.Add(syscode.Id, syscode.CodeValue);
                }
            }
            var Substations = await _substationRepository.GetListAsync();
            Dictionary<Guid, string> sdictionary = new();
            if (Substations != null)
            {
                foreach (var sub in Substations)
                {
                    sdictionary.Add(sub.Id, sub.SubstationName);
                }
            }
            //貿易夥伴
            var tradePartners = await _tradePartnerRepository.GetListAsync();
            Dictionary<Guid, string> tdictionary = new();
            if (tradePartners != null && tradePartners.Count > 0)
            {
                foreach (var tradePartner in tradePartners)
                {
                    tdictionary.Add(tradePartner.Id, tradePartner.TPName);
                }
            }
            //Mbls
            var mbls = await _mblRepository.GetListAsync();
            Dictionary<Guid, OceanImportMbl> mdictionary = new();
            if (mbls != null)
            {
                foreach (var mbl in mbls)
                {
                    mdictionary.Add(mbl.Id, mbl);
                }
            }
            //港口
            var ports = await _portRepository.GetListAsync();
            Dictionary<Guid, string> pdictionary = new();
            if (ports != null && ports.Count > 0)
            {
                foreach (var port in ports)
                {
                    pdictionary.Add(port.Id, port.SubDiv + " " + port.PortName + " ( " + port.Locode + " ) ");
                }
            }
            var OceanImportHbls = await _repository.GetListAsync();
            List<OceanImportHbl> rs;
            List<OceanImportHblDto> list = new List<OceanImportHblDto>();
            if (query != null && query.MblId != null)
            {
                rs = OceanImportHbls.Where(x => x.MblId.Equals(query.MblId.Value)).ToList();
            }
            else
            {
                rs = OceanImportHbls;
            }
            if (rs != null && rs.Count > 0)
            {

                foreach (var pu in rs)
                {
                    var dto = ObjectMapper.Map<OceanImportHbl, OceanImportHblDto>(pu);
                    dto.FilingNo = mdictionary[dto.MblId].FilingNo;
                    dto.MblNo = mdictionary[dto.MblId].SoNo;
                    dto.OfficeName = sdictionary[mdictionary[dto.MblId].OfficeId.Value];
                    //SysCode
                    if (mdictionary[dto.MblId].OblTypeId != null) dto.OblTypeName = dictionary[mdictionary[dto.MblId].OblTypeId.Value];

                    //人
                    if (dto.AgentId != null) dto.AgentName = tdictionary[dto.AgentId.Value];
                    if (dto.HblShipperId != null) dto.HblShipperName = tdictionary[dto.HblShipperId.Value];
                    if (dto.HblConsigneeId != null) dto.HblConsigneeName = tdictionary[dto.HblConsigneeId.Value];
                    if (mdictionary[dto.MblId].MblCarrierId != null) dto.MblCarrierName = tdictionary[mdictionary[dto.MblId].MblCarrierId.Value];
                    //if (mdictionary[dto.MblId].shipModeId != null) dto.shipModeName = tdictionary[mdictionary[dto.MblId].shipModeId.Value];


                    //港口
                    if (dto.PodId != null) dto.PodName = pdictionary[dto.PodId.Value];
                    if (dto.PolId != null) dto.PolName = pdictionary[dto.PolId.Value];
                    if (dto.PorId != null) dto.PorName = pdictionary[dto.PorId.Value];
                    if (dto.DelId != null) dto.DelName = pdictionary[dto.DelId.Value];
                    if (dto.FdestId != null) dto.FdestName = pdictionary[dto.FdestId.Value];
                    list.Add(dto);
                }
            }
            PagedResultDto<OceanImportHblDto> listDto = new PagedResultDto<OceanImportHblDto>();
            listDto.Items = list;
            listDto.TotalCount = list.Count;
            return listDto;
        }
        public async Task<IList<OceanImportHblDto>> QueryListByMidAsync(QueryHblDto query)
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
            var OceanImportHbls = await _repository.GetListAsync();
            List<OceanImportHbl> rs;
            List<OceanImportHblDto> list = new List<OceanImportHblDto>();
            if (query != null && query.MblId != null)
            {
                rs = OceanImportHbls.Where(x => x.MblId.Equals(query.MblId.Value)).ToList();
            }
            else
            {
                rs = OceanImportHbls;
            }
            if (rs != null && rs.Count > 0)
            {

                foreach (var pu in rs)
                {
                    var pud = ObjectMapper.Map<OceanImportHbl, OceanImportHblDto>(pu);
                    if (pud.CardColorId != null) pud.CardColorValue = dictionary[pud.CardColorId.Value];
                    if (pud.ColorRemarkId != null) pud.ColorRemarkValue = dictionary[pud.ColorRemarkId.Value];
                    list.Add(pud);
                }
            }
            return list;
        }
        public async Task<CreateUpdateOceanImportHblDto> GetHblById(QueryHblDto query)
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
            var oceanImportHbl = await _repository.GetAsync(query.Id.Value);
            var rs = ObjectMapper.Map<OceanImportHbl, CreateUpdateOceanImportHblDto>(oceanImportHbl);
            if (rs.CardColorId != null) rs.CardColorValue = dictionary[rs.CardColorId.Value];
            return rs;
        }
        public async void LockedOrUnLockedOceanImportHblAsync(QueryHblDto query)
        {
            var Hbl = await _repository.GetAsync(query.HblId.Value);
            Hbl.IsLocked = !Hbl.IsLocked;
            await _repository.UpdateAsync(Hbl);
        }
        public async Task<List<OceanImportHblDto>> GetHblCardsById(Guid Id)
        {
            var data = await _repository.GetListAsync(f => f.MblId == Id);
            var retVal = ObjectMapper.Map<List<OceanImportHbl>, List<OceanImportHblDto>>(data);

            return retVal;
        }
        public async Task<OceanImportHblDto> GetHawbCardById(Guid Id)
        {
            if (await _repository.AnyAsync(f => f.Id == Id))
            {
                var data = await _repository.GetAsync(f => f.Id == Id);
                var retVal = ObjectMapper.Map<OceanImportHbl, OceanImportHblDto>(data);
                return retVal;
            }

            return new OceanImportHblDto();
        }
    }
}