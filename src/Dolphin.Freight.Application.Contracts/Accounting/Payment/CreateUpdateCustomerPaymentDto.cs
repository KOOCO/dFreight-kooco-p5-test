using Dolphin.Freight.Accounting.Inv;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.Accounting.Payment
{
    public class CreateUpdateCustomerPaymentDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 收付款ID
        /// </summary>
        public Guid PaymentId { get; set; }

        /// <summary>
        /// 收付款級別
        /// </summary>
        public string PaymentLevel { get; set; }

        /// <summary>
        /// 收款來源
        /// </summary>
        public Guid? ReceivablesSources { get; set; }

        /// <summary>
        /// 發布日期
        /// </summary>
        [Required]
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// 類別
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// 支票號碼
        /// </summary>
        public string CheckNo { get; set; }

        /// <summary>
        /// 存款
        /// </summary>
        public bool DepositChk { get; set; }

        /// <summary>
        /// 存款
        /// </summary>
        public DateTime? Deposit { get; set; }

        /// <summary>
        /// 作廢
        /// </summary>
        public bool InvalidChk { get; set; }

        /// <summary>
        /// 作廢
        /// </summary>
        public DateTime? Invalid { get; set; }

        /// <summary>
        /// 分站ID
        /// </summary>
        public Guid? OfficeId { get; set; }

        /// <summary>
        /// 銀行
        /// </summary>
        public string Bank { get; set; }

        /// <summary>
        /// 銀行幣種
        /// </summary>
        public string BankCurrency { get; set; }

        /// <summary>
        /// USD => TWD
        /// </summary>
        public string U2T { get; set; }

        /// <summary>
        /// RMB => TWD
        /// </summary>
        public string R2T { get; set; }

        /// <summary>
        /// HKD => TWD
        /// </summary>
        public string H2T { get; set; }

        /// <summary>
        /// 備忘錄
        /// </summary>
        public string Memo { get; set; }

        public Guid GU { get; set; }

        public List<CreateUpdateInvDto> datatablelist { get; set; }

        public string Edit { get; set; }
    }
}

