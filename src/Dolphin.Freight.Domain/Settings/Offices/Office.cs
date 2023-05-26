using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;

namespace Dolphin.Freight.Settings.Offices
{
    public class Office : AuditedAggregateRoot<Guid>, ISoftDelete
    {
        /// <summary>
        /// 分站名稱
        /// </summary>
        public string OfficeName { get; set; }
        /// <summary>
        /// 分站代號
        /// </summary>
        public string OfficeCode { get; set; }
        /// <summary>
        /// 是否刪除
        /// </summary>
        public bool IsDeleted { get; set; }

    }
}
