using System;
using System.ComponentModel.DataAnnotations;

namespace Dolphin.Freight.Accounting.Payment
{
    public class CreateUpdatePaymentMadeListDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 收付款ID
        /// </summary>
        public string PaymentId { get; set; }

        /// <summary>
        /// 發布日期
        /// </summary>
        public string PostDate { get; set; }

        /// <summary>
        /// 發票日期
        /// </summary>
        public string InvoiceDate { get; set; }

        /// <summary>
        /// 到期日期
        /// </summary>
        public string DueDate { get; set; }

        /// <summary>
        /// 類別
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 分站
        /// </summary>
        public string OfficeId { get; set; }

        /// <summary>
        /// 客戶ID
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// 發票號碼
        /// </summary>
        public string InvoiceNo { get; set; }

        /// <summary>
        /// 科目ID
        /// </summary>
        public string GlCodeId { get; set; }

        /// <summary>
        /// 幣種
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// 發票金額
        /// </summary>
        public string InvoiceAmount { get; set; }

        /// <summary>
        /// 餘額金額
        /// </summary>
        public string BalanceAmount { get; set; }

        /// <summary>
        /// 收付款
        /// </summary>
        public string PaymentAmount { get; set; }

        /// <summary>
        /// 收付款(TWD)
        /// </summary>
        public string PaymentAmountTwd { get; set; }

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

