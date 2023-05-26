using System;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.Settings.Countries
{
    public class CountryDisplayNameListDto
    {
        /// <summary>
        /// 分站ID
        /// </summary>
        public Guid? Id { get; set; }
        /// <summary>
        /// 顯示名稱
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 國家ID
        /// </summary>
        public Guid CountryId { get; set; }
        /// <summary>
        /// 國家名稱
        /// </summary>
        public string CountryName { get; set; }
        /// <summary>
        /// 航線名稱
        /// </summary>
        public string AirportName { get; set; }
    }
}
