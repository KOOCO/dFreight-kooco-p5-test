using System;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.iFreightDB.BaseTables.Bsfrtcentertms
{
    public class Bsfrtcentertm_Dto : EntityDto
    {
        /// <summary>
        /// 集團
        /// </summary>
        public string GroupId { get; set; }
        /// <summary>
        /// 公司
        /// </summary>
        public string Cmp { get; set; }
        /// <summary>
        /// 站別
        /// </summary>
        public string Stn { get; set; }
        /// <summary>
        /// 工作編號
        /// </summary>
        public string JobNo { get; set; }
        /// <summary>
        /// 合約號碼
        /// </summary>
        public string ContractNo { get; set; }
        /// <summary>
        /// 舊合約號碼(作廢用)
        /// </summary>
        public string ContractNoHistory { get; set; }
        /// <summary>
        /// 客戶名稱
        /// </summary>
        public string OrdCd { get; set; }
        /// <summary>
        /// 生效日期
        /// </summary>
        public DateTime? EffectiveDate { get; set; }
        /// <summary>
        /// 到期日期
        /// </summary>
        public DateTime? ExpirationDate { get; set; }
        /// <summary>
        /// 航線
        /// </summary>
        public string OceanLine { get; set; }
        /// <summary>
        /// 創建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        /// 創建日期
        /// </summary>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public string ModifyBy { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? ModifyDate { get; set; }
        /// <summary>
        /// 審核人
        /// </summary>
        public string ConfirmBy { get; set; }
        /// <summary>
        /// 審核日期
        /// </summary>
        public DateTime? ConfirmDate { get; set; }
        /// <summary>
        /// 是否推動 Y:是 N:否
        /// </summary>
        public string Rec { get; set; }
        /// <summary>
        /// 10運價中心主管未審核/ 15運價成本已作廢[無法到其他狀態]/ 20運價中心主管已審核(老闆須審核未審核) / 30運價中心主管已審核(老闆無須審核)[已啟用此運價成本] / 40運價中心主管已審核(老闆已審核)[已啟用此運價成本] / 50此運價成本已有報價單引用
        /// </summary>
        public string ConfirmFlag { get; set; }
        /// <summary>
        /// 作廢人
        /// </summary>
        public string VoidBy { get; set; }
        /// <summary>
        /// 作廢時間
        /// </summary>
        public DateTime? VoidDate { get; set; }
        /// <summary>
        /// 作廢原因
        /// </summary>
        public string VoidReason { get; set; }
    }
}
