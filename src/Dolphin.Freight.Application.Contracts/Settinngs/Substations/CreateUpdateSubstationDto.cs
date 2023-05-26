using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.Settinngs.Substations
{
    public class CreateUpdateSubstationDto : AuditedEntityDto<Guid>
    {
        /// <summary>
        /// 分站名稱
        /// </summary>
        public string SubstationName { get; set; }
        /// <summary>
        /// 分站簡稱
        /// </summary>
        public string AbbreviationName { get; set; }
        /// <summary>
        /// 分站使用貨幣
        /// </summary>
        public string Currency { get; set; }
        /// <summary>
        /// 是否刪除
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
