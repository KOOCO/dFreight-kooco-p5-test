using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.AccountingSettings.GlCodes
{
    public class QueryGlCodeDto : PagedAndSortedResultRequestDto
    {
        /// <summary>
        /// 科目代碼
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Remark { get; set; }
    }
}