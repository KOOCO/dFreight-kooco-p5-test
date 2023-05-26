using Dolphin.Freight.Settings.PackageUnits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dolphin.Freight.ImportExport.Common
{
    /// <summary>
    /// 艙單貨物
    /// </summary>
    public class CargoManifest : AuditedAggregateRoot<Guid>, ISoftDelete
    {
        /// <summary>
        /// 貨物描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 包裝
        /// </summary>
        public int PackageNum { get; set; }
        /// <summary>
        /// 包裝種類ID
        /// </summary>
        public Guid? PackageUnitId { get; set; }
        /// <summary>
        /// 包裝種類
        /// </summary>
        [ForeignKey("PackageUnitId")]
        public virtual PackageUnit PackageUnit { get; set; }
        /// <summary>
        /// HTS代碼
        /// </summary>
        public string HtsCode { get; set; }
        /// <summary>
        /// 件數
        /// </summary>
        public int Pcs { get; set; }
        /// <summary>
        /// 淨重
        /// </summary>
        public double NetWeight { get; set; }
        /// <summary>
        /// 毛重
        /// </summary>
        public double GrossWeight { get; set; }
        /// <summary>
        /// 單價
        /// </summary>
        public double UnitPrice { get; set; }
        /// <summary>
        /// 金額
        /// </summary>
        public double Amount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Detail { get; set; }
        /// <summary>
        /// 是否刪除
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
