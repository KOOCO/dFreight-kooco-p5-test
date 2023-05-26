using Dolphin.Freight.Settings.ContainerSizes;
using Dolphin.Freight.Settings.SysCodes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;
using Dolphin.Freight.Settings.PackageUnits;

namespace Dolphin.Freight.ImportExport.Common
{
    /// <summary>
    /// 倉儲收據清單
    /// </summary>
    public class WarehouseReceipt : AuditedAggregateRoot<Guid>, ISoftDelete
    {
        /// <summary>
        /// 收據編號
        /// </summary>
        public string ReceiptNo { get; set; }
        /// <summary>
        /// 長度
        /// </summary>
        public double Length { get; set; }
        /// <summary>
        /// 寬度
        /// </summary>
        public double Width { get; set; }
        /// <summary>
        /// 高度
        /// </summary>
        public double Height { get; set; }
        /// <summary>
        /// 尺寸ID
        /// </summary>
        public Guid? DimensionUnitId { get; set; }
        /// <summary>
        /// 尺寸
        /// </summary>
        [ForeignKey("DimensionUnitId")]
        public virtual SysCode DimensionUnit { get; set; }
        /// <summary>
        /// 件數
        /// </summary>
        public int Pcs { get; set; }
        /// <summary>
        /// 單位ID
        /// </summary>
        public Guid? PackageUnitId { get; set; }
        /// <summary>
        /// 單位
        /// </summary>
        [ForeignKey("PackageUnitId")]
        public virtual PackageUnit PackageUnit { get; set; }
        /// <summary>
        /// 重量
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// 材積
        /// </summary>
        public double Measure { get; set; }
        /// <summary>
        /// 裝箱單備註
        /// </summary>
        public string LoadPlanRemarks { get; set; }
        /// <summary>
        /// 是否刪除
        /// </summary>
        public bool IsDeleted { get; set; }

    }
}
