using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dolphin.Freight.ReportLog
{
    public class ReportLog : AuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// MBLId or HBLId
        /// </summary>
        public Guid ReportId { get; set; }

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

    public class MawbReport
    {
        public string ReportType { get; set; }
        public int No { get; set; }
        public Guid? ConsigneeId { get; set; }
        public Guid? OverseaAgentId { get; set; }
        public Guid? OfficeId { get; set; }
        public string Free { get; set; } = "";
        public string Nomi { get; set; } = "";
        public string Col { get; set; } = "";
        public string SUM { get; set; } = "";
        public string CNTR { get; set; } = "";
        public string OverseaAgent { get; set; } = "";
    }
}
