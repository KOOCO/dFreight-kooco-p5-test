using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dolphin.Freight.Settings.ItNoRanges
{
    /// <summary>
    /// IT號碼管理Entity
    /// </summary>
    public class ItNoRange : AuditedAggregateRoot<Guid>, ISoftDelete
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

        /// <summary>
        /// Defined by ISoftDelete
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
