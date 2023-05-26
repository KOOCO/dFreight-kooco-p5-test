using System;
using System.Collections.Generic;
using System.Text;

namespace Dolphin.Freight.Permissions
{
    public class FreightCenterPermissions
    {
        public const string GroupName = "FreightCenter";
        
        /// <summary>
        /// 
        /// </summary>
        public static class ContractCostQuery
        {
            public const string Default = GroupName + ".ContractCostQuery";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
    }
}
