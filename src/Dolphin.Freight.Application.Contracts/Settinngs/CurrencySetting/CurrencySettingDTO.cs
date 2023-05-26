using System;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.Settings.CurrencySetting
{
    public class CurrencySettingDTO : AuditedEntityDto<Guid>
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
    }
}
