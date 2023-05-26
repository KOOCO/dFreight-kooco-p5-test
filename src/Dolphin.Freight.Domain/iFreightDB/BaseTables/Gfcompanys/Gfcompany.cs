using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Dolphin.Freight.iFreightDB.BaseTables.Gfcompanys
{
    public partial class Gfcompany : Entity
    {
        public override object[] GetKeys()
        {
            return new object[] { GroupId, Cmp, Stn };
        }

        public string GroupId { get; set; }
        public string Cmp { get; set; }
        public string CmpCd { get; set; }
        public string Stn { get; set; }
        public string Cur { get; set; }
        public string CmpBsLic { get; set; }
        public decimal? CmpRegCap { get; set; }
        public string CmpRegAddr { get; set; }
        public decimal? CmpTtlCap { get; set; }
        public string CmpBsEntity { get; set; }
        public string CmpAttn { get; set; }
        public string CmpAttnTel { get; set; }
        public string CmpAttnCell { get; set; }
        public string CmpAttnMail { get; set; }
        public DateTime? CmpEfficDateFrom { get; set; }
        public DateTime? CmpEfficDateTo { get; set; }
        public string CmpRmk { get; set; }
        public string CmpCloseFlag { get; set; }
        public string CmpUsebk { get; set; }
        public string UseTracking { get; set; }
        public string UseMessage { get; set; }
        public string UseIsoffset { get; set; }
        public string UseSharesales { get; set; }
        public decimal? DiffTime { get; set; }
        public string UseAedate { get; set; }
        public string UseAidate { get; set; }
        public string UseOedate { get; set; }
        public string UseOidate { get; set; }
        public string PostGl { get; set; }
        public string UseDnbyitem { get; set; }
        public string BaseStn { get; set; }
        public string CustAcdate { get; set; }
        public string CustAedate { get; set; }
        public string CustAidate { get; set; }
        public string CustOedate { get; set; }
        public string CustOidate { get; set; }
        public string Fcur { get; set; }
        public string ContractStn { get; set; }
        public string LockExchrt { get; set; }
        public string AutochangeInvdate { get; set; }
        public string McontractStn { get; set; }
        public string OpenInvPostAc { get; set; }
        public string CustSharecmp { get; set; }
        public string CustSharestn { get; set; }
        public string RateMonthOne { get; set; }
        public string BaseCmp { get; set; }
        public string Pc { get; set; }
        public string TruckCd { get; set; }
        public string CustAddSharecmp { get; set; }
        public string CustAddSharestn { get; set; }
        public string IsCmpAlone { get; set; }
        public string AirContractStn { get; set; }
        public string AirMcontractStn { get; set; }
        public string CustAutonoCmpstn { get; set; }
        public string UseAebldate { get; set; }
        public string UseAibldate { get; set; }
        public string UseOibldate { get; set; }
        public string UseOebldate { get; set; }
        public string CreditCmpstn { get; set; }
        public string Accountid1 { get; set; }
        public string ChgCdCmp { get; set; }
        public string ChgCdStn { get; set; }
        /// <summary>
        /// 業務賣價製作
        /// </summary>
        public string MakeSalesChg { get; set; }
    }
}
