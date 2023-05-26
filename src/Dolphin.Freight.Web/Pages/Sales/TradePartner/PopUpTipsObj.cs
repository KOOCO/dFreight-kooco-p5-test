namespace Dolphin.Freight.Web.Pages.Sales.TradePartner
{
    public class PopUpTipsObj
    {
        public bool DoorToDoor { get; set; }
        public bool BadCustomer { get; set; }
        public bool ImportOnly { get; set; }
        public bool ExportOnly { get; set; }
        public bool CoLoader { get; set; }
        public bool CustomClear { get; set; }
        public bool Warehouse { get; set; }
        public bool ISFCharges { get; set; }
        public bool FreeHandCargo { get; set; }
        public bool Nomination { get; set; }
        public bool SeeMemoRemark { get; set; }

        public PopUpTipsObj()
        {
            // For Deserialize
        }

        public PopUpTipsObj(
            bool doorToDoor,
            bool badCustomer,
            bool importOnly,
            bool exportOnly,
            bool coLoader,
            bool customClear,
            bool warehouse,
            bool isfCharges,
            bool freeHandCargo,
            bool nomination,
            bool seeMoreRemark)
        {
            DoorToDoor = doorToDoor;
            BadCustomer = badCustomer;
            ImportOnly = importOnly;
            ExportOnly = exportOnly;
            CoLoader = coLoader;
            CustomClear = customClear;
            Warehouse = warehouse;
            ISFCharges = isfCharges;
            FreeHandCargo = freeHandCargo;
            Nomination = nomination;
            SeeMemoRemark = seeMoreRemark;
        }
    }
}
