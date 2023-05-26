using System;
using System.Collections.Generic;
using System.Text;

namespace Dolphin.Freight.Permissions
{
    public class ReportsPermissions
    {
        public const string GroupName = "Reports";
        public static class VolumeProfitReport
        {
            public const string Default = GroupName + ".VolumeProfitReport";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }

      
    }
}
