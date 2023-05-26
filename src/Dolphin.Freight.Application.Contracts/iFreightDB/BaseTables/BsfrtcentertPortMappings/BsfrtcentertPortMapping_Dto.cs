using System;
using Volo.Abp.Application.Dtos;

namespace Dolphin.Freight.iFreightDB.BaseTables.BsfrtcentertPortMappings
{
    public class BsfrtcentertPortMapping_Dto : EntityDto
    {
        /// <summary>
        /// Excel中的港口或城市名稱
        /// </summary>
        public string PortName { get; set; }
        /// <summary>
        /// 城市代碼
        /// </summary>
        public string CityCd { get; set; }
        /// <summary>
        /// 國家代碼
        /// </summary>
        public string CntyCd { get; set; }
    }
}
