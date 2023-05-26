using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace Dolphin.Freight.Settings.CurrencySetting
{
    /// <summary>
    /// 新增修改貨幣表管理DTO
    /// </summary>
    public class CreateUpdateCurrencySettingDTO
    {

        /// <summary>
        /// 部門
        /// </summary>
        [Required]
        public string CurrencyDepartment { get; set; }

        /// <summary>
        /// 客戶代碼
        /// </summary>
        public string CustomerShortCode { get; set; }

        /// <summary>
        /// 起始幣別
        /// </summary>
        [Required]
        public string StartingCurrency { get; set; }

        /// <summary>
        /// 結算幣別
        /// </summary>
        [Required]
        public string EndCurrency { get; set; }

        /// <summary>
        /// 換算匯率
        /// </summary>
        [Required]
        public float ExChangeRate { get; set; }
        
        /// <summary>
        /// 生效日期
        /// </summary>
        [Required]
        public DateTime EffectDate { get; set; }

    }
}
