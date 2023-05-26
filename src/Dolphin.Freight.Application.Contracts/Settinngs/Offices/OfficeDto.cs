using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.Settinngs.Offices
{
    public class OfficeDto : AuditedEntityDto<Guid>
    {
        /// <summary>
        /// 分站名稱
        /// </summary>
        public string OfficeName { get; set; }
        /// <summary>
        /// 分站代號
        /// </summary>
        public string OfficeCode { get; set; }
    }
}
