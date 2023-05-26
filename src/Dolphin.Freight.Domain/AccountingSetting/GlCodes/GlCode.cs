using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;
using Dolphin.Freight.Settings.SysCodes;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dolphin.Freight.AccountingSettings.GlCodes
{
    /// <summary>
    /// 會計科目代碼管理
    /// </summary>
    public class GlCode : AuditedAggregateRoot<Guid>, ISoftDelete
    {
        /// <summary>
        /// 科目代碼
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 類別ID
        /// </summary>
        public Guid? GlTypeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("GlTypeId")]
        public SysCode GlType { get; set; }
        /// <summary>
        /// 群組ID
        /// </summary>
        public Guid? GlGroupId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("GlGroupId")]
        public virtual SysCode GlGroup { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 子項目
        /// </summary>
        public string SubInfo { get; set; }
        /// <summary>
        /// 會計用科目代碼
        /// </summary>
        public string AccountingGlCode { get; set; }
        /// <summary>
        /// 是否啟用
        /// </summary>
        public bool IsUsed { get; set; }
        /// <summary>
        /// 是否存款
        /// </summary>
        public bool IsDeposit { get; set; }
        /// <summary>
        /// 是否收付款
        /// </summary>
        public bool IsPayment { get; set; }
        /// <summary>
        /// 是否重估
        /// </summary>
        public bool IsRevaluation { get; set; }
        /// <summary>
        /// 是否刪除
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
