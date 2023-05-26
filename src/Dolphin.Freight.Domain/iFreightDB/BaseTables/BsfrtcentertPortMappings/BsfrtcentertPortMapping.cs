using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Volo.Abp.Domain.Entities;

namespace Dolphin.Freight.iFreightDB.BaseTables.BsfrtcentertPortMappings
{
    public partial class BsfrtcentertPortMapping : Entity
    {
        public override object[] GetKeys()
        {
            return new object[] { PortName };
        }

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
