using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;

namespace Dolphin.Freight.Settings.Substations
{
    public class Substation : AuditedAggregateRoot<Guid>, ISoftDelete
    {
        /// <summary>
        /// 分站名稱
        /// </summary>
        public string SubstationName { get; set; }
        /// <summary>
        /// 分站簡稱
        /// </summary>
        public string AbbreviationName { get; set; }
        /// <summary>
        /// 分站使用貨幣
        /// </summary>
        public string Currency { get; set; }
        /// <summary>
        /// 是否刪除
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
