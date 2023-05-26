using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;
using Dolphin.Freight.Settings.Countries;

namespace Dolphin.Freight.Settings.Ports
{
    public class Port : AuditedAggregateRoot<Guid>, ISoftDelete
    {
        /// <summary>
        /// 所屬國家ID
        /// </summary>
        public Guid? CountryId { get; set; }
        /// <summary>
        /// 所屬國家
        /// </summary>
        public virtual Country Country { get; set; }
        /// <summary>
        /// 港口名稱
        /// </summary>
        public string PortName { get; set; }
        /// <summary>
        /// 聯合國口岸及相關地點代碼
        /// </summary>
        public string Locode { get; set; }
        /// <summary>
        /// 細分
        /// </summary>
        public string SubDiv { get; set; }
        /// <summary>
        /// 是否港口
        /// </summary>
        public bool IsPort { get; set; }
        /// <summary>
        /// 是否刪除
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
