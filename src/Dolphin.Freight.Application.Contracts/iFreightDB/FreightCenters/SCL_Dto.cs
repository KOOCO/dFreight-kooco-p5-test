using System;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.iFreightDB.FreightCenters
{
    public class SCL_Dto : EntityDto
    {
        /// <summary>
        /// 明細 JOB_NO
        /// </summary>
        public string JobNo { get; set; }
        /// <summary>
        /// 運價取得/資料來源
        /// </summary>
        public string Agent { get; set; }
        /// <summary>
        /// 合約編號：抓主表， CONTRACT_NO
        /// </summary>
        public string SC_NO { get; set; }
        /// <summary>
        /// 生效日期：抓主表， EFFECTIVE_DATE
        /// </summary>
        public DateTime? EffectiveDate { get; set;}
        /// <summary>
        /// 到期日：抓主表，EXPIRATION_DATE
        /// </summary>
        public DateTime? ExpiryDate { get; set;}
        /// <summary>
        /// 船公司：F_CARRIER
        /// </summary>
        public string Carrier { get; set;}
        /// <summary>
        /// 服務模式：F_TYPE
        /// </summary>
        public string ServiceMode { get; set;}
        /// <summary>
        /// 起運地：POL_CD
        /// </summary>
        public string Origin { get; set;}
        /// <summary>
        /// 卸貨港：POD_CD
        /// </summary>
        public string POD { get; set;}
        /// <summary>
        /// 交貨地：DEST_CD
        /// </summary>
        public string Destination { get; set;}
        public string Ctn_20GP { get; set;}
        public string Ctn_40GP { get; set;}
        public string Ctn_40HQ { get; set;}
        public string Ctn_45HQ { get; set;}
        /// <summary>
        /// OF Currency：F_CURRENCY
        /// </summary>
        public string OF_Currency { get; set;}
        /// <summary>
        /// 散貨 CBM：CHG_UNIT = 'CBM'
        /// </summary>
        public string CFS_CBM { get; set;}
        /// <summary>
        /// 散貨 的幣別：F_CURRENCY
        /// </summary>
        public string CFS_Currency { get; set;}
        /// <summary>
        /// 備註 F_RMK
        /// </summary>
        public string Remark { get; set;}
        /// <summary>
        /// 航程天數 F_TRANSIT
        /// </summary>
        public string TT { get; set;}
        /// <summary>
        /// 截關日 CLOSING
        /// </summary>
        public string ETC { get; set;}
        /// <summary>
        /// 預計開航時間 ETD
        /// </summary>
        public string ETD { get; set;}
        /// <summary>
        /// 預計到達時間 ETA
        /// </summary>
        public string ETA { get; set;}
        /// <summary>
        /// 免費倉儲時間 FREE_TIME
        /// </summary>
        public string FreeTime { get; set;}

        public string Extension1 { get; set;}



    }
}
