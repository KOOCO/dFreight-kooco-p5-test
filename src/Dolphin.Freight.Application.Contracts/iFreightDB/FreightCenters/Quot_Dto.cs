using System;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.iFreightDB.FreightCenters
{
    public class Quot_Dto : EntityDto
    {

        // 運價查詢，主要以明細表為主

        #region 外建/組合屬性
        public string FreightCenterMainJobNo { get; set; } // 主表單號
        public string CurrencyExchangeRate { get; set; } // 存放匯率
        public string TotalPrice { get; set; } // 加總金額

        public string CustomField01 { get; set; }
        public string CustomField02 { get; set; }
        public string CustomField03 { get; set; }
        public string CustomField04 { get; set; }
        public string CustomField05 { get; set; }
        public string CustomField06 { get; set; }
        public string CustomField07 { get; set; }
        #endregion

        #region 基本欄位
        public string JobNo { get; set; }
        public string Carrier { get; set; } // 船 航空 名
        public string ChargeCode { get; set; } // F_CHARGE_CD // 費用代碼
        public decimal? MinCharge { get; set; } // 計費單價
        public string ChargeUnit { get; set; } // CHG_UNIT // 計費單位
        public string Currency { get; set; } // F_CURRENCY // 貨幣
        public decimal? BasicPrice { get; set; } // BASIC_PRICE // 基本價格
        public string ChargeUnit_1 { get; set; } // CHG_UNIT1 // 
        public string ChargeFlag_1 { get; set; } // CHG_FLAG1 // 
        public decimal? Rate_1 { get; set; } // RATE1 // 計費單價1
        public string ChargeUnit_2 { get; set; } // CHG_UNIT2
        public string ChargeFlag_2 { get; set; } // CHG_FLAG2
        public decimal? Rate_2 { get; set; } // RATE2
        public string ChargeUnit_3 { get; set; } // CHG_UNIT3
        public string ChargeFlag_3 { get; set; } // CHG_FLAG3
        public decimal? Rate_3 { get; set; } // RATE3
        public string ChargeUnit_4 { get; set; } // CHG_UNIT4
        public string ChargeFlag_4 { get; set; } // CHG_FLAG4
        public decimal? Rate_4 { get; set; } // RATE4
        public string ChargeUnit_5 { get; set; } // CHG_UNIT5
        public string ChargeFlag_5 { get; set; } // CHG_FLAG5
        public decimal? Rate_5 { get; set; } // RATE5
        public string ChargeUnit_6 { get; set; } // CHG_UNIT6
        public string ChargeFlag_6 { get; set; } // CHG_FLAG6
        public decimal? Rate_6 { get; set; } // RATE6
        public string SVCModeTerm { get; set; } // SVC_MODE_TERM // 貿易條款
        public string PrepaidCollect { get; set; } // PC // 運費條款 L.國內/F.國外
        public string TransitDay { get; set; } // F_TRANSIT // 航程天數
        public string Closing { get; set; } // CLOSING // 結關日 // SUN,MON...NEXT SUN,NEXT MON...
        public decimal? Sequence { get; set; } // SEQ // 第幾筆明細
        public string FreightRemarks { get; set; } // F_RMK // 備註


        public string VATFlag { get; set; } // VAT_FLAG // 計稅類型
        public decimal? TaxRate { get; set; } // TAX_RATE // 稅率


        /*
        public Guid? FreightCenterMainId { get; set; }
        public string DepartmentCode { get; set; } 
        public string SalesDepartmentId { get; set; } 
        public string AgentCode { get; set; } // AGENT_CD // 代理代碼
        public string Vessel { get; set; } // VSL // 船的名子或航班的號碼
        public string BillingMethod { get; set; } // F_TYPE // 計費方式
        public string PortReceiptCode { get; set; } // POR_CD // 收貨港
        public string PortLoadingCode { get; set; } // POL_CD // 起運地/裝貨港
        public string PortDestinationCode { get; set; } // POD_CD // 目的地/卸貨港
        public string PortReceiptCountry { get; set; } // POR_CNTY // 收貨港 國家
        public string PortLoadingCountry { get; set; } // POL_CNTY // 起運地/裝貨港 國家
        public string PortDestinationCountry { get; set; } // POD_CNTY // 目的地/卸貨港 國家
        public string DestinationCode { get; set; } // DEST_CD // 目的地代碼
        public string DestinationCountry { get; set; } // DEST_CNTY // 目的國家
        public string Destination_name { get; set; } // DEST_NM // 簡稱
        public string Destination_2_Code { get; set; } // DEST2_CD
        public string Destination_3_Code { get; set; } // DEST3_CD
        public string Destination_4_Code { get; set; } // DEST4_CD
        public string Destination_2_Country { get; set; } // DEST2_CNTY
        public string Destination_3_Country { get; set; } // DEST3_CNTY
        public string Destination_4_Country { get; set; } // DEST4_CNTY
        public string AccumulatorFlag { get; set; } // ACC_FLAG // 累計加總 Y:是,N:否
        public string Via { get; set; } // VIA // 轉運的方式
        public string ETD { get; set; } // ETD // Estimated Time of Delivery 開航/起飛日
        public string TransitType { get; set; } // TRANSIT_TYPE // 轉運類型
        public string GUIFlag { get; set; } // GUI_FLG // 是否開發票
        */
        #endregion
    }
}
