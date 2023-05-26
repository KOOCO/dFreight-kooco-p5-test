using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;

namespace Dolphin.Freight.ImportExport.Common
{
    /// <summary>
    /// 集裝箱清單尺寸
    /// </summary>
    public class ContainerDimension : AuditedAggregateRoot<Guid>, ISoftDelete
    {
        /// <summary>
        /// 集裝箱清單的ID
        /// </summary>
        public Guid ContainerId { get; set; }
        /// <summary>
        /// 長度
        /// </summary>
        public double ContainerLength { get; set; }
        /// <summary>
        /// 寬度
        /// </summary>
        public double ContainerWidth { get; set; }
        /// <summary>
        /// 高度
        /// </summary>
        public double ContainerHeight { get; set; }
        /// <summary>
        /// 數量
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// 是否刪除
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
