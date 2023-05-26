using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Volo.Abp.Domain.Entities;

namespace Dolphin.Freight.iFreightDB.BaseTables.BsfrtcentertExcelTemps
{
    public partial class BsfrtcentertExcelTemp : Entity
    {
        public override object[] GetKeys()
        {
            return new object[] { ExcelTempId };
        }

        /// <summary>
        /// 流水號
        /// </summary>
        public long ExcelTempId { get; set; }
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
        /// 資料來源/運價取得/代理人
        /// </summary>
        public string Agent { get; set; }
        /// <summary>
        /// 合約生效日期
        /// </summary>
        public DateTime? EffectiveDate { get; set; }
        /// <summary>
        /// 合約到期日期
        /// </summary>
        public DateTime? ValidTill { get; set; }
        /// <summary>
        /// 船/航空公司代碼
        /// </summary>
        public string Carrier { get; set; }
        /// <summary>
        /// 起運地
        /// </summary>
        public string Origin { get; set; }
        /// <summary>
        /// 目的港
        /// </summary>
        public string Pod { get; set; }
        /// <summary>
        /// 最終交貨地
        /// </summary>
        public string Destination { get; set; }
        /// <summary>
        /// 模式
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// 幣別
        /// </summary>
        public string Currency { get; set; }
        /// <summary>
        /// 20&apos;GP的價錢
        /// </summary>
        public string Ic20gp { get; set; }
        /// <summary>
        /// 40&apos;GP的價錢
        /// </summary>
        public string Ic40gp { get; set; }
        /// <summary>
        /// 40&apos;HQ的價錢
        /// </summary>
        public string Ic40hq { get; set; }
        /// <summary>
        /// 航程天數
        /// </summary>
        public string TrasitTime { get; set; }
        /// <summary>
        /// 截關日
        /// </summary>
        public string Etc { get; set; }
        /// <summary>
        /// 預計開航時間
        /// </summary>
        public string Etd { get; set; }
        /// <summary>
        /// 預計到達時間
        /// </summary>
        public string Eta { get; set; }
        /// <summary>
        /// 免費倉儲時間
        /// </summary>
        public string FreeTime { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 上傳人
        /// </summary>
        public string UploaderId { get; set; }
        /// <summary>
        /// 上傳時間
        /// </summary>
        public DateTime? UploaderTime { get; set; }
        /// <summary>
        /// 是否刪除
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
