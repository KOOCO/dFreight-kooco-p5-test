using System;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.Settings.PortsManagement
{
    /// <summary>
    /// 港口管理DTO
    /// </summary>
    public class PortsManagementDTO : AuditedEntityDto<Guid>
    {
        /// <summary>
        /// 起始號碼
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 所屬國家ID
        /// </summary>
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
    }
}