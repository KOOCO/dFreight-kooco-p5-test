using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;
using System.Xml.Linq;

namespace Dolphin.Freight.Settings.Currencies
{
    public class Currency : AuditedAggregateRoot<Guid>, ISoftDelete
    {
        /// <summary>
        /// 貨幣名稱
        /// </summary>
        public string CurrencyName { get; set; }
        /// <summary>
        /// 字母代碼
        /// </summary>
        public string AlphabetCode { get; set; }
        /// <summary>
        /// 是否刪除
        /// </summary>
        public bool IsDeleted { get; set; }

        private Currency()
        {
        }
        internal Currency(
            Guid id,
            string currencyName,
            string alphaCode)        
            : base(id)
        {
            CurrencyName = Check.NotNullOrWhiteSpace(currencyName, nameof(currencyName), 50);
            AlphabetCode = Check.NotNullOrWhiteSpace(alphaCode, nameof(alphaCode), 5);
        }
    }
}
