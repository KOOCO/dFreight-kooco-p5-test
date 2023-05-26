using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;
using Dolphin.Freight.Common;

namespace Dolphin.Freight.Common.Memos
{
    /// <summary>
    /// 備忘錄
    /// </summary>
    public class Memo : AuditedAggregateRoot<Guid>, ISoftDelete
    {
        /// <summary>
        /// 標題
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// 內容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 對應的文件類別
        /// </summary>
        public FreightPageType FType { get; set; }
        /// <summary>
        /// 隸屬的ID
        /// </summary>
        public Guid SourceId { get; set; }
        /// <summary>
        /// 是否刪除
        /// </summary>
        public bool IsDeleted { get; set; }
        public bool Highlight { get; set; }
    }
}
