using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.AccountingSettings.GlCodes
{
    public class GlCodeDto : AuditedEntityDto<Guid>
    {
        /// <summary>
        /// 科目代碼
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 類別ID
        /// </summary>
        public Guid? GlTypeId { get; set; }
        public string GlTypeName { get; set; }
        /// <summary>
        /// 群組ID
        /// </summary>
        public Guid? GlGroupId { get; set; }
        public string GlGroupName { get; set; }
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
