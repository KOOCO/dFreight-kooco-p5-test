using System;
using System.ComponentModel.DataAnnotations;

namespace Dolphin.Freight.ReportLog
{
    public class CreateUpdateReportLogDto
    {
        /// <summary>
        /// MBLId or HBLId
        /// </summary>
        public string ReportId { get; set; }

        /// <summary>
        /// 報表名稱
        /// </summary>
        public string ReportName { get; set; }

        /// <summary>
        /// 報表資料內容
        /// </summary>
        public string ReportData { get; set; }

        /// <summary>
        /// 最後更新時間
        /// </summary>
        public DateTime? LastUpdateTime { get; set; }
    }
}

