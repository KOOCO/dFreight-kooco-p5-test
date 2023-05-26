using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.Settings.DisplaySetting
{
    /// <summary>
    /// 修改顯示設定DTO
    /// </summary>
    public class CreateUpdateDisplaySettingDTO
    {

        /// <summary>
        /// 自動轉變狀態到"已完成票貨"的天數
        /// </summary>
         [Required]
        public string CompleteDay { get; set; }
    }
}