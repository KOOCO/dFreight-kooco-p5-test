using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;
using Dolphin.Freight.Settings.SysCodes;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dolphin.Freight.AccountingSettings.CurrencyTables
{
    public class CurrencyTable : AuditedAggregateRoot<Guid>, ISoftDelete
    {
        /// <summary>
        /// 來源幣種
        /// </summary>
        public Guid? Ccy1Id { get; set; }
        /// <summary>
        /// 兌換幣種
        /// </summary>
        [ForeignKey("Ccy1Id")]
        public virtual SysCode Ccy1 { get; set; }
        /// <summary>
        /// 來源幣種
        /// </summary>
        public Guid? Ccy2Id { get; set; }
        /// <summary>
        /// 兌換幣種
        /// </summary>
        [ForeignKey("Ccy2Id")]
        public virtual SysCode Ccy2 { get; set; }
        /// <summary>
        /// 開始時間
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 匯率(內部)
        /// </summary>
        public double RateInternal { get; set; }
        /// <summary>
        /// 匯率(外部)
        /// </summary>
        public double RateInterna2 { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 是否刪除
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
