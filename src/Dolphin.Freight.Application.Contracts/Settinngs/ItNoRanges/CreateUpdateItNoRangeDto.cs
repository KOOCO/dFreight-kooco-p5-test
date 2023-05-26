using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.Settings.ItNoRanges
{
    /// <summary>
    /// 新增修改IT號碼管理DTO
    /// </summary>
    public class CreateUpdateItNoRangeDto
    {
        /// <summary>
        /// 起始號碼
        /// </summary>
        [Required]
        [StringLength(8)]
        public string StartNo { get; set; }

        /// <summary>
        /// 結束號碼
        /// </summary>
        [Required]
        [StringLength(8)]
        public string EndNo { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string Note { get; set; }
    }
}