using System;
using Volo.Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;
using Dolphin.Freight.Settings.Offices;
using Dolphin.Freight.ImportExport.AirExports;

namespace Dolphin.Freight.Settings.Countries
{
    public class CountryDisplayName : AuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 顯示名稱
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 航線ID
        /// </summary>
        public Guid? AirportId { get; set; }
        /// <summary>
        /// 航線
        /// </summary>
        [ForeignKey("AirportId")]
        public Airport Airport { get; set; }
        /// <summary>
        /// 國家ID
        /// </summary>
        public Guid CountryId { get; set; }
        /// <summary>
        /// 國家
        /// </summary>
        [ForeignKey("CountryId")]
        public Country Country { get; set; }
        /// <summary>
        /// 分站ID
        /// </summary>
        public Guid OfficeId { get; set; }
        /// <summary>
        /// 分站
        /// </summary>
        [ForeignKey("OfficeId")]
        public Office Office { get; set; }
    }
}
