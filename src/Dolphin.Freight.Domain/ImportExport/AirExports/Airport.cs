using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Dolphin.Freight.ImportExport.AirExports
{
    public class Airport : BasicAggregateRoot<Guid>, ISoftDelete
    {
        /// <summary>
        /// 機場名稱
        /// </summary>
        public string AirportName { get; set; }
        /// <summary>
        /// IATA 3-Letter Airport code
        /// </summary>
        public string AirportIataCode { get; set; }
        public bool IsDeleted { get; set; }
    }
}
