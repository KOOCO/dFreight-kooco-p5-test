using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Domain.Entities;

namespace Dolphin.Freight.iFreightDB.BaseTables.Bscss
{
    public partial class Bscs : Entity
    {

        public override object[] GetKeys()
        {
            return new object[] { GroupId, Cmp, Stn, CustCd };
        }

        public string GroupId { get; set; }
        public string CustType { get; set; }
        public string CustCd { get; set; }
        public string HeaderCd { get; set; }
        public string GlobalCd { get; set; }
        public string EngNm { get; set; }
        public string EngAddr { get; set; }
        public string LocalNm { get; set; }
        public string LocalAddr { get; set; }
        public string CityCd { get; set; }
        public string CntyCd { get; set; }
        public string Area { get; set; }
        public string AbrNm { get; set; }
        public string VoidFlag { get; set; }
        public string VoidBy { get; set; }
        public DateTime? VoidDate { get; set; }
        public string ZipCd { get; set; }
        public string Rmk { get; set; }
        public string Cmp { get; set; }
        public string Stn { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string LockUser { get; set; }
        public string State { get; set; }
        public string ScacCode { get; set; }
        public string RarNo { get; set; }
        public string KcNo { get; set; }
        public string Status { get; set; }
        public string CustLev { get; set; }
        public string AciCode { get; set; }
        public string PsCenter { get; set; }
        public string EdiCode { get; set; }
        public string TaxNo { get; set; }
        public string FollowupBy { get; set; }
        public DateTime? KcDate { get; set; }
        public Guid Rowid { get; set; }
        public string CreateStn { get; set; }
        public string Opener { get; set; }
        public DateTime? OpenDate { get; set; }
        public string Website { get; set; }
        public string AccountNo { get; set; }
        public string IataCd { get; set; }
        public string Itrace { get; set; }
        public string CustTypeEx { get; set; }
        public string StockCode { get; set; }
        public decimal? Capital { get; set; }
        public string ContractCur { get; set; }
        public string Verticals { get; set; }
        public string EngAddrA { get; set; }
        public string EngAddrO { get; set; }
        public string LocalAddrA { get; set; }
        public string LocalAddrO { get; set; }
        public string MAddr { get; set; }
        public string Exchrt { get; set; }
        public string CustTel { get; set; }
        public string CustFax { get; set; }
        public string AgntType { get; set; }
        public string CustMail { get; set; }
        public string CustAttn { get; set; }
        public string FaxUser { get; set; }
        public string Organ { get; set; }
        public string Updatecredit { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public Guid? ActionId { get; set; }
        public string Aeo { get; set; }
        /// <summary>
        /// 有無紙本資料，Y=有
        /// </summary>
        public string HaveHardcopy { get; set; }
        /// <summary>
        /// 是否合格，Y=是
        /// </summary>
        public string IsQualified { get; set; }
        /// <summary>
        /// 評鑑日期
        /// </summary>
        public DateTime? QualifiedDate { get; set; }
        /// <summary>
        /// 評鑑有效日期
        /// </summary>
        public DateTime? QualifiedExpdate { get; set; }
        /// <summary>
        /// 鼎新WorkFlow
        /// </summary>
        public string Towf { get; set; }
        /// <summary>
        /// 客戶評鑑級別
        /// </summary>
        public string QualifiedLev { get; set; }
    }
}
