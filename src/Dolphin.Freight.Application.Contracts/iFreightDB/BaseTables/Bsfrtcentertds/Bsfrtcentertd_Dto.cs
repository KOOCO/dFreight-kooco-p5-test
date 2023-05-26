using System;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.iFreightDB.BaseTables.Bsfrtcentertds
{
    public class Bsfrtcentertd_Dto : EntityDto
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
        /// 來源主單的工作編號
        /// </summary>
        public string FJobNo { get; set; }
        /// <summary>
        /// 合約子號
        /// </summary>
        public string FRlsNo { get; set; }
        /// <summary>
        /// 部門
        /// </summary>
        public string Dep { get; set; }
        /// <summary>
        /// 業務所屬部門
        /// </summary>
        public string SalesDepId { get; set; }
        /// <summary>
        /// 代理代碼
        /// </summary>
        public string AgentCd { get; set; }
        /// <summary>
        /// 船公司/航空公司
        /// </summary>
        public string FCarrier { get; set; }
        /// <summary>
        /// 船名/航班號
        /// </summary>
        public string Vsl { get; set; }
        /// <summary>
        /// 計費方式
        /// </summary>
        public string FType { get; set; }
        /// <summary>
        /// 收貨港代碼
        /// </summary>
        public string PorCd { get; set; }
        /// <summary>
        /// 起運地/裝貨港代碼
        /// </summary>
        public string PolCd { get; set; }
        /// <summary>
        /// 卸貨港代碼
        /// </summary>
        public string PodCd { get; set; }
        /// <summary>
        /// 貿易條款
        /// </summary>
        public string SvcModeTerm { get; set; }
        /// <summary>
        /// 費用代碼
        /// </summary>
        public string FChargeCd { get; set; }
        /// <summary>
        /// 幣別
        /// </summary>
        public string FCurrency { get; set; }
        /// <summary>
        /// 計費單位
        /// </summary>
        public string ChgUnit { get; set; }
        /// <summary>
        /// 計費單價
        /// </summary>
        public decimal? MinChg { get; set; }
        /// <summary>
        /// 定價策略
        /// </summary>
        public decimal? PriceSt { get; set; }
        /// <summary>
        /// 基本價格
        /// </summary>
        public decimal? BasicPrice { get; set; }
        /// <summary>
        /// 計費單位1
        /// </summary>
        public string ChgUnit1 { get; set; }
        /// <summary>
        /// 計費單位型態1
        /// </summary>
        public string ChgFlag1 { get; set; }
        /// <summary>
        /// 計費單價1
        /// </summary>
        public decimal? Rate1 { get; set; }
        /// <summary>
        /// 計費單位2
        /// </summary>
        public string ChgUnit2 { get; set; }
        /// <summary>
        /// 計費單位型態2
        /// </summary>
        public string ChgFlag2 { get; set; }
        /// <summary>
        /// 計費單價2
        /// </summary>
        public decimal? Rate2 { get; set; }
        /// <summary>
        /// 計費單位3
        /// </summary>
        public string ChgUnit3 { get; set; }
        /// <summary>
        /// 計費單位型態3
        /// </summary>
        public string ChgFlag3 { get; set; }
        /// <summary>
        /// 計費單價3
        /// </summary>
        public decimal? Rate3 { get; set; }
        /// <summary>
        /// 計費單位4
        /// </summary>
        public string ChgUnit4 { get; set; }
        /// <summary>
        /// 計費單位型態4
        /// </summary>
        public string ChgFlag4 { get; set; }
        /// <summary>
        /// 計費單價4
        /// </summary>
        public decimal? Rate4 { get; set; }
        /// <summary>
        /// 計費單位5
        /// </summary>
        public string ChgUnit5 { get; set; }
        /// <summary>
        /// 計費單位型態5
        /// </summary>
        public string ChgFlag5 { get; set; }
        /// <summary>
        /// 計費單價5
        /// </summary>
        public decimal? Rate5 { get; set; }
        /// <summary>
        /// 計費單位6
        /// </summary>
        public string ChgUnit6 { get; set; }
        /// <summary>
        /// 計費單位型態6
        /// </summary>
        public string ChgFlag6 { get; set; }
        /// <summary>
        /// 計費單價6
        /// </summary>
        public decimal? Rate6 { get; set; }
        /// <summary>
        /// 累計加總 Y:是,N:否
        /// </summary>
        public string AccFlag { get; set; }
        /// <summary>
        /// 轉運的方式
        /// </summary>
        public string Via { get; set; }
        /// <summary>
        /// 結關日
        /// </summary>
        public string Closing { get; set; }
        /// <summary>
        /// 開航/起飛日
        /// </summary>
        public string Etd { get; set; }
        /// <summary>
        /// 車隊起運地
        /// </summary>
        public string TruckOrgn { get; set; }
        /// <summary>
        /// 車隊目的地
        /// </summary>
        public string TruckDest { get; set; }
        /// <summary>
        /// 第二城市代碼
        /// </summary>
        public string Dest2Cd { get; set; }
        /// <summary>
        /// 第三城市代碼
        /// </summary>
        public string Dest3Cd { get; set; }
        /// <summary>
        /// 第四城市代碼
        /// </summary>
        public string Dest4Cd { get; set; }
        /// <summary>
        /// L.國內/F.國外
        /// </summary>
        public string Pc { get; set; }
        /// <summary>
        /// 航程天數
        /// </summary>
        public string FTransit { get; set; }
        /// <summary>
        /// 轉運類型
        /// </summary>
        public string TransitType { get; set; }
        /// <summary>
        /// 品名
        /// </summary>
        public string FCmdt { get; set; }
        /// <summary>
        /// 長
        /// </summary>
        public decimal? L { get; set; }
        /// <summary>
        /// 寬
        /// </summary>
        public decimal? W { get; set; }
        /// <summary>
        /// 高
        /// </summary>
        public decimal? H { get; set; }
        /// <summary>
        /// 件數
        /// </summary>
        public decimal? Pkg { get; set; }
        /// <summary>
        /// 件數單位
        /// </summary>
        public string PkgUnit { get; set; }
        /// <summary>
        /// 體積重
        /// </summary>
        public decimal? Vw { get; set; }
        /// <summary>
        /// 體積重單位
        /// </summary>
        public string VwUnit { get; set; }
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
        /// 備註
        /// </summary>
        public string FRmk { get; set; }
        /// <summary>
        /// 收貨港國家代碼
        /// </summary>
        public string PorCnty { get; set; }
        /// <summary>
        /// 裝貨港國家代碼
        /// </summary>
        public string PolCnty { get; set; }
        /// <summary>
        /// 卸貨港國家代碼
        /// </summary>
        public string PodCnty { get; set; }
        /// <summary>
        /// 第二城市國家代碼
        /// </summary>
        public string Dest2Cnty { get; set; }
        /// <summary>
        /// 第三城市國家代碼
        /// </summary>
        public string Dest3Cnty { get; set; }
        /// <summary>
        /// 第四城市國家代碼
        /// </summary>
        public string Dest4Cnty { get; set; }
        /// <summary>
        /// 收貨港名稱
        /// </summary>
        public string PorNm { get; set; }
        /// <summary>
        /// 裝貨港名稱
        /// </summary>
        public string PolNm { get; set; }
        /// <summary>
        /// 卸貨港名稱
        /// </summary>
        public string PodNm { get; set; }
        /// <summary>
        /// 第二城市名稱
        /// </summary>
        public string Dest2Nm { get; set; }
        /// <summary>
        /// 第三城市名稱
        /// </summary>
        public string Dest3Nm { get; set; }
        /// <summary>
        /// 第四城市名稱
        /// </summary>
        public string Dest4Nm { get; set; }
        /// <summary>
        /// 定價策略2
        /// </summary>
        public decimal? PriceSt2 { get; set; }
        /// <summary>
        /// 定價策略3
        /// </summary>
        public decimal? PriceSt3 { get; set; }
        /// <summary>
        /// 定價策略4
        /// </summary>
        public decimal? PriceSt4 { get; set; }
        /// <summary>
        /// 定價策略5
        /// </summary>
        public decimal? PriceSt5 { get; set; }
        /// <summary>
        /// 定價策略6
        /// </summary>
        public decimal? PriceSt6 { get; set; }
        /// <summary>
        /// 第幾筆明細
        /// </summary>
        public decimal? Seq { get; set; }
        /// <summary>
        /// 計稅類型
        /// </summary>
        public string VatFlag { get; set; }
        /// <summary>
        /// 稅率
        /// </summary>
        public decimal? TaxRate { get; set; }
        /// <summary>
        /// 是否開發票
        /// </summary>
        public string GuiFlg { get; set; }
        /// <summary>
        /// 最終目的代碼
        /// </summary>
        public string DestCd { get; set; }
        /// <summary>
        /// 最終目的國家
        /// </summary>
        public string DestCnty { get; set; }
        /// <summary>
        /// 最終目的名稱
        /// </summary>
        public string DestNm { get; set; }
        /// <summary>
        /// 預計到達時間
        /// </summary>
        public string Eta { get; set; }
        /// <summary>
        /// 免費倉儲時間
        /// </summary>
        public string FreeTime { get; set; }
    }
}
