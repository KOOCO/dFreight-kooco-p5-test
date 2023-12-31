﻿using Dolphin.Freight.Settings.Ports;
using Dolphin.Freight.Settings.Substations;
using Dolphin.Freight.Settings.SysCodes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Dolphin.Freight.ImportExport.OceanExports.ExportBookings
{
    public class ExportBookingAppService :
        CrudAppService<
            ExportBooking,
            ExportBookingDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateExportBookingDto>,
        IExportBookingAppService
    {
        private IRepository<ExportBooking, Guid> _repository;
        private IRepository<SysCode, Guid> _sysCodeRepository;
        private IRepository<Port, Guid> _portRepository;
        private IRepository<Substation, Guid> _substationRepository;
        private IRepository<Dolphin.Freight.TradePartners.TradePartner, Guid> _tradePartnerRepository;
        public ExportBookingAppService(IRepository<ExportBooking, Guid> repository, IRepository<SysCode, Guid> sysCodeRepository, IRepository<Port, Guid> portRepository, IRepository<Substation, Guid> substationRepository, IRepository<Dolphin.Freight.TradePartners.TradePartner, Guid> tradePartnerRepository)
            : base(repository)
        {
            _repository = repository;
            _sysCodeRepository = sysCodeRepository;
            _portRepository = portRepository;
            _substationRepository = substationRepository;
            _tradePartnerRepository = tradePartnerRepository;
            /*
            GetPolicyName = OceanExportPermissions.ExportBookingas.Default;
            GetListPolicyName = OceanExportPermissions.ExportBookingas.Default;
            CreatePolicyName = OceanExportPermissions.ExportBookingas.Create;
            UpdatePolicyName = OceanExportPermissions.ExportBookingas.Edit;
            DeletePolicyName = OceanExportPermissions.ExportBookingas.Delete;*/
        }
        public async Task<PagedResultDto<ExportBookingDto>> QueryListAsync(QueryExportBookingDto query)
        {
            var Ports = await _portRepository.GetListAsync();
            Dictionary<Guid, string> pdictionary = new();
            if (Ports != null)
            {
                foreach (var port in Ports)
                {
                    pdictionary.Add(port.Id, port.PortName);
                }
            }
            var Substations = await _substationRepository.GetListAsync();
            Dictionary<Guid, string> sdictionary = new();
            if (Substations != null)
            {
                foreach (var substation in Substations)
                {
                    sdictionary.Add(substation.Id, substation.SubstationName);
                }
            }
            var TradePartners = await _tradePartnerRepository.GetListAsync();
            Dictionary<Guid, string> tdictionary = new();
            if (TradePartners != null)
            {
                foreach (var tradePartner in TradePartners)
                {
                    tdictionary.Add(tradePartner.Id, tradePartner.TPName);
                }
            }
            var SysCodes = await _sysCodeRepository.GetListAsync();
            Dictionary<Guid, string> sysdictionary = new();
            if (SysCodes != null)
            {
                foreach (var sysCode in SysCodes)
                {
                    sysdictionary.Add(sysCode.Id, sysCode.ShowName);
                }
            }
            var ExportBookings = await _repository.GetListAsync();
            List<ExportBooking> rs = ExportBookings;
            List<ExportBookingDto> list = new List<ExportBookingDto>();

            if (rs != null && rs.Count > 0)
            {

                foreach (var pu in rs)
                {
                    var pud = ObjectMapper.Map<ExportBooking, ExportBookingDto>(pu);
                    if (pud.PolId != null) pud.PolName = pdictionary[pud.PolId.Value];
                    if (pud.PorId != null) pud.PorName = pdictionary[pud.PorId.Value];
                    if (pud.PodId != null) pud.PodName = pdictionary[pud.PodId.Value];
                    if (pud.DelId != null) pud.DelName = pdictionary[pud.DelId.Value];
                    if (pud.ShipperId != null) pud.ShipperName = tdictionary[pud.ShipperId.Value];
                    if (pud.CustomerId != null) pud.CustomerName = tdictionary[pud.CustomerId.Value];
                    if (pud.CarrierId != null) pud.CarrierName = tdictionary[pud.CarrierId.Value];
                    if (pud.ShippingAgentId != null) pud.ShippingAgentName = tdictionary[pud.ShippingAgentId.Value];
                    string SvcName = "";
                    if (pud.SvcTermFromId != null) SvcName = sysdictionary[pud.SvcTermFromId.Value];
                    if (pud.SvcTermToId != null) {
                        if (SvcName.Length > 0) SvcName = SvcName + " - ";
                        SvcName = SvcName + sysdictionary[pud.SvcTermToId.Value];
                    }
                    if (pud.OfficeId != null) pud.OfficeName = sdictionary[pud.OfficeId.Value];
                    //if (pud.MblOverseaAgentId != null) pud.MblOverseaAgentName = tdictionary[pud.MblOverseaAgentId.Value];
                    list.Add(pud);
                }
            }
            PagedResultDto<ExportBookingDto> listDto = new PagedResultDto<ExportBookingDto>();
            listDto.Items = list;
            listDto.TotalCount = list.Count;
            return listDto;
        }
    }
}