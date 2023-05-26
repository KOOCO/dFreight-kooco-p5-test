using System;
using System.Collections.Generic;
using System.Text;

namespace Dolphin.Freight.Permissions
{
    public class AccountingSettingPermissions
    {
        public const string GroupName = "AccountingSetting";
        public static class BillingCodes
        {
            public const string Default = GroupName + ".BillingCodes";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
        public static class GlCodes
        {
            public const string Default = GroupName + ".GlCodes";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
        public static class CurrencyTables
        {
            public const string Default = GroupName + ".CurrencyTables";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }

    }
}
