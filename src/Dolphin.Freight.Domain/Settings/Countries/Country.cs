using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;
using System.ComponentModel.DataAnnotations.Schema;
using Dolphin.Freight.Settings.Currencies;

namespace Dolphin.Freight.Settings.Countries
{
    public class Country : AuditedAggregateRoot<Guid>, ISoftDelete
    {
        /// <summary>
        /// 國家名稱
        /// </summary>
        public string CountryName { get; set; }
        /// <summary>
        /// 國家代號
        /// </summary>
        public string CountryCode { get; set; }
        /// <summary>
        /// 使用貨幣ID
        /// </summary>
        public Guid? CurrencyId { get; set; }
        /// <summary>
        /// 使用貨幣
        /// </summary>
        [ForeignKey("CurrencyId")]
        public Currency Currency { get; set; }
        /// <summary>
        /// 是否刪除
        /// </summary>
        public bool IsDeleted { get; set; }

    }
}
