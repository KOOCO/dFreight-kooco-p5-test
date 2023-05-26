using Dolphin.Freight.Settings.Countries;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dolphin.Freight.Settings.PortsManagement
{
    /// <summary>
    /// 港口管理
    /// </summary>
    public class PortsManagement : AuditedAggregateRoot<Guid>, ISoftDelete
    {
        /// <summary>
        /// 是否顯示
        /// </summary>
        public bool IsActive { get; set; }

        public string CountryId { get; set; }
        /// <summary>
        /// 所屬國家
        /// </summary>
        public string Country { get; set; }
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
