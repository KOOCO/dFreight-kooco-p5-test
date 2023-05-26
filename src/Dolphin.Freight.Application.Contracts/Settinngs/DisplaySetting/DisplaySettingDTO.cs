using System;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.Settings.DisplaySetting
{

    /// <summary>
    /// 顯示設定DTO
    /// </summary>
    public class DisplaySettingDTO : AuditedEntityDto<Guid>
    {
        /// <summary>
        /// 自動轉變狀態到"已完成票貨"的天數
        /// </summary>
        public string CompleteDay { get; set; }

    }
}