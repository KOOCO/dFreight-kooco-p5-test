using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dolphin.Freight.Accounting.Inv
{
    public class Inv : AuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 收付款ID
        /// </summary>
        public Guid PaymentId { get; set; }

        /// <summary>
        /// 發布日期
        /// </summary>
        public DateTime? PostDate { get; set; }

        /// <summary>
        /// 發票日期
        /// </summary>
        public DateTime? InvoiceDate { get; set; }

        /// <summary>
        /// 到期日期
        /// </summary>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// 類別
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 分站
        /// </summary>
        public Guid? OfficeId { get; set; }

        /// <summary>
        /// 客戶ID
        /// </summary>
        public Guid? CustomerId { get; set; }
        /// <summary>
        /// 客戶
        /// </summary>
        [ForeignKey("CustomerId")]
        public virtual Dolphin.Freight.TradePartners.TradePartner Customer { get; set; }

        /// <summary>
        /// 發票號碼
        /// </summary>
        public string InvoiceNo { get; set; }

        /// <summary>
        /// 科目ID
        /// </summary>
        public Guid? GlCodeId { get; set; }
        /// <summary>
        /// 科目
        /// </summary>
        [ForeignKey("GlCodeId")]
        public virtual AccountingSettings.GlCodes.GlCode GlCode { get; set; }
        
        /// <summary>
        /// 幣種
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// 發票金額
        /// </summary>
        public decimal? InvoiceAmount { get; set; }

        /// <summary>
        /// 餘額金額
        /// </summary>
        public decimal? BalanceAmount { get; set; }

        /// <summary>
        /// 收付款
        /// </summary>
        public decimal? PaymentAmount { get; set; }

        /// <summary>
        /// 收付款(TWD)
        /// </summary>
        public decimal? PaymentAmountTwd { get; set; }

        /// <summary>
        /// 發票描述
        /// </summary>
        public string InvoiceDescription { get; set; }

        /// <summary>
        /// 文件編號
        /// </summary>
        public string DocNo { get; set; }

        /// <summary>
        /// 提單號碼
        /// </summary>
        public string BlNo { get; set; }

        /// <summary>
        /// PO號碼
        /// </summary>
        public string PoNo { get; set; }

        /// <summary>
        /// 操作員
        /// </summary>
        public string CsCode { get; set; }

        /// <summary>
        /// 業務員
        /// </summary>
        public string SalesCode { get; set; }
    }
}
