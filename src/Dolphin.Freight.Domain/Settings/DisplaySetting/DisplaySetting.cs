using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Dolphin.Freight.Settings.DisplaySetting
{
	public class DisplaySetting : AuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 自動轉變狀態到"已完成票貨"的天數
        /// </summary>
        public string CompleteDay { get; set; }
    }
}

