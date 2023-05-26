using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.ImportExport.AirExports
{
    public class CreateUpdateAirportDto : AuditedEntityDto<Guid>
    {
        /// <summary>
        /// 機場名稱
        /// </summary>
        public string AirportName { get; set; }
        /// <summary>
        /// IATA 3-Letter Airport code
        /// </summary>
        public string AirportIataCode { get; set; }
    }
}
