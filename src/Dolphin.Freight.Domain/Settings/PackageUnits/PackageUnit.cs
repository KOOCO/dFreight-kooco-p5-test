using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;
using System.ComponentModel.DataAnnotations.Schema;
using Dolphin.Freight.Settings.AwbNoRanges;
using Dolphin.Freight.Settings.SysCodes;

namespace Dolphin.Freight.Settings.PackageUnits
{
    /// <summary>
    /// 包裝種類
    /// </summary>
    public class PackageUnit : AuditedAggregateRoot<Guid>, ISoftDelete
    {
        /// <summary>
        /// 代碼
        /// </summary>
        public string PackageCode { get; set; }
        /// <summary>
        /// 名稱
        /// </summary>
        public string PackageName { get; set; }
        /// <summary>
        /// Ams編號ID
        /// </summary>
        public Guid? AmsNoId { get; set; }
        /// <summary>
        /// Ams編號
        /// </summary>
        [ForeignKey("AmsNoId")]
        public virtual SysCode AmsNo { get; set; }
        /// <summary>
        /// EManifest ID
        /// </summary>
        public Guid? EManifestId { get; set; }
        /// <summary>
        /// EManifest代碼
        /// </summary>
        [ForeignKey("EManifestId")]
        public virtual SysCode EManifest { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 是否刪除
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
