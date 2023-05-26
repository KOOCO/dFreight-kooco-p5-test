using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.Settinngs.PackageUnits
{
    public class PackageUnitDto : AuditedEntityDto<Guid>
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
        public string AmsNo { get; set; }
        /// <summary>
        /// EManifest ID
        /// </summary>
        public Guid? EManifestId { get; set; }
        public string EManifestNo  { get; set; }
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
