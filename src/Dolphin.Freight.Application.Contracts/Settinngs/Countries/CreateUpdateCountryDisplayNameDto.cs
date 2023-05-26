using System;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.Settings.Countries
{
    public class CreateUpdateCountryDisplayNameDto : AuditedEntityDto<Guid>
    {
        /// <summary>
        /// ID
        /// </summary>
        public new Guid? Id { get; set; }
        /// <summary>
        /// 顯示名稱
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 航線ID
        /// </summary>
        public string AirportId { get; set; }
        /// <summary>
        /// 航線名稱
        /// </summary>
        public string AirportName { get; set; }
        /// <summary>
        /// 航線代碼
        /// </summary>
        public string AirportCode { get; set; }
        /// <summary>
        /// 國家ID
        /// </summary>
        public Guid CountryId { get; set; }
        /// <summary>
        /// 分站ID
        /// </summary>
        public Guid OfficeId { get; set; }
    }
}
