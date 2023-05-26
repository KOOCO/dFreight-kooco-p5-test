using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dolphin.Freight.Settings.AwbNoRanges
{
    public class AwbNoRange : AuditedAggregateRoot<Guid>, ISoftDelete
    {
        /// <summary>
        /// 公司ID
        /// </summary>
        public Guid? CompanyId { get; set; }
        /// <summary>
        /// 公司
        /// </summary>
        [ForeignKey("CompanyId")]
        public virtual Dolphin.Freight.TradePartners.TradePartner Company { get; set; }
        /// <summary>
        /// 起始號碼
        /// </summary>
        public string StartNo { get; set; }

        /// <summary>
        /// 結束號碼
        /// </summary>
        public string EndNo { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// 當前分配的號碼
        /// </summary>
        public string CurrentNo { get; set; }

        /// <summary>
        /// Defined by ISoftDelete
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
