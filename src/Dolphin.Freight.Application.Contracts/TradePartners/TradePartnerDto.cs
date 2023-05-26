using Dolphin.Freight.TradePartner;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.TradePartners
{
    public class TradePartnerDto : AuditedEntityDto<Guid>
    {
        // Basic Setting
        public TPType TPType { get; set; }
        public string TPCode { get; set; }
        public string TPName { get; set; }
        public string TPNamePrint { get; set; }
        public string TPNameLocal { get; set; }

        public string TPLocalAddress { get; set; }
        public string CityCode { get; set; } // 城市代碼
        public string StateCode { get; set; }
        public string PostCode { get; set; }
        public string CountryCode { get; set; }

        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public string TPPrintAddress { get; set; }
        public string Remark { get; set; }

        // Other Setting
        public bool IsActive { get; set; }


        public string TPAliasName { get; set; }
        public string Ceo { get; set; }
        public string CorpNo { get; set; }
        public string IataCode { get; set; }
        public string IataPrefix { get; set; }
        public string ScacCode { get; set; }
        public string FirmsCode { get; set; } // 美國FIRMS編號
        public string CbsaCode { get; set; }
        public string DutyPaymentType { get; set; }
        public string OpenHours { get; set; }
        public BussinessStatusType BussinessStatusType { get; set; }
        public string CsCode { get; set; }
        public string SalesOfficeCode { get; set; }
        public string SalesCode { get; set; }
        public string SalesCodeOe { get; set; }
        public string SalesCodeOi { get; set; }
        public string SalesCodeAe { get; set; }
        public string SalesCodeAi { get; set; }
        public string SalesCodeCuOe { get; set; }
        public string SalesCodeCuAe { get; set; }
        public string SalesCodeCuOi { get; set; }
        public string SalesCodeCuAi { get; set; }


        // Account Setting
        public string AccountAddress { get; set; }
        public string TaxId { get; set; }
        public bool TrackPayment { get; set; }
        public PaymentType PaymentType { get; set; }
        public CreditTermType CreditTermType { get; set; }
        public int CreditTermDays { get; set; }
        public int CreditLimit { get; set; }
        public bool BillToAgentCode { get; set; }
        public bool Clm { get; set; }
        public string AccountName { get; set; }
        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public string AccountCurrencyCode { get; set; }
        public string BankName2 { get; set; }
        public string AccountNo2 { get; set; }
        public string AccountCurrencyCode2 { get; set; }
        public string BankName3 { get; set; }
        public string AccountNo3 { get; set; }
        public string AccountCurrencyCode3 { get; set; }


        // ISF Setting
        public string IsfSubmissionName { get; set; }
        public ImporterCodeType ImporterCodeType { get; set; }
        public string ImporterNo { get; set; }

        // PopUp Tips
        public string PopUpTips { get; set; }

        public Guid AccountGroupId { get; set; }
        public Guid CreditLimitGroupId { get; set; }

        public string CountryName { get; set; }


    }
}
