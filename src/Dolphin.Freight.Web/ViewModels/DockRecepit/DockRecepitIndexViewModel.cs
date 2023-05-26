using System;

namespace Dolphin.Freight.Web.ViewModels.DockRecepit
{
    public class DockRecepitIndexViewModel
    {
        public string BaseUrl { get; set; }
        public string Office { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Date { get; set; }
        public string DateTime { get; set; }


        public string SHIPPER_EXPORTER { get; set; }
        public string CONSIGNEE { get; set; }
        public string NOTIFY { get; set; }
        public string DELIVERY_TO { get; set; }

        public string CARRIER_BOOKING_NO { get; set; }
        public string EXPORT_FILE_NO { get; set; }
        public string INVOICE_NO { get; set; }
        public string PO_NO { get; set; }
        public string EXPORT_CARRIER { get; set; }
        public string VESSEL_VOYAGE_NO { get; set; }
        public string CUT_OFF_PORT { get; set; }
        public string CUT_OFF_RAIL { get; set; }
        public string CUT_OFF_WAREHOUSE { get; set; }
        public string CUT_OFF_SED_DOC { get; set; }
        public string PORT_OF_RECEIPT { get; set; }
        public string PORT_OF_LOADING { get; set; }
        public string PORT_OF_DISCHARGE { get; set; }
        public string PLACE_OF_DELIVERY { get; set; }


        public string MARK_NUMBER { get; set; }
        public string NO_OF_PKGS { get; set; }
        public string DESCRIPTION_OF_GOODS { get; set; }
        public string WEIGHT { get; set; }
        public string MEASUREMENT { get; set; }

        public string DELIVERY_BY { get; set; }
        public string TRUCKING_CO { get; set; }
        public string ARRIVED_DATE { get; set; }
        public string ARRIVED_TIME { get; set; }
        public string UNLOADED_DATE { get; set; }
        public string UNLOADED_TIME { get; set; }
        public string CHECK_BY { get; set; }
        public string INSHIP { get; set; }
        public string ON_DOCK { get; set; }
        public string LOCATION { get; set; }

        //ReportLog
        public Guid ReportId { get; set; }
    }
}
