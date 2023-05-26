using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.Settings.AirOtherCharge
{
    /// <summary>
    /// 新增修改空運出口其他費用DTO
    /// </summary>
    public class CreateUpdateAirOtherChargeDTO
    {
        /// <summary>
        /// 航空公司/代理
        /// </summary>
        [Required]
        [StringLength(8)]
        public string companyType { get; set; }

        /// <summary>
        /// 付款方式
        /// </summary>
        [Required]
        [StringLength(8)]
        public string paymentType { get; set; }

        /// <summary>
        /// 顯示於MAWB
        /// </summary>
        public Boolean showOnMAWB { get; set; }

        /// <summary>
        /// 顯示於HAWB
        /// </summary>
        public Boolean showOnHAWB { get; set; }

        /// <summary>
        /// 收費項目
        /// </summary>
        [Required]
        public string chargeItem { get; set; }

        /// <summary>
        /// 收費細項
        /// </summary>
        [Required]
        public string chargeItemSubitem { get; set; }

        /// <summary>
        /// 收費費率
        /// </summary>
        [Required]
        public int chargeRate { get; set; }

        /// <summary>
        /// 收費費率單位
        /// </summary>
        [Required]
        public string chargeRateUnit { get; set; }

        /// <summary>
        /// 最低收費
        /// </summary>
        public string minPrice { get; set; }
    }
}