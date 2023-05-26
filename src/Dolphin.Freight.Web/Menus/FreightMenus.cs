namespace Dolphin.Freight.Web.Menus;

public class FreightMenus
{
    private const string Prefix = "Dolphin.Freight";
    public const string Home = Prefix + ".Home";

    //Add your menu items here...
    // Trade Partner Management Menu constant
    public static class TradePartnerManagement
    {
        public const string GroupName = Prefix + ".TradePartnerManagement";
        public const string Addition = GroupName + ".Addition";
        public const string CreditEntry = GroupName + ".CreditEntry";
        public const string List = GroupName + ".List";
    }

    public static class AirExportManagement
    {
        public const string GroupName = Prefix + ".AirExportManagement";
        public const string Shipment = GroupName + ".Shipment";
        public const string ShipmentList = GroupName + ".ShipmentList";
        public const string Mawb = GroupName + ".Mawb";
        public const string MawbList = GroupName + ".MawbList";
        public const string Hawb = GroupName + ".Hawb";
        public const string HawbList = GroupName + ".Hawb";
        public const string Booking = GroupName + ".Booking";
        public const string BookingList = GroupName + ".Booking";
    }

    public static class AirImportManagement
    {
        public const string GroupName = Prefix + ".AirImportManagement";
        public const string Shipment = GroupName + ".Shipment";
        public const string ShipmentList = GroupName + ".ShipmentList";
        public const string Mawb = GroupName + ".Mawb";
        public const string MawbList = GroupName + ".MawbList";
        public const string Hawb = GroupName + ".Hawb";
        public const string HawbList = GroupName + ".HawbList";
    }

    public static class ReportManagement
    {
        public const string GroupName = Prefix + ".ReportManagement";
        public const string VolumeProfitReport = GroupName + ".VolumeProfitReport";

    }

}
