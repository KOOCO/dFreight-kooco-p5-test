using System;
using System.Collections.Generic;
using System.Text;

namespace Dolphin.Freight.Permissions
{
    public class OceanExportPermissions
    {
        public const string GroupName = "OceanExport";
        /// <summary>
        /// 海運出口管理MBL
        /// </summary>
        public static class OceanExportMbls
        {
            public const string Default = GroupName + ".OceanExportMbls";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
        /// <summary>
        /// 海運出口管理HBL
        /// </summary>
        public static class OceanExportHbls
        {
            public const string Default = GroupName + ".OceanExportHbls";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
        /// <summary>
        /// 海運出口管理HBL
        /// </summary>
        public static class VesselSchedules
        {
            public const string Default = GroupName + ".VesselSchedules";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
        public static class ExportBookings
        {
            public const string Default = GroupName + ".ExportBookings";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
    }
}
