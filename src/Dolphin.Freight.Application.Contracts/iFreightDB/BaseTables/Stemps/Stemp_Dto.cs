using System;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.iFreightDB.BaseTables.Stemps
{
    public class Stemp_Dto : EntityDto
    {
        public string GroupId { get; set; }
        public string EmpId { get; set; }
        public string EmpCnm { get; set; }
        public string EmpEnm { get; set; }
        public string EmpPass { get; set; }
        public string EmpTel { get; set; }
        public string EmpFax { get; set; }
        public string EmpCell { get; set; }
        public string EmpMail { get; set; }
        public string EmpMsn { get; set; }
        public string EmpSkype { get; set; }
        public string EmpQq { get; set; }
        public string EmpTitle { get; set; }
        public string SalesFlag { get; set; }
        public string OwnLeader { get; set; }
        public string Dep { get; set; }
        public string Cmp { get; set; }
        public string Stn { get; set; }
        public string CmpChoice { get; set; }
        public string StnChoice { get; set; }
        public string DepChoice { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string InternalFlag { get; set; }
        public string EvidentPass { get; set; }
        public string Favorites { get; set; }
        public string SelfFlag { get; set; }
        public string IesId { get; set; }
        public string SalesDepId { get; set; }
        public string EmpIsshare { get; set; }
        public string IsOnline { get; set; }
        public DateTime? LastAccessTime { get; set; }
        public string LastAccessIp { get; set; }
        public string FStatus { get; set; }
        public string CustType { get; set; }
        public string SalesdepChoice { get; set; }
        public string MailUser { get; set; }
        public string MailPsw { get; set; }
        public DateTime? LastmodifyPsw { get; set; }
        public string OceanLine { get; set; }
        public string OceanLineNm { get; set; }
        public string CmpLogin { get; set; }
        public string StnLogin { get; set; }
        public string CmpCust { get; set; }
        public string StnCust { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? LeaveDate { get; set; }
        public string GuiDep { get; set; }
        /// <summary>
        /// 業務的CS
        /// </summary>
        public string SalesCs { get; set; }
        /// <summary>
        /// 公司角色
        /// </summary>
        public string CmpRole { get; set; }
        /// <summary>
        /// 居家角色
        /// </summary>
        public string HomeRole { get; set; }
        /// <summary>
        /// VPN開始時間
        /// </summary>
        public DateTime? VpnFromDate { get; set; }
        /// <summary>
        /// VPN結束時間
        /// </summary>
        public DateTime? VpnToDate { get; set; }
        /// <summary>
        /// 審核客戶類型
        /// </summary>
        public string ApproveCustType { get; set; }
        /// <summary>
        /// 審核帳單類型
        /// </summary>
        public string ApproveAgntType { get; set; }
        /// <summary>
        /// 以SHA512加密的密碼
        /// </summary>
        public string EmpPassSha512 { get; set; }
        /// <summary>
        /// iFreight版本
        /// </summary>
        public string IfVersion { get; set; }
    }
}
