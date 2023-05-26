using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.AccountingSettings.CurrencyTables
{
    public class QueryCurrencyTableDto : PagedAndSortedResultRequestDto
    {
        /// <summary>
        /// 來源幣種
        /// </summary>
        public string Ccy1Id { get; set; }
        /// <summary>
        /// 兌換幣種
        /// </summary>
        public string Ccy2Id { get; set; }
    }
}