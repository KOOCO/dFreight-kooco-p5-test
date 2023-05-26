using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;



namespace Dolphin.Freight.Settings.CurrencySetting
{
    public class CurrencySetting : AuditedAggregateRoot<Guid>, ISoftDelete
    {
        /// <summary>
        /// 部門
        /// </summary>
        public string CurrencyDepartment { get; set; }

        /// <summary>
        /// 客戶代碼
        /// </summary>
        public string CustomerShortCode { get; set; }

        /// <summary>
        /// 起始幣別
        /// </summary>
        public string StartingCurrency { get; set; }

        /// <summary>
        /// 結算幣別
        /// </summary>
        public string EndCurrency { get; set; }

        /// <summary>
        /// 換算匯率
        /// </summary>
        public float ExChangeRate { get; set; }


        /// <summary>
        /// 生效日期
        /// </summary>
        public DateTime EffectDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}
