using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.Settinngs.Ports
{
    public class PortDto : AuditedEntityDto<Guid>
    {
        /// <summary>
        /// 所屬國家ID
        /// </summary>
        public Guid? CountryId { get; set; }
        /// <summary>
        /// 所屬國家
        /// </summary>
        public string CountryName { get; set; }
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
