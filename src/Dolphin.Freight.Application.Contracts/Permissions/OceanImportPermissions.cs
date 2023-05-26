using System;
using System.Collections.Generic;
using System.Text;

namespace Dolphin.Freight.Permissions
{
    public class OceanImportPermissions
    {
        public const string GroupName = "OceanImport";
        /// <summary>
        /// 海運進口管理MBL
        /// </summary>
        public static class OceanImportMbls
        {
            public const string Default = GroupName + ".OceanImportMbls";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
        /// <summary>
        /// 海運進口管理HBL
        /// </summary>
        public static class OceanImportHbls
        {
            public const string Default = GroupName + ".OceanImportHbls";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
    }
}
