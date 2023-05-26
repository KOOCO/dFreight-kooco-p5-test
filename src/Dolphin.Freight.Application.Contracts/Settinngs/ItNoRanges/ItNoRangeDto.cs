using System;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.Settings.ItNoRanges
{
    /// <summary>
    /// IT號碼管理DTO
    /// </summary>
    public class ItNoRangeDto : AuditedEntityDto<Guid>
    {
        /// <summary>
        /// 起始號碼
        /// </summary>
        public string StartNo { get; set; }

        /// <summary>
        /// 結束號碼
        /// </summary>
        public string EndNo { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// 當前分配的號碼
        /// </summary>
        public string CurrentNo { get; set; }
    }
}