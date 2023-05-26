using System;
using System.Collections.Generic;
using System.Text;

namespace Dolphin.Freight.Permissions
{
    public class AccountingPermissions
    {
        public const string GroupName = "Accounting";
        public static class CustomerPayment
        {
            public const string Default = GroupName + ".CustomerPayment";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }

        public static class Customer
        {
            public const string Default = GroupName + ".Customer";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }

        public static class Payment
        {
            public const string Default = GroupName + ".Payment";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }

        public static class PaymentMadeList
        {
            public const string Default = GroupName + ".PaymentMadeList";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
        public static class Invoice
        {
            public const string Default = GroupName + ".Invoice";
            public const string List = GroupName + ".List";
            public const string GAList = GroupName + ".GAList";
            public const string GAPCreate = Default + ".GAPCreate";
            public const string GARCreate = Default + ".GARCreate";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
    }
}
